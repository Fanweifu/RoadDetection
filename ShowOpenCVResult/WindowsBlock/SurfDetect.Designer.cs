namespace ShowOpenCVResult
{
    partial class SurfDetect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SurfDetect));
            this.drawImageBox1 = new ShowOpenCVResult.DrawImageBox();
            this.drawImageBox2 = new ShowOpenCVResult.DrawImageBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenImg1 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOpenIma2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.drawImageBox3 = new ShowOpenCVResult.DrawImageBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.drawImageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawImageBox2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawImageBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // drawImageBox1
            // 
            this.drawImageBox1.DargOnNull = true;
            this.drawImageBox1.AllowDrop = true;
            this.drawImageBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawImageBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.drawImageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.drawImageBox1.Location = new System.Drawing.Point(0, 0);
            this.drawImageBox1.Name = "drawImageBox1";
            this.drawImageBox1.Size = new System.Drawing.Size(200, 209);
            this.drawImageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.drawImageBox1.TabIndex = 2;
            this.drawImageBox1.TabStop = false;
            // 
            // drawImageBox2
            // 
            this.drawImageBox2.DargOnNull = true;
            this.drawImageBox2.AllowDrop = true;
            this.drawImageBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawImageBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawImageBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.drawImageBox2.Location = new System.Drawing.Point(0, 209);
            this.drawImageBox2.Name = "drawImageBox2";
            this.drawImageBox2.Size = new System.Drawing.Size(200, 128);
            this.drawImageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.drawImageBox2.TabIndex = 2;
            this.drawImageBox2.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenImg1,
            this.tsbtnOpenIma2,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(633, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpenImg1
            // 
            this.tsbtnOpenImg1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpenImg1.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenImg1.Image")));
            this.tsbtnOpenImg1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenImg1.Name = "tsbtnOpenImg1";
            this.tsbtnOpenImg1.Size = new System.Drawing.Size(23, 22);
            this.tsbtnOpenImg1.Text = "toolStripButton1";
            this.tsbtnOpenImg1.Click += new System.EventHandler(this.tsbtnOpenImg1_Click);
            // 
            // tsbtnOpenIma2
            // 
            this.tsbtnOpenIma2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpenIma2.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenIma2.Image")));
            this.tsbtnOpenIma2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenIma2.Name = "tsbtnOpenIma2";
            this.tsbtnOpenIma2.Size = new System.Drawing.Size(23, 22);
            this.tsbtnOpenIma2.Text = "toolStripButton1";
            this.tsbtnOpenIma2.Click += new System.EventHandler(this.tsbtnOpenIma2_Click);
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
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 103);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 337);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // drawImageBox3
            // 
            this.drawImageBox3.DargOnNull = true;
            this.drawImageBox3.AllowDrop = true;
            this.drawImageBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawImageBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawImageBox3.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.drawImageBox3.Location = new System.Drawing.Point(203, 103);
            this.drawImageBox3.Name = "drawImageBox3";
            this.drawImageBox3.Size = new System.Drawing.Size(430, 337);
            this.drawImageBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.drawImageBox3.TabIndex = 5;
            this.drawImageBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.drawImageBox2);
            this.panel1.Controls.Add(this.drawImageBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 337);
            this.panel1.TabIndex = 6;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 209);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(200, 3);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.numericUpDown2);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 78);
            this.panel2.TabIndex = 7;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(66, 32);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "单点";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(119, 32);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "多点";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "原图";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(141, 3);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown2.TabIndex = 1;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(13, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // BitmapSuftDetect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 440);
            this.Controls.Add(this.drawImageBox3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BitmapSuftDetect";
            this.Text = "SuftDetect";
            this.Load += new System.EventHandler(this.SuftDetect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawImageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drawImageBox2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawImageBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DrawImageBox drawImageBox1;
        private DrawImageBox drawImageBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenImg1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenIma2;
        private System.Windows.Forms.Splitter splitter1;
        private DrawImageBox drawImageBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}