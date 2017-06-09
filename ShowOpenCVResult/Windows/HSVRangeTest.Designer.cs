namespace ShowOpenCVResult.Windows
{
    partial class HSVRangeTest
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
            this.imageIO1 = new ShowOpenCVResult.ImageIO();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vmaxbar = new ShowOpenCVResult.MyTrackBar();
            this.vminbar = new ShowOpenCVResult.MyTrackBar();
            this.smaxbar = new ShowOpenCVResult.MyTrackBar();
            this.sminbar = new ShowOpenCVResult.MyTrackBar();
            this.hmaxbar = new ShowOpenCVResult.MyTrackBar();
            this.hminbar = new ShowOpenCVResult.MyTrackBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageIO1
            // 
            this.imageIO1.AutoDispose = false;
            this.imageIO1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIO1.InImage = null;
            this.imageIO1.Location = new System.Drawing.Point(0, 153);
            this.imageIO1.Name = "imageIO1";
            this.imageIO1.OutImage = null;
            this.imageIO1.Size = new System.Drawing.Size(724, 291);
            this.imageIO1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIO1.TabIndex = 0;
            this.imageIO1.DoImgChange += new System.EventHandler(this.imageIO1_DoImgChange);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.vmaxbar);
            this.panel1.Controls.Add(this.vminbar);
            this.panel1.Controls.Add(this.smaxbar);
            this.panel1.Controls.Add(this.sminbar);
            this.panel1.Controls.Add(this.hmaxbar);
            this.panel1.Controls.Add(this.hminbar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 128);
            this.panel1.TabIndex = 1;
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
            this.vmaxbar.ValueChanged += new System.EventHandler(this.vmaxbar_ValueChanged);
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
            this.vminbar.ValueChanged += new System.EventHandler(this.vminbar_ValueChanged);
            // 
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
            this.smaxbar.ValueChanged += new System.EventHandler(this.smaxbar_ValueChanged);
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
            this.sminbar.ValueChanged += new System.EventHandler(this.sminbar_ValueChanged);
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
            this.hmaxbar.ValueChanged += new System.EventHandler(this.hmaxbar_ValueChanged);
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
            this.hminbar.ValueChanged += new System.EventHandler(this.hminbar_ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(724, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton1.Text = "Open";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.CheckOnClick = true;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(72, 22);
            this.toolStripButton2.Text = "Normalize";
            // 
            // HSVRangeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 444);
            this.Controls.Add(this.imageIO1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HSVRangeTest";
            this.Text = "HSVRangeTest";
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageIO imageIO1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private MyTrackBar vmaxbar;
        private MyTrackBar vminbar;
        private MyTrackBar smaxbar;
        private MyTrackBar sminbar;
        private MyTrackBar hmaxbar;
        private MyTrackBar hminbar;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}