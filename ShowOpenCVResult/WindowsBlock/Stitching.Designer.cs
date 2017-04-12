namespace ShowOpenCVResult
{
    partial class Stitching
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stitching));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.panel1 = new System.Windows.Forms.Panel();
            this.myTrackBar5 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar4 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar3 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar2 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar1 = new ShowOpenCVResult.MyTrackBar();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(903, 25);
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
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 232);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(96, 191);
            this.treeView1.TabIndex = 1;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imageIOControl1
            // 
            this.imageIOControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIOControl1.Image1 = null;
            this.imageIOControl1.Image2 = null;
            this.imageIOControl1.Location = new System.Drawing.Point(96, 232);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.Size = new System.Drawing.Size(807, 191);
            this.imageIOControl1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIOControl1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.myTrackBar5);
            this.panel1.Controls.Add(this.myTrackBar4);
            this.panel1.Controls.Add(this.myTrackBar3);
            this.panel1.Controls.Add(this.myTrackBar2);
            this.panel1.Controls.Add(this.myTrackBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 207);
            this.panel1.TabIndex = 3;
            // 
            // myTrackBar5
            // 
            this.myTrackBar5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar5.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar5.Location = new System.Drawing.Point(0, 164);
            this.myTrackBar5.Maximum = 20;
            this.myTrackBar5.Minimum = 1;
            this.myTrackBar5.Name = "myTrackBar5";
            this.myTrackBar5.Size = new System.Drawing.Size(903, 43);
            this.myTrackBar5.TabIndex = 4;
            this.myTrackBar5.Title = "SIzeH";
            this.myTrackBar5.Value = 1;
            this.myTrackBar5.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // myTrackBar4
            // 
            this.myTrackBar4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar4.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar4.Location = new System.Drawing.Point(0, 121);
            this.myTrackBar4.Maximum = 20;
            this.myTrackBar4.Minimum = 1;
            this.myTrackBar4.Name = "myTrackBar4";
            this.myTrackBar4.Size = new System.Drawing.Size(903, 43);
            this.myTrackBar4.TabIndex = 3;
            this.myTrackBar4.Title = "SizeW";
            this.myTrackBar4.Value = 3;
            this.myTrackBar4.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // myTrackBar3
            // 
            this.myTrackBar3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar3.Location = new System.Drawing.Point(0, 79);
            this.myTrackBar3.Maximum = 1000;
            this.myTrackBar3.Minimum = 0;
            this.myTrackBar3.Name = "myTrackBar3";
            this.myTrackBar3.Size = new System.Drawing.Size(903, 42);
            this.myTrackBar3.TabIndex = 2;
            this.myTrackBar3.Title = "系数比";
            this.myTrackBar3.Value = 130;
            this.myTrackBar3.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // myTrackBar2
            // 
            this.myTrackBar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar2.Location = new System.Drawing.Point(0, 36);
            this.myTrackBar2.Maximum = 10;
            this.myTrackBar2.Minimum = 0;
            this.myTrackBar2.Name = "myTrackBar2";
            this.myTrackBar2.Size = new System.Drawing.Size(903, 43);
            this.myTrackBar2.TabIndex = 1;
            this.myTrackBar2.Title = "金字塔数量";
            this.myTrackBar2.Value = 5;
            this.myTrackBar2.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar1.Location = new System.Drawing.Point(0, 0);
            this.myTrackBar1.Maximum = 3000;
            this.myTrackBar1.Minimum = 0;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(903, 36);
            this.myTrackBar1.TabIndex = 0;
            this.myTrackBar1.Title = "特征数量";
            this.myTrackBar1.Value = 1500;
            this.myTrackBar1.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(96, 232);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 191);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // BitmapStitching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 423);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.imageIOControl1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BitmapStitching";
            this.Text = "BitmapStitching";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TreeView treeView1;
        private ImageIO imageIOControl1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panel1;
        private MyTrackBar myTrackBar5;
        private MyTrackBar myTrackBar4;
        private MyTrackBar myTrackBar3;
        private MyTrackBar myTrackBar2;
        private MyTrackBar myTrackBar1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}