using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace WindowsFormsApplication1
{
    public partial class OcrForm : Form
    {
        string imgpath = "";
        string exepath = "";
        List<Rectangle> lsrect = new List<Rectangle>();
        Mat srcimg = new Mat();

        public OcrForm()
        {
            InitializeComponent();
        }

        private void tsbtnOpenImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "IMG|*.jpg;*.png;*.bmp;*.tif";
                if (of.ShowDialog() != DialogResult.OK) return;
                srcimg = new Mat(of.FileName, LoadImageType.Unchanged);
                imgpath = of.FileName;
                Mat imgsegment = getbinaryimg(srcimg);
                imgboxImgSegment.Image = imgsegment;
                DoSegment();
            }
        }

        void DoSegment() {
            Mat img = imgboxImgSegment.Image as Mat;
            if (img == null) return;
            double rectx = (double)numCharW.Value;
            int recty = (int)numCharH.Value;
            Mat result = doprocess(img, lsrect, rectx, recty);
            imgboxDectArea.Image = result;
        }

        Mat getbinaryimg(Mat img)
        {
            Mat result = new Mat();
            if (img.NumberOfChannels == 3)
            {
                CvInvoke.CvtColor(img, result, ColorConversion.Bgr2Gray);
                CvInvoke.Threshold(result, result, 100, 255, ThresholdType.Otsu);
            }
            else if (img.NumberOfChannels == 3)
            {
                Mat gray = new Mat(img.Size, DepthType.Cv8U, 1);
                VectorOfMat vm = new VectorOfMat();
                CvInvoke.Split(img, vm);
                result = vm[3];
            }
            else
            {
                CvInvoke.Threshold(img, result, 100, 255, ThresholdType.Otsu);
            }

            int cnt = CvInvoke.CountNonZero(result);
            if (cnt < result.Size.Height * result.Size.Width / 2)
                CvInvoke.BitwiseNot(result, result);
            return result;
        }

        string getOEMcmd()
        {
            if (checkUseOEM.Checked)
            {
                return string.Format(" --oem {0}", (int)numOEMType.Value);
            }
            else
                return "";
        }
        string getLangCmd()
        {
            string result = " -l ";
            if (checkCHI.Checked)
            {
                result += (checkCHI.Text+"+");
            }
            if (checkENG.Checked)
            {
                result += (checkENG.Text + "+");
            }
            if (checkOSD.Checked)
            {
                result += (checkOSD.Text + "+");
            }

            return result.Substring(0, result.Length - 1);
        }
        string getRangeCmd()
        {
            return " -c tessedit_char_whitelist=ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        }
        string getPsmCmd()
        {
            if (checkPsm.Checked)
            {
                return string.Format(" --psm {0}", (int)numPsm.Value);
            }
            else
                return "";
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
        Mat doprocess(Mat imgse , List<Rectangle> LsRect,double rectx, double recty)
        {

            var img = imgse.Clone();
            //var imgblack = new Mat(imgse.Size, DepthType.Cv8U, 3);
            //imgblack.SetTo(new MCvScalar(0,0,0));
            var imgblack = imgse.Clone();
            CvInvoke.CvtColor(imgblack, imgblack, ColorConversion.Gray2Bgr);
            VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint();
            int[,] array = CvInvoke.FindContourTree(img, vvp, ChainApproxMethod.ChainApproxSimple);

            LsRect.Clear();
            List<Rectangle> allrect = new List<Rectangle>();
            VectorOfVectorOfPoint resultvp = new VectorOfVectorOfPoint();
            for (int i = 0; i < vvp.Size; i++)
            {
                if (!isWriteContoursIndex(array, i)) continue;
                
                Rectangle rect = CvInvoke.BoundingRectangle(vvp[i]);
                allrect.Add(rect);
                if (allrect.Count > 2)
                {
                    int cnt = allrect.Count;
                    Rectangle rectlast = allrect[cnt - 1];
                    Rectangle rectlastb = allrect[cnt - 2];
                    if (NeedMerge(rectlast, rectlastb)) {
                        Rectangle megrect = RectMerge(rectlastb, rectlast);
                        allrect.RemoveAt(cnt - 1);
                        allrect.RemoveAt(cnt - 2);
                        allrect.Add(megrect);
                    }
                }  
            }
            foreach (var rect in allrect)
            {
                if (rect.Height < (int)numThreshold.Value && rect.Height > (int)numMinHeight.Value) 
                {
                

                    CvInvoke.Rectangle(imgblack, rect, new MCvScalar(155,0,0), 1);
                    int nums = (int)((double)rect.Width / rectx + 0.8);
                    for (int j = 0; j < nums; j++)
                    {
                        int width = rect.Right - (rect.Left + Math.Round(j * rectx)) > rectx ? (int)(Math.Round((j + 1) * rectx) - Math.Round(j * rectx)) : rect.Right - (rect.Left + (int)Math.Round(j * rectx));
                        Rectangle wordrect = new Rectangle(rect.Left + (int)(j * rectx), rect.Top, width-1, (int)Math.Round(recty));
                        CvInvoke.Rectangle(imgblack, wordrect, new MCvScalar(0,255,255), 1);
                        LsRect.Add(wordrect);
                    }

                }



                LsRect.Sort((re1,re2)=>
                {
                    if (re1.Top - re2.Top > 10)
                        return 1;
                    else if (re1.Top - re2.Top < -10)
                        return -1;
                    if (re1.Left < re2.Left)
                        return -1;
                    else if (re1.Left == re2.Left)
                        return 0;
                    else
                        return 1;
                
                });
                
            }


            return imgblack;
        }
        Rectangle RectMerge(Rectangle rect1, Rectangle rect2)
        {
            Rectangle rectM = new Rectangle();
            rectM.X = Math.Min(rect1.X, rect2.X);
            rectM.Y = Math.Min(rect1.Y, rect2.Y);
            rectM.Width = Math.Max(rect1.X + rect1.Width, rect2.X + rect2.Width) - rectM.X;
            rectM.Height = Math.Max(rect1.Y + rect1.Height, rect2.Y + rect2.Height) - rectM.Y;
            return rectM;
        }
        bool NeedMerge(Rectangle rect1, Rectangle rect2,double scale =0.3)
        {
            bool need = rect1.IntersectsWith(rect2);

            if (!need) return false;
            Rectangle temp = rect1 ;
            temp.Intersect(rect2);
            double area1 = rect1.Size.Width * rect1.Size.Height, area2 = rect1.Size.Width * rect2.Size.Height;
            double minarea = Math.Min(area1, area2);
            if (temp.Size.Width * temp.Size.Height / minarea > scale)
                return true;
            else
                return false;
        }
        string dodetect(string imgpath, string txtpath, string othercmd)
        {
            if (!File.Exists(imgpath)) return null;
            string notxt = txtpath.Substring(0, txtpath.Length - 4);
            fnOCR(exepath, imgpath, notxt, othercmd);
            string result = File.ReadAllText(txtpath);
            if (File.Exists(txtpath))
                File.Delete(txtpath);
            return result;
        }

        private void OcrForm_Load(object sender, EventArgs e)
        {
            var config = Properties.Settings.Default;
            numCharW.Value = (decimal)config.CharWidth;
            numCharH.Value = (decimal)config.CharHeight;
            numMinHeight.Value = config.MinHeight;
            numThreshold.Value = config.Threshold;
            numOEMType.DataBindings.Add(new Binding("Enabled", checkUseOEM, "Checked"));
            numPsm.DataBindings.Add(new Binding("Enabled", checkPsm, "Checked"));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var config = Properties.Settings.Default;
            config.CharWidth = (float)numCharW.Value;
            config.MinHeight = (int)numMinHeight.Value;
            config.Threshold = (int)numThreshold.Value;
            config.Save();
        }

        private void numCharW_ValueChanged(object sender, EventArgs e)
        {
            DoSegment();
        }

        private void numCharH_ValueChanged(object sender, EventArgs e)
        {
            DoSegment();
        }

        private void btnDetectChar_Click(object sender, EventArgs e)
        {
            if (!File.Exists(exepath))
            {
                MessageBox.Show("Not found tesseract work directory");
                return;
            }

            richTextBox1.Text = null;
            if ((imgboxImgSegment.Image as Mat) == null) return;
            Mat img = imgboxImgSegment.Image as Mat;
            string tempimgpath = string.Format("{0}\\temp.png", Application.StartupPath);

            for (int i = 0; i < lsrect.Count; i++)
            {
                Mat imgrect = new Mat(img, lsrect[i]);
                Mat imgwrite = new Mat(img.Size, DepthType.Cv8U, 1);
                imgwrite.SetTo(new MCvScalar(255));
                Mat imgroi = new Mat(imgwrite, lsrect[i]);
                imgrect.CopyTo(imgroi);

                imgwrite.Save(tempimgpath);
                
                string txtpath = string.Format("{0}\\{1}.txt", Application.StartupPath,i);
                
                string result = dodetect(tempimgpath, txtpath, getLangCmd()+ getRangeCmd()+ getOEMcmd()+" --psm 8");

                richTextBox1.Text += result.Trim();
            }
        }

        private void fnOCR(string v_strTesseractPath, string v_strSourceImgPath, string v_strOutputPath, string v_strPsm)
        {
            using (Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = v_strTesseractPath;
                process.StartInfo.Arguments = v_strSourceImgPath + " " + v_strOutputPath  + v_strPsm;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                while (!process.HasExited)
                {
                    Thread.Sleep(50);
                }

                process.WaitForExit();
            }
        }

        private void btnImgocr_Click(object sender, EventArgs e)
        {
            if (!File.Exists(exepath))
            {
                MessageBox.Show("Not found tesseract work directory");
                return;
            }
            richTextBox1.Text = null;
            string psmstr = string.Format("{0}{1}{2}", getLangCmd(), getPsmCmd(), getOEMcmd());
            richTextBox1.Text = dodetect(imgpath, Application.StartupPath+"\\debug.txt", psmstr);
        }

        private void numMinHeight_ValueChanged(object sender, EventArgs e)
        {
            DoSegment();
        }

        private void tsbtnSelectWorkExe_Click(object sender, EventArgs e)
        {
            string exename = "tesseract.exe";
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "EXE|*.exe";
                of.FileName = exename;
                if (of.ShowDialog() != DialogResult.OK) return;

                if(!Path.GetFileName(of.FileName).Equals(exename))
                {
                    MessageBox.Show("selectName is not " + exename);
                    return;
                }

                exepath = of.FileName;
                gboxOcrParams.Enabled = true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog  sf = new SaveFileDialog())
            {
                sf.Filter = "TXT|*.txt";
                sf.FileName = "result.txt";
                if (sf.ShowDialog() != DialogResult.OK) return;
                File.WriteAllText(sf.FileName, richTextBox1.Text);
            }
        }

    }
}
