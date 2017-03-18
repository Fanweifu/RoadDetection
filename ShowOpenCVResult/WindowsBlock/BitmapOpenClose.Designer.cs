namespace ShowOpenCVResult
{
    partial class BitmapOpenClose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BitmapOpenClose));
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.myTrackBar1 = new ShowOpenCVResult.MyTrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.panel2.Size = new System.Drawing.Size(758, 429);
            this.panel2.TabIndex = 5;
            // 
            // imageIOControl1
            // 
            this.imageIOControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIOControl1.Location = new System.Drawing.Point(0, 91);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.Image2 = null;
            this.imageIOControl1.Size = new System.Drawing.Size(758, 338);
            this.imageIOControl1.TabIndex = 1;
            this.imageIOControl1.DoImgChange += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar1.Location = new System.Drawing.Point(0, 48);
            this.myTrackBar1.Maximum = 30;
            this.myTrackBar1.Minimum = 1;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(758, 43);
            this.myTrackBar1.TabIndex = 4;
            this.myTrackBar1.Title = "核值";
            this.myTrackBar1.Value = 5;
            this.myTrackBar1.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.rbtnBlur);
            this.panel1.Controls.Add(this.rbtnBoxBlur);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 23);
            this.panel1.TabIndex = 2;
            // 
            // rbtnBlur
            // 
            this.rbtnBlur.AutoSize = true;
            this.rbtnBlur.Location = new System.Drawing.Point(171, 3);
            this.rbtnBlur.Name = "rbtnBlur";
            this.rbtnBlur.Size = new System.Drawing.Size(59, 16);
            this.rbtnBlur.TabIndex = 2;
            this.rbtnBlur.Text = "闭操作";
            this.rbtnBlur.UseVisualStyleBackColor = true;
            this.rbtnBlur.Click += new System.EventHandler(this.rbtnBlur_Click);
            // 
            // rbtnBoxBlur
            // 
            this.rbtnBoxBlur.AutoSize = true;
            this.rbtnBoxBlur.Checked = true;
            this.rbtnBoxBlur.Location = new System.Drawing.Point(96, 4);
            this.rbtnBoxBlur.Name = "rbtnBoxBlur";
            this.rbtnBoxBlur.Size = new System.Drawing.Size(59, 16);
            this.rbtnBoxBlur.TabIndex = 1;
            this.rbtnBoxBlur.TabStop = true;
            this.rbtnBoxBlur.Text = "开操作";
            this.rbtnBoxBlur.UseVisualStyleBackColor = true;
            this.rbtnBoxBlur.CheckedChanged += new System.EventHandler(this.rbtnBoxBlur_CheckedChanged);
            this.rbtnBoxBlur.Click += new System.EventHandler(this.rbtnBoxBlur_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "形态学方式";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenImg});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(758, 25);
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
            // BitmapOpenClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(758, 429);
            this.Controls.Add(this.panel2);
            this.Name = "BitmapOpenClose";
            this.Text = "膨胀腐蚀";
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

        private System.Windows.Forms.Panel panel2;
        private ImageIO imageIOControl1;
        private MyTrackBar myTrackBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnBlur;
        private System.Windows.Forms.RadioButton rbtnBoxBlur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenImg;
    }
}