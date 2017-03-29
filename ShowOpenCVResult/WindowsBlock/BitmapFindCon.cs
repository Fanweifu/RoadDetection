using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV.CvEnum;

namespace ShowOpenCVResult
{
    public partial class BitmapFindCon : MoveBlock
    {
        int selectIndex = -1;
        VectorOfVectorOfPoint cons = new VectorOfVectorOfPoint();
        VectorOfPoint m_modeLine ;
        Image<Bgr, Byte> filesrc;
        Image<Gray, Byte> filegray;
        Image<Gray, Byte> modeFile;
        private Emgu.CV.CvEnum.ContoursMatchType m_matchType = Emgu.CV.CvEnum.ContoursMatchType.I1;
        private List<double> m_i1 = new List<double>();
        private List<double> m_i2 = new List<double>();
        private List<double> m_i3 = new List<double>();

        public BitmapFindCon()
        {
            InitializeComponent();
        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {
            if (filesrc == null) return;
            if (imageIOControl1.Image1 != null)
            {
                imageIOControl1.Image1.Dispose();
            }
            Image<Gray, Byte> imgcan = new Image<Gray, Byte>(filesrc .Size);
            Image<Gray, Byte> gary = filesrc.Convert<Gray, Byte>();
            if (checkBox1.Checked)
            {
                CvInvoke.Canny(gary, imgcan, myTrackBar1.Value, myTrackBar2.Value);
            }
            else {
                imgcan = filegray;
            }
            Image<Bgr, Byte> img2 = filesrc.Clone();
            
           

            int[] b = null;
            cons = GetTreeData(imgcan, ref b,myTrackBar4.Value,myTrackBar5.Value, (double)myTrackBar3.Value / 100);
            EditNode(b,treeView1);
            imageIOControl1.Image1 = img2;
            img2.DrawPolyline(cons.ToArrayOfArray(), true, new Bgr(0,0,255));
            myTrackBar6.Enabled = false;
        }

        /// <summary>
        /// 获得轮廓
        /// </summary>
        /// <param name="image">灰度图</param>
        /// <param name="b">表达树状数据的数组</param>
        /// <returns>VectorOfVectorOfPoint类型的轮廓数据</returns>
        VectorOfVectorOfPoint GetTreeData(Image<Gray, Byte> image, ref int[] b, int minpts, int maxpts, double apppar = -1)
        {
            Mat he = new Mat();
            VectorOfVectorOfPoint cons = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(image, cons, he, Emgu.CV.CvEnum.RetrType.Tree, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
            b = new int[he.Cols * 4];
            he.CopyTo(b);
            int ccnt = cons.Size;
            List<int> dels = new List<int>();
            for (int i = 0; i < ccnt; i++)
            {
                if (cons[i].Size < minpts || cons[i].Size > maxpts)
                {
                    cons[i].Clear();
                    dels.Add(i);
                }
            }
            for (int i = 0; i < b.Count(); i++)
            {
                if (dels.Contains(i / 4))
                {
                    b[i] = -2;
                }
                if (dels.Contains(b[i]))
                {
                    b[i] = -1;
                }
            }



            if (apppar == -1)
                return cons;
            else
            {
                VectorOfVectorOfPoint apcons = new VectorOfVectorOfPoint();
                for (int i = 0; i <= cons.Size - 1; i++)
                {
                    VectorOfPoint vp = new VectorOfPoint();
                    if (cons[i].Size > 0)
                        CvInvoke.ApproxPolyDP(cons[i], vp, apppar, true);
                    apcons.Push(vp);
                }
                cons.Dispose();
                return apcons;
            }
        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            imageIOControl1.DoChange();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string path = OpencvForm.SelectImg();
            if (path == null) return;
            filesrc = new Image<Bgr, byte>(path);
            filegray = new Image<Gray, byte>(filesrc.Size);
            CvInvoke.Threshold(filesrc.Convert<Gray, Byte>(), filegray, 100,255, Emgu.CV.CvEnum.ThresholdType.Otsu);
            imageIOControl1.DoChange();
        }

        /// <summary>
        /// 将数组以树状显示在treeView1中
        /// </summary>
        /// <param name="a">数组</param>
        /// <param name="treeView1">控件</param>
        void EditNode(int[] a, TreeView treeView1)
        {
            treeView1.Nodes.Clear();
            int cnt = a.Count() / 4;
            TreeNode[] s = new TreeNode[cnt];
            for (int i = 0; i <= cnt - 1; i++) {
                s[i] = new TreeNode(i.ToString());
            }
            for (int i = 0; i < cnt; i++) {
                if (a[i * 4 + 3] == -1){
                        treeView1.Nodes.Add(s[i]);
                }
                    
                else {
                    if (a[i * 4 + 3]>=0&&!s[a[i * 4 + 3]].Nodes.Contains(s[i]) && s[i].Parent==null)
                        s[a[i * 4 + 3]].Nodes.Add(s[i]);
                }
            }

            for (int i = 0; i < cnt; i++)
            {
                if (a[i * 4 + 2] < 0) { 
                    
                }

                else
                {
                    if (!s[i].Nodes.Contains(s[a[i * 4 + 2]]) && s[a[i * 4 + 2]].Parent==null)
                        s[i].Nodes.Add(s[a[i * 4 + 2]]);
                }
            }

            for (int i = 0; i < cnt; i++)
            {
                if (a[i * 4] < 0)
                {

                }

                else
                {
                    if (s[i].Parent != null) {
                        s[a[i * 4]].Remove();
                        int index = s[i].Index;
                        s[i].Parent.Nodes.Insert(index + 1, s[a[i * 4]]);
                        
                    }
                }
            }
            for (int i = 0; i < cnt; i++)
            {
                if (a[i * 4+1] < 0 )
                {

                }

                else
                {
                    if (s[i].Parent != null)
                    {
                        s[a[i * 4 + 1]].Remove();
                        int index = s[i].Index;
                        s[i].Parent.Nodes.Insert(index, s[a[i * 4+1]]);

                    }
                }
            }

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int index = int.Parse(e.Node.Text);
            
            var img = filesrc.Clone();
            Point[] pts = cons.ToArrayOfArray()[index];
            img.DrawPolyline(pts, true, new Bgr(0, 255, 0), 2);

            if (tsbtnRotateRect.Checked)
            {
                var rr = CvInvoke.MinAreaRect(cons[index]);
                BaseFunc.DrawRotatedRect(rr, img);
                tsslblRectAngle.Text = rr.Angle.ToString("0.00");
                tsslblRectSize.Text = rr.Size.ToString();
            }

            if (tsbtnWeightCentre.Checked)
            {
                var moment = CvInvoke.Moments(cons[index]);
                Point p = new Point((int)(moment.M10 / moment.M00), (int)(moment.M01 / moment.M00));
                CvInvoke.Circle(img, p, 1, new MCvScalar(255, 0, 0));
            }

            if (tsbtnFitLine.Checked)
            {
                PointF dir = new PointF(), point = new PointF();
                Point[] pt = cons[index].ToArray();
                int cnt = pt.Count();
                PointF[] ptf = new PointF[cnt];
                for (int i = 0; i < cnt; i++)
                {
                    ptf[i] = new PointF(pt[i].X, pt[i].Y);
                }
                CvInvoke.FitLine(ptf, out dir, out point, DistType.C,0, 0.01,0.01);
                CvInvoke.Line(img, new Point((int)point.X, (int)point.Y), new Point((int)(point.X + dir.X), (int)(point.Y + dir.Y)),new MCvScalar(0,0,255));
            }
            

            selectIndex = index;
            Calfam(cons[index]);

            if (imageIOControl1.Image1 != null) imageIOControl1.Image1.Dispose();
            imageIOControl1.Image1 = img;

            if (tsbtnLookWhenSelect.Checked)
            {
                Mat a = BaseFunc.GetSquareExampleImg(cons[index], filesrc.Size);

                new Thread(() =>
                {
                    ImageViewer.Show(a);
                }
                ).Start();
            }


            
        }

        private void Calfam(VectorOfPoint vp) {
            if (m_modeLine != null && m_modeLine.Size > 0)
            {
                double val = CvInvoke.MatchShapes(vp, m_modeLine, m_matchType);
                tslblFm.Text = val.ToString("0.000");
   
            }
        
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string path = OpencvForm.SelectImg();
            if(path==null) return;
            modeFile =ExtensionImg( new Image<Gray, byte>(path));
            VectorOfPoint vp = GetModelLine(modeFile);
            if (vp == null) return;
            m_modeLine = new VectorOfPoint();
            CvInvoke.ApproxPolyDP(vp, m_modeLine, (double)myTrackBar3.Value /100, true);
            tslblModeFilePath.Text = path;
             Image<Bgr, byte> draw = modeFile.Clone().Convert<Bgr,byte>() ;
             draw.DrawPolyline(m_modeLine.ToArray(), true, new Bgr(0,0,255),3);
             imageIOControl1.Image2 = draw;
             groupBox1.Enabled = true;
        }

        public VectorOfPoint GetModelLine(Image<Gray,Byte> input, int minpts =10,int maxpts = 3000) {
            Image<Gray, Byte> bin = input.ThresholdBinary(new Gray(100), new Gray(255));
            VectorOfVectorOfPoint lines = new VectorOfVectorOfPoint();

            CvInvoke.FindContours(bin, lines, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < lines.Size; i++) {
                int cnt = lines[i].Size;
                if (cnt > minpts && cnt < maxpts) {
                    return lines[i];
                }
            }
            return null;
        }

        public Image<Gray, Byte> ExtensionImg( Image<Gray, Byte> inputImg,int exsize = 10) {
            Image<Gray, Byte> eximg = new Image<Gray, byte>(inputImg.Width + exsize * 2, inputImg.Height + exsize * 2);
            for (int i = 0; i < inputImg.Height; i++)
                for (int j = 0; j < inputImg.Width; j++)
                {
                    eximg[i + exsize, j + exsize] = inputImg[i, j];
                }
            return eximg;
        }

        private void i1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_matchType = Emgu.CV.CvEnum.ContoursMatchType.I1;
            toolStripSplitButton1.Text = "I1";
            Calfam(cons[selectIndex]);
        }

        private void i2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_matchType = Emgu.CV.CvEnum.ContoursMatchType.I2;
            toolStripSplitButton1.Text = "I2";
            Calfam(cons[selectIndex]);
        }

