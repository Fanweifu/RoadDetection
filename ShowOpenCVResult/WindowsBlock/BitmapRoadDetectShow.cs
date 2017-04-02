using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Emgu.CV.CvEnum;

namespace ShowOpenCVResult
{
    public partial class BitmapRoadDetectShow : MoveBlock
    {
        Thread playthead = null ;
        long timesum=0;
        int playcnt = 0;
        string [] exs = new string[] { ".jpg",".png",".bmp","jpeg"};

        public BitmapRoadDetectShow()
        {
            InitializeComponent();
        }

        List<string> imgspath = new List<string>();
        List<Mat> mats = new List<Mat>();
        ManualResetEvent mr = new ManualResetEvent(false);
        

        private void tsbtnOpenImg_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fb = new FolderBrowserDialog()) {
                if (fb.ShowDialog() != DialogResult.OK) return;
                DirectoryInfo dt = new DirectoryInfo(fb.SelectedPath);
                foreach (FileInfo fi in dt.GetFiles()) {
                    if (exs.Contains(fi.Extension)) {
                        imgspath.Add(fi.FullName);
                    }
                }
                toolStripProgressBar1.Maximum = imgspath.Count;
                toolStripProgressBar1.Value = 0;
                toolStripButton2.Enabled = true;
                InitPlay();
            }

        }


        void InitPlay()
        {
            playthead = new Thread(() =>
            {

                foreach (var path in imgspath)
                {
                    Mat matimg = new Mat(path, LoadImageType.Unchanged);
                    if (imageIOControl1.Image1 != null)
                        imageIOControl1.Image1.Dispose();
                    imageIOControl1.Image1 = matimg;
                    long time = 0;
                    Mat road = null;
                    Mat result = OpencvMath.FinalLineProcess(matimg, out time ,out road , true);
                    var vpp = OpencvMath.WalkRoadImg(result);
                    for (int i = 0; i < vpp.Size; i++)
                    {
                        OpencvMath.DrawRotatedRect(CvInvoke.MinAreaRect(vpp[i]), result);
                    }
                    if (imageIOControl1.Image2 != null)
                        imageIOControl1.Image2.Dispose();
                    imageIOControl1.Image2 = result;
                    playcnt++;
                    timesum += time;

                    Thread.Sleep(1000);


                    Invoke(new Action(() => {
                        toolStripStatusLabel2.Text = string.Format("总体耗时:{0}ms,播放帧数{1},平均耗时{2}", timesum, playcnt, timesum / playcnt);
                    }));
                }

            });



            

        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }

        private void drawImageBox1_DragDrop(object sender, DragEventArgs e)
        {
            myTrackBar1_ValueChanged(null, null);
        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIOControl1.Image1 == null) return;
            if (imageIOControl1.Image2 != null) imageIOControl1.Image2.Dispose();



        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            playthead.Start();


        }

        }
}
