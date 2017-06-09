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

namespace ShowOpenCVResult.Windows
{
    public partial class HsvTrack : MoveBlock
    {
        int chnidx = 1;
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

        [DefaultValue(0)]
        public int Hmin
        {
            get;set;
        }

        [DefaultValue(180)]
        public int Hmax
        {
            get; set;
        }

        [DefaultValue(0)]
        public int Smin
        {
            get; set;

        }
        [DefaultValue(255)]
        public int Smax
        {
            get; set;
        }
        [DefaultValue(0)]
        public int Vmin
        {
            get; set;
        }
        [DefaultValue(255)]
        public int Vmax
        {
            get; set;
        }
        [DefaultValue(30)]
        public int Fps
        {
            get;set;
        }

        private void HsvTrack_Load(object sender, EventArgs e)
        {
            DataBindings.Add(new Binding("Hmin", hminbar, "Value"));
            DataBindings.Add(new Binding("Hmax", hmaxbar, "Value"));
            DataBindings.Add(new Binding("Smin", sminbar, "Value"));
            DataBindings.Add(new Binding("Smax", smaxbar, "Value"));
            DataBindings.Add(new Binding("Vmin", vminbar, "Value"));
            DataBindings.Add(new Binding("Vmax", vmaxbar, "Value"));
            DataBindings.Add(new Binding("Fps", numFps, "Value"));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (!int.TryParse(tstbIndex.Text, out index)) return;
            if (m_cap != null) {

            }
            m_cap = new Emgu.CV.Capture(index);
            isinplay = true;


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

                    imageIO1.InImage = img;

                    if (m_ot.IsInDetect)
                    {
                        currect = m_ot.Track(img, chnidx);
                        imageIO1.OutImage = m_ot.DrawRectangle(new MCvScalar(0.255, 255));
                    }
                    else
                    {
                        Mat hsvreshold = getMask(img, Hmin, Hmax, Smin, Smax, Vmin, Vmax);
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

        private void btnFindColor_Click(object sender, EventArgs e)
        {
            Mat img = (imageIO1.InImage as Mat).Clone();
            Mat hsvreshold = getMask(img, hminbar.Value, hmaxbar.Value, sminbar.Value, smaxbar.Value, vminbar.Value, vmaxbar.Value);
            var vp = maxArea(hsvreshold);
            findrect = CvInvoke.BoundingRectangle(vp);
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