        private void i3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_matchType = Emgu.CV.CvEnum.ContoursMatchType.I3;
            toolStripSplitButton1.Text = "I3";
            Calfam(cons[selectIndex]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cons==null||cons.Size==0) return;
            if(m_modeLine==null||m_modeLine.Size ==0) return;
            switch (m_matchType) {
                case Emgu.CV.CvEnum.ContoursMatchType.I1:
                    m_i1.Clear();
                    for (int i = 0; i < cons.Size; i++) {
                        m_i1.Add(CvInvoke.MatchShapes(cons[i], m_modeLine, m_matchType));
                    }
                    break;
                case Emgu.CV.CvEnum.ContoursMatchType.I2:
                      m_i2.Clear();
                    for (int i = 0; i < cons.Size; i++) {
                        m_i2.Add(CvInvoke.MatchShapes(cons[i], m_modeLine, m_matchType));
                    }
                    break;
                case Emgu.CV.CvEnum.ContoursMatchType.I3:
                    m_i3.Clear();
                    for (int i = 0; i < cons.Size; i++)
                    {
                        m_i3.Add(CvInvoke.MatchShapes(cons[i], m_modeLine, m_matchType));
                    }
                    break;
            }
            myTrackBar6.Enabled = true;
        }

        private void myTrackBar6_ValueChanged(object sender, EventArgs e)
        {
            Image<Bgr, Byte> selectimg = filesrc.Clone();
            switch(m_matchType){
                case Emgu.CV.CvEnum.ContoursMatchType.I1:
                    for (int i = 0; i < cons.Size; i++) {
                        if (m_i1[i] < (double)myTrackBar6.Value / 100) {
                            selectimg.DrawPolyline(cons[i].ToArray(), true, new Bgr(0, 255, 255), 2);
                        }
                    }
                break;
                case Emgu.CV.CvEnum.ContoursMatchType.I2:
                for (int i = 0; i < cons.Size; i++)
                {
                    if (m_i2[i] < (double)myTrackBar6.Value / 100)
                    {
                        selectimg.DrawPolyline(cons[i].ToArray(), true, new Bgr(0, 255, 255), 2);
                    }
                }
                break;
                case Emgu.CV.CvEnum.ContoursMatchType.I3:
                for (int i = 0; i < cons.Size; i++)
                {
                    if (m_i3[i] < (double)myTrackBar6.Value / 100)
                    {
                        selectimg.DrawPolyline(cons[i].ToArray(), true, new Bgr(0, 255, 255), 2);
                    }
                }
                break;

            
            }
            if (imageIOControl1.Image1 != null) imageIOControl1.Image1.Dispose();
            imageIOControl1.Image1 = selectimg;
        }

        private void imageIOControl1_AfterImgLoaded(object sender, EventArgs e)
        {
            filesrc = (imageIOControl1.Image1 as Image<Bgr, Byte>).Clone();
            filegray = filesrc.Convert<Gray, Byte>();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (cons != null && selectIndex < cons.Size) { 
                using(SaveFileDialog sf = new SaveFileDialog()){
                    sf.Title = "生成轮廓像素图";
                    sf.Filter = "(PNG)*.png|*.png";
                    if (sf.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

                    Mat result = BaseFunc.GetSquareExampleImg(cons[selectIndex], filesrc.Size);
                    result.ToImage<Bgr, Byte>().Save(sf.FileName);
                }
            }
        }

        private void myTrackBar2_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (cons == null) return;
            long time = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Mat result = BaseFunc.JugdeTest(cons, filesrc.Mat, ref time);
            sw.Stop();
            MessageBox.Show(string.Format("耗时{0}毫秒", sw.ElapsedMilliseconds));

            if (imageIOControl1.Image1 != null) imageIOControl1.Image1.Dispose();
            imageIOControl1.Image1 = result;
        }
    }
}
