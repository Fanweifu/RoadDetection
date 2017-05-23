namespace ShowOpenCVResult
{
    partial class Blur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Blur));
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.myTrackBar1 = new ShowOpenCVResult.MyTrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnBilateral = new System.Windows.Forms.RadioButton();
            this.rbtnMiddleValue = new System.Windows.Forms.RadioButton();
            this.rbtnGaussian = new System.Windows.Forms.RadioButton();
            this.rbtnBlur = new System.Windows.Forms.RadioButton();
            this.rbtnBoxBlur = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenImg = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.imageIOControl1);
            this.panel2.Controls.Add(this.myTrackBar1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 489);
            this.panel2.TabIndex = 4;
            // 
            // imageIOControl1
            // 
            this.imageIOControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIOControl1.Location = new System.Drawing.Point(0, 93);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.OutImage = null;
            this.imageIOControl1.Size = new System.Drawing.Size(663, 396);
            this.imageIOControl1.TabIndex = 1;
            this.imageIOControl1.DoImgChange += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar1.Location = new System.Drawing.Point(0, 50);
            this.myTrackBar1.Maximum = 255;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(663, 43);
            this.myTrackBar1.TabIndex = 4;
            this.myTrackBar1.Title = "算子核大小";
            this.myTrackBar1.Value = 5;
            this.myTrackBar1.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.rbtnBilateral);
            this.panel1.Controls.Add(this.rbtnMiddleValue);
            this.panel1.Controls.Add(this.rbtnGaussian);
            this.panel1.Controls.Add(this.rbtnBlur);
            this.panel1.Controls.Add(this.rbtnBoxBlur);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 25);
            this.panel1.TabIndex = 2;
            // 
            // rbtnBilateral
            // 
            this.rbtnBilateral.AutoSize = true;
            this.rbtnBilateral.Location = new System.Drawing.Point(288, 6);
            this.rbtnBilateral.Name = "rbtnBilateral";
            this.rbtnBilateral.Size = new System.Drawing.Size(47, 16);
            this.rbtnBilateral.TabIndex = 5;
            this.rbtnBilateral.Text = "双边";
            this.rbtnBilateral.UseVisualStyleBackColor = true;
            this.rbtnBilateral.Click += new System.EventHandler(this.rbtnBilateral_Click);
            // 
            // rbtnMiddleValue
            // 
            this.rbtnMiddleValue.AutoSize = true;
            this.rbtnMiddleValue.Location = new System.Drawing.Point(235, 6);
            this.rbtnMiddleValue.Name = "rbtnMiddleValue";
            this.rbtnMiddleValue.Size = new System.Drawing.Size(47, 16);
            this.rbtnMiddleValue.TabIndex = 4;
            this.rbtnMiddleValue.Text = "中值";
            this.rbtnMiddleValue.UseVisualStyleBackColor = true;
            this.rbtnMiddleValue.Click += new System.EventHandler(this.rbtnMiddleValue_Click);
            // 
            // rbtnGaussian
            // 
            this.rbtnGaussian.AutoSize = true;
            this.rbtnGaussian.Location = new System.Drawing.Point(182, 6);
            this.rbtnGaussian.Name = "rbtnGaussian";
            this.rbtnGaussian.Size = new System.Drawing.Size(47, 16);
            this.rbtnGaussian.TabIndex = 3;
            this.rbtnGaussian.Text = "高斯";
            this.rbtnGaussian.UseVisualStyleBackColor = true;
            this.rbtnGaussian.Click += new System.EventHandler(this.rbtnGaussian_Click);
            // 
            // rbtnBlur
            // 
            this.rbtnBlur.AutoSize = true;
            this.rbtnBlur.Location = new System.Drawing.Point(129, 6);
            this.rbtnBlur.Name = "rbtnBlur";
            this.rbtnBlur.Size = new System.Drawing.Size(47, 16);
            this.rbtnBlur.TabIndex = 2;
            this.rbtnBlur.Text = "均值";
            this.rbtnBlur.UseVisualStyleBackColor = true;
            this.rbtnBlur.Click += new System.EventHandler(this.rbtnBlur_Click);
            // 
            // rbtnBoxBlur
            // 
            this.rbtnBoxBlur.AutoSize = true;
            this.rbtnBoxBlur.Checked = true;
            this.rbtnBoxBlur.Location = new System.Drawing.Point(76, 6);
            this.rbtnBoxBlur.Name = "rbtnBoxBlur";
            this.rbtnBoxBlur.Size = new System.Drawing.Size(47, 16);
            this.rbtnBoxBlur.TabIndex = 1;
            this.rbtnBoxBlur.TabStop = true;
            this.rbtnBoxBlur.Text = "方框";
            this.rbtnBoxBlur.UseVisualStyleBackColor = true;
            this.rbtnBoxBlur.Click += new System.EventHandler(this.rbtnBoxBlur_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "滤波方式";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenImg});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(663, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpenImg
            // 
            this.tsbtnOpenImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpenImg.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenImg.Image")));
            this.tsbtnOpenImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenImg.Name = "tsbtnOpenImg";
            this.tsbtnOpenImg.Size = new System.Drawing.Size(23, 22);
            this.tsbtnOpenImg.Text = "toolStripButton1";
            this.tsbtnOpenImg.Click += new System.EventHandler(this.tsbtnOpenImg_Click);
            // 
            // BitmapBlur
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 489);
            this.Controls.Add(this.panel2);
            this.Name = "BitmapBlur";
            this.Text = "滤波";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageIO imageIOControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.RadioButton rbtnBilateral;
        private System.Windows.Forms.RadioButton rbtnGaussian;
        private System.Windows.Forms.RadioButton rbtnBlur;
        private System.Windows.Forms.RadioButton rbtnBoxBlur;
        private System.Windows.Forms.RadioButton rbtnMiddleValue;
        private System.Windows.Forms.Panel panel2;
        private MyTrackBar myTrackBar1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenImg;
    }
}