namespace ShowOpenCVResult
{
    partial class OpencvForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin5 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin5 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient13 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient29 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin5 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient5 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient30 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient14 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient31 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient5 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient32 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient33 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient15 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient34 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient35 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.msMenus = new System.Windows.Forms.MenuStrip();
            this.预处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.滤波ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.局部阈值ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.直方图ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.逆转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.膨胀腐蚀ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.颜色阈值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.特征提取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.边缘检测ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.直线检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同物体追踪ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标线流程测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.识别分类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.特征点检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.svm训练ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像拼接ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenus.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenus
            // 
            this.msMenus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.预处理ToolStripMenuItem,
            this.特征提取ToolStripMenuItem,
            this.myTestToolStripMenuItem,
            this.识别分类ToolStripMenuItem,
            this.其他ToolStripMenuItem});
            this.msMenus.Location = new System.Drawing.Point(0, 0);
            this.msMenus.Name = "msMenus";
            this.msMenus.Size = new System.Drawing.Size(1184, 25);
            this.msMenus.TabIndex = 0;
            this.msMenus.Text = "menuStrip1";
            // 
            // 预处理ToolStripMenuItem
            // 
            this.预处理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.滤波ToolStripMenuItem,
            this.局部阈值ToolStripMenuItem1,
            this.直方图ToolStripMenuItem1,
            this.逆转换ToolStripMenuItem,
            this.膨胀腐蚀ToolStripMenuItem,
            this.颜色阈值ToolStripMenuItem});
            this.预处理ToolStripMenuItem.Name = "预处理ToolStripMenuItem";
            this.预处理ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.预处理ToolStripMenuItem.Text = "预处理";
            // 
            // 滤波ToolStripMenuItem
            // 
            this.滤波ToolStripMenuItem.Name = "滤波ToolStripMenuItem";
            this.滤波ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.滤波ToolStripMenuItem.Text = "滤波";
            this.滤波ToolStripMenuItem.Click += new System.EventHandler(this.滤波ToolStripMenuItem_Click);
            // 
            // 局部阈值ToolStripMenuItem1
            // 
            this.局部阈值ToolStripMenuItem1.Name = "局部阈值ToolStripMenuItem1";
            this.局部阈值ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.局部阈值ToolStripMenuItem1.Text = "局部阈值";
            this.局部阈值ToolStripMenuItem1.Click += new System.EventHandler(this.局部阈值ToolStripMenuItem1_Click);
            // 
            // 直方图ToolStripMenuItem1
            // 
            this.直方图ToolStripMenuItem1.Name = "直方图ToolStripMenuItem1";
            this.直方图ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.直方图ToolStripMenuItem1.Text = "直方图";
            this.直方图ToolStripMenuItem1.Click += new System.EventHandler(this.直方图ToolStripMenuItem1_Click);
            // 
            // 逆转换ToolStripMenuItem
            // 
            this.逆转换ToolStripMenuItem.Name = "逆转换ToolStripMenuItem";
            this.逆转换ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.逆转换ToolStripMenuItem.Text = "逆转换";
            this.逆转换ToolStripMenuItem.Click += new System.EventHandler(this.逆转换ToolStripMenuItem_Click);
            // 
            // 膨胀腐蚀ToolStripMenuItem
            // 
            this.膨胀腐蚀ToolStripMenuItem.Name = "膨胀腐蚀ToolStripMenuItem";
            this.膨胀腐蚀ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.膨胀腐蚀ToolStripMenuItem.Text = "膨胀腐蚀";
            this.膨胀腐蚀ToolStripMenuItem.Click += new System.EventHandler(this.膨胀腐蚀ToolStripMenuItem_Click);
            // 
            // 颜色阈值ToolStripMenuItem
            // 
            this.颜色阈值ToolStripMenuItem.Name = "颜色阈值ToolStripMenuItem";
            this.颜色阈值ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.颜色阈值ToolStripMenuItem.Text = "颜色阈值";
            this.颜色阈值ToolStripMenuItem.Click += new System.EventHandler(this.颜色阈值ToolStripMenuItem_Click);
            // 
            // 特征提取ToolStripMenuItem
            // 
            this.特征提取ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.边缘检测ToolStripMenuItem1,
            this.直线检测ToolStripMenuItem});
            this.特征提取ToolStripMenuItem.Name = "特征提取ToolStripMenuItem";
            this.特征提取ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.特征提取ToolStripMenuItem.Text = "特征提取";
            // 
            // 边缘检测ToolStripMenuItem1
            // 
            this.边缘检测ToolStripMenuItem1.Name = "边缘检测ToolStripMenuItem1";
            this.边缘检测ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.边缘检测ToolStripMenuItem1.Text = "边缘检测";
            this.边缘检测ToolStripMenuItem1.Click += new System.EventHandler(this.边缘检测ToolStripMenuItem1_Click);
            // 
            // 直线检测ToolStripMenuItem
            // 
            this.直线检测ToolStripMenuItem.Name = "直线检测ToolStripMenuItem";
            this.直线检测ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.直线检测ToolStripMenuItem.Text = "直线检测";
            this.直线检测ToolStripMenuItem.Click += new System.EventHandler(this.直线检测ToolStripMenuItem_Click);
            // 
            // myTestToolStripMenuItem
            // 
            this.myTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.同物体追踪ToolStripMenuItem,
            this.标线流程测试ToolStripMenuItem});
            this.myTestToolStripMenuItem.Name = "myTestToolStripMenuItem";
            this.myTestToolStripMenuItem.Size = new System.Drawing.Size(62, 21);
            this.myTestToolStripMenuItem.Text = "MyTest";
            // 
            // 同物体追踪ToolStripMenuItem
            // 
            this.同物体追踪ToolStripMenuItem.Name = "同物体追踪ToolStripMenuItem";
            this.同物体追踪ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.同物体追踪ToolStripMenuItem.Text = "同物体追踪";
            this.同物体追踪ToolStripMenuItem.Click += new System.EventHandler(this.同物体追踪ToolStripMenuItem_Click);
            // 
            // 标线流程测试ToolStripMenuItem
            // 
            this.标线流程测试ToolStripMenuItem.Name = "标线流程测试ToolStripMenuItem";
            this.标线流程测试ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.标线流程测试ToolStripMenuItem.Text = "标线流程测试";
            this.标线流程测试ToolStripMenuItem.Click += new System.EventHandler(this.标线流程测试ToolStripMenuItem_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.AutoSize = true;
            this.dockPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.Control;
            this.dockPanel1.Location = new System.Drawing.Point(0, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(1184, 736);
            dockPanelGradient13.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient13.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin5.DockStripGradient = dockPanelGradient13;
            tabGradient29.EndColor = System.Drawing.SystemColors.Control;
            tabGradient29.StartColor = System.Drawing.SystemColors.Control;
            tabGradient29.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin5.TabGradient = tabGradient29;
            dockPanelSkin5.AutoHideStripSkin = autoHideStripSkin5;
            tabGradient30.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient30.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient30.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient5.ActiveTabGradient = tabGradient30;
            dockPanelGradient14.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient14.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient5.DockStripGradient = dockPanelGradient14;
            tabGradient31.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient31.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient31.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient5.InactiveTabGradient = tabGradient31;
            dockPaneStripSkin5.DocumentGradient = dockPaneStripGradient5;
            tabGradient32.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient32.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient32.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient32.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient5.ActiveCaptionGradient = tabGradient32;
            tabGradient33.EndColor = System.Drawing.SystemColors.Control;
            tabGradient33.StartColor = System.Drawing.SystemColors.Control;
            tabGradient33.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient5.ActiveTabGradient = tabGradient33;
            dockPanelGradient15.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient15.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient5.DockStripGradient = dockPanelGradient15;
            tabGradient34.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient34.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient34.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient34.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient5.InactiveCaptionGradient = tabGradient34;
            tabGradient35.EndColor = System.Drawing.Color.Transparent;
            tabGradient35.StartColor = System.Drawing.Color.Transparent;
            tabGradient35.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient5.InactiveTabGradient = tabGradient35;
            dockPaneStripSkin5.ToolWindowGradient = dockPaneStripToolWindowGradient5;
            dockPanelSkin5.DockPaneStripSkin = dockPaneStripSkin5;
            this.dockPanel1.Skin = dockPanelSkin5;
            this.dockPanel1.TabIndex = 3;
            // 
            // 识别分类ToolStripMenuItem
            // 
            this.识别分类ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.特征点检测ToolStripMenuItem,
            this.svm训练ToolStripMenuItem});
            this.识别分类ToolStripMenuItem.Name = "识别分类ToolStripMenuItem";
            this.识别分类ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.识别分类ToolStripMenuItem.Text = "识别分类";
            // 
            // 特征点检测ToolStripMenuItem
            // 
            this.特征点检测ToolStripMenuItem.Name = "特征点检测ToolStripMenuItem";
            this.特征点检测ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.特征点检测ToolStripMenuItem.Text = "特征点检测";
            this.特征点检测ToolStripMenuItem.Click += new System.EventHandler(this.特征点检测ToolStripMenuItem_Click);
            // 
            // svm训练ToolStripMenuItem
            // 
            this.svm训练ToolStripMenuItem.Name = "svm训练ToolStripMenuItem";
            this.svm训练ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.svm训练ToolStripMenuItem.Text = "svm训练";
            this.svm训练ToolStripMenuItem.Click += new System.EventHandler(this.svm训练ToolStripMenuItem_Click);
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图像拼接ToolStripMenuItem1});
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.其他ToolStripMenuItem.Text = "其他";
            // 
            // 图像拼接ToolStripMenuItem1
            // 
            this.图像拼接ToolStripMenuItem1.Name = "图像拼接ToolStripMenuItem1";
            this.图像拼接ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.图像拼接ToolStripMenuItem1.Text = "图像拼接";
            this.图像拼接ToolStripMenuItem1.Click += new System.EventHandler(this.图像拼接ToolStripMenuItem1_Click);
            // 
            // OpencvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.msMenus);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMenus;
            this.Name = "OpencvForm";
            this.Text = "opencv in .net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.msMenus.ResumeLayout(false);
            this.msMenus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenus;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem 预处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 滤波ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 局部阈值ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 直方图ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 逆转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 膨胀腐蚀ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 特征提取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 边缘检测ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 直线检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同物体追踪ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标线流程测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 颜色阈值ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 识别分类ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 特征点检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem svm训练ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其他ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像拼接ToolStripMenuItem1;
    }
}

