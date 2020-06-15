using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.IO;
using System.Reflection;

namespace server
{
	public partial class Form1 : Form
	{
        Bitmap pintedImg_;
		bool isDrawing_;
		Point oldPos_;
		Point currentPos_;
		Point startPos_;
        Point Cpos;
        Pen pen_red;
        Pen pen_black;
        Pen pen_blue;
        Pen pen_green;
        Pen pen_yellow;
		HandleServer server_;
        public int pen_color = 1;
        public int start = 1;
        public int flag = 0;
        private Image image;

        private KinectSensor sensor;


        public Form1()
		{
			InitializeComponent();
            pintedImg_ = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			isDrawing_ = false;
			pen_red = new Pen(Color.FromArgb(255, 255, 0, 0), 7);
            pen_black = new Pen(Color.FromArgb(255, 0, 0, 0), 7);
            pen_blue = new Pen(Color.FromArgb(255, 0, 120, 255), 7);
            pen_green = new Pen(Color.FromArgb(255, 21, 184, 0), 7);
            pen_yellow = new Pen(Color.FromArgb(255, 255, 216, 0), 7);

        }

		//ピクチャーボックス上のマウスダウンイベント
        
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{/*
			if(e.Button == MouseButtons.Left)
			{
				currentPos_.X = e.X;
				currentPos_.Y = e.Y;
				oldPos_ = currentPos_;
				startPos_ = currentPos_;
				isDrawing_ = true;
			}*/
		}

		//ピクチャーボックス上のマウスムーブイベント
		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{/*
			if (server_ != null && isDrawing_)
			{
				using (var g = Graphics.FromImage(pintedImg_))
				{
					g.DrawLine(pen_, oldPos_.X, oldPos_.Y, e.X, e.Y);
					oldPos_ = currentPos_;
					currentPos_.X = e.X;
					currentPos_.Y = e.Y;
					pictureBox1.Image = pintedImg_; //描画更新

					server_.sendPaintInfo(startPos_, currentPos_);
					startPos_ = currentPos_;

				}
			}*/
		}

		//ピクチャーボックス上のマウスアップイベント
		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{/*
			if (e.Button == MouseButtons.Left)
			{
				isDrawing_ = false;
			}*/
		}

		//フォームのロードイベント
		private void Form1_Load(object sender, EventArgs e)
		{
            this.WindowState = FormWindowState.Maximized;
            Black.Parent = pictureBox1;
            pictureBox1.Parent = textInfo.Parent;
        }
        
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if(server_ != null)
			{
				server_.IsWorking = false;
			}
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
            int port = 0;
			bool canConvert = int.TryParse(textPort.Text, out port);

