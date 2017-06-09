namespace ShowOpenCVResult.Windows
{
    partial class ConvertVideoToImgs
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStrat = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbOutputImgDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelectVideo = new System.Windows.Forms.Button();
            this.tbVideoPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.drawImageBox1 = new ShowOpenCVResult.DrawImageBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsspbarShowProcess = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslbFrameCnt = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawImageBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStrat);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tbOutputImgDirectory);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSelectVideo);
            this.groupBox1.Controls.Add(this.tbVideoPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 110);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Path";
            // 
            // btnStrat
            // 
            this.btnStrat.Location = new System.Drawing.Point(277, 78);
            this.btnStrat.Name = "btnStrat";
            this.btnStrat.Size = new System.Drawing.Size(131, 23);
            this.btnStrat.TabIndex = 8;
            this.btnStrat.Text = "Start";
            this.btnStrat.UseVisualStyleBackColor = true;
            this.btnStrat.Click += new System.EventHandler(this.btnStrat_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            ".jpg",
            ".png",
            ".bmp",
            ".tif"});
            this.comboBox1.Location = new System.Drawing.Point(124, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "OutputTpye";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = ".....";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbOutputImgDirectory
            // 
            this.tbOutputImgDirectory.Location = new System.Drawing.Point(124, 45);
            this.tbOutputImgDirectory.Name = "tbOutputImgDirectory";
            this.tbOutputImgDirectory.ReadOnly = true;
            this.tbOutputImgDirectory.Size = new System.Drawing.Size(244, 21);
            this.tbOutputImgDirectory.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "OutputDirectory";
            // 
            // btnSelectVideo
            // 
            this.btnSelectVideo.Location = new System.Drawing.Point(374, 16);
            this.btnSelectVideo.Name = "btnSelectVideo";
            this.btnSelectVideo.Size = new System.Drawing.Size(34, 23);
            this.btnSelectVideo.TabIndex = 2;
            this.btnSelectVideo.Text = ".....";
            this.btnSelectVideo.UseVisualStyleBackColor = true;
            this.btnSelectVideo.Click += new System.EventHandler(this.btnSelectVideo_Click);
            // 
            // tbVideoPath
            // 
            this.tbVideoPath.Location = new System.Drawing.Point(124, 18);
            this.tbVideoPath.Name = "tbVideoPath";
            this.tbVideoPath.ReadOnly = true;
            this.tbVideoPath.Size = new System.Drawing.Size(244, 21);
            this.tbVideoPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "InputVideo";
            // 
            // drawImageBox1
            // 
            this.drawImageBox1.AllowDrop = true;
            this.drawImageBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawImageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawImageBox1.Location = new System.Drawing.Point(0, 110);
            this.drawImageBox1.Name = "drawImageBox1";
            this.drawImageBox1.Size = new System.Drawing.Size(766, 312);
            this.drawImageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.drawImageBox1.TabIndex = 2;
            this.drawImageBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsspbarShowProcess,
            this.tsslbFrameCnt});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(766, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsspbarShowProcess
            // 
            this.tsspbarShowProcess.Name = "tsspbarShowProcess";
            this.tsspbarShowProcess.Size = new System.Drawing.Size(100, 16);
            // 
            // tsslbFrameCnt
            // 
            this.tsslbFrameCnt.Name = "tsslbFrameCnt";
            this.tsslbFrameCnt.Size = new System.Drawing.Size(27, 17);
            this.tsslbFrameCnt.Text = "0/0";
            // 
            // ConvertVideoToImgs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 444);
            this.Controls.Add(this.drawImageBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConvertVideoToImgs";
            this.Text = "video to imgs";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawImageBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbOutputImgDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectVideo;
        private System.Windows.Forms.TextBox tbVideoPath;
        private System.Windows.Forms.Label label1;
        private DrawImageBox drawImageBox1;
        private System.Windows.Forms.Button btnStrat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsspbarShowProcess;
        private System.Windows.Forms.ToolStripStatusLabel tsslbFrameCnt;
    }
}