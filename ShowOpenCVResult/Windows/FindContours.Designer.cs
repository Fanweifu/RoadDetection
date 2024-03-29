﻿namespace ShowOpenCVResult.Windows
{
    partial class FindContours
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindContours));
            this.imageIOControl1 = new ShowOpenCVResult.ImageIO();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.myTrackBar6 = new ShowOpenCVResult.MyTrackBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.maxAreabar = new ShowOpenCVResult.MyTrackBar();
            this.minAreabar = new ShowOpenCVResult.MyTrackBar();
            this.epsilonbar = new ShowOpenCVResult.MyTrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxAreaToLenght = new ShowOpenCVResult.MyTrackBar();
            this.minAreaRatebar = new ShowOpenCVResult.MyTrackBar();
            this.maxLengthbar = new ShowOpenCVResult.MyTrackBar();
            this.minLengthBar = new ShowOpenCVResult.MyTrackBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenImg = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOpenModelImg = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCreatConImg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRotateRect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnWeightCentre = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFitLine = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLookWhenSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblRectAngle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblRectSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblModeFilePath = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslblFm = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageIOControl1
            // 
            this.imageIOControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageIOControl1.InImage = null;
            this.imageIOControl1.OutImage = null;
            this.imageIOControl1.Location = new System.Drawing.Point(124, 202);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.Size = new System.Drawing.Size(807, 161);
            this.imageIOControl1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIOControl1.TabIndex = 1;
            this.imageIOControl1.DoImgChange += new System.EventHandler(this.imageIOControl1_DoImgChange);
            this.imageIOControl1.AfterImgLoaded += new System.EventHandler(this.imageIOControl1_AfterImgLoaded);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.myTrackBar6);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(124, 363);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(807, 59);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // myTrackBar6
            // 
            this.myTrackBar6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTrackBar6.Enabled = false;
            this.myTrackBar6.Location = new System.Drawing.Point(63, 17);
            this.myTrackBar6.Maximum = 3000;
            this.myTrackBar6.Minimum = 0;
            this.myTrackBar6.Name = "myTrackBar6";
            this.myTrackBar6.Size = new System.Drawing.Size(741, 39);
            this.myTrackBar6.TabIndex = 2;
            this.myTrackBar6.Title = "SelectValue";
            this.myTrackBar6.Value = 180;
            this.myTrackBar6.ValueChanged += new System.EventHandler(this.myTrackBar6_ValueChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(60, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 19);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(121, 202);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 220);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 202);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 220);
            this.treeView1.TabIndex = 4;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(931, 177);
            this.panel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.maxAreabar);
            this.groupBox2.Controls.Add(this.minAreabar);
            this.groupBox2.Controls.Add(this.epsilonbar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(359, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(572, 177);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ApproxPoly";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 137);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // maxAreabar
            // 
            this.maxAreabar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxAreabar.Dock = System.Windows.Forms.DockStyle.Top;
            this.maxAreabar.Location = new System.Drawing.Point(3, 91);
            this.maxAreabar.Maximum = 10000;
            this.maxAreabar.Minimum = 0;
            this.maxAreabar.Name = "maxAreabar";
            this.maxAreabar.Size = new System.Drawing.Size(566, 36);
            this.maxAreabar.TabIndex = 3;
            this.maxAreabar.Title = "MaxArea";
            this.maxAreabar.Value = 1000;
            this.maxAreabar.ValueChanged += new System.EventHandler(this.myTrackBar5_ValueChanged);
            // 
            // minAreabar
            // 
            this.minAreabar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minAreabar.Dock = System.Windows.Forms.DockStyle.Top;
            this.minAreabar.Location = new System.Drawing.Point(3, 54);
            this.minAreabar.Maximum = 1000;
            this.minAreabar.Minimum = 0;
            this.minAreabar.Name = "minAreabar";
            this.minAreabar.Size = new System.Drawing.Size(566, 37);
            this.minAreabar.TabIndex = 2;
            this.minAreabar.Title = "MinArea";
            this.minAreabar.Value = 10;
            this.minAreabar.ValueChanged += new System.EventHandler(this.myTrackBar5_ValueChanged);
            // 
            // epsilonbar
            // 
            this.epsilonbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.epsilonbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.epsilonbar.Location = new System.Drawing.Point(3, 17);
            this.epsilonbar.Maximum = 1000;
            this.epsilonbar.Minimum = 0;
            this.epsilonbar.Name = "epsilonbar";
            this.epsilonbar.Size = new System.Drawing.Size(566, 37);
            this.epsilonbar.TabIndex = 1;
            this.epsilonbar.Title = "epsilon";
            this.epsilonbar.Value = 100;
            this.epsilonbar.ValueChanged += new System.EventHandler(this.myTrackBarEpsilon_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxAreaToLenght);
            this.groupBox1.Controls.Add(this.minAreaRatebar);
            this.groupBox1.Controls.Add(this.maxLengthbar);
            this.groupBox1.Controls.Add(this.minLengthBar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 177);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Boundary Selection";
            // 
            // maxAreaToLenght
            // 
            this.maxAreaToLenght.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxAreaToLenght.Dock = System.Windows.Forms.DockStyle.Top;
            this.maxAreaToLenght.Location = new System.Drawing.Point(3, 130);
            this.maxAreaToLenght.Maximum = 1000;
            this.maxAreaToLenght.Minimum = 0;
            this.maxAreaToLenght.Name = "maxAreaToLenght";
            this.maxAreaToLenght.Size = new System.Drawing.Size(353, 46);
            this.maxAreaToLenght.TabIndex = 5;
            this.maxAreaToLenght.Title = "MaxAreaToLength";
            this.maxAreaToLenght.Value = 100;
            this.maxAreaToLenght.ValueChanged += new System.EventHandler(this.myTrackBar5_ValueChanged);
            // 
            // minAreaRatebar
            // 
            this.minAreaRatebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minAreaRatebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.minAreaRatebar.Location = new System.Drawing.Point(3, 91);
            this.minAreaRatebar.Maximum = 100;
            this.minAreaRatebar.Minimum = 0;
            this.minAreaRatebar.Name = "minAreaRatebar";
            this.minAreaRatebar.Size = new System.Drawing.Size(353, 39);
            this.minAreaRatebar.TabIndex = 4;
            this.minAreaRatebar.Title = "minAreaRate";
            this.minAreaRatebar.Value = 50;
            this.minAreaRatebar.ValueChanged += new System.EventHandler(this.myTrackBar5_ValueChanged);
            // 
            // maxLengthbar
            // 
            this.maxLengthbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maxLengthbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.maxLengthbar.Location = new System.Drawing.Point(3, 54);
            this.maxLengthbar.Maximum = 1000;
            this.maxLengthbar.Minimum = 0;
            this.maxLengthbar.Name = "maxLengthbar";
            this.maxLengthbar.Size = new System.Drawing.Size(353, 37);
            this.maxLengthbar.TabIndex = 3;
            this.maxLengthbar.Title = "MaxLength";
            this.maxLengthbar.Value = 1000;
            this.maxLengthbar.ValueChanged += new System.EventHandler(this.myTrackBar5_ValueChanged);
            // 
            // minLengthBar
            // 
            this.minLengthBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minLengthBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.minLengthBar.Location = new System.Drawing.Point(3, 17);
            this.minLengthBar.Maximum = 1000;
            this.minLengthBar.Minimum = 0;
            this.minLengthBar.Name = "minLengthBar";
            this.minLengthBar.Size = new System.Drawing.Size(353, 37);
            this.minLengthBar.TabIndex = 2;
            this.minLengthBar.Title = "MinLength";
            this.minLengthBar.Value = 10;
            this.minLengthBar.ValueChanged += new System.EventHandler(this.myTrackBar5_ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenImg,
            this.tsbtnOpenModelImg,
            this.tsbtnCreatConImg,
            this.toolStripSeparator1,
            this.tsbtnRotateRect,
            this.tsbtnWeightCentre,
            this.tsbtnFitLine,
            this.tsbtnLookWhenSelect,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(931, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpenImg
            // 
            this.tsbtnOpenImg.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenImg.Image")));
            this.tsbtnOpenImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenImg.Name = "tsbtnOpenImg";
            this.tsbtnOpenImg.Size = new System.Drawing.Size(52, 22);
            this.tsbtnOpenImg.Text = "打开";
            this.tsbtnOpenImg.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbtnOpenModelImg
            // 
            this.tsbtnOpenModelImg.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenModelImg.Image")));
            this.tsbtnOpenModelImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenModelImg.Name = "tsbtnOpenModelImg";
            this.tsbtnOpenModelImg.Size = new System.Drawing.Size(88, 22);
            this.tsbtnOpenModelImg.Text = "加载模板图";
            this.tsbtnOpenModelImg.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tsbtnCreatConImg
            // 
            this.tsbtnCreatConImg.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCreatConImg.Image")));
            this.tsbtnCreatConImg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCreatConImg.Name = "tsbtnCreatConImg";
            this.tsbtnCreatConImg.Size = new System.Drawing.Size(88, 22);
            this.tsbtnCreatConImg.Text = "生成轮廓图";
            this.tsbtnCreatConImg.ToolTipText = "生成轮廓图";
            this.tsbtnCreatConImg.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnRotateRect
            // 
            this.tsbtnRotateRect.Checked = true;
            this.tsbtnRotateRect.CheckOnClick = true;
            this.tsbtnRotateRect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbtnRotateRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnRotateRect.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRotateRect.Image")));
            this.tsbtnRotateRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRotateRect.Name = "tsbtnRotateRect";
            this.tsbtnRotateRect.Size = new System.Drawing.Size(75, 22);
            this.tsbtnRotateRect.Text = "RotateRect";
            // 
            // tsbtnWeightCentre
            // 
            this.tsbtnWeightCentre.CheckOnClick = true;
            this.tsbtnWeightCentre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnWeightCentre.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnWeightCentre.Image")));
            this.tsbtnWeightCentre.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnWeightCentre.Name = "tsbtnWeightCentre";
            this.tsbtnWeightCentre.Size = new System.Drawing.Size(91, 22);
            this.tsbtnWeightCentre.Text = "WeightCentre";
            // 
            // tsbtnFitLine
            // 
            this.tsbtnFitLine.CheckOnClick = true;
            this.tsbtnFitLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnFitLine.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFitLine.Image")));
            this.tsbtnFitLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFitLine.Name = "tsbtnFitLine";
            this.tsbtnFitLine.Size = new System.Drawing.Size(77, 22);
            this.tsbtnFitLine.Text = "tsbtnFitLine";
            // 
            // tsbtnLookWhenSelect
            // 
            this.tsbtnLookWhenSelect.CheckOnClick = true;
            this.tsbtnLookWhenSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbtnLookWhenSelect.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLookWhenSelect.Image")));
            this.tsbtnLookWhenSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLookWhenSelect.Name = "tsbtnLookWhenSelect";
            this.tsbtnLookWhenSelect.Size = new System.Drawing.Size(52, 22);
            this.tsbtnLookWhenSelect.Text = "Review";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton1.Text = "计算分类结果";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(88, 22);
            this.toolStripButton2.Text = "人行道检测";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton3.Text = "加载训练文件";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click_1);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(75, 22);
            this.toolStripButton4.Text = "显示svm";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel5,
            this.tsslblRectAngle,
            this.toolStripStatusLabel7,
            this.tsslblRectSize,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel2,
            this.tslblModeFilePath,
            this.toolStripStatusLabel1,
            this.tslblFm});
            this.statusStrip1.Location = new System.Drawing.Point(0, 422);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(931, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel5.Text = "矩形旋转角";
            // 
            // tsslblRectAngle
            // 
            this.tsslblRectAngle.Name = "tsslblRectAngle";
            this.tsslblRectAngle.Size = new System.Drawing.Size(25, 17);
            this.tsslblRectAngle.Text = "0.0";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel7.Text = "长宽";
            // 
            // tsslblRectSize
            // 
            this.tsslblRectSize.Name = "tsslblRectSize";
            this.tsslblRectSize.Size = new System.Drawing.Size(25, 17);
            this.tsslblRectSize.Text = "0,0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(558, 17);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel2.Text = "模板路径：";
            // 
            // tslblModeFilePath
            // 
            this.tslblModeFilePath.Name = "tslblModeFilePath";
            this.tslblModeFilePath.Size = new System.Drawing.Size(47, 17);
            this.tslblModeFilePath.Text = "NULL  ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "不相似度：";
            // 
            // tslblFm
            // 
            this.tslblFm.Name = "tslblFm";
            this.tslblFm.Size = new System.Drawing.Size(25, 17);
            this.tslblFm.Text = "1.0";
            // 
            // FindContours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 444);
            this.Controls.Add(this.imageIOControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FindContours";
            this.Text = "FindContours";
            this.Load += new System.EventHandler(this.FindContours_Load);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
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
        private ImageIO imageIOControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MyTrackBar epsilonbar;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Splitter splitter1;
        private MyTrackBar maxAreabar;
        private MyTrackBar minAreabar;
        private System.Windows.Forms.ToolStripButton tsbtnOpenModelImg;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblModeFilePath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tslblFm;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private MyTrackBar myTrackBar6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tsslblRectAngle;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel tsslblRectSize;
        private System.Windows.Forms.ToolStripButton tsbtnCreatConImg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnLookWhenSelect;
        private System.Windows.Forms.ToolStripButton tsbtnRotateRect;
        private System.Windows.Forms.ToolStripButton tsbtnWeightCentre;
        private System.Windows.Forms.ToolStripButton tsbtnFitLine;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ComboBox comboBox1;
        private MyTrackBar minAreaRatebar;
        private MyTrackBar maxLengthbar;
        private MyTrackBar minLengthBar;
        private MyTrackBar maxAreaToLenght;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
    }
}