            using (System.IO.StreamReader file = new System.IO.StreamReader(@".\test.txt", System.Text.Encoding.GetEncoding("shift_jis"))) 
            {
                string line = "";
                List<string> themeList = new List<string>();
                String theme = "";

                while ((line = file.ReadLine()) != null)
                {
                    themeList.Add(line);
                }
                Random rnd = new System.Random();
                int intResult = rnd.Next(20);

                theme = themeList[intResult];
                textInfo.Text += ("「" + theme + "」を描いてください\r\n");
                if (canConvert == false)
                {
                    MessageBox.Show("ポート番号に数値を入力してください");
                    return;
                }

                try
                {
                    server_ = new HandleServer();
                    server_.start(port);
                    server_.theme = theme;
                    server_.RecivedMessageEvent = (string name, string text) =>
                    {
                        if (this.InvokeRequired)//別スレッドから呼び出されたとき Invokeして呼びなおす
                        {
                            this.Invoke(new Action(() => server_.RecivedMessageEvent(name, text)), null);
                            return;
                        }

                        textInfo.Text += (name +  " >> " + text + "\r\n");

                        if (text == server_.theme)
                        {
                            Correct();
                            textInfo.Text += (name + "さんが正解！答えは「" + server_.theme + "」\r\n");
                            rnd = new System.Random();
                            intResult = rnd.Next(10);

                            server_.theme = themeList[intResult];
                            textInfo.Text += ("「" + server_.theme + "」を描いてください\r\n");
                        }

                        textInfo.HideSelection = false;
                        textInfo.AppendText("\n");
                    };

                    pintedImg_ = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    isDrawing_ = false;
                    ChagenButtonState();

                    foreach (var potentialSensor in KinectSensor.KinectSensors)
                    {
                        if (potentialSensor.Status == KinectStatus.Connected)
                        {
                            this.sensor = potentialSensor;
                            break;
                        }
                    }

                    if (null != this.sensor)
                    {
                        // Turn on the skeleton stream to receive skeleton frames
                        this.sensor.SkeletonStream.Enable();

                        // Add an event handler to be called whenever there is new color frame data
                        this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;

                        // Start the sensor!
                        try
                        {
                            this.sensor.Start();
                        }
                        catch (IOException)
                        {
                            this.sensor = null;
                        }
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
		}

        public void Correct()
        {
            Bitmap canvas = new Bitmap(520,395);
            Graphics g = pictureBox1.CreateGraphics();
            Image img = Properties.Resources.hanamaru;
            g.DrawImage(img, 110, 20, 400, 400);
            img.Dispose();
            g.Dispose();
            sound();
            FillCanvas();
        }

        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }

            if (skeletons.Length != 0)
            {

                foreach (Skeleton skel in skeletons)
                {

                    if (skel.TrackingState == SkeletonTrackingState.Tracked)
                    {
                        Joint jointR = skel.Joints[JointType.HandRight];
                        Joint jointL = skel.Joints[JointType.HandLeft];
                        Joint jointH = skel.Joints[JointType.Head];
                        var hpoint = SkeletonPointToScreen(jointH.Position);
                        var rpoint = SkeletonPointToScreen(jointR.Position);
                        var lpoint = SkeletonPointToScreen(jointL.Position);
                        rpoint.X = (int)(((float)rpoint.X * 1067 / 640));
                        rpoint.Y = (int)(((float)rpoint.Y * 720 / 480));
                        rpoint = pictureBox1.PointToClient(rpoint);
                        Cpos = rpoint;

                        //ピクチャーボックス上のマウスダウンイベント
                        if (hpoint.Y < lpoint.Y)
                        {
                            currentPos_.X = rpoint.X;
                            currentPos_.Y = rpoint.Y;
                            oldPos_ = currentPos_;
                            startPos_ = currentPos_;
                            isDrawing_ = true;
                        }


                        //ピクチャーボックス上のマウスムーブイベント

                        if (server_ != null && isDrawing_)
                        {
                            using (var g = Graphics.FromImage(pintedImg_))
                            {
                                if (hpoint.X < lpoint.X)
                                {
                                    flag = 1;
                                }

                                //chenge color
                                if (hpoint.X > lpoint.X)
                                {
                                    if (flag == 1)
                                    {
                                        //chenge color
                                        if (pen_color < 6)
                                        {
                                            pen_color++;
                                        }
                                        else
                                        {
                                            pen_color = 1;
                                        }
                                        flag = 0;
                                        start++;
                                    }
                                }

                                Rectangle clipRect = new Rectangle(50, 15, 520, 395);
                                g.SetClip(clipRect);

                                switch (pen_color)
                                {
                                    case 1:
                                        g.DrawLine(pen_black, oldPos_.X, oldPos_.Y, currentPos_.X, currentPos_.Y);
                                        if (start == 1)
                                        {
                                            Black.Location = Cpos;
                                            Black.Parent = pictureBox1;
                                            break;
                                        }
                                        Green.Location = new Point(647, 414);
                                        Black.Location = Cpos;
                                        Black.Parent = pictureBox1;
                                        Green.Parent = textInfo.Parent;
                                        break;
                                    case 2:
                                        g.DrawLine(pen_red, oldPos_.X, oldPos_.Y, currentPos_.X, currentPos_.Y);
                                        Black.Location = new Point(647, 533);
                                        Red.Location = Cpos;
                                        Red.Parent = pictureBox1;
                                        Black.Parent = textInfo.Parent;
                                        break;
                                    case 3:
                                        g.DrawLine(pen_blue, oldPos_.X, oldPos_.Y, currentPos_.X, currentPos_.Y);
                                        Red.Location = new Point(647, 57);
                                        Blue.Location = Cpos;
                                        Blue.Parent = pictureBox1;
                                        Red.Parent = textInfo.Parent;
                                        break;
                                    case 4:
                                        g.DrawLine(pen_yellow, oldPos_.X, oldPos_.Y, currentPos_.X, currentPos_.Y);
                                        Blue.Location = new Point(647, 176);
                                        Yellow.Location = Cpos;
                                        Yellow.Parent = pictureBox1;
                                        Blue.Parent = textInfo.Parent;
                                        break;
                                    case 5:
                                        g.DrawLine(pen_green, oldPos_.X, oldPos_.Y, currentPos_.X, currentPos_.Y);
                                        Yellow.Location = new Point(647, 295);
                                        Green.Location = Cpos;
                                        Green.Parent = pictureBox1;
                                        Yellow.Parent = textInfo.Parent;
                                        break;
                                }


                                oldPos_ = currentPos_;
                                currentPos_.X = rpoint.X;
                                currentPos_.Y = rpoint.Y;
                                pictureBox1.Image = pintedImg_; //描画更新

                                server_.sendPaintInfo(startPos_, currentPos_, pen_color);
                                startPos_ = currentPos_;

                            }
                        }

                        if (hpoint.Y > lpoint.Y)
                        {
                            isDrawing_ = false;
                        }
                    }
                }
            }
        }

