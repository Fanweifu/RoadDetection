namespace ShowOpenCVResult.Windows
{
    partial class MorphologyEx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MorphologyEx));
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.mybarX = new ShowOpenCVResult.MyTrackBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenImg = new System.Windows.Forms.ToolStripButton();
            this.mybarY = new ShowOpenCVResult.MyTrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.imageIOControl1);
            this.panel2.Controls.Add(this.mybarY);
            this.panel2.Controls.Add(this.mybarX);
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
            this.imageIOControl1.InImage = null;
            this.imageIOControl1.OutImage = null;
            this.imageIOControl1.Location = new System.Drawing.Point(0, 137);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.Size = new System.Drawing.Size(758, 292);
            this.imageIOControl1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIOControl1.TabIndex = 1;
            this.imageIOControl1.DoImgChange += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // mybarX
            // 
            this.mybarX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mybarX.Dock = System.Windows.Forms.DockStyle.Top;
            this.mybarX.Location = new System.Drawing.Point(0, 51);
            this.mybarX.Maximum = 30;
            this.mybarX.Minimum = 1;
            this.mybarX.Name = "mybarX";
            this.mybarX.Size = new System.Drawing.Size(758, 43);
            this.mybarX.TabIndex = 4;
            this.mybarX.Title = "X";
            this.mybarX.Value = 5;
            this.mybarX.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
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
            // mybarY
            // 
            this.mybarY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mybarY.Dock = System.Windows.Forms.DockStyle.Top;
            this.mybarY.Location = new System.Drawing.Point(0, 94);
            this.mybarY.Maximum = 30;
            this.mybarY.Minimum = 1;
            this.mybarY.Name = "mybarY";
            this.mybarY.Size = new System.Drawing.Size(758, 43);
            this.mybarY.TabIndex = 5;
            this.mybarY.Title = "Y";
            this.mybarY.Value = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "形态学方式";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(95, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(363, 2);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 21);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(260, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(72, 20);
            this.comboBox2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 26);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(173, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "形状";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MorphologyEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(758, 429);
            this.Controls.Add(this.panel2);
            this.Name = "MorphologyEx";
            this.Text = "膨胀腐蚀";
            this.Load += new System.EventHandler(this.MorphologyEx_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private ImageIO imageIOControl1;
        private MyTrackBar mybarX;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenImg;
        private MyTrackBar mybarY;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}