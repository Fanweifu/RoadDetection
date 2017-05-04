namespace ShowOpenCVResult
{
    partial class LineDetect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineDetect));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.imageIO1 = new ShowOpenCVResult.ImageIO();
            this.myTrackBar2 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar1 = new ShowOpenCVResult.MyTrackBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.myTrackBar2);
            this.panel1.Controls.Add(this.myTrackBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 100);
            this.panel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(579, 25);
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
            // imageIO1
            // 
            this.imageIO1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIO1.Image1 = null;
            this.imageIO1.Image2 = null;
            this.imageIO1.Location = new System.Drawing.Point(0, 125);
            this.imageIO1.Name = "imageIO1";
            this.imageIO1.Size = new System.Drawing.Size(579, 284);
            this.imageIO1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIO1.TabIndex = 2;
            this.imageIO1.DoImgChange += new System.EventHandler(this.imageIO1_DoImgChange);
            this.imageIO1.AfterImgLoaded += new System.EventHandler(this.imageIO1_AfterImgLoaded);
            // 
            // myTrackBar2
            // 
            this.myTrackBar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar2.Location = new System.Drawing.Point(0, 43);
            this.myTrackBar2.Maximum = 255;
            this.myTrackBar2.Minimum = 0;
            this.myTrackBar2.Name = "myTrackBar2";
            this.myTrackBar2.Size = new System.Drawing.Size(585, 34);
            this.myTrackBar2.TabIndex = 1;
            this.myTrackBar2.Title = "Diff";
            this.myTrackBar2.Value = 10;
            this.myTrackBar2.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar1.Location = new System.Drawing.Point(0, 3);
            this.myTrackBar1.Maximum = 255;
            this.myTrackBar1.Minimum = 0;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(588, 43);
            this.myTrackBar1.TabIndex = 0;
            this.myTrackBar1.Title = "Length";
            this.myTrackBar1.Value = 50;
            this.myTrackBar1.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
            this.comboBox1.Location = new System.Drawing.Point(3, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // LineDetect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 409);
            this.Controls.Add(this.imageIO1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "LineDetect";
            this.Text = "LineDetect";
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel1;
        private MyTrackBar myTrackBar2;
        private MyTrackBar myTrackBar1;
        private ImageIO imageIO1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}