        public void sound()
        {
            //正解サウンド
            System.IO.Stream strm = Properties.Resources.correctsound;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
            player.PlaySync();
            player.Dispose();
        }

        private Point SkeletonPointToScreen(SkeletonPoint skelpoint)
        {
            // Convert point to depth space.  
            // We are not using depth directly, but we do want the points in our 1067 * 720 output resolution.
            DepthImagePoint depthPoint = this.sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(skelpoint, DepthImageFormat.Resolution640x480Fps30);
            return new Point(depthPoint.X, depthPoint.Y);
        }

        private void btnStop_Click(object sender, EventArgs e)
		{
			server_.IsWorking = false;
			ChagenButtonState();
		}

		private void ChagenButtonState()
		{
			btnStart.Enabled = !btnStart.Enabled;
			btnStop.Enabled = !btnStop.Enabled;
		}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isDrawing_ == true)
            {
                Skeleton[] skeletons = new Skeleton[0];

                if (skeletons.Length != 0)
                {

                    foreach (Skeleton skel in skeletons)
                    {
                        if (skel.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            Joint jointR = skel.Joints[JointType.HandRight];
                            var rpoint = SkeletonPointToScreen(jointR.Position);
                            rpoint.X = (int)(((float)rpoint.X * 1067 / 640));
                            rpoint.Y = (int)(((float)rpoint.Y * 720 / 480));
                            rpoint = pictureBox1.PointToClient(rpoint);
                            Cpos = rpoint;
                        }
                    }
                }
            }
        }


        private void newCanvas_Click(object sender, EventArgs e)
        {
            FillCanvas();
        }
        private void FillCanvas()
        {
            using (var g = Graphics.FromImage(pintedImg_))
            {
                Point fillPos_ = startPos_;
                fillPos_.X = -1;
                fillPos_.Y = -1;

                g.FillRectangle(Brushes.White, 50, 15, 520, 395);
                pictureBox1.Image = pintedImg_; //描画更新
                server_.sendPaintInfo(fillPos_, fillPos_,pen_color);
            }
        }
    }
}
