namespace ShowOpenCVResult
{
    partial class HsvTrack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HsvTrack));
            this.Finder = new System.Windows.Forms.GroupBox();
            this.numFps = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numIdx = new System.Windows.Forms.NumericUpDown();
            this.BtnPalyOrPause = new System.Windows.Forms.Button();
            this.btnStartTrack = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFindColor = new System.Windows.Forms.Button();
            this.pnParams = new System.Windows.Forms.Panel();
            this.vmaxbar = new ShowOpenCVResult.MyTrackBar();
            this.vminbar = new ShowOpenCVResult.MyTrackBar();
            this.smaxbar = new ShowOpenCVResult.MyTrackBar();
            this.sminbar = new ShowOpenCVResult.MyTrackBar();
            this.hmaxbar = new ShowOpenCVResult.MyTrackBar();
            this.hminbar = new ShowOpenCVResult.MyTrackBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tstbIndex = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.imageIO1 = new ShowOpenCVResult.ImageIO();
            this.Finder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIdx)).BeginInit();
            this.pnParams.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Finder
            // 
            this.Finder.Controls.Add(this.numFps);
            this.Finder.Controls.Add(this.label2);
            this.Finder.Controls.Add(this.label1);
            this.Finder.Controls.Add(this.numIdx);
            this.Finder.Controls.Add(this.BtnPalyOrPause);
            this.Finder.Controls.Add(this.btnStartTrack);
            this.Finder.Controls.Add(this.btnReset);
            this.Finder.Controls.Add(this.btnFindColor);
            this.Finder.Dock = System.Windows.Forms.DockStyle.Top;
            this.Finder.Location = new System.Drawing.Point(0, 153);
            this.Finder.Name = "Finder";
            this.Finder.Size = new System.Drawing.Size(724, 67);
            this.Finder.TabIndex = 3;
            this.Finder.TabStop = false;
            this.Finder.Text = "Config";
            // 
            // numFps
            // 
            this.numFps.Location = new System.Drawing.Point(491, 20);
            this.numFps.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numFps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFps.Name = "numFps";
            this.numFps.Size = new System.Drawing.Size(99, 21);
            this.numFps.TabIndex = 7;
            this.numFps.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numFps.ValueChanged += new System.EventHandler(this.numFps_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(462, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fps";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "ChnIdx";
            // 
            // numIdx
            // 
            this.numIdx.Location = new System.Drawing.Point(343, 20);
            this.numIdx.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numIdx.Name = "numIdx";
            this.numIdx.Size = new System.Drawing.Size(99, 21);
            this.numIdx.TabIndex = 4;
            // 
            // BtnPalyOrPause
            // 
            this.BtnPalyOrPause.Location = new System.Drawing.Point(637, 20);
            this.BtnPalyOrPause.Name = "BtnPalyOrPause";
            this.BtnPalyOrPause.Size = new System.Drawing.Size(75, 23);
            this.BtnPalyOrPause.TabIndex = 3;
            this.BtnPalyOrPause.Text = "Play/Pause";
            this.BtnPalyOrPause.UseVisualStyleBackColor = true;
            this.BtnPalyOrPause.Click += new System.EventHandler(this.BtnPalyOrPause_Click);
            // 
            // btnStartTrack
            // 
            this.btnStartTrack.Location = new System.Drawing.Point(106, 20);
            this.btnStartTrack.Name = "btnStartTrack";
            this.btnStartTrack.Size = new System.Drawing.Size(75, 23);
            this.btnStartTrack.TabIndex = 2;
            this.btnStartTrack.Text = "Track";
            this.btnStartTrack.UseVisualStyleBackColor = true;
            this.btnStartTrack.Click += new System.EventHandler(this.btnStartTrack_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(203, 20);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFindColor
            // 
            this.btnFindColor.Location = new System.Drawing.Point(13, 21);
            this.btnFindColor.Name = "btnFindColor";
            this.btnFindColor.Size = new System.Drawing.Size(75, 23);
            this.btnFindColor.TabIndex = 0;
            this.btnFindColor.Text = "Find";
            this.btnFindColor.UseVisualStyleBackColor = true;
            this.btnFindColor.Click += new System.EventHandler(this.btnFindColor_Click);
            // 
            // pnParams
            // 
            this.pnParams.Controls.Add(this.vmaxbar);
            this.pnParams.Controls.Add(this.vminbar);
            this.pnParams.Controls.Add(this.smaxbar);
            this.pnParams.Controls.Add(this.sminbar);
            this.pnParams.Controls.Add(this.hmaxbar);
            this.pnParams.Controls.Add(this.hminbar);
            this.pnParams.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnParams.Location = new System.Drawing.Point(0, 25);
            this.pnParams.Name = "pnParams";
            this.pnParams.Size = new System.Drawing.Size(724, 128);
            this.pnParams.TabIndex = 1;
            // 
            // vmaxbar
            // 
            this.vmaxbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vmaxbar.Location = new System.Drawing.Point(366, 83);
            this.vmaxbar.Maximum = 255;
            this.vmaxbar.Minimum = 0;
            this.vmaxbar.Name = "vmaxbar";
            this.vmaxbar.Size = new System.Drawing.Size(357, 43);
            this.vmaxbar.TabIndex = 5;
            this.vmaxbar.Title = "vmax";
            this.vmaxbar.Value = 255;
            // 
            // vminbar
            // 
            this.vminbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vminbar.Location = new System.Drawing.Point(3, 83);
            this.vminbar.Maximum = 255;
            this.vminbar.Minimum = 0;
            this.vminbar.Name = "vminbar";
            this.vminbar.Size = new System.Drawing.Size(357, 43);
            this.vminbar.TabIndex = 4;
            this.vminbar.Title = "vmin";
            this.vminbar.Value = 0;
            // smaxbar
            // 
            this.smaxbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.smaxbar.Location = new System.Drawing.Point(366, 43);
            this.smaxbar.Maximum = 255;
            this.smaxbar.Minimum = 0;
            this.smaxbar.Name = "smaxbar";
            this.smaxbar.Size = new System.Drawing.Size(357, 43);
            this.smaxbar.TabIndex = 3;
            this.smaxbar.Title = "smax";
            this.smaxbar.Value = 255;
            // 
            // sminbar
            // 
            this.sminbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sminbar.Location = new System.Drawing.Point(3, 43);
            this.sminbar.Maximum = 255;
            this.sminbar.Minimum = 0;
            this.sminbar.Name = "sminbar";
            this.sminbar.Size = new System.Drawing.Size(357, 43);
            this.sminbar.TabIndex = 2;
            this.sminbar.Title = "smin";
            this.sminbar.Value = 0;
            // 
            // hmaxbar
            // 
            this.hmaxbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hmaxbar.Location = new System.Drawing.Point(366, 0);
            this.hmaxbar.Maximum = 180;
            this.hmaxbar.Minimum = 0;
            this.hmaxbar.Name = "hmaxbar";
            this.hmaxbar.Size = new System.Drawing.Size(357, 43);
            this.hmaxbar.TabIndex = 1;
            this.hmaxbar.Title = "hmax";
            this.hmaxbar.Value = 180;
            // 
            // hminbar
            // 
            this.hminbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hminbar.Location = new System.Drawing.Point(3, 0);
            this.hminbar.Maximum = 180;
            this.hminbar.Minimum = 0;
            this.hminbar.Name = "hminbar";
            this.hminbar.Size = new System.Drawing.Size(357, 43);
            this.hminbar.TabIndex = 0;
            this.hminbar.Title = "hmin";
            this.hminbar.Value = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.tstbIndex,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(724, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton1.Text = "Camera";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tstbIndex
            // 
            this.tstbIndex.Name = "tstbIndex";
            this.tstbIndex.Size = new System.Drawing.Size(100, 25);
            this.tstbIndex.Text = "0";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.CheckOnClick = true;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(88, 22);
            this.toolStripButton2.Text = "Normalize";
            // 
            // imageIO1
            // 
            this.imageIO1.AutoDispose = false;
            this.imageIO1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIO1.InImage = null;
            this.imageIO1.Location = new System.Drawing.Point(0, 220);
            this.imageIO1.Name = "imageIO1";
            this.imageIO1.OutImage = null;
            this.imageIO1.Size = new System.Drawing.Size(724, 304);
            this.imageIO1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIO1.TabIndex = 0;
            this.imageIO1.DoImgChange += new System.EventHandler(this.imageIO1_DoImgChange);
            // 
            // HsvTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 524);
            this.Controls.Add(this.imageIO1);
            this.Controls.Add(this.Finder);
            this.Controls.Add(this.pnParams);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HsvTrack";
            this.Text = "HsvTrack";
            this.Load += new System.EventHandler(this.HsvTrack_Load);
            this.Finder.ResumeLayout(false);
            this.Finder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIdx)).EndInit();
            this.pnParams.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageIO imageIO1;
        private System.Windows.Forms.Panel pnParams;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private MyTrackBar vmaxbar;
        private MyTrackBar vminbar;
        private MyTrackBar smaxbar;
        private MyTrackBar sminbar;
        private MyTrackBar hmaxbar;
        private MyTrackBar hminbar;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox Finder;
        private System.Windows.Forms.Button btnStartTrack;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFindColor;
        private System.Windows.Forms.Button BtnPalyOrPause;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numIdx;
        private System.Windows.Forms.ToolStripTextBox tstbIndex;
        private System.Windows.Forms.NumericUpDown numFps;
        private System.Windows.Forms.Label label2;
    }
}