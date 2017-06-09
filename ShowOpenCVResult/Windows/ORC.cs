using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using tessnet2;

namespace ShowOpenCVResult.Windows
{
    public partial class ORC : MoveBlock
    {
        Mat m_filsrc = null;
        Emgu.CV.OCR.Tesseract m_engocr = new Emgu.CV.OCR.Tesseract(@"C:/Emgu/emgucv-windows-universal 3.0.0.2157/bin/tessdata/", "eng", OcrEngineMode.TesseractOnly);
     
        //tessnet2.Tesseract m_netengocr = new tessnet2.Tesseract();
        //tessnet2.Tesseract m_netchiocr = new tessnet2.Tesseract();
        public ORC()
        {
            InitializeComponent();
            StartProcess(@"C:\Program Files (x86)\Tesseract-OCR\tesseract.exe", "C:\\Users\fwf\\Desktop\\cv\\ocr\\test.png result -l chi_sim");


            //m_netengocr.Init("eng.traineddata", "eng", true);
            //m_netchiocr.Init("chi_sim.traineddata", "chi_sim", true);
        }

        public bool StartProcess(string filename, string s)
        {
            try
            {
                s = s.Trim();
                Process myprocess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(filename, s);
                myprocess.StartInfo = startInfo;
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("启动应用程序时出错！原因：" + ex.Message);
            }
            return false;
        }

        private void tsbtnOpenImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "IMG|*.png;*.jpg;*.tif;";
                if (of.ShowDialog() != DialogResult.OK) return;
                m_filsrc  = new Mat(of.FileName,LoadImageType.Unchanged);
                imageIO1.InImage  = getbinaryimg(m_filsrc);
            }

            
        }

        Mat getbinaryimg(Mat img)
        {
            Mat result = new Mat();
            if (img.NumberOfChannels == 3)
            {
                CvInvoke.CvtColor(img, result, ColorConversion.Bgr2Gray);
                CvInvoke.Threshold(result, result, 100, 255, ThresholdType.Otsu);
            }
            else if (img.NumberOfChannels == 4) {
                Mat gray = new Mat(m_filsrc.Size, DepthType.Cv8U, 1);
                VectorOfMat vm = new VectorOfMat();
                CvInvoke.Split(m_filsrc, vm);
                result = vm[3].Clone();
                vm.Dispose();
            }
            else
            {
                CvInvoke.Threshold(img, result, 100, 255, ThresholdType.Otsu);
            }
            return result;
        }

        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            Mat img = imageIO1.InImage as Mat;
            if (img == null) return;

            Mat conimg = img.Clone();
            Mat blackimg = img.Clone();
            Mat strct = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3),new Point(-1,-1));
            CvInvoke.MorphologyEx(conimg, conimg, MorphOp.Close, strct, new Point(-1, -1), 1, BorderType.Default, default(MCvScalar));
            VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint();
            
            int [,] array = CvInvoke.FindContourTree(conimg, vvp, ChainApproxMethod.ChainApproxSimple);
            double rectx = (double)numRectX.Value;
            int recty = (int)numRectY.Value;
            List<Rectangle> engls = new List<Rectangle>();
            for (int i = 0; i < vvp.Size; i++)
            {
                if (!isWriteContoursIndex(array, i)) continue;
                Rectangle rect = CvInvoke.BoundingRectangle(vvp[i]);
                if (rect.Height < 20 && rect.Height > 14)
                {
                    engls.Add(rect);
                    int nums = (int)((double)rect.Width / rectx + 0.8);
                    for (int j = 0; j < nums; j++)
                    {
                        Rectangle wordrect = new Rectangle(rect.Left + (int)(j * rectx), rect.Top, (int)((j+1) * rectx)- (int)(j * rectx), recty);
                        CvInvoke.Rectangle(blackimg, wordrect, new MCvScalar(150), 1);
                    }
                }
                
            }

            imageIO1.OutImage = blackimg;
            richTextBox1.Text = null;
            foreach (var item in engls)
            {
                Mat chimg = new Mat(img, item);
                m_engocr.Recognize(chimg);
                string text = m_engocr.GetText();
                richTextBox1.Text += text;
            }
            
        }

        bool isWriteContoursIndex(int[,] array, int id)
        {
            int inedx = id;
            int layer = 0;
            while (array[inedx, 3] > 0)
            {
                inedx = array[inedx, 3];
                layer++;
            }
            return layer % 2 == 0;
        }

        private void imageIO1_AfterImgLoaded(object sender, EventArgs e)
        {
            m_filsrc = (imageIO1.InImage as Image<Bgr, byte>).Mat;
            imageIO1.InImage = getbinaryimg(m_filsrc);
        }

        private void numRectX_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void numRectY_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void ORC_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
