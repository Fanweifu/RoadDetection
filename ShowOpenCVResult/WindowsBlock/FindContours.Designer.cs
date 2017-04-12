namespace ShowOpenCVResult
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
            this.button1 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.myTrackBar5 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar4 = new ShowOpenCVResult.MyTrackBar();
            this.myTrackBar3 = new ShowOpenCVResult.MyTrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.myTrackBar1 = new ShowOpenCVResult.MyTrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.myTrackBar2 = new ShowOpenCVResult.MyTrackBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenImg = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOpenModelImg = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCreatConImg = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRotateRect = new System.Windows.Forms.ToolStripButton();
            this.tsbtnWeightCentre = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFitLine = new System.Windows.Forms.ToolStripButton();
            this.tsbtnLookWhenSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
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
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.i3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.i2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.i1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
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
            this.imageIOControl1.Image1 = null;
            this.imageIOControl1.Image2 = null;
            this.imageIOControl1.Location = new System.Drawing.Point(124, 164);
            this.imageIOControl1.Name = "imageIOControl1";
            this.imageIOControl1.Size = new System.Drawing.Size(602, 198);
            this.imageIOControl1.SpOrientation = System.Windows.Forms.Orientation.Vertical;
            this.imageIOControl1.TabIndex = 1;
            this.imageIOControl1.DoImgChange += new System.EventHandler(this.imageIOControl1_DoImgChange);
            this.imageIOControl1.AfterImgLoaded += new System.EventHandler(this.imageIOControl1_AfterImgLoaded);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.myTrackBar6);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(124, 362);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 59);
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
            this.myTrackBar6.Size = new System.Drawing.Size(536, 39);
            this.myTrackBar6.TabIndex = 2;
            this.myTrackBar6.Title = "SelectValue";
            this.myTrackBar6.Value = 180;
            this.myTrackBar6.ValueChanged += new System.EventHandler(this.myTrackBar6_ValueChanged);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(3, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(121, 164);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 257);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 164);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 257);
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
            this.panel1.Size = new System.Drawing.Size(726, 139);
            this.panel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.myTrackBar5);
            this.groupBox2.Controls.Add(this.myTrackBar4);
            this.groupBox2.Controls.Add(this.myTrackBar3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(359, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 139);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ApproxPoly";
            // 
            // myTrackBar5
            // 
            this.myTrackBar5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar5.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar5.Location = new System.Drawing.Point(3, 100);
            this.myTrackBar5.Maximum = 10000;
            this.myTrackBar5.Minimum = 0;
            this.myTrackBar5.Name = "myTrackBar5";
            this.myTrackBar5.Size = new System.Drawing.Size(361, 40);
            this.myTrackBar5.TabIndex = 3;
            this.myTrackBar5.Title = "MaxPts";
            this.myTrackBar5.Value = 1000;
            this.myTrackBar5.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // myTrackBar4
            // 
            this.myTrackBar4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar4.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar4.Location = new System.Drawing.Point(3, 60);
            this.myTrackBar4.Maximum = 1000;
            this.myTrackBar4.Minimum = 0;
            this.myTrackBar4.Name = "myTrackBar4";
            this.myTrackBar4.Size = new System.Drawing.Size(361, 40);
            this.myTrackBar4.TabIndex = 2;
            this.myTrackBar4.Title = "MinPts";
            this.myTrackBar4.Value = 100;
            this.myTrackBar4.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // myTrackBar3
            // 
            this.myTrackBar3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar3.Dock = System.Windows.Forms.DockStyle.Top;
            this.myTrackBar3.Location = new System.Drawing.Point(3, 17);
            this.myTrackBar3.Maximum = 1000;
            this.myTrackBar3.Minimum = 0;
            this.myTrackBar3.Name = "myTrackBar3";
            this.myTrackBar3.Size = new System.Drawing.Size(361, 43);
            this.myTrackBar3.TabIndex = 1;
            this.myTrackBar3.Title = "epsilon";
            this.myTrackBar3.Value = 100;
            this.myTrackBar3.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myTrackBar1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.myTrackBar2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 139);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Canny";
            // 
            // myTrackBar1
            // 
            this.myTrackBar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myTrackBar1.Location = new System.Drawing.Point(3, 50);
            this.myTrackBar1.Maximum = 300;
            this.myTrackBar1.Minimum = 0;
            this.myTrackBar1.Name = "myTrackBar1";
            this.myTrackBar1.Size = new System.Drawing.Size(353, 43);
            this.myTrackBar1.TabIndex = 0;
            this.myTrackBar1.Title = "threshold1";
            this.myTrackBar1.Value = 120;
            this.myTrackBar1.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox1.Location = new System.Drawing.Point(3, 17);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(353, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "use Canny";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // myTrackBar2
            // 
            this.myTrackBar2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTrackBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myTrackBar2.Location = new System.Drawing.Point(3, 93);
            this.myTrackBar2.Maximum = 300;
            this.myTrackBar2.Minimum = 0;
            this.myTrackBar2.Name = "myTrackBar2";
            this.myTrackBar2.Size = new System.Drawing.Size(353, 43);
            this.myTrackBar2.TabIndex = 1;
            this.myTrackBar2.Title = "threshold2";
            this.myTrackBar2.Value = 180;
            this.myTrackBar2.ValueChanged += new System.EventHandler(this.myTrackBar1_ValueChanged);
            this.myTrackBar2.Load += new System.EventHandler(this.myTrackBar2_Load);
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
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(726, 25);
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
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton1.Text = "计算分类结果";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
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
            this.tslblFm,
            this.toolStripStatusLabel3,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 421);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(726, 23);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(68, 18);
            this.toolStripStatusLabel5.Text = "矩形旋转角";
            // 
            // tsslblRectAngle
            // 
            this.tsslblRectAngle.Name = "tsslblRectAngle";
            this.tsslblRectAngle.Size = new System.Drawing.Size(25, 18);
            this.tsslblRectAngle.Text = "0.0";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(32, 18);
            this.toolStripStatusLabel7.Text = "长宽";
            // 
            // tsslblRectSize
            // 
            this.tsslblRectSize.Name = "tsslblRectSize";
            this.tsslblRectSize.Size = new System.Drawing.Size(25, 18);
            this.tsslblRectSize.Text = "0,0";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(234, 18);
            this.toolStripStatusLabel4.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(68, 18);
            this.toolStripStatusLabel2.Text = "模板路径：";
            // 
            // tslblModeFilePath
            // 
            this.tslblModeFilePath.Name = "tslblModeFilePath";
            this.tslblModeFilePath.Size = new System.Drawing.Size(47, 18);
            this.tslblModeFilePath.Text = "NULL  ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 18);
            this.toolStripStatusLabel1.Text = "不相似度：";
            // 
            // tslblFm
            // 
            this.tslblFm.Name = "tslblFm";
            this.tslblFm.Size = new System.Drawing.Size(25, 18);
            this.tslblFm.Text = "1.0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 18);
            this.toolStripStatusLabel3.Text = "匹配方式：";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.i3ToolStripMenuItem,
            this.i2ToolStripMenuItem,
            this.i1ToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(51, 21);
            this.toolStripSplitButton1.Text = "I1";
            // 
            // i3ToolStripMenuItem
            // 
            this.i3ToolStripMenuItem.Name = "i3ToolStripMenuItem";
            this.i3ToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.i3ToolStripMenuItem.Text = "I3";
            this.i3ToolStripMenuItem.Click += new System.EventHandler(this.i3ToolStripMenuItem_Click);
            // 
            // i2ToolStripMenuItem
            // 
            this.i2ToolStripMenuItem.Name = "i2ToolStripMenuItem";
            this.i2ToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.i2ToolStripMenuItem.Text = "I2";
            this.i2ToolStripMenuItem.Click += new System.EventHandler(this.i2ToolStripMenuItem_Click);
            // 
            // i1ToolStripMenuItem
            // 
            this.i1ToolStripMenuItem.Name = "i1ToolStripMenuItem";
            this.i1ToolStripMenuItem.Size = new System.Drawing.Size(87, 22);
            this.i1ToolStripMenuItem.Text = "I1";
            this.i1ToolStripMenuItem.Click += new System.EventHandler(this.i1ToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(88, 21);
            this.toolStripButton2.Text = "人行道检测";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click_1);
            // 
            // BitmapFindCon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 444);
            this.Controls.Add(this.imageIOControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "BitmapFindCon";
            this.Text = "BitmapFindCon";
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private MyTrackBar myTrackBar1;
        private MyTrackBar myTrackBar2;
        private MyTrackBar myTrackBar3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Splitter splitter1;
        private MyTrackBar myTrackBar5;
        private MyTrackBar myTrackBar4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenModelImg;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblModeFilePath;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tslblFm;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem i3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem i2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem i1ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private MyTrackBar myTrackBar6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tsslblRectAngle;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
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
    }
}