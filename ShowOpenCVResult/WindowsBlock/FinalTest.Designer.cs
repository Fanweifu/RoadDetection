﻿namespace ShowOpenCVResult
{
    partial class FinalTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinalTest));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.imageIO1 = new ShowOpenCVResult.ImageIO();
            this.myTrackBar1 = new ShowOpenCVResult.MyTrackBar();
            this.toolStrip1.SuspendLayout();
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
            // imageIO1
            // 
            this.imageIO1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIO1.Image1 = null;
            this.imageIO1.Image2 = null;
            this.imageIO1.Location = new System.Drawing.Point(0, 76);
            this.imageIO1.Name = "imageIO1";
            this.imageIO1.Size = new System.Drawing.Size(723, 368);
            this.imageIO1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIO1.TabIndex = 1;
            this.imageIO1.DoImgChange += new System.EventHandler(this.imageIO1_DoImgChange);
            this.imageIO1.AfterImgLoaded += new System.EventHandler(this.imageIO1_AfterImgLoaded);
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar1.Location = new System.Drawing.Point(0, 25);
            this.myTrackBar1.Maximum = 100;
            this.myTrackBar1.Minimum = 0;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(723, 51);
            this.myTrackBar1.TabIndex = 2;
            this.myTrackBar1.Title = "Threshold";
            this.myTrackBar1.Value = 0;
            this.myTrackBar1.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // FinalTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 444);
            this.Controls.Add(this.imageIO1);
            this.Controls.Add(this.myTrackBar1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FinalTest";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private ImageIO imageIO1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private MyTrackBar myTrackBar1;
    }
}