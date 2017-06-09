namespace WindowsFormsApplication1
{
    partial class OcrForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OcrForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenImg = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSelectWorkExe = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.gboxParams = new System.Windows.Forms.GroupBox();
            this.numMinHeight = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.numThreshold = new System.Windows.Forms.NumericUpDown();
            this.numCharH = new System.Windows.Forms.NumericUpDown();
            this.numCharW = new System.Windows.Forms.NumericUpDown();
            this.checkCHI = new System.Windows.Forms.CheckBox();
            this.checkOSD = new System.Windows.Forms.CheckBox();
            this.checkENG = new System.Windows.Forms.CheckBox();
            this.checkUseOEM = new System.Windows.Forms.CheckBox();
            this.numOEMType = new System.Windows.Forms.NumericUpDown();
            this.btnImgocr = new System.Windows.Forms.Button();
            this.btnDetectChar = new System.Windows.Forms.Button();
            this.imgboxImgSegment = new Emgu.CV.UI.ImageBox();
            this.imgboxDectArea = new Emgu.CV.UI.ImageBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkPsm = new System.Windows.Forms.CheckBox();
            this.numPsm = new System.Windows.Forms.NumericUpDown();
            this.gboxOcrParams = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.gboxParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCharH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCharW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOEMType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxImgSegment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxDectArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPsm)).BeginInit();
            this.gboxOcrParams.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenImg,
            this.tsbtnSelectWorkExe,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(583, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpenImg
            // 
            this.tsbtnOpenImg.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenImg.Image")));
            this.tsbtnOpenImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenImg.Name = "tsbtnOpenImg";
            this.tsbtnOpenImg.Size = new System.Drawing.Size(83, 22);
            this.tsbtnOpenImg.Text = "OpenImg";
            this.tsbtnOpenImg.Click += new System.EventHandler(this.tsbtnOpenImg_Click);
            // 
            // tsbtnSelectWorkExe
            // 
            this.tsbtnSelectWorkExe.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSelectWorkExe.Image")));
            this.tsbtnSelectWorkExe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSelectWorkExe.Name = "tsbtnSelectWorkExe";
            this.tsbtnSelectWorkExe.Size = new System.Drawing.Size(112, 22);
            this.tsbtnSelectWorkExe.Text = "SetOcrExePath";
            this.tsbtnSelectWorkExe.Click += new System.EventHandler(this.tsbtnSelectWorkExe_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(101, 22);
            this.toolStripButton1.Text = "ExportResult";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // gboxParams
            // 
            this.gboxParams.Controls.Add(this.numMinHeight);
            this.gboxParams.Controls.Add(this.label7);
            this.gboxParams.Controls.Add(this.label5);
            this.gboxParams.Controls.Add(this.label3);
            this.gboxParams.Controls.Add(this.label2);
            this.gboxParams.Controls.Add(this.btnSave);
            this.gboxParams.Controls.Add(this.numThreshold);
            this.gboxParams.Controls.Add(this.numCharH);
            this.gboxParams.Controls.Add(this.numCharW);
            this.gboxParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxParams.Location = new System.Drawing.Point(0, 0);
            this.gboxParams.Name = "gboxParams";
            this.gboxParams.Size = new System.Drawing.Size(583, 132);
            this.gboxParams.TabIndex = 1;
            this.gboxParams.TabStop = false;
            this.gboxParams.Text = "Params";
            // 
            // numMinHeight
            // 
            this.numMinHeight.Location = new System.Drawing.Point(207, 16);
            this.numMinHeight.Name = "numMinHeight";
            this.numMinHeight.Size = new System.Drawing.Size(62, 21);
            this.numMinHeight.TabIndex = 15;
            this.numMinHeight.ValueChanged += new System.EventHandler(this.numMinHeight_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "CharHeight";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "MinHeight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Threshold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "CharWidth";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(275, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numThreshold
            // 
            this.numThreshold.Location = new System.Drawing.Point(207, 50);
            this.numThreshold.Name = "numThreshold";
            this.numThreshold.Size = new System.Drawing.Size(62, 21);
            this.numThreshold.TabIndex = 2;
            this.numThreshold.ValueChanged += new System.EventHandler(this.numMinHeight_ValueChanged);
            // 
            // numCharH
            // 
            this.numCharH.Location = new System.Drawing.Point(77, 49);
            this.numCharH.Name = "numCharH";
            this.numCharH.Size = new System.Drawing.Size(59, 21);
            this.numCharH.TabIndex = 1;
            this.numCharH.ValueChanged += new System.EventHandler(this.numCharH_ValueChanged);
            // 
            // numCharW
            // 
            this.numCharW.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numCharW.Location = new System.Drawing.Point(77, 16);
            this.numCharW.Name = "numCharW";
            this.numCharW.Size = new System.Drawing.Size(59, 21);
            this.numCharW.TabIndex = 0;
            this.numCharW.ValueChanged += new System.EventHandler(this.numCharW_ValueChanged);
            // 
            // checkCHI
            // 
            this.checkCHI.AutoSize = true;
            this.checkCHI.Checked = true;
            this.checkCHI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkCHI.Location = new System.Drawing.Point(10, 67);
            this.checkCHI.Name = "checkCHI";
            this.checkCHI.Size = new System.Drawing.Size(66, 16);
            this.checkCHI.TabIndex = 19;
            this.checkCHI.Text = "chi_sim";
            this.checkCHI.UseVisualStyleBackColor = true;
            // 
            // checkOSD
            // 
            this.checkOSD.AutoSize = true;
            this.checkOSD.Location = new System.Drawing.Point(130, 67);
            this.checkOSD.Name = "checkOSD";
            this.checkOSD.Size = new System.Drawing.Size(42, 16);
            this.checkOSD.TabIndex = 18;
            this.checkOSD.Text = "osd";
            this.checkOSD.UseVisualStyleBackColor = true;
            // 
            // checkENG
            // 
            this.checkENG.AutoSize = true;
            this.checkENG.Checked = true;
            this.checkENG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkENG.Location = new System.Drawing.Point(82, 67);
            this.checkENG.Name = "checkENG";
            this.checkENG.Size = new System.Drawing.Size(42, 16);
            this.checkENG.TabIndex = 17;
            this.checkENG.Text = "eng";
            this.checkENG.UseVisualStyleBackColor = true;
            // 
            // checkUseOEM
            // 
            this.checkUseOEM.AutoSize = true;
            this.checkUseOEM.Location = new System.Drawing.Point(10, 45);
            this.checkUseOEM.Name = "checkUseOEM";
            this.checkUseOEM.Size = new System.Drawing.Size(42, 16);
            this.checkUseOEM.TabIndex = 16;
            this.checkUseOEM.Text = "OEM";
            this.checkUseOEM.UseVisualStyleBackColor = true;
            // 
            // numOEMType
            // 
            this.numOEMType.Location = new System.Drawing.Point(75, 44);
            this.numOEMType.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numOEMType.Name = "numOEMType";
            this.numOEMType.Size = new System.Drawing.Size(104, 21);
            this.numOEMType.TabIndex = 7;
            this.numOEMType.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnImgocr
            // 
            this.btnImgocr.Location = new System.Drawing.Point(10, 89);
            this.btnImgocr.Name = "btnImgocr";
            this.btnImgocr.Size = new System.Drawing.Size(75, 23);
            this.btnImgocr.TabIndex = 6;
            this.btnImgocr.Text = "ImgOcr";
            this.btnImgocr.UseVisualStyleBackColor = true;
            this.btnImgocr.Click += new System.EventHandler(this.btnImgocr_Click);
            // 
            // btnDetectChar
            // 
            this.btnDetectChar.Location = new System.Drawing.Point(90, 89);
            this.btnDetectChar.Name = "btnDetectChar";
            this.btnDetectChar.Size = new System.Drawing.Size(75, 23);
            this.btnDetectChar.TabIndex = 5;
            this.btnDetectChar.Text = "charDetect";
            this.btnDetectChar.UseVisualStyleBackColor = true;
            this.btnDetectChar.Click += new System.EventHandler(this.btnDetectChar_Click);
            // 
            // imgboxImgSegment
            // 
            this.imgboxImgSegment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgboxImgSegment.Dock = System.Windows.Forms.DockStyle.Left;
            this.imgboxImgSegment.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.PanAndZoom;
            this.imgboxImgSegment.Location = new System.Drawing.Point(0, 157);
            this.imgboxImgSegment.Name = "imgboxImgSegment";
            this.imgboxImgSegment.Size = new System.Drawing.Size(214, 217);
            this.imgboxImgSegment.TabIndex = 2;
            this.imgboxImgSegment.TabStop = false;
            // 
            // imgboxDectArea
            // 
            this.imgboxDectArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgboxDectArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgboxDectArea.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.PanAndZoom;
            this.imgboxDectArea.Location = new System.Drawing.Point(219, 157);
            this.imgboxDectArea.Name = "imgboxDectArea";
            this.imgboxDectArea.Size = new System.Drawing.Size(224, 217);
            this.imgboxDectArea.TabIndex = 2;
            this.imgboxDectArea.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(214, 157);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 217);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(440, 157);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 217);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBox1.Location = new System.Drawing.Point(443, 157);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(140, 217);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // checkPsm
            // 
            this.checkPsm.AutoSize = true;
            this.checkPsm.Location = new System.Drawing.Point(10, 19);
            this.checkPsm.Name = "checkPsm";
            this.checkPsm.Size = new System.Drawing.Size(42, 16);
            this.checkPsm.TabIndex = 20;
            this.checkPsm.Text = "PSM";
            this.checkPsm.UseVisualStyleBackColor = true;
            // 
            // numPsm
            // 
            this.numPsm.Location = new System.Drawing.Point(75, 18);
            this.numPsm.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numPsm.Name = "numPsm";
            this.numPsm.Size = new System.Drawing.Size(104, 21);
            this.numPsm.TabIndex = 21;
            this.numPsm.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            // 
            // gboxOcrParams
            // 
            this.gboxOcrParams.Controls.Add(this.checkPsm);
            this.gboxOcrParams.Controls.Add(this.checkOSD);
            this.gboxOcrParams.Controls.Add(this.checkCHI);
            this.gboxOcrParams.Controls.Add(this.checkENG);
            this.gboxOcrParams.Controls.Add(this.numPsm);
            this.gboxOcrParams.Controls.Add(this.checkUseOEM);
            this.gboxOcrParams.Controls.Add(this.btnImgocr);
            this.gboxOcrParams.Controls.Add(this.numOEMType);
            this.gboxOcrParams.Controls.Add(this.btnDetectChar);
            this.gboxOcrParams.Dock = System.Windows.Forms.DockStyle.Right;
            this.gboxOcrParams.Enabled = false;
            this.gboxOcrParams.Location = new System.Drawing.Point(405, 0);
            this.gboxOcrParams.Name = "gboxOcrParams";
            this.gboxOcrParams.Size = new System.Drawing.Size(178, 132);
            this.gboxOcrParams.TabIndex = 22;
            this.gboxOcrParams.TabStop = false;
            this.gboxOcrParams.Text = "OcrParams";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gboxOcrParams);
            this.panel1.Controls.Add(this.gboxParams);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 132);
            this.panel1.TabIndex = 23;
            // 
            // OcrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 374);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.imgboxDectArea);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.imgboxImgSegment);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "OcrForm";
            this.Text = "orctest";
            this.Load += new System.EventHandler(this.OcrForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gboxParams.ResumeLayout(false);
            this.gboxParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMinHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCharH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCharW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOEMType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxImgSegment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgboxDectArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPsm)).EndInit();
            this.gboxOcrParams.ResumeLayout(false);
            this.gboxOcrParams.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenImg;
        private System.Windows.Forms.GroupBox gboxParams;
        private System.Windows.Forms.NumericUpDown numThreshold;
        private System.Windows.Forms.NumericUpDown numCharH;
        private System.Windows.Forms.NumericUpDown numCharW;
        private Emgu.CV.UI.ImageBox imgboxImgSegment;
        private Emgu.CV.UI.ImageBox imgboxDectArea;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDetectChar;
        private System.Windows.Forms.Button btnImgocr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numOEMType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numMinHeight;
        private System.Windows.Forms.CheckBox checkUseOEM;
        private System.Windows.Forms.CheckBox checkCHI;
        private System.Windows.Forms.CheckBox checkOSD;
        private System.Windows.Forms.CheckBox checkENG;
        private System.Windows.Forms.NumericUpDown numPsm;
        private System.Windows.Forms.CheckBox checkPsm;
        private System.Windows.Forms.ToolStripButton tsbtnSelectWorkExe;
        private System.Windows.Forms.GroupBox gboxOcrParams;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

