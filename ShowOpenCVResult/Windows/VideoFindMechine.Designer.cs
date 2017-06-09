namespace ShowOpenCVResult.Windows
{
    partial class VideoFindMechine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoFindMechine));
            this.imageIO1 = new ShowOpenCVResult.ImageIO();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.myTrackBar2 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar1 = new ShowOpenCVResult.MyTrackBar();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageIO1
            // 
            this.imageIO1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIO1.InImage = null;
            this.imageIO1.OutImage = null;
            this.imageIO1.Location = new System.Drawing.Point(0, 125);
            this.imageIO1.Name = "imageIO1";
            this.imageIO1.Size = new System.Drawing.Size(723, 319);
            this.imageIO1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIO1.TabIndex = 1;
            this.imageIO1.DoImgChange += new System.EventHandler(this.imageIO1_DoImgChange);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(723, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.myTrackBar2);
            this.panel1.Controls.Add(this.myTrackBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 100);
            this.panel1.TabIndex = 2;
            // 
            // myTrackBar2
            // 
            this.myTrackBar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar2.Location = new System.Drawing.Point(3, 51);
            this.myTrackBar2.Maximum = 188;
            this.myTrackBar2.Minimum = 0;
            this.myTrackBar2.Name = "myTrackBar2";
            this.myTrackBar2.Size = new System.Drawing.Size(585, 43);
            this.myTrackBar2.TabIndex = 1;
            this.myTrackBar2.Title = "redThresholdInv";
            this.myTrackBar2.Value = 5;
            this.myTrackBar2.ValueChanged += new System.EventHandler(this.myTrackBar2_ValueChanged);
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar1.Location = new System.Drawing.Point(3, 3);
            this.myTrackBar1.Maximum = 180;
            this.myTrackBar1.Minimum = 0;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(585, 43);
            this.myTrackBar1.TabIndex = 0;
            this.myTrackBar1.Title = "redThreshold";
            this.myTrackBar1.Value = 5;
            this.myTrackBar1.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // VideoFindMechine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 444);
            this.Controls.Add(this.imageIO1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "VideoFindMechine";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private ImageIO imageIO1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Panel panel1;
        private MyTrackBar myTrackBar2;
        private MyTrackBar myTrackBar1;
    }
}