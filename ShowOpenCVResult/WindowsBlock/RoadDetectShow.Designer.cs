namespace ShowOpenCVResult
{
    partial class RoadDetectShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoadDetectShow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenImg = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnConnectcam = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gpBox = new System.Windows.Forms.GroupBox();
            this.numDetectInternal = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbShow = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbshowturn = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDetectInternal)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenImg,
            this.toolStripButton6,
            this.tsbtnConnectcam,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.tsbtnUpdate,
            this.toolStripButton4,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(805, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpenImg
            // 
            this.tsbtnOpenImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnOpenImg.ForeColor = System.Drawing.Color.Black;
            this.tsbtnOpenImg.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenImg.Image")));
            this.tsbtnOpenImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenImg.Name = "tsbtnOpenImg";
            this.tsbtnOpenImg.Size = new System.Drawing.Size(60, 22);
            this.tsbtnOpenImg.Text = "选择目录";
            this.tsbtnOpenImg.Click += new System.EventHandler(this.tsbtnOpenImg_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton6.Text = "选择视频";
            // 
            // tsbtnConnectcam
            // 
            this.tsbtnConnectcam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnConnectcam.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnConnectcam.Image")));
            this.tsbtnConnectcam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnConnectcam.Name = "tsbtnConnectcam";
            this.tsbtnConnectcam.Size = new System.Drawing.Size(72, 22);
            this.tsbtnConnectcam.Text = "连接摄像头";
            this.tsbtnConnectcam.Click += new System.EventHandler(this.tsbtnConnectcam_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(81, 22);
            this.toolStripButton2.Text = "暂停/播放";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tsbtnUpdate
            // 
            this.tsbtnUpdate.CheckOnClick = true;
            this.tsbtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUpdate.Image")));
            this.tsbtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUpdate.Name = "tsbtnUpdate";
            this.tsbtnUpdate.Size = new System.Drawing.Size(52, 22);
            this.tsbtnUpdate.Text = "更新";
            this.tsbtnUpdate.ToolTipText = "更新";
            this.tsbtnUpdate.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(79, 22);
            this.toolStripButton4.Text = "加载SVM";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "toolStripButton5";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click_1);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(103, 22);
            this.toolStripButton3.Text = "ResetPramas";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // imageIOControl1
            // 
            this.imageIOControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIOControl1.Image1 = null;
            this.imageIOControl1.Image2 = null;
            this.imageIOControl1.Location = new System.Drawing.Point(0, 132);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.Size = new System.Drawing.Size(805, 326);
            this.imageIOControl1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIOControl1.TabIndex = 2;
            this.imageIOControl1.DoImgChange += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.imageIOControl1);
            this.panel1.Controls.Add(this.gpBox);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 480);
            this.panel1.TabIndex = 3;
            // 
            // gpBox
            // 
            this.gpBox.BackColor = System.Drawing.Color.GhostWhite;
            this.gpBox.Controls.Add(this.numDetectInternal);
            this.gpBox.Controls.Add(this.button1);
            this.gpBox.Controls.Add(this.tbDirectory);
            this.gpBox.Controls.Add(this.label2);
            this.gpBox.Controls.Add(this.label1);
            this.gpBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpBox.Location = new System.Drawing.Point(0, 0);
            this.gpBox.Name = "gpBox";
            this.gpBox.Size = new System.Drawing.Size(805, 132);
            this.gpBox.TabIndex = 4;
            this.gpBox.TabStop = false;
            this.gpBox.Text = "Funcation";
            // 
            // numDetectInternal
            // 
            this.numDetectInternal.Location = new System.Drawing.Point(83, 51);
            this.numDetectInternal.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDetectInternal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDetectInternal.Name = "numDetectInternal";
            this.numDetectInternal.Size = new System.Drawing.Size(133, 21);
            this.numDetectInternal.TabIndex = 5;
            this.numDetectInternal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDetectInternal.ValueChanged += new System.EventHandler(this.numDetectInternal_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(268, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 21);
            this.button1.TabIndex = 4;
            this.button1.Text = "ShowDirectroy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbDirectory
            // 
            this.tbDirectory.Location = new System.Drawing.Point(83, 12);
            this.tbDirectory.Name = "tbDirectory";
            this.tbDirectory.ReadOnly = true;
            this.tbDirectory.Size = new System.Drawing.Size(179, 21);
            this.tbDirectory.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Internal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel3,
            this.tsslbShow,
            this.tsslbshowturn});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(805, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(673, 17);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // tsslbShow
            // 
            this.tsslbShow.BackColor = System.Drawing.SystemColors.Control;
            this.tsslbShow.Name = "tsslbShow";
            this.tsslbShow.Size = new System.Drawing.Size(15, 17);
            this.tsslbShow.Text = "0";
            // 
            // tsslbshowturn
            // 
            this.tsslbshowturn.Name = "tsslbshowturn";
            this.tsslbshowturn.Size = new System.Drawing.Size(0, 17);
            // 
            // RoadDetectShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(805, 505);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RoadDetectShow";
            this.Text = "HSV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoadDetectShow_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gpBox.ResumeLayout(false);
            this.gpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDetectInternal)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenImg;
        private ImageIO imageIOControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton tsbtnConnectcam;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslbShow;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripButton tsbtnUpdate;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripStatusLabel tsslbshowturn;
        private System.Windows.Forms.GroupBox gpBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numDetectInternal;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
    }
}