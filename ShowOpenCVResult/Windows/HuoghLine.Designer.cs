namespace ShowOpenCVResult.Windows
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
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.myTrackBar1 = new ShowOpenCVResult.MyTrackBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.barAngle = new ShowOpenCVResult.MyTrackBar();
            this.checkSelectLines = new System.Windows.Forms.CheckBox();
            this.cannyGroup = new System.Windows.Forms.GroupBox();
            this.myTrackBar2 = new ShowOpenCVResult.MyTrackBar();
            this.groupHoughParams = new System.Windows.Forms.GroupBox();
            this.thetaBar = new ShowOpenCVResult.MyTrackBar();
            this.rhoBar = new ShowOpenCVResult.MyTrackBar();
            this.maxgrapBar = new ShowOpenCVResult.MyTrackBar();
            this.minLenghtBar = new ShowOpenCVResult.MyTrackBar();
            this.thresholdBar = new ShowOpenCVResult.MyTrackBar();
            this.rbtnCanny = new System.Windows.Forms.RadioButton();
            this.rbtnMyHorizontal = new System.Windows.Forms.RadioButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cannyGroup.SuspendLayout();
            this.groupHoughParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(723, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripButton1.Text = "open_img";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(95, 22);
            this.toolStripButton3.Text = "save_config";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // imageIOControl1
            // 
            this.imageIOControl1.AutoDispose = false;
            this.imageIOControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIOControl1.InImage = null;
            this.imageIOControl1.Location = new System.Drawing.Point(0, 243);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.OutImage = null;
            this.imageIOControl1.Size = new System.Drawing.Size(723, 201);
            this.imageIOControl1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIOControl1.TabIndex = 2;
            this.imageIOControl1.DoImgChange += new System.EventHandler(this.imageIOControl1_DoImgChange);
            this.imageIOControl1.AfterImgLoaded += new System.EventHandler(this.imageIOControl1_AfterImgLoaded);
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar1.Location = new System.Drawing.Point(3, 17);
            this.myTrackBar1.Maximum = 1000;
            this.myTrackBar1.Minimum = 0;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(235, 43);
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
            this.splitContainer1.Panel1.Controls.Add(this.rbtnMyHorizontal);
            this.splitContainer1.Panel1.Controls.Add(this.rbtnCanny);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.checkSelectLines);
            this.splitContainer1.Panel1.Controls.Add(this.cannyGroup);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupHoughParams);
            this.splitContainer1.Size = new System.Drawing.Size(723, 218);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.barAngle);
            this.groupBox1.Location = new System.Drawing.Point(0, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 68);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "selectParams";
            // 
            // barAngle
            // 
            this.barAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.barAngle.Dock = System.Windows.Forms.DockStyle.Top;
            this.barAngle.Location = new System.Drawing.Point(3, 17);
            this.barAngle.Maximum = 10;
            this.barAngle.Minimum = 0;
            this.barAngle.Name = "barAngle";
            this.barAngle.Size = new System.Drawing.Size(235, 41);
            this.barAngle.TabIndex = 2;
            this.barAngle.Title = "angle";
            this.barAngle.Value = 5;
            this.barAngle.ValueChanged += new System.EventHandler(this.barAngle_ValueChanged);
            // 
            // checkSelectLines
            // 
            this.checkSelectLines.AutoSize = true;
            this.checkSelectLines.Location = new System.Drawing.Point(0, 134);
            this.checkSelectLines.Name = "checkSelectLines";
            this.checkSelectLines.Size = new System.Drawing.Size(60, 16);
            this.checkSelectLines.TabIndex = 3;
            this.checkSelectLines.Text = "select";
            this.checkSelectLines.UseVisualStyleBackColor = true;
            this.checkSelectLines.CheckedChanged += new System.EventHandler(this.checkSelectLines_CheckedChanged);
            // 
            // cannyGroup
            // 
            this.cannyGroup.Controls.Add(this.myTrackBar2);
            this.cannyGroup.Controls.Add(this.myTrackBar1);
            this.cannyGroup.Location = new System.Drawing.Point(0, 16);
            this.cannyGroup.Name = "cannyGroup";
            this.cannyGroup.Size = new System.Drawing.Size(241, 118);
            this.cannyGroup.TabIndex = 2;
            this.cannyGroup.TabStop = false;
            this.cannyGroup.Text = "Canny";
            // 
            // myTrackBar2
            // 
            this.myTrackBar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar2.Location = new System.Drawing.Point(3, 60);
            this.myTrackBar2.Maximum = 1000;
            this.myTrackBar2.Minimum = 0;
            this.myTrackBar2.Name = "myTrackBar2";
            this.myTrackBar2.Size = new System.Drawing.Size(235, 41);
            this.myTrackBar2.TabIndex = 1;
            this.myTrackBar2.Title = "threshold2";
            this.myTrackBar2.Value = 180;
            this.myTrackBar2.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // groupHoughParams
            // 
            this.groupHoughParams.Controls.Add(this.thetaBar);
            this.groupHoughParams.Controls.Add(this.rhoBar);
            this.groupHoughParams.Controls.Add(this.maxgrapBar);
            this.groupHoughParams.Controls.Add(this.minLenghtBar);
            this.groupHoughParams.Controls.Add(this.thresholdBar);
            this.groupHoughParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupHoughParams.Location = new System.Drawing.Point(0, 0);
            this.groupHoughParams.Name = "groupHoughParams";
            this.groupHoughParams.Size = new System.Drawing.Size(478, 218);
            this.groupHoughParams.TabIndex = 7;
            this.groupHoughParams.TabStop = false;
            this.groupHoughParams.Text = "houghParams";
            // 
            // thetaBar
            // 
            this.thetaBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thetaBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.thetaBar.Location = new System.Drawing.Point(3, 177);
            this.thetaBar.Maximum = 500;
            this.thetaBar.Minimum = 1;
            this.thetaBar.Name = "thetaBar";
            this.thetaBar.Size = new System.Drawing.Size(472, 37);
            this.thetaBar.TabIndex = 3;
            this.thetaBar.Title = "theta";
            this.thetaBar.Value = 1;
            this.thetaBar.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // rhoBar
            // 
            this.rhoBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rhoBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.rhoBar.Location = new System.Drawing.Point(3, 140);
            this.rhoBar.Maximum = 628;
            this.rhoBar.Minimum = 1;
            this.rhoBar.Name = "rhoBar";
            this.rhoBar.Size = new System.Drawing.Size(472, 37);
            this.rhoBar.TabIndex = 2;
            this.rhoBar.Title = "rho";
            this.rhoBar.Value = 100;
            this.rhoBar.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // maxgrapBar
            // 
            this.maxgrapBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxgrapBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.maxgrapBar.Location = new System.Drawing.Point(3, 99);
            this.maxgrapBar.Maximum = 500;
            this.maxgrapBar.Minimum = 0;
            this.maxgrapBar.Name = "maxgrapBar";
            this.maxgrapBar.Size = new System.Drawing.Size(472, 41);
            this.maxgrapBar.TabIndex = 6;
            this.maxgrapBar.Title = "MaxGrap";
            this.maxgrapBar.Value = 50;
            this.maxgrapBar.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // minLenghtBar
            // 
            this.minLenghtBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minLenghtBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.minLenghtBar.Location = new System.Drawing.Point(3, 58);
            this.minLenghtBar.Maximum = 500;
            this.minLenghtBar.Minimum = 0;
            this.minLenghtBar.Name = "minLenghtBar";
            this.minLenghtBar.Size = new System.Drawing.Size(472, 41);
            this.minLenghtBar.TabIndex = 5;
            this.minLenghtBar.Title = "Minlength";
            this.minLenghtBar.Value = 50;
            this.minLenghtBar.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // thresholdBar
            // 
            this.thresholdBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.thresholdBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.thresholdBar.Location = new System.Drawing.Point(3, 17);
            this.thresholdBar.Maximum = 500;
            this.thresholdBar.Minimum = 1;
            this.thresholdBar.Name = "thresholdBar";
            this.thresholdBar.Size = new System.Drawing.Size(472, 41);
            this.thresholdBar.TabIndex = 4;
            this.thresholdBar.Title = "threshold";
            this.thresholdBar.Value = 50;
            this.thresholdBar.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // rbtnCanny
            // 
            this.rbtnCanny.AutoSize = true;
            this.rbtnCanny.Checked = true;
            this.rbtnCanny.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnCanny.Location = new System.Drawing.Point(0, 0);
            this.rbtnCanny.Name = "rbtnCanny";
            this.rbtnCanny.Size = new System.Drawing.Size(241, 16);
            this.rbtnCanny.TabIndex = 5;
            this.rbtnCanny.TabStop = true;
            this.rbtnCanny.Text = "Canny";
            this.rbtnCanny.UseVisualStyleBackColor = true;
            this.rbtnCanny.CheckedChanged += new System.EventHandler(this.rbtnCanny_CheckedChanged);
            // 
            // rbtnMyHorizontal
            // 
            this.rbtnMyHorizontal.AutoSize = true;
            this.rbtnMyHorizontal.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbtnMyHorizontal.Location = new System.Drawing.Point(0, 16);
            this.rbtnMyHorizontal.Name = "rbtnMyHorizontal";
            this.rbtnMyHorizontal.Size = new System.Drawing.Size(241, 16);
            this.rbtnMyHorizontal.TabIndex = 6;
            this.rbtnMyHorizontal.Text = "MyHorizontal";
            this.rbtnMyHorizontal.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.cannyGroup.ResumeLayout(false);
            this.groupHoughParams.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.GroupBox cannyGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkSelectLines;
        private MyTrackBar barAngle;
        private System.Windows.Forms.GroupBox groupHoughParams;
        private System.Windows.Forms.RadioButton rbtnMyHorizontal;
        private System.Windows.Forms.RadioButton rbtnCanny;
    }
}