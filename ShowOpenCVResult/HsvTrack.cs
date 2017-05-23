using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ShowOpenCVResult
{
    public partial class HsvTrack : MoveBlock
    {
        int fps = 30;
        Capture m_cap = null;
        Task playthread = null;
        Rectangle findrect = default(Rectangle);
        Rectangle currect = default(Rectangle);
        ManualResetEvent mr = new ManualResetEvent(true);
        bool isinplay = false;
        ShowOpenCVResult.ImgProcess.ObjectTrack m_ot = new ImgProcess.ObjectTrack();
        public HsvTrack()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (!int.TryParse(tstbIndex.Text, out index)) return;

            m_cap = new Emgu.CV.Capture(index);
            isinplay = true;
            //m_cap.ImageGrabbed += M_cap_ImageGrabbed;
            //m_cap.Start();
            playthread = new Task(() =>
            {
                while (true)
                {
                    if (!isinplay)
                    {
                        mr.WaitOne();
                    }
                    Stopwatch sw = Stopwatch.StartNew();
                    Mat img = m_cap.QueryFrame();
                    //if (imageIO1.Image1 != null)
                    //{
                    //    imageIO1.Image1.Dispose();
                    //}

                    imageIO1.InImage = img;

                    if (m_ot.IsInDetect)
                    {
                        currect = m_ot.Track(img, chnidx);
                        if (imageIO1.OutImage != null)
                        {
                            imageIO1.OutImage.Dispose();
                        }
                        imageIO1.OutImage = m_ot.DrawRectangle(new MCvScalar(0.255, 255));
                    }
                    else
                    {
                        Mat hsvreshold = getMask(img, hmin, hmax, smin, smax, vmin, vmax);
                        Mat result = new Mat(img.Size, DepthType.Cv8U, 3);
                        img.CopyTo(result, hsvreshold);
                        var vp = maxArea(hsvreshold);
                        hsvreshold.Dispose();
                        if (vp != null)
                            findrect = CvInvoke.BoundingRectangle(vp);
                        if (!findrect.Equals(default(Rectangle)))
                        {
                            CvInvoke.Rectangle(result, findrect, new MCvScalar(0, 255, 255), 2);
                        }

                        if (imageIO1.OutImage != null)
                        {
                            imageIO1.OutImage.Dispose();
                        }
                        imageIO1.OutImage = result;
                    }
                    sw.Stop();
                    double time = (double)1000 / fps - sw.ElapsedMilliseconds;
                    if (time > 0)
                        Thread.Sleep((int)time);
                }
            });
            playthread.Start();

        }

        int hmin = 0, hmax = 180, smin = 0, smax = 255, vmin = 0, vmax = 255;
        int chnidx = 1;
        int playcnt = 0;
        private void M_cap_ImageGrabbed(object sender, EventArgs e)
        {
            if (playcnt++ % 3 != 0) return;

            Mat img = new Mat();
            m_cap.Retrieve(img);
            if (imageIO1.InImage != null)
            {
                imageIO1.InImage.Dispose();
            }

            imageIO1.InImage = img;

            if (m_ot.IsInDetect) {
                currect = m_ot.Track(img,chnidx);
                if (imageIO1.OutImage != null)
                {
                    imageIO1.OutImage.Dispose();
                }
                imageIO1.OutImage = m_ot.DrawRectangle(new MCvScalar(0.255,255));
            }else
            {
                Mat hsvreshold = getMask(img, hmin, hmax, smin, smax, vmin, vmax);
                Mat result = new Mat(img.Size, DepthType.Cv8U, 3);
                img.CopyTo(result, hsvreshold);
                var vp = maxArea(hsvreshold);
                hsvreshold.Dispose();
                if (vp!=null)
                    findrect = CvInvoke.BoundingRectangle(vp);
                if (!findrect.Equals(default(Rectangle)))
                {
                    CvInvoke.Rectangle(result, findrect, new MCvScalar(0, 255, 255), 2);
                }

                if (imageIO1.OutImage != null)
                {
                    imageIO1.OutImage.Dispose();
                }
                imageIO1.OutImage = result;
            }
         
        }

        private void imageIO1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIO1.InImage == null) return;
            if (sminbar.Value > smaxbar.Value || vminbar.Value > vmaxbar.Value) return;

            var img = (imageIO1.InImage as Image<Bgr, byte>).Mat;
            Mat hsvreshold = getMask(img, hminbar.Value, hmaxbar.Value, sminbar.Value, smaxbar.Value, vminbar.Value, vmaxbar.Value);
            Mat result = new Mat(img.Size, DepthType.Cv8U, 3);
            img.CopyTo(result, hsvreshold);

            if (!findrect.Equals(default(Rectangle))) {
                CvInvoke.Rectangle(result, findrect, new MCvScalar(0, 255, 255), 2);
            }

            
            imageIO1.OutImage = hsvreshold;


        }

        private void hmaxbar_ValueChanged(object sender, EventArgs e)
        {
            hmax = hmaxbar.Value;
        }

        private void hminbar_ValueChanged(object sender, EventArgs e)
        {
            hmin = hminbar.Value;
        }

        private void sminbar_ValueChanged(object sender, EventArgs e)
        {
            smin = sminbar.Value;
        }

        private void smaxbar_ValueChanged(object sender, EventArgs e)
        {
            smax = smaxbar.Value;
        }

        private void vminbar_ValueChanged(object sender, EventArgs e)
        {
            vmin = vminbar.Value;
        }

        private void vmaxbar_ValueChanged(object sender, EventArgs e)
        {
            vmax = vmaxbar.Value;
        }

        private void btnFindColor_Click(object sender, EventArgs e)
        {
            Mat img = (imageIO1.InImage as Mat).Clone();
            Mat hsvreshold = getMask(img, hminbar.Value, hmaxbar.Value, sminbar.Value, smaxbar.Value, vminbar.Value, vmaxbar.Value);
            var vp = maxArea(hsvreshold);
            findrect = CvInvoke.BoundingRectangle(vp);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            chnidx = (int)numIdx.Value;
        }

        private void BtnPalyOrPause_Click(object sender, EventArgs e)
        {
            if (isinplay)
            {
                isinplay = false;
                mr.Reset();
            }
            else
            {
                isinplay = true;
                mr.Set();
            }
        }

        private void numFps_ValueChanged(object sender, EventArgs e)
        {
            fps = (int)numFps.Value;
        }

        private void HsvTrack_Load(object sender, EventArgs e)
        {

        }

        Mat getMask(Mat img,int hmin,int hmax,int smin,int smax,int vmin,int vmax)
        {
            Mat hsv = new Mat();
            CvInvoke.CvtColor(img, hsv, ColorConversion.Bgr2Hsv);
            var vm = new VectorOfMat();
            CvInvoke.Split(hsv, vm);
            hsv.Dispose();
            OpencvMath.MyThreshold(vm[0], (byte)hmin, (byte)hmax, 255, true);
            OpencvMath.MyThreshold(vm[1], (byte)smin, (byte)smax, 255, false);
            OpencvMath.MyThreshold(vm[2], (byte)vmin, (byte)vmax, 255, false);
            CvInvoke.BitwiseAnd(vm[0],vm[1], vm[0]);
            CvInvoke.BitwiseAnd(vm[0], vm[2], vm[0]);
            var result = vm[0].Clone();
            vm.Dispose();
            return result;
        }
        VectorOfPoint maxArea(Mat bwimg)
        {
            VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(bwimg, vvp, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            double maxarea = 0;
            VectorOfPoint vp = null;
            for (int i = 0; i < vvp.Size; i++)
            {
                var v = vvp[i];
                double area = CvInvoke.ContourArea(v);
                if (area > maxarea)
                {
                    maxarea = area;
                    vp = v;
                }
            }
            return vp;
        }

        private void btnStartTrack_Click(object sender, EventArgs e)
        {
            m_ot.SetData(findrect, imageIO1.InImage as Mat);

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            m_ot.Reset();
        }

    }
}
