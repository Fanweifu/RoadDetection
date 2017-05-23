using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ShowOpenCVResult
{
    //[Guid("52F0F7CF-B73F-4AD4-A04E-DAEF6333A9B0")]
    //[ComVisible(true)]
    //public interface IComTest        
    //{
    //    [DispId(1)]       
    //    int Plus(int one, int two);
    //}

    //[Guid("2293C017-26F7-459B-BA3C-38E76E05E5DE")]
    //[ClassInterface(ClassInterfaceType.None)]
    public partial class VideoFindMechine : MoveBlock/*,IComTest*/
    {
        bool isvideo = false;
        Capture m_cp = new Capture();
        double fps = 0;
        int count = 0;
        Thread video = null;
        Image<Bgr, byte> fileimg = null;
            
        public VideoFindMechine()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.Filter = "(AVI)*.avi|*.avi";
                if (op.ShowDialog() != DialogResult.OK) return;
                m_cp = new Capture(op.FileName);
                fps = m_cp.GetCaptureProperty(CapProp.Fps);
                count = (int)m_cp.GetCaptureProperty(CapProp.FrameCount);
                isvideo = true;
            }

            imageIO1.DoChange();

        }

        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIO1.InImage == null) return;

            Mat img = null;
            if (isvideo)
            {
                if (m_cp == null) return;
                int nums = 0;

                if (video != null) {
                    video.Abort();
                    video = null;
                }

                video = new Thread(() =>
                {
                    while (nums < count)
                    {
                        img = m_cp.QueryFrame();
                        var backup = img.Clone();
                        //OpencvMath.NormalizeBGR(backup);
                        Thread.Sleep((int)(1000.0 / fps));
                        Mat mask = new Mat();

                        imageIO1.InImage = img;
                        imageIO1.OutImage = backup;
                        nums++;
                    }

                });

                video.Start();

            }
            else {
                if (video != null) {
                    video.Abort();
                    video = null;
                }

                img = fileimg.Mat.Clone();
                process(img);

            }
       
        }

        void process(Mat img) {
            RotatedRect rr = new RotatedRect();

            Mat result = FindObjectRect(img, out rr);
            OpencvMath.DrawRotatedRect(rr, img);
            
            imageIO1.InImage = img;

            
            imageIO1.OutImage = result;
        }


        void preDo(Mat binary,int blackgap,int writebanrch) {
            if (binary == null || binary.NumberOfChannels != 1||binary.Depth!= DepthType.Cv8U) return;
            unsafe {
                byte* ptrhead = (byte*)binary.DataPointer;
                int rows = binary.Rows, cols = binary.Cols;
                for (int i = 0; i < rows; i++)
                {
                    byte* rowhead = ptrhead + cols * i;
                    int lastindex = 0;
                    for (int j = 1; j < cols; j++)
                    {
                        byte curvalue = *(rowhead + j), lastvalue = *(rowhead + j - 1);
                        if (curvalue * lastvalue == 0 && curvalue != lastvalue) {
                            if (curvalue > 0)
                            {
                                if (lastindex == 0)
                                {
                                    lastindex = j;
                                }
                                else
                                {
                                    if (j - lastindex < blackgap)
                                    {
                                        for (int p = lastindex; p < j; p++)
                                        {
                                            *(rowhead + p) = 255;
                                        }
                                    }
                                }
                            }
                            else {
                                if (lastindex == 0)
                                {
                                    lastindex = j;
                                }
                                else
                                {
                                    if (j - lastindex < writebanrch)
                                    {
                                        for (int p = lastindex; p < j; p++)
                                        {
                                            *(rowhead + p) = 0 ;
                                        }
                                    }
                                }
                            }
                        }
                    } 
                }


                for (int i = 0; i < cols; i++)
                {
                    byte* rowhead = ptrhead +  i;
                    int lastindex = 0;
                    for (int j = 1; j < rows; j++)
                    {
                        byte curvalue = *(rowhead + j*cols), lastvalue = *(rowhead + (j - 1)*cols);
                        if (curvalue * lastvalue == 0 && curvalue != lastvalue)
                        {
                            if (curvalue > 0)
                            {
                                if (lastindex == 0)
                                {
                                    lastindex = j;
                                }
                                else
                                {
                                    if (j - lastindex < blackgap)
                                    {
                                        for (int p = lastindex; p < j; p++)
                                        {
                                            *(rowhead + p*cols) = 255;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (lastindex == 0)
                                {
                                    lastindex = j;
                                }
                                else
                                {
                                    if (j - lastindex < writebanrch)
                                    {
                                        for (int p = lastindex; p < j; p++)
                                        {
                                            *(rowhead + p * cols) = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        Mat FindObjectRect( Mat img,out RotatedRect rect ) {
        
            Mat mask = new Mat();
            Rectangle rectempty = new Rectangle();
            var imgresult = img.Clone();
            CvInvoke.CvtColor(imgresult , mask, ColorConversion.Bgr2Gray);
            CvInvoke.FloodFill(mask, null, new Point(1, 1), new MCvScalar(0),out rectempty, new MCvScalar(2),new MCvScalar(30));
            CvInvoke.Threshold(mask, mask, 0, 255, ThresholdType.Binary);

            CvInvoke.CvtColor(imgresult, imgresult, ColorConversion.Bgr2Hsv);
            Mat hsv = new Mat();
            imgresult.CopyTo(hsv, mask);
            VectorOfMat bgr = OpencvMath.NormolizeHsvImg(hsv, mask);
            hsv.Dispose();
            mask.Dispose();

            CvInvoke.Threshold(bgr[1], bgr[1], 100, 255, ThresholdType.Otsu);
            int maxindex = 0;
            VectorOfVectorOfPoint vvp = OpencvMath.FindMaxAreaIndexCon(bgr[1], out maxindex);

            Mat black = bgr[1].Clone();
            black.SetTo(new MCvScalar(0));
            CvInvoke.DrawContours(black, vvp, maxindex, new MCvScalar(255), -1);
            preDo(black, myTrackBar1.Value, myTrackBar2.Value);
            int maxindex2 = 0;
            VectorOfVectorOfPoint vvp2 = OpencvMath.FindMaxAreaIndexCon(black, out maxindex2);
            var roterect = CvInvoke.MinAreaRect(vvp2[maxindex2]);

            OpencvMath.DrawRotatedRect(roterect, img);

            rect = roterect;
            return black;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            IImage img = OpencvForm.GetImage();
            if (img == null) return;

            isvideo = false;
            fileimg = img as Image<Bgr, byte>;
            imageIO1.SetInput(fileimg.Clone());


        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }

        private void myTrackBar2_ValueChanged(object sender, EventArgs e)
        {
            imageIO1.DoChange();
        }


        //public int Plus(int one, int two)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
