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
using ShowOpenCVResult.Properties;
using System.Xml;

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
            var config = Settings.Default;
            //RoadTransform.SetTransform(config.InputWidth, config.InputHeigth, config.AX, config.AY, config.LT, config.OW, config.OH);
            try
            {
                RoadTransform.LoadSetting();
            }
            catch
            {

            }

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
            new WarpPerspective().Show(this.dockPanel1, DockState.Document);
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
            new WalkerDetect().Show(this.dockPanel1, DockState.Document);
        }

        private void 多角度样本生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CreatAnglesImg().Show(this.dockPanel1, DockState.Document);
        }

        private void 滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Blur().Show(this.dockPanel1, DockState.Document);
        }

        private void 局部阈值ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AdaptiveThreshold().Show(this.dockPanel1, DockState.Document);
        }

        private void 直方图ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new HarrisTest().Show(this.dockPanel1, DockState.Document);
        }

        private void 逆转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new WarpPerspective().Show(this.dockPanel1, DockState.Document);
        }

        private void 膨胀腐蚀ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new MorphologyEx().Show(this.dockPanel1, DockState.Document);
        }

        private void 边缘检测ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new FindContours().Show(this.dockPanel1, DockState.Document);
        }

        private void 直线检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new HuoghLine().Show(this.dockPanel1, DockState.Document);
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
            new RoadDetectShow().Show(this.dockPanel1, DockState.Document);
        }

        private void 特征点检测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SurfDetect().Show(this.dockPanel1, DockState.Document);
        }

        private void svm训练ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EmguSVMTrain().Show(this.dockPanel1, DockState.Document);
        }

        private void 图像拼接ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Stitching().Show(this.dockPanel1, DockState.Document);
        }

        private void 填充测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FloodFill().Show(this.dockPanel1, DockState.Document);
        }

        private void 机床定位ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new VideoFindMechine().Show(this.dockPanel1, DockState.Document);
        }

        private void hSV测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new  HSVRangeTest().Show(this.dockPanel1, DockState.Document);
        }

        private void acoordsvmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AccordSvmTrain().Show(this.dockPanel1, DockState.Document);
        }

        private void 设置ROIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SetROI().Show(this.dockPanel1, DockState.Document);

        }

        //private void 车道检测ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    new LineDetectTest().Show(this.dockPanel1, DockState.Document);
        //}

        //private void 车辆检测ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    new CarDetect().Show(this.dockPanel1, DockState.Document);
        //}

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf= new SaveFileDialog())
            {
                sf.Filter = "XML|*.xml";
                if (sf.ShowDialog() != DialogResult.OK) return;
                SaveConfigTOXML(sf.FileName);
            }
        }

        public void SaveConfigTOXML(string path)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.CreateXmlDeclaration("1.0", "UT8-F", "yes");
            var root = xmldoc.CreateElement("DetectParams");

            var config = Properties.Settings.Default;

            ///DetectArea
            var noderect = xmldoc.CreateElement("DetectArea");
            root.AppendChild(noderect);

            var rectx = xmldoc.CreateElement("X");
            rectx.InnerText= config.DetectArea.X.ToString();
            noderect.AppendChild(rectx);

            var recty = xmldoc.CreateElement("Y");
            recty.InnerText = config.DetectArea.Y.ToString();
            noderect.AppendChild(recty);

            var rectw = xmldoc.CreateElement("Width");
            rectw.InnerText = config.DetectArea.Width.ToString();
            noderect.AppendChild(rectw);

            var recth = xmldoc.CreateElement("Height");
            recth.InnerText = config.DetectArea.Height.ToString();
            noderect.AppendChild(recth);

            ///OutSize
            var nodetransize = xmldoc.CreateElement("OutSize");
            root.AppendChild(nodetransize);

            var nodeoutw = xmldoc.CreateElement("outSizeW");
            nodeoutw.InnerText = config.OW.ToString();
            nodetransize.AppendChild(nodeoutw);

            var nodeouth = xmldoc.CreateElement("outSizeH");
            nodeouth.InnerText = config.OH.ToString();
            nodetransize.AppendChild(nodeouth);

            ///Tranformation Scale
            var nodeTransScale = xmldoc.CreateElement("TranformationScale");
            root.AppendChild(nodeTransScale);

            var nodeax = xmldoc.CreateElement("AX");
            nodeax.InnerText = config.AX.ToString();
            nodeTransScale.AppendChild(nodeax);

            var nodeay = xmldoc.CreateElement("AY");
            nodeay.InnerText = config.AY.ToString();
            nodeTransScale.AppendChild(nodeay);

            var nodelt = xmldoc.CreateElement("LT");
            nodelt.InnerText = config.LT.ToString();
            nodeTransScale.AppendChild(nodelt);

            ///AdaptiveThreshold
            var nodead = xmldoc.CreateElement("AdaptiveThreshold");
            root.AppendChild(nodead);

            var nodeblocksize = xmldoc.CreateElement("BlockSize");
            nodeblocksize.InnerText = config.AdaptiveBlockSize.ToString();
            nodead.AppendChild(nodeblocksize);

            var nodeparams = xmldoc.CreateElement("Params");
            nodeparams.InnerText = config.AdaptiveParam.ToString();
            nodead.AppendChild(nodeparams);

            ///Canny
            var nodecanny = xmldoc.CreateElement("Canny");
            root.AppendChild(nodecanny);

            var nodecannythreshold = xmldoc.CreateElement("CannyThreshold");
            nodecannythreshold.InnerText = config.CannyThreshold.ToString();
            nodecanny.AppendChild(nodecannythreshold);

            var nodecannythressholdlink = xmldoc.CreateElement("ThresholdLink");
            nodecannythressholdlink.InnerText = config.CannyLink.ToString();
            nodecanny.AppendChild(nodecannythressholdlink);

            ///Line
            var nodehuoghline = xmldoc.CreateElement("HuoghLine");
            root.AppendChild(nodehuoghline);

            var nodehuoghthreshold = xmldoc.CreateElement("Threshold");
            nodehuoghthreshold.InnerText = config.LineThreshold.ToString();
            nodehuoghline.AppendChild(nodehuoghthreshold);

            var nodehuoghminlength = xmldoc.CreateElement("MinLength");
            nodehuoghminlength.InnerText = config.LineMinLength.ToString();
            nodehuoghline.AppendChild(nodehuoghminlength);

            var nodehoughmaxgrap = xmldoc.CreateElement("MaxGrap");
            nodehoughmaxgrap.InnerText = config.LineMaxGrap.ToString();
            nodehuoghline.AppendChild(nodehoughmaxgrap);

            ///FindContours
            var nodecontours = xmldoc.CreateElement("Contours");
            root.AppendChild(nodecontours);

            var nodeminarea = xmldoc.CreateElement("MinArea");
            nodeminarea.InnerText = config.MinArea.ToString();
            nodecontours.AppendChild(nodeminarea);

            var nodeminlenght = xmldoc.CreateElement("MinLength");
            nodeminlenght.InnerText = config.MinLength.ToString();
            nodecontours.AppendChild(nodeminlenght);

            var nodemaxwidth = xmldoc.CreateElement("MaxWidth");
            nodemaxwidth.InnerText = config.MaxAreaToLength.ToString();
            nodecontours.AppendChild(nodemaxwidth);

            var nodemaxarea = xmldoc.CreateElement("MaxArea");
            nodemaxarea.InnerText = config.MaxArea.ToString();
            nodecontours.AppendChild(nodemaxarea);

            var nodeepslion = xmldoc.CreateElement("Esplion");
            nodeepslion.InnerText = config.Epsilon.ToString();
            nodecontours.AppendChild(nodeepslion);
            xmldoc.AppendChild(root);
            xmldoc.Save(path);
        }

        public void LoadConfigFromXml(string path)
        {
            var config = Properties.Settings.Default;
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNode xn = xml.SelectSingleNode("DetectParams");
            XmlNodeList xnls = xn.ChildNodes;

            XmlElement noderect = xnls[0] as XmlElement;
            var rectls = noderect.ChildNodes;
            int x = int.Parse(((XmlElement)rectls[0]).InnerText);
            int y = int.Parse(((XmlElement)rectls[1]).InnerText);
            int w = int.Parse(((XmlElement)rectls[2]).InnerText);
            int h = int.Parse(((XmlElement)rectls[3]).InnerText);
            config.DetectArea = new Rectangle(x, y, w, h);

            XmlElement nodeoutsize = xnls[1] as XmlElement;
            config.OW = int.Parse(((XmlElement)nodeoutsize.ChildNodes[0]).InnerText);
            config.OH= int.Parse(((XmlElement)nodeoutsize.ChildNodes[1]).InnerText);

            ///Tranformation Scale
            XmlElement nodetrans = xnls[2] as XmlElement;
            config.AX = float.Parse(((XmlElement)nodetrans.ChildNodes[0]).InnerText);
            config.AY = float.Parse(((XmlElement)nodetrans.ChildNodes[1]).InnerText);
            config.LT = float.Parse(((XmlElement)nodetrans.ChildNodes[2]).InnerText);

            ///AdaptiveThreshold
            XmlElement nodead = xnls[3] as XmlElement;
            config.AdaptiveBlockSize = int.Parse(((XmlElement)nodead.ChildNodes[0]).InnerText);
            config.AdaptiveParam = int.Parse(((XmlElement)nodead.ChildNodes[1]).InnerText);

            ///Canny
            XmlElement nodecanny = xnls[4] as XmlElement;
            config.CannyThreshold = int.Parse(((XmlElement)nodecanny.ChildNodes[0]).InnerText);
            config.CannyLink = int.Parse(((XmlElement)nodecanny.ChildNodes[1]).InnerText);

            ///Line
            XmlElement nodeline = xnls[5] as XmlElement;
            config.LineThreshold = int.Parse(((XmlElement)nodeline.ChildNodes[0]).InnerText);
            config.LineMinLength = int.Parse(((XmlElement)nodeline.ChildNodes[1]).InnerText);
            config.LineMaxGrap = int.Parse(((XmlElement)nodeline.ChildNodes[2]).InnerText);

            ///FindContours
            XmlElement nodecontours= xnls[6] as XmlElement;
            config.MinArea = double.Parse(((XmlElement)nodecontours.ChildNodes[0]).InnerText);
            config.MinLength = double.Parse(((XmlElement)nodecontours.ChildNodes[1]).InnerText);
            config.MaxAreaToLength= int.Parse(((XmlElement)nodecontours.ChildNodes[2]).InnerText);
            config.MaxArea = int.Parse(((XmlElement)nodecontours.ChildNodes[3]).InnerText);
            config.Epsilon = double.Parse(((XmlElement)nodecontours.ChildNodes[4]).InnerText);

            config.Save();

        }

        private void 视频分解ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ConvertVideoToImgs().Show(this.dockPanel1, DockState.Document);
        }

        private void 读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "XML|*.xml";
                if (of.ShowDialog() != DialogResult.OK) return;
                LoadConfigFromXml(of.FileName);
            }
        }

        private void 视频追踪ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new HsvTrack().Show(this.dockPanel1, DockState.Document);
        }

        private void ocrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ORC().Show(this.dockPanel1, DockState.Document);
        }
    }


}
