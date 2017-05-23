namespace ShowOpenCVResult
{
    partial class WarpPerspective
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarpPerspective));
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbOH = new System.Windows.Forms.Label();
            this.lbLT = new System.Windows.Forms.Label();
            this.lbOW = new System.Windows.Forms.Label();
            this.lbAY = new System.Windows.Forms.Label();
            this.lbAX = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudOH = new System.Windows.Forms.NumericUpDown();
            this.nudOW = new System.Windows.Forms.NumericUpDown();
            this.nudAY = new System.Windows.Forms.NumericUpDown();
            this.nudAX = new System.Windows.Forms.NumericUpDown();
            this.nudLT = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenImg = new System.Windows.Forms.ToolStripButton();
            this.tsbtnMultyDeal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLT)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoScrollMinSize = new System.Drawing.Size(640, 440);
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.imageIOControl1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(672, 440);
            this.panel2.TabIndex = 7;
            // 
            // imageIOControl1
            // 
            this.imageIOControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIOControl1.InImage = null;
            this.imageIOControl1.OutImage = null;
            this.imageIOControl1.Location = new System.Drawing.Point(0, 109);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.Size = new System.Drawing.Size(672, 331);
            this.imageIOControl1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIOControl1.TabIndex = 6;
            this.imageIOControl1.DoImgChange += new System.EventHandler(this.imageIOControl1_DoImgChange);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(672, 109);
            this.panel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.lbOH);
            this.groupBox2.Controls.Add(this.lbLT);
            this.groupBox2.Controls.Add(this.lbOW);
            this.groupBox2.Controls.Add(this.lbAY);
            this.groupBox2.Controls.Add(this.lbAX);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(458, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 109);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "保存参数";
            // 
            // lbOH
            // 
            this.lbOH.AutoSize = true;
            this.lbOH.Location = new System.Drawing.Point(125, 51);
            this.lbOH.Name = "lbOH";
            this.lbOH.Size = new System.Drawing.Size(83, 12);
            this.lbOH.TabIndex = 13;
            this.lbOH.Text = "output-Height";
            // 
            // lbLT
            // 
            this.lbLT.AutoSize = true;
            this.lbLT.Location = new System.Drawing.Point(6, 76);
            this.lbLT.Name = "lbLT";
            this.lbLT.Size = new System.Drawing.Size(17, 12);
            this.lbLT.TabIndex = 14;
            this.lbLT.Text = "LT";
            // 
            // lbOW
            // 
            this.lbOW.AutoSize = true;
            this.lbOW.Location = new System.Drawing.Point(6, 49);
            this.lbOW.Name = "lbOW";
            this.lbOW.Size = new System.Drawing.Size(77, 12);
            this.lbOW.TabIndex = 11;
            this.lbOW.Text = "output-Width";
            // 
            // lbAY
            // 
            this.lbAY.AutoSize = true;
            this.lbAY.Location = new System.Drawing.Point(125, 24);
            this.lbAY.Name = "lbAY";
            this.lbAY.Size = new System.Drawing.Size(53, 12);
            this.lbAY.TabIndex = 10;
            this.lbAY.Text = "anchor-Y";
            // 
            // lbAX
            // 
            this.lbAX.AutoSize = true;
            this.lbAX.Location = new System.Drawing.Point(6, 24);
            this.lbAX.Name = "lbAX";
            this.lbAX.Size = new System.Drawing.Size(53, 12);
            this.lbAX.TabIndex = 9;
            this.lbAX.Text = "anchor-X";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btnSaveData);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudOH);
            this.groupBox1.Controls.Add(this.nudOW);
            this.groupBox1.Controls.Add(this.nudAY);
            this.groupBox1.Controls.Add(this.nudAX);
            this.groupBox1.Controls.Add(this.nudLT);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(672, 109);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "调试参数";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(316, 73);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(63, 20);
            this.comboBox3.TabIndex = 15;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(247, 73);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(63, 20);
            this.comboBox2.TabIndex = 14;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(178, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(63, 20);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnSaveData
            // 
            this.btnSaveData.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSaveData.Location = new System.Drawing.Point(382, 20);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(70, 23);
            this.btnSaveData.TabIndex = 12;
            this.btnSaveData.Text = "Save";
            this.btnSaveData.UseVisualStyleBackColor = false;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "output-Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "output-Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "anchor-Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "anchor-X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "LT";
            // 
            // nudOH
            // 
            this.nudOH.Location = new System.Drawing.Point(265, 46);
            this.nudOH.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudOH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOH.Name = "nudOH";
            this.nudOH.Size = new System.Drawing.Size(70, 21);
            this.nudOH.TabIndex = 7;
            this.nudOH.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudOH.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // nudOW
            // 
            this.nudOW.Location = new System.Drawing.Point(89, 47);
            this.nudOW.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudOW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudOW.Name = "nudOW";
            this.nudOW.Size = new System.Drawing.Size(70, 21);
            this.nudOW.TabIndex = 6;
            this.nudOW.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.nudOW.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // nudAY
            // 
            this.nudAY.Location = new System.Drawing.Point(265, 22);
            this.nudAY.Name = "nudAY";
            this.nudAY.Size = new System.Drawing.Size(70, 21);
            this.nudAY.TabIndex = 5;
            this.nudAY.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudAY.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // nudAX
            // 
            this.nudAX.Location = new System.Drawing.Point(89, 20);
            this.nudAX.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudAX.Name = "nudAX";
            this.nudAX.Size = new System.Drawing.Size(70, 21);
            this.nudAX.TabIndex = 4;
            this.nudAX.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudAX.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // nudLT
            // 
            this.nudLT.Location = new System.Drawing.Point(89, 74);
            this.nudLT.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudLT.Name = "nudLT";
            this.nudLT.Size = new System.Drawing.Size(70, 21);
            this.nudLT.TabIndex = 2;
            this.nudLT.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudLT.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenImg,
            this.tsbtnMultyDeal,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(672, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpenImg
            // 
            this.tsbtnOpenImg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpenImg.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenImg.Image")));
            this.tsbtnOpenImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenImg.Name = "tsbtnOpenImg";
            this.tsbtnOpenImg.Size = new System.Drawing.Size(23, 22);
            this.tsbtnOpenImg.Text = "打开图片";
            this.tsbtnOpenImg.Click += new System.EventHandler(this.tsbtnOpenImg_Click);
            // 
            // tsbtnMultyDeal
            // 
            this.tsbtnMultyDeal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnMultyDeal.Enabled = false;
            this.tsbtnMultyDeal.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnMultyDeal.Image")));
            this.tsbtnMultyDeal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnMultyDeal.Name = "tsbtnMultyDeal";
            this.tsbtnMultyDeal.Size = new System.Drawing.Size(23, 22);
            this.tsbtnMultyDeal.Text = "批量处理";
            this.tsbtnMultyDeal.Click += new System.EventHandler(this.tsbtnMultyDeal_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(672, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
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
            // WarpPerspective
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 487);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "WarpPerspective";
            this.Text = "投影转换";
            this.Load += new System.EventHandler(this.BitmapTransformation_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLT)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenImg;
        private System.Windows.Forms.ToolStripButton tsbtnMultyDeal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudOW;
        private System.Windows.Forms.NumericUpDown nudAY;
        private System.Windows.Forms.NumericUpDown nudAX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudLT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudOH;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Label lbLT;
        private System.Windows.Forms.Label lbOH;
        private System.Windows.Forms.Label lbOW;
        private System.Windows.Forms.Label lbAY;
        private System.Windows.Forms.Label lbAX;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private ImageIO imageIOControl1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}