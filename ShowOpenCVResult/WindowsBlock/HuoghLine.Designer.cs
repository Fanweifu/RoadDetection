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
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.myTrackBar1 = new ShowOpenCVResult.MyTrackBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.myTrackBar2 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar7 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar6 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar5 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar4 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar3 = new ShowOpenCVResult.MyTrackBar();
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
            this.toolStripButton1});
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
            // imageIOControl1
            // 
            this.imageIOControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIOControl1.Image1 = null;
            this.imageIOControl1.Image2 = null;
            this.imageIOControl1.Location = new System.Drawing.Point(0, 227);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.Size = new System.Drawing.Size(723, 217);
            this.imageIOControl1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIOControl1.TabIndex = 2;
            this.imageIOControl1.DoImgChange += new System.EventHandler(this.imageIOControl1_DoImgChange);
            this.imageIOControl1.AfterImgLoaded += new System.EventHandler(this.imageIOControl1_AfterImgLoaded);
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar1.Location = new System.Drawing.Point(0, 0);
            this.myTrackBar1.Maximum = 500;
            this.myTrackBar1.Minimum = 0;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(360, 43);
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
            this.splitContainer1.Panel1.Controls.Add(this.myTrackBar2);
            this.splitContainer1.Panel1.Controls.Add(this.myTrackBar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.myTrackBar7);
            this.splitContainer1.Panel2.Controls.Add(this.myTrackBar6);
            this.splitContainer1.Panel2.Controls.Add(this.myTrackBar5);
            this.splitContainer1.Panel2.Controls.Add(this.myTrackBar4);
            this.splitContainer1.Panel2.Controls.Add(this.myTrackBar3);
            this.splitContainer1.Size = new System.Drawing.Size(723, 202);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 3;
            // 
            // myTrackBar2
            // 
            this.myTrackBar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar2.Location = new System.Drawing.Point(0, 43);
            this.myTrackBar2.Maximum = 500;
            this.myTrackBar2.Minimum = 0;
            this.myTrackBar2.Name = "myTrackBar2";
            this.myTrackBar2.Size = new System.Drawing.Size(360, 43);
            this.myTrackBar2.TabIndex = 1;
            this.myTrackBar2.Title = "threshold2";
            this.myTrackBar2.Value = 180;
            this.myTrackBar2.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // myTrackBar7
            // 
            this.myTrackBar7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar7.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar7.Location = new System.Drawing.Point(0, 156);
            this.myTrackBar7.Maximum = 500;
            this.myTrackBar7.Minimum = 0;
            this.myTrackBar7.Name = "myTrackBar7";
            this.myTrackBar7.Size = new System.Drawing.Size(359, 41);
            this.myTrackBar7.TabIndex = 6;
            this.myTrackBar7.Title = "MaxGrap";
            this.myTrackBar7.Value = 50;
            this.myTrackBar7.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // myTrackBar6
            // 
            this.myTrackBar6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar6.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar6.Location = new System.Drawing.Point(0, 115);
            this.myTrackBar6.Maximum = 500;
            this.myTrackBar6.Minimum = 0;
            this.myTrackBar6.Name = "myTrackBar6";
            this.myTrackBar6.Size = new System.Drawing.Size(359, 41);
            this.myTrackBar6.TabIndex = 5;
            this.myTrackBar6.Title = "Minlength";
            this.myTrackBar6.Value = 50;
            this.myTrackBar6.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // myTrackBar5
            // 
            this.myTrackBar5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar5.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar5.Location = new System.Drawing.Point(0, 74);
            this.myTrackBar5.Maximum = 500;
            this.myTrackBar5.Minimum = 1;
            this.myTrackBar5.Name = "myTrackBar5";
            this.myTrackBar5.Size = new System.Drawing.Size(359, 41);
            this.myTrackBar5.TabIndex = 4;
            this.myTrackBar5.Title = "threshold";
            this.myTrackBar5.Value = 50;
            this.myTrackBar5.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // myTrackBar4
            // 
            this.myTrackBar4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar4.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar4.Location = new System.Drawing.Point(0, 37);
            this.myTrackBar4.Maximum = 500;
            this.myTrackBar4.Minimum = 1;
            this.myTrackBar4.Name = "myTrackBar4";
            this.myTrackBar4.Size = new System.Drawing.Size(359, 37);
            this.myTrackBar4.TabIndex = 3;
            this.myTrackBar4.Title = "theta";
            this.myTrackBar4.Value = 1;
            this.myTrackBar4.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // myTrackBar3
            // 
            this.myTrackBar3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar3.Location = new System.Drawing.Point(0, 0);
            this.myTrackBar3.Maximum = 628;
            this.myTrackBar3.Minimum = 1;
            this.myTrackBar3.Name = "myTrackBar3";
            this.myTrackBar3.Size = new System.Drawing.Size(359, 37);
            this.myTrackBar3.TabIndex = 2;
            this.myTrackBar3.Title = "rho";
            this.myTrackBar3.Value = 100;
            this.myTrackBar3.ValueChanged += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // BitmapHuoghTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 444);
            this.Controls.Add(this.imageIOControl1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BitmapHuoghTest";
            this.Text = "BitmapHuoghTest";
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
        private MyTrackBar myTrackBar4;
        private MyTrackBar myTrackBar3;
        private MyTrackBar myTrackBar5;
        private MyTrackBar myTrackBar7;
        private MyTrackBar myTrackBar6;
    }
}