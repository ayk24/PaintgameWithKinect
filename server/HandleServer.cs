using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;           //IPEndPointを使うため
using System.Threading;     //スレッドを使うため
using System.Net.Sockets;   //ソケットを使うため
using System.Drawing;       //point構造体を使うため

using MyUtil;	//自作dllを使用するため
namespace server
{
	public class HandleServer
	{
		protected Object SyncClientSockets_ = new Object();
		protected Socket serverSocket_;
		public Dictionary<string, Socket> clinetList_ = new Dictionary<string, Socket>();
        public string theme = "";
		public delegate void RecivedMessage(string name, string text);
		public RecivedMessage RecivedMessageEvent;
		public bool IsWorking	//falseにするとサーバスレッドを止める
		{
			get;
			set;
		}

		public void start(int port)
		{
			var ipp = new IPEndPoint(IPAddress.Any, port);
			serverSocket_ = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			serverSocket_.Bind(ipp);
			serverSocket_.Listen(10);

			var ctThread = new Thread(this.doWork);
			ctThread.Start();
		}

		protected void doWork()
		{
			IsWorking = true;
			var bytesFrom = new byte[2048];
			while (IsWorking)
			{
				bool poolState = serverSocket_.Poll(1, SelectMode.SelectRead);
				if (poolState)
				{
					Socket client = serverSocket_.Accept();

					int readBytes = client.Receive(bytesFrom);
					var recivedData = new byte[readBytes];
					Array.Copy(bytesFrom, 0, recivedData, 0, readBytes);
					var userName = System.Text.Encoding.UTF8.GetString(recivedData);

					if (userName == "" || clinetList_.ContainsKey(userName))
					{
						client.Send(System.Text.Encoding.UTF8.GetBytes("NG"));
						client.Close();
					}
					else
					{
						client.Send(System.Text.Encoding.UTF8.GetBytes("OK"));
						clinetList_.Add(userName, client);
					}
				}

				foreach (var name in clinetList_.Keys)
				{
					poolState = clinetList_[name].Poll(1, SelectMode.SelectRead);
					if (poolState)
					{
						var BytesFrom = new byte[2048];
						
						//データの大きさの取得
						clinetList_[name].Receive(BytesFrom, 0, 4, SocketFlags.None);
						var SizeArray = new byte[4];
						Array.Copy(BytesFrom, SizeArray, 4);
						int DataSize = Util.ToIntFromBigEndianArray(SizeArray);

						//データサイズ以降のデータの読み込み
						clinetList_[name].Receive(BytesFrom, 4, DataSize, SocketFlags.None);

						//データタイプの取得
						var DataType = BytesFrom[4];    //4番地に格納されている

						//データタイプによって処理を切り替える
						if (DataType == Util.TypeChat)
						{
							var JsonByteDataSize = DataSize - 1;
							var JsonByteData = new byte[JsonByteDataSize];
							Array.Copy(BytesFrom, 5, JsonByteData, 0, JsonByteDataSize);
							var chatData = Util.DeSerialize<ChatData>(JsonByteData);
							sendChatData(chatData.Name, chatData.Text);
							RecivedMessageEvent(chatData.Name, chatData.Text);
						}
					}
				}
			}
			serverSocket_.Close();
			foreach (var name in clinetList_.Keys)
			{
				clinetList_[name].Close();
			}
			clinetList_.Clear();
		}

		public void sendChatData(string sourceName, string text)
		{
			//チャットデータをシリアライズ
			var sendData = new ChatData()
			{
				Name = sourceName,
				Text = text
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

			//全てのクライアントに送信
			lock (SyncClientSockets_)
			{
				foreach (var name in clinetList_.Keys)
				{
					if(name != sourceName)
					{
						clinetList_[name].Send(mergedArray);
					}
				}
			}

            if (text == theme)
            {
                sendChatData("sever", sourceName + "さんが正解！答えは「" + theme + "」");
            }
        }

		public void sendPaintInfo(Point startPos, Point endPos, int pen_color)
		{
			//座標データをシリアライズ
			var sendData = new PaintInfo()
			{
				StartPos = startPos,
				EndPos = endPos,
                Pen_color = pen_color
			};
			var jsonString = Util.Serialize(sendData);
			var sendToBytes = System.Text.Encoding.UTF8.GetBytes(jsonString);

			//独自パケット作成
			var mergedArray = Util.MergeByteArrays(new List<byte[]>
			{
				Util.ToBigEndianArray((ulong)sendToBytes.Length + 1,4),
				new byte[]{Util.TypePos},
				sendToBytes
			});

			//全てのクライアントに送信
			lock (SyncClientSockets_)
			{
				foreach (var name in clinetList_.Keys)
				{
					clinetList_[name].Send(mergedArray);
				}
			}
		}
	}
}
