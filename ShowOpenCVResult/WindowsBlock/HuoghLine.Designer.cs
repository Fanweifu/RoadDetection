namespace ShowOpenCVResult
{
    partial class HuoghLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HuoghLine));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.myTrackBar1 = new ShowOpenCVResult.MyTrackBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.myTrackBar2 = new ShowOpenCVResult.MyTrackBar();
            this.rhoBar = new ShowOpenCVResult.MyTrackBar();
            this.thetaBar = new ShowOpenCVResult.MyTrackBar();
            this.thresholdBar = new ShowOpenCVResult.MyTrackBar();
            this.minLenghtBar = new ShowOpenCVResult.MyTrackBar();
            this.maxgrapBar = new ShowOpenCVResult.MyTrackBar();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton4,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(723, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Checked = true;
            this.toolStripButton2.CheckOnClick = true;
            this.toolStripButton2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(106, 22);
            this.toolStripButton2.Text = "cannyProcess";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.CheckOnClick = true;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(91, 22);
            this.toolStripButton4.Text = "SelectLines";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(54, 22);
            this.toolStripButton3.Text = "save";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // imageIOControl1
            // 
            this.imageIOControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIOControl1.Image1 = null;
            this.imageIOControl1.Image2 = null;
            this.imageIOControl1.Location = new System.Drawing.Point(0, 223);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.Size = new System.Drawing.Size(723, 221);
            this.imageIOControl1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIOControl1.TabIndex = 2;
            this.imageIOControl1.DoImgChange += new System.EventHandler(this.imageIOControl1_DoImgChange);
            this.imageIOControl1.AfterImgLoaded += new System.EventHandler(this.imageIOControl1_AfterImgLoaded);
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar1.Location = new System.Drawing.Point(0, 43);
            this.myTrackBar1.Maximum = 1000;
            this.myTrackBar1.Minimum = 0;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(241, 43);
            this.myTrackBar1.TabIndex = 0;
            this.myTrackBar1.Title = "threshold1";
            this.myTrackBar1.Value = 120;
            this.myTrackBar1.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.myTrackBar1);
            this.splitContainer1.Panel1.Controls.Add(this.myTrackBar2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rhoBar);
            this.splitContainer1.Panel2.Controls.Add(this.thetaBar);
            this.splitContainer1.Panel2.Controls.Add(this.thresholdBar);
            this.splitContainer1.Panel2.Controls.Add(this.minLenghtBar);
            this.splitContainer1.Panel2.Controls.Add(this.maxgrapBar);
            this.splitContainer1.Size = new System.Drawing.Size(723, 198);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.TabIndex = 3;
            // 
            // myTrackBar2
            // 
            this.myTrackBar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar2.Location = new System.Drawing.Point(0, 0);
            this.myTrackBar2.Maximum = 1000;
            this.myTrackBar2.Minimum = 0;
            this.myTrackBar2.Name = "myTrackBar2";
            this.myTrackBar2.Size = new System.Drawing.Size(241, 43);
            this.myTrackBar2.TabIndex = 1;
            this.myTrackBar2.Title = "threshold2";
            this.myTrackBar2.Value = 180;
            this.myTrackBar2.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // rhoBar
            // 
            this.rhoBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rhoBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.rhoBar.Location = new System.Drawing.Point(0, 160);
            this.rhoBar.Maximum = 628;
            this.rhoBar.Minimum = 1;
            this.rhoBar.Name = "rhoBar";
            this.rhoBar.Size = new System.Drawing.Size(478, 37);
            this.rhoBar.TabIndex = 2;
            this.rhoBar.Title = "rho";
            this.rhoBar.Value = 100;
            this.rhoBar.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // thetaBar
            // 
            this.thetaBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thetaBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.thetaBar.Location = new System.Drawing.Point(0, 123);
            this.thetaBar.Maximum = 500;
            this.thetaBar.Minimum = 1;
            this.thetaBar.Name = "thetaBar";
            this.thetaBar.Size = new System.Drawing.Size(478, 37);
            this.thetaBar.TabIndex = 3;
            this.thetaBar.Title = "theta";
            this.thetaBar.Value = 1;
            this.thetaBar.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // thresholdBar
            // 
            this.thresholdBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thresholdBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.thresholdBar.Location = new System.Drawing.Point(0, 82);
            this.thresholdBar.Maximum = 500;
            this.thresholdBar.Minimum = 1;
            this.thresholdBar.Name = "thresholdBar";
            this.thresholdBar.Size = new System.Drawing.Size(478, 41);
            this.thresholdBar.TabIndex = 4;
            this.thresholdBar.Title = "threshold";
            this.thresholdBar.Value = 50;
            this.thresholdBar.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // minLenghtBar
            // 
            this.minLenghtBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minLenghtBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.minLenghtBar.Location = new System.Drawing.Point(0, 41);
            this.minLenghtBar.Maximum = 500;
            this.minLenghtBar.Minimum = 0;
            this.minLenghtBar.Name = "minLenghtBar";
            this.minLenghtBar.Size = new System.Drawing.Size(478, 41);
            this.minLenghtBar.TabIndex = 5;
            this.minLenghtBar.Title = "Minlength";
            this.minLenghtBar.Value = 50;
            this.minLenghtBar.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // maxgrapBar
            // 
            this.maxgrapBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxgrapBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.maxgrapBar.Location = new System.Drawing.Point(0, 0);
            this.maxgrapBar.Maximum = 500;
            this.maxgrapBar.Minimum = 0;
            this.maxgrapBar.Name = "maxgrapBar";
            this.maxgrapBar.Size = new System.Drawing.Size(478, 41);
            this.maxgrapBar.TabIndex = 6;
            this.maxgrapBar.Title = "MaxGrap";
            this.maxgrapBar.Value = 50;
            this.maxgrapBar.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // HuoghLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 444);
            this.Controls.Add(this.imageIOControl1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HuoghLine";
            this.Text = "BitmapHuoghTest";
            this.Load += new System.EventHandler(this.HuoghLine_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private ImageIO imageIOControl1;
        private MyTrackBar myTrackBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MyTrackBar myTrackBar2;
        private MyTrackBar thetaBar;
        private MyTrackBar rhoBar;
        private MyTrackBar thresholdBar;
        private MyTrackBar maxgrapBar;
        private MyTrackBar minLenghtBar;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}