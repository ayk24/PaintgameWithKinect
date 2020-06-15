using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;           //IPEndPointを使うため
using System.Threading;     //スレッドを使うため
using System.Net.Sockets;   //ソケットを使うため

using MyUtil;   //自作dllを使用するため

namespace client
{
	class HandleClient
	{
		protected Socket socket_;
		protected Object SyncSocket_ = new Object();
		protected string Name_;
		public bool IsWorking   //falseしてスレッドを止める
		{
			get;
			set;
		}

		public delegate void UpdatePictureBox(PaintInfo info);
		public UpdatePictureBox PaintEvent;

		public delegate void RecivedMessage(string name, string text);
		public RecivedMessage RecivedMessageEvent;

		public bool start(string name, string ip,int port)
		{
			var ipep = new IPEndPoint(IPAddress.Parse(ip), port);
			socket_ = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket_.Connect(ipep);
                socket_.Send(System.Text.Encoding.UTF8.GetBytes(name)); //名前の送信

                var bytesFrom = new byte[2048];
                int readBytes = socket_.Receive(bytesFrom);
                var recvedData = new byte[readBytes];
                Array.Copy(bytesFrom, 0, recvedData,0, readBytes);
                var res = System.Text.Encoding.UTF8.GetString(recvedData);
                if (res == "OK")
                {
					Name_ = name;
					var ctThread = new Thread(this.doWork);
                    ctThread.Start();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
        public void sendMessage(string msg)
        {
            if (IsWorking)
            {
                //チャットデータをシリアライズ
                var sendData = new ChatData()
                {
                    Name = Name_,
                    Text = msg
                };
                var jsonString = Util.Serialize(sendData);
                var sendToBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);

                //独自パケット作成
                var mergedArray = Util.MergeByteArrays(new List<byte[]>
                {
                    Util.ToBigEndianArray((ulong)sendToBytes.Length + 1,4),
                    new byte[]{Util.TypeChat},
                    sendToBytes
                });

                //サーバに送信
                socket_.Send(mergedArray);
            }
        }

        protected void doWork()
        {
            IsWorking = true;
            var BytesFrom = new byte[2048];
            while (IsWorking)
            {
                bool poolState = socket_.Poll(1000, SelectMode.SelectRead);
                if (poolState && socket_.Available == 0)
                {
                    break;
                }

                if (poolState)
                {
                    //データの大きさの取得
                    socket_.Receive(BytesFrom, 0, 4, SocketFlags.None);
                    var SizeArray = new byte[4];
                    Array.Copy(BytesFrom, SizeArray, 4);
                    int DataSize = Util.ToIntFromBigEndianArray(SizeArray);

                    //データサイズ以降のデータの読み込み
                    socket_.Receive(BytesFrom, 4, DataSize, SocketFlags.None);

                    //データタイプの取得
                    var DataType = BytesFrom[4];    //4番地に格納されている

                    //jsonデータの取得
                    var JsonByteDataSize = DataSize - 1;
                    var JsonByteData = new byte[JsonByteDataSize];
                    Array.Copy(BytesFrom, 5, JsonByteData, 0, JsonByteDataSize);

                    //データタイプによって処理を切り替える
                    if (DataType == Util.TypePos)
                    {
                        var info = Util.DeSerialize<PaintInfo>(JsonByteData);
                        PaintEvent(info);
                    }
                    else if (DataType == Util.TypeChat)
                    {
                        var data = Util.DeSerialize<ChatData>(JsonByteData);
                        RecivedMessageEvent(data.Name, data.Text);
                    }
                }
            }
            socket_.Close();
        }
    }
}
