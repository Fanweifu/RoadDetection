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
    public partial class FindContours : MoveBlock
    {
        int selectIndex = -1;
        VectorOfVectorOfPoint cons = new VectorOfVectorOfPoint();
        VectorOfVectorOfPoint vvp = new VectorOfVectorOfPoint();
        List<int> dels = new List<int>();
        VectorOfPoint m_modeLine ;
        Image<Bgr, byte> m_filesrc;
        Image<Gray, byte> m_filegray;
        Image<Gray, byte> m_modeFile;
        Mat layerstrcut = null;
        private List<double> m_i1 = new List<double>();
        private List<double> m_i2 = new List<double>();
        private List<double> m_i3 = new List<double>();

        public FindContours()
        {
            InitializeComponent();
        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {
            if (m_filesrc == null) return;

            Image<Gray, byte> imgcan = m_filegray.Clone();
            Image<Bgr, byte> imgback = m_filesrc.Clone();
            CvInvoke.Threshold(imgcan, imgcan, 240, 255, ThresholdType.Binary);
            cons = GetTreeData(imgcan,out layerstrcut, (double)myTrackBar3.Value / 100);
            doSelect();
            imgcan.Dispose();

            CvInvoke.DrawContours(imgback, cons, -1, new MCvScalar(0, 0, 255), 2, LineType.FourConnected);

            if (imageIOControl1.Image1 != null)
            {
                imageIOControl1.Image1.Dispose();
            }

            imageIOControl1.Image1 = imgback;
            
            myTrackBar6.Enabled = false;
        }

        /// <summary>
        /// 获得轮廓
        /// </summary>
        /// <param name="image">灰度图</param>
        /// <param name="b">表达树状数据的数组</param>
        /// <returns>VectorOfVectorOfPoint类型的轮廓数据</returns>
        VectorOfVectorOfPoint GetTreeData(Image<Gray, byte> image, out Mat hirerarchy, double apppar = -1)
        {
            hirerarchy = new Mat();
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(image, contours, hirerarchy, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
            if (apppar != -1)
            {
                for (int i = 0; i <contours.Size ; i++)
                {
                    if (contours[i].Size > 0)
                        CvInvoke.ApproxPolyDP(contours[i], contours[i], apppar, true);
                }
            }
            return contours;
        }

        void selectCons(VectorOfVectorOfPoint vvp, Mat hirerarchy ,int minarea ,int maxarea,int minlength,int maxlength,double minarearate, ref int[] array) {
            if (vvp == null || vvp.Size == 0) return;
            if (hirerarchy == null || hirerarchy.IsEmpty) return;
            int [] resultarray  = new int[hirerarchy.Cols * 4];
            hirerarchy.CopyTo(resultarray);
            dels.Clear();

            for (int i = 0; i < vvp.Size; i++)
            {
                double area = CvInvoke.ContourArea(vvp[i]);
                double length = CvInvoke.ArcLength(vvp[i], true);
                var rect = CvInvoke.MinAreaRect(vvp[i]);
                double rate = area / (rect.Size.Width * rect.Size.Height);
                bool isneed = area >= minarea && area <= maxarea && length >= minlength && length <= maxlength && rate >= minarearate;

                if (!isneed)
                {
                    dels.Add(i);
                }
            }

            int bcnt = resultarray.Count();
            for (int i = 0; i < bcnt; i++)
            {
                if (dels.Contains(i / 4))
                {
                    resultarray[i] = -2;
                }
                if (dels.Contains(resultarray[i]))
                {
                    resultarray[i] = -1;
                }
            }
            array = resultarray;
        }

        void doSelect() {
            if (cons == null || cons.Size == 0) return;
            int[] result = null;
            selectCons(cons, layerstrcut, myTrackBar4.Value, myTrackBar5.Value, myTrackBar1.Value, myTrackBar2.Value, (double)myTrackBar7.Value/100, ref result);
            editNode(result, treeView1);
            var img = m_filesrc.Clone();


        }

        private void myTrackBarEpsilon_ValueChanged(object sender, EventArgs e)
        {
            if (m_filesrc == null || cons == null || cons.Size == 0) return;

            vvp = new VectorOfVectorOfPoint();
            for (int i = 0; i < cons.Size; i++)
            {
                if (cons[i].Size > 0)
                {
                    VectorOfPoint vp = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(cons[i], vp, (double)myTrackBar3.Value / 100, true);
                    vvp.Push(vp);
                }
            }
            var imgback = m_filesrc.Clone();

            CvInvoke.DrawContours(imgback, vvp, -1, new MCvScalar(0, 0, 255), 2, LineType.FourConnected);

            if (imageIOControl1.Image1 != null)
            {
                imageIOControl1.Image1.Dispose();
            }

            imageIOControl1.Image1 = imgback;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string path = OpencvForm.SelectImg();
            if (path == null) return;
            m_filesrc = new Image<Bgr, byte>(path);
            m_filegray = new Image<Gray, byte>(m_filesrc.Size);
            CvInvoke.Threshold(m_filegray, m_filegray,10 ,255, ThresholdType.Otsu);
            imageIOControl1.DoChange();
        }

        /// <summary>
        /// 将数组以树状显示在treeView1中
        /// </summary>
        /// <param name="a">数组</param>
        /// <param name="treeView1">控件</param>
        void editNode(int[] a, TreeView treeView1)
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
            int index = 0;
            if (!int.TryParse(e.Node.Text, out index)) return;
            
            var img = m_filesrc.Clone();
            CvInvoke.DrawContours(img, cons, index, new MCvScalar(0, 255, 0), 2);

            if (tsbtnRotateRect.Checked)
            {
                var rr = CvInvoke.MinAreaRect(cons[index]);
                OpencvMath.DrawRotatedRect(rr, img);
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
                Mat a = OpencvMath.GetSquareExampleImg(cons[index], m_filesrc.Size);

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
                double val = CvInvoke.MatchShapes(vp, m_modeLine, (ContoursMatchType)comboBox1.SelectedItem) ;
                tslblFm.Text = val.ToString("0.000");
   
            }
        
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string path = OpencvForm.SelectImg();
            if (path == null) return;
            m_modeFile = extensionImg(new Image<Gray, byte>(path));
            VectorOfPoint vp = getModelLine(m_modeFile);
            if (vp == null) return;
            m_modeLine = new VectorOfPoint();
            CvInvoke.ApproxPolyDP(vp, m_modeLine, (double)myTrackBar3.Value / 100, true);
            tslblModeFilePath.Text = path;
            Image<Bgr, byte> draw = m_modeFile.Clone().Convert<Bgr, byte>();
            draw.DrawPolyline(m_modeLine.ToArray(), true, new Bgr(0, 0, 255), 3);
            imageIOControl1.Image2 = draw;
            groupBox1.Enabled = true;
        }

        VectorOfPoint getModelLine(Image<Gray,byte> input, int minpts =10,int maxpts = 3000) {
            Image<Gray, byte> bin = input.ThresholdBinary(new Gray(100), new Gray(255));
            VectorOfVectorOfPoint lines = new VectorOfVectorOfPoint();

            CvInvoke.FindContours(bin, lines, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < lines.Size; i++) {
                int cnt = lines[i].Size;
                if (cnt > minpts && cnt < maxpts) {
                    return lines[i];
                }
            }
            return null;
        }

        Image<Gray, byte> extensionImg( Image<Gray, byte> inputImg,int exsize = 10) {
            Image<Gray, byte> eximg = new Image<Gray, byte>(inputImg.Width + exsize * 2, inputImg.Height + exsize * 2);
            for (int i = 0; i < inputImg.Height; i++)
                for (int j = 0; j < inputImg.Width; j++)
                {
                    eximg[i + exsize, j + exsize] = inputImg[i, j];
                }
            return eximg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cons==null||cons.Size==0) return;
            if(m_modeLine==null||m_modeLine.Size ==0) return;

            switch ((ContoursMatchType)comboBox1.SelectedItem) {

                case ContoursMatchType.I1:
                    m_i1.Clear();
                    for (int i = 0; i < cons.Size; i++) {
                        m_i1.Add(CvInvoke.MatchShapes(cons[i], m_modeLine, ContoursMatchType.I1));
                    }
                    myTrackBar6.Maximum = (int)(m_i1.Max() * 100);
                    break;
                case ContoursMatchType.I2:
                      m_i2.Clear();
                    for (int i = 0; i < cons.Size; i++) {
                        m_i2.Add(CvInvoke.MatchShapes(cons[i], m_modeLine, ContoursMatchType.I2));
                    }
                    myTrackBar6.Maximum = (int)(m_i2.Max() * 100);
                    break;
                case ContoursMatchType.I3:
                    m_i3.Clear();
                    for (int i = 0; i < cons.Size; i++)
                    {
                        m_i3.Add(CvInvoke.MatchShapes(cons[i], m_modeLine, ContoursMatchType.I3));
                    }
                    myTrackBar6.Maximum = (int)(m_i3.Max() * 100);
                    break;
            }
            myTrackBar6.Enabled = true;
        }

        private void myTrackBar6_ValueChanged(object sender, EventArgs e)
        {
            Image<Bgr, byte> selectimg = m_filesrc.Clone();
            switch((ContoursMatchType)comboBox1.SelectedItem){
                case ContoursMatchType.I1:
                    for (int i = 0; i < cons.Size; i++) {
                        if (m_i1[i] < (double)myTrackBar6.Value / 100) {
                            selectimg.DrawPolyline(cons[i].ToArray(), true, new Bgr(0, 255, 255), 2);
                        }
                    }
                break;
                case ContoursMatchType.I2:
                for (int i = 0; i < cons.Size; i++)
                {
                    if (m_i2[i] < (double)myTrackBar6.Value / 100)
                    {
                        selectimg.DrawPolyline(cons[i].ToArray(), true, new Bgr(0, 255, 255), 2);
                    }
                }
                break;
                case ContoursMatchType.I3:
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
            m_filesrc = (imageIOControl1.Image1 as Image<Bgr, byte>).Clone();
            m_filegray = m_filesrc.Convert<Gray, byte>();
            myTrackBar4.Maximum = m_filesrc.Width * m_filesrc.Height/2;
            myTrackBar4.Value = 0;
            myTrackBar5.Maximum = m_filesrc.Width * m_filesrc.Height;
            myTrackBar5.Value = m_filesrc.Width * m_filesrc.Height;
            myTrackBar1.Maximum = 100;
            myTrackBar1.Value = 0;
            myTrackBar2.Maximum = (m_filesrc.Width + m_filesrc.Height)*2;
            myTrackBar2.Value = (m_filesrc.Width + m_filesrc.Height) * 2;
            myTrackBar7.Maximum = 100;
            myTrackBar7.Value = 0;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (cons != null && selectIndex < cons.Size)
            {
                Mat result = OpencvMath.GetSquareExampleImg(cons[selectIndex], m_filesrc.Size);
                imageIOControl1.Image2 = result;
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (cons == null) return;
            long time = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Mat result = OpencvMath.JugdeTest(cons, m_filesrc.Mat, ref time);
            sw.Stop();
            MessageBox.Show(string.Format("耗时{0}毫秒", sw.ElapsedMilliseconds));

            if (imageIOControl1.Image1 != null) imageIOControl1.Image1.Dispose();
            imageIOControl1.Image1 = result;
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            if (m_filesrc == null) return;
            Image<Gray, byte> gray = m_filesrc.Convert<Gray, byte>();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            VectorOfVectorOfPoint vvp = OpencvMath.WalkRoadImg(gray.Mat);
            for (int i = 0; i < vvp.Size; i++)
            {
                Point[] pts = vvp[i].ToArray();
                int cnt = pts.Count();
                OpencvMath.DrawRotatedRect(CvInvoke.MinAreaRect(vvp[i]), gray);
                for (int j = 0; j < cnt; j++)
                {
                    CvInvoke.Circle(gray, pts[j], 3, new MCvScalar(200), 3);
                }

            }
        
            sw.Stop();
            MessageBox.Show(string.Format("耗时:{0}", sw.ElapsedMilliseconds));
            imageIOControl1.Image2 = gray;
        }

        private void FindContours_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = Enum.GetValues(typeof(ContoursMatchType));
        }

        private void myTrackBar5_ValueChanged(object sender, EventArgs e)
        {
            if (cons == null) return;
            var img = m_filesrc.Clone();

            doSelect();
            for (int i = 0; i < cons.Size; i++)
            {
                if (dels != null && dels.Contains(i)) continue;
                CvInvoke.DrawContours(img, vvp , i, new MCvScalar(0, 0, 255), 2);
       
            }
            if (imageIOControl1.Image1!=null)
            {
                imageIOControl1.Image1.Dispose();   
            }
            imageIOControl1.Image1 = img;
        }

    }
}
