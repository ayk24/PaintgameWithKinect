namespace server
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textInfo = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Yellow = new System.Windows.Forms.PictureBox();
            this.Green = new System.Windows.Forms.PictureBox();
            this.Blue = new System.Windows.Forms.PictureBox();
            this.Red = new System.Windows.Forms.PictureBox();
            this.newCanvas = new System.Windows.Forms.Button();
            this.Black = new System.Windows.Forms.PictureBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Yellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Black)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textPort
            // 
            this.textPort.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPort.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textPort.Location = new System.Drawing.Point(83, 11);
            this.textPort.Margin = new System.Windows.Forms.Padding(4);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(88, 32);
            this.textPort.TabIndex = 6;
            this.textPort.Text = "8888";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("メイリオ", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(22, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port";
            // 
            // textInfo
            // 
            this.textInfo.BackColor = System.Drawing.Color.Snow;
            this.textInfo.Font = new System.Drawing.Font("メイリオ", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textInfo.Location = new System.Drawing.Point(13, 504);
            this.textInfo.Margin = new System.Windows.Forms.Padding(4);
            this.textInfo.Multiline = true;
            this.textInfo.Name = "textInfo";
            this.textInfo.ReadOnly = true;
            this.textInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInfo.Size = new System.Drawing.Size(607, 154);
            this.textInfo.TabIndex = 8;
            this.textInfo.WordWrap = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Yellow
            // 
            this.Yellow.BackColor = System.Drawing.Color.Transparent;
            this.Yellow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Yellow.Image = global::server.Properties.Resources.yellow_pen;
            this.Yellow.Location = new System.Drawing.Point(647, 295);
            this.Yellow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Yellow.Name = "Yellow";
            this.Yellow.Size = new System.Drawing.Size(90, 90);
            this.Yellow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Yellow.TabIndex = 15;
            this.Yellow.TabStop = false;
            // 
            // Green
            // 
            this.Green.BackColor = System.Drawing.Color.Transparent;
            this.Green.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Green.Image = global::server.Properties.Resources.green_pen;
            this.Green.Location = new System.Drawing.Point(647, 414);
            this.Green.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(90, 90);
            this.Green.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Green.TabIndex = 14;
            this.Green.TabStop = false;
            // 
            // Blue
            // 
            this.Blue.BackColor = System.Drawing.Color.Transparent;
            this.Blue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Blue.Image = global::server.Properties.Resources.blue_pen;
            this.Blue.Location = new System.Drawing.Point(647, 176);
            this.Blue.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(90, 90);
            this.Blue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Blue.TabIndex = 13;
            this.Blue.TabStop = false;
            // 
            // Red
            // 
            this.Red.BackColor = System.Drawing.Color.Transparent;
            this.Red.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Red.Image = global::server.Properties.Resources.red_pen;
            this.Red.Location = new System.Drawing.Point(647, 57);
            this.Red.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(90, 90);
            this.Red.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Red.TabIndex = 12;
            this.Red.TabStop = false;
            // 
            // newCanvas
            // 
            this.newCanvas.BackgroundImage = global::server.Properties.Resources.blue_tag;
            this.newCanvas.Font = new System.Drawing.Font("メイリオ", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCanvas.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.newCanvas.Location = new System.Drawing.Point(482, 6);
            this.newCanvas.Name = "newCanvas";
            this.newCanvas.Size = new System.Drawing.Size(134, 37);
            this.newCanvas.TabIndex = 11;
            this.newCanvas.Text = "newCanvas";
            this.newCanvas.UseVisualStyleBackColor = true;
            this.newCanvas.Click += new System.EventHandler(this.newCanvas_Click);
            // 
            // Black
            // 
            this.Black.BackColor = System.Drawing.Color.Transparent;
            this.Black.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Black.Image = global::server.Properties.Resources.black_pen;
            this.Black.Location = new System.Drawing.Point(13, 57);
            this.Black.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Black.Name = "Black";
            this.Black.Size = new System.Drawing.Size(90, 90);
            this.Black.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Black.TabIndex = 10;
            this.Black.TabStop = false;
            this.Black.CursorChanged += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.White;
            this.btnStop.BackgroundImage = global::server.Properties.Resources.yellow_tag;
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("メイリオ", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnStop.Location = new System.Drawing.Point(342, 6);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(133, 37);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = global::server.Properties.Resources.pink_tag;
            this.btnStart.Font = new System.Drawing.Font("メイリオ", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnStart.Location = new System.Drawing.Point(201, 6);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(133, 37);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = global::server.Properties.Resources.sketch;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(13, 57);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(607, 439);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::server.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(777, 681);
            this.Controls.Add(this.Yellow);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.newCanvas);
            this.Controls.Add(this.Black);
            this.Controls.Add(this.textInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("メイリオ", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Yellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Black)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.TextBox textPort;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textInfo;
        private System.Windows.Forms.PictureBox Black;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button newCanvas;
        private System.Windows.Forms.PictureBox Red;
        private System.Windows.Forms.PictureBox Blue;
        private System.Windows.Forms.PictureBox Green;
        private System.Windows.Forms.PictureBox Yellow;
    }
}

