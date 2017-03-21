using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
namespace ShowOpenCVResult
{
    public partial class OpencvForm : Form
    {
        private string m_DockPath = string.Empty;


        public OpencvForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dockPanel1.DocumentStyle = DocumentStyle.DockingMdi;
            this.m_DockPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");

                
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                dockPanel1.SaveAsXml(this.m_DockPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存Dockpanel配置文件失败，" + ex.Message);
                return;
            }
        }

        private void tsmiAnchor_Click(object sender, EventArgs e)
        {
            new BitmapTransformation().Show(this.dockPanel1, DockState.Document);
        }


        static public string SelectImg()
        {
            using (OpenFileDialog od = new OpenFileDialog())
            {
                od.Title = "打开图片";
                od.Filter = "IMG|*.jpg;*.png;*.bmp;*.jpeg";
                if (od.ShowDialog() != System.Windows.Forms.DialogResult.OK) return null;
                return od.FileName;
            }
        }

        static public IImage GetImage()
        {
            string str = SelectImg();
            if (str == null) return null;
            else
            {
                return new Image<Bgr, Byte>(str);
            }

        }
        static public string[] SelectImgs()
        {
            using (OpenFileDialog od = new OpenFileDialog())
            {
                od.Title = "打开图片";
                od.Filter = "IMG|*.jpg;*.png;*.bmp;*.jpeg";
                od.Multiselect = true;
                if (od.ShowDialog() != System.Windows.Forms.DialogResult.OK) return null;
                return od.FileNames;
            }
        }

        private void 样本生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BitmapWlakerTest().Show(this.dockPanel1, DockState.Document);
        }

        private void 多角度样本生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BitmapCreatAngles().Show(this.dockPanel1, DockState.Document);
        }

        private void 滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BitmapBlur().Show(this.dockPanel1, DockState.Document);
        }

        private void 局部阈值ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new BitmapAdaptiveThreshold().Show(this.dockPanel1, DockState.Document);
        }

        private void 直方图ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new BitmapHis().Show(this.dockPanel1, DockState.Document);
        }

        private void 逆转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BitmapTransformation().Show(this.dockPanel1, DockState.Document);
        }

        private void 膨胀腐蚀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BitmapOpenClose().Show(this.dockPanel1, DockState.Document);
        }

        private void 边缘检测ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new BitmapFindCon().Show(this.dockPanel1, DockState.Document);
        }

        private void 直线检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BitmapHuoghTest().Show(this.dockPanel1, DockState.Document);
        }

        private void 同物体追踪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CompareTest().Show(this.dockPanel1, DockState.Document);
        }

        private void 标线流程测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FinalTest().Show(this.dockPanel1, DockState.Document);
        }

        private void 颜色阈值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BitmapHSV().Show(this.dockPanel1, DockState.Document);
        }

        private void 特征点检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BitmapSuftDetect().Show(this.dockPanel1, DockState.Document);
        }

        private void svm训练ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BitmapSVMTrain().Show(this.dockPanel1, DockState.Document);
        }

        private void 图像拼接ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new BitmapStitching().Show(this.dockPanel1, DockState.Document);
        }

        private void 填充测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FillTest().Show(this.dockPanel1, DockState.Document);
        }
    }


}
