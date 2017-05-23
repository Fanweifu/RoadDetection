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
            this.tsbtnConnectToVideo = new System.Windows.Forms.ToolStripButton();
            this.tsbtnConnectcam = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnPlayPause = new System.Windows.Forms.ToolStripButton();
            this.tsbtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnLoadSvm = new System.Windows.Forms.ToolStripButton();
            this.tsbtnTest = new System.Windows.Forms.ToolStripButton();
            this.tsbtnReloadParams = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnStartRecord = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEnd = new System.Windows.Forms.ToolStripButton();
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gpBox = new System.Windows.Forms.GroupBox();
            this.numDetectInternal = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.tbDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tspbProcess = new System.Windows.Forms.ToolStripProgressBar();
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
            this.tsbtnConnectToVideo,
            this.tsbtnConnectcam,
            this.toolStripSeparator1,
            this.tsbtnPlayPause,
            this.tsbtnUpdate,
            this.toolStripSeparator3,
            this.tsbtnLoadSvm,
            this.tsbtnTest,
            this.tsbtnReloadParams,
            this.toolStripSeparator2,
            this.tsbtnStartRecord,
            this.tsbtnEnd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(823, 25);
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
            this.tsbtnOpenImg.Size = new System.Drawing.Size(94, 22);
            this.tsbtnOpenImg.Text = "ImgsDirectory";
            this.tsbtnOpenImg.Click += new System.EventHandler(this.tsbtnOpenImg_Click);
            // 
            // tsbtnConnectToVideo
            // 
            this.tsbtnConnectToVideo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnConnectToVideo.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnConnectToVideo.Image")));
            this.tsbtnConnectToVideo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnConnectToVideo.Name = "tsbtnConnectToVideo";
            this.tsbtnConnectToVideo.Size = new System.Drawing.Size(46, 22);
            this.tsbtnConnectToVideo.Text = "Video";
            this.tsbtnConnectToVideo.Click += new System.EventHandler(this.tsbtnConnectToVideo_Click);
            // 
            // tsbtnConnectcam
            // 
            this.tsbtnConnectcam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnConnectcam.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnConnectcam.Image")));
            this.tsbtnConnectcam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnConnectcam.Name = "tsbtnConnectcam";
            this.tsbtnConnectcam.Size = new System.Drawing.Size(57, 22);
            this.tsbtnConnectcam.Text = "Camera";
            this.tsbtnConnectcam.Click += new System.EventHandler(this.tsbtnConnectcam_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnPlayPause
            // 
            this.tsbtnPlayPause.Enabled = false;
            this.tsbtnPlayPause.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPlayPause.Image")));
            this.tsbtnPlayPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPlayPause.Name = "tsbtnPlayPause";
            this.tsbtnPlayPause.Size = new System.Drawing.Size(81, 22);
            this.tsbtnPlayPause.Text = "暂停/播放";
            this.tsbtnPlayPause.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tsbtnUpdate
            // 
            this.tsbtnUpdate.CheckOnClick = true;
            this.tsbtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUpdate.Image")));
            this.tsbtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUpdate.Name = "tsbtnUpdate";
            this.tsbtnUpdate.Size = new System.Drawing.Size(71, 22);
            this.tsbtnUpdate.Text = "Updata";
            this.tsbtnUpdate.ToolTipText = "更新";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnLoadSvm
            // 
            this.tsbtnLoadSvm.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLoadSvm.Image")));
            this.tsbtnLoadSvm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLoadSvm.Name = "tsbtnLoadSvm";
            this.tsbtnLoadSvm.Size = new System.Drawing.Size(103, 22);
            this.tsbtnLoadSvm.Text = "LoadSVMFile";
            this.tsbtnLoadSvm.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // tsbtnTest
            // 
            this.tsbtnTest.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnTest.Image")));
            this.tsbtnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnTest.Name = "tsbtnTest";
            this.tsbtnTest.Size = new System.Drawing.Size(75, 22);
            this.tsbtnTest.Text = "ImgTest";
            this.tsbtnTest.Click += new System.EventHandler(this.toolStripButton5_Click_1);
            // 
            // tsbtnReloadParams
            // 
            this.tsbtnReloadParams.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnReloadParams.Image")));
            this.tsbtnReloadParams.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnReloadParams.Name = "tsbtnReloadParams";
            this.tsbtnReloadParams.Size = new System.Drawing.Size(103, 22);
            this.tsbtnReloadParams.Text = "ResetPramas";
            this.tsbtnReloadParams.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnStartRecord
            // 
            this.tsbtnStartRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnStartRecord.Image")));
            this.tsbtnStartRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnStartRecord.Name = "tsbtnStartRecord";
            this.tsbtnStartRecord.Size = new System.Drawing.Size(97, 22);
            this.tsbtnStartRecord.Text = "StartRecord";
            this.tsbtnStartRecord.ToolTipText = "StartRecord";
            this.tsbtnStartRecord.Click += new System.EventHandler(this.tsbtnStartRecord_Click);
            // 
            // tsbtnEnd
            // 
            this.tsbtnEnd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEnd.Image")));
            this.tsbtnEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEnd.Name = "tsbtnEnd";
            this.tsbtnEnd.Size = new System.Drawing.Size(50, 22);
            this.tsbtnEnd.Text = "End";
            this.tsbtnEnd.ToolTipText = "StartRecord";
            this.tsbtnEnd.Click += new System.EventHandler(this.tsbtnEnd_Click);
            // 
            // imageIOControl1
            // 
            this.imageIOControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIOControl1.InImage = null;
            this.imageIOControl1.OutImage = null;
            this.imageIOControl1.Location = new System.Drawing.Point(0, 0);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.Size = new System.Drawing.Size(823, 458);
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
            this.panel1.Size = new System.Drawing.Size(823, 480);
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
            this.tspbProcess,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel3,
            this.tsslbShow,
            this.tsslbshowturn});
            this.statusStrip1.Location = new System.Drawing.Point(0, 458);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(823, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tspbProcess
            // 
            this.tspbProcess.Name = "tspbProcess";
            this.tspbProcess.Size = new System.Drawing.Size(100, 16);
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
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(691, 17);
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
            this.ClientSize = new System.Drawing.Size(823, 505);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RoadDetectShow";
            this.Text = "VideoTest";
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
        private System.Windows.Forms.ToolStripButton tsbtnPlayPause;
        private System.Windows.Forms.ToolStripButton tsbtnLoadSvm;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tspbProcess;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslbShow;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripButton tsbtnUpdate;
        private System.Windows.Forms.ToolStripButton tsbtnTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnReloadParams;
        private System.Windows.Forms.ToolStripStatusLabel tsslbshowturn;
        private System.Windows.Forms.GroupBox gpBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numDetectInternal;
        private System.Windows.Forms.ToolStripButton tsbtnConnectToVideo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnEnd;
        private System.Windows.Forms.ToolStripButton tsbtnStartRecord;
    }
}