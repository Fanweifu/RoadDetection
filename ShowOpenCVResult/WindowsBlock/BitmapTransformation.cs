using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace ShowOpenCVResult
{
    public partial class BitmapTransformation :MoveBlock
    {
        public BitmapTransformation()
        {
            InitializeComponent();
        }

        private void tsbtnOpenImg_Click(object sender, EventArgs e)
        {
            string path = OpencvForm.SelectImg();
            if (path == null) return;
            imageIOControl1.SetInput(new Image<Bgr,Byte>(path));
            numericUpDown_ValueChanged(null, null);
            
        }

        

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.imageIOControl1.DoChange();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            lbAX.Tag = nudAX.Value;
            lbAX.Text = string.Format("anchor-X:{0}", lbAX.Tag);
            lbAY.Tag = nudAY.Value;
            lbAY.Text = string.Format("anchor-Y:{0}", lbAY.Tag);
            lbOW.Tag = nudOW.Value;
            lbOW.Text = string.Format("output-Width:{0}", lbOW.Tag);
            lbOH.Tag = nudOH.Value;
            lbOH.Text = string.Format("output-Height:{0}", lbOH.Tag);
            lbLT.Tag = nudLT.Value;
            lbLT.Text = string.Format("LT:{0}", lbLT.Tag);
            tsbtnMultyDeal.Enabled = true;
        }

        private void tsbtnMultyDeal_Click(object sender, EventArgs e)
        {
            string[] filenames = OpencvForm.SelectImgs();
            if (filenames == null) return;

            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Maximum = filenames.Count();
            toolStripProgressBar1.Value = 0;
            MessageBox.Show(string.Format("已选择{0}个需转换文件,请选择输出目录", toolStripProgressBar1.Maximum));

            string dire = null;
            using (FolderBrowserDialog fd = new FolderBrowserDialog()) {
                fd.Description = "请选择文件夹";
                if (fd.ShowDialog() == DialogResult.OK || fd.ShowDialog() == DialogResult.Yes)
                {
                    dire = fd.SelectedPath;
                }
            }

            new Thread(() =>
            {
                try
                {
                    foreach (string str in filenames)
                    {
                        Bitmap result = null;// GclrOpencvProces.BitmapTransformation(new Bitmap(str), (double)(decimal)lbLT.Tag / 100, (double)(decimal)lbAX.Tag / 100, (double)(decimal)lbAY.Tag / 100, (int)(decimal)lbOW.Tag, (int)(decimal)lbOH.Tag);
                        string outpath = string.Format("{0}\\{1}_TRANSFORMAT{2}", dire, Path.GetFileNameWithoutExtension(str), Path.GetExtension(str));
                        if (File.Exists(outpath))
                            File.Delete(outpath);
                        result.Save(outpath);

                        Invoke(new Action(() => { toolStripProgressBar1.Value++; }));
                    }
                }
                catch (Exception ex) {
                    Invoke(new Action(() => { MessageBox.Show("文件读写出错:" + ex.ToString()); }));
                }

                Thread.Sleep(200);
                Invoke(new Action(() => { toolStripProgressBar1.Visible = false; }));
            }).Start();
        }
        

        private void BitmapTransformation_Load(object sender, EventArgs e)
        {
            //DirectoryInfo di = new DirectoryInfo(@"E:\Users\fwf\Desktop\实习素材\Tran3");
            //FileInfo[] fs = di.GetFiles();
            //int i = 0;
            //foreach (FileInfo f in fs)
            //{
            //    if (Path.GetExtension(f.Name).Equals(".jpg"))
            //    {
            //        string outpath = string.Format("{0}\\{1}{2}", Path.GetDirectoryName(f.FullName), Path.GetFileNameWithoutExtension(f.FullName), ".jgw");
            //        File.WriteAllLines(outpath, new string[6] { "1", "0", "0", "-1", "0", (i * 512).ToString() });
            //        i++;
            //    }
            //}
        }


        private void dibSrc_DragDrop(object sender, DragEventArgs e)
        {
            numericUpDown_ValueChanged(null, null);
        }

        private void imageIOControl1_DoImgChange(object sender, EventArgs e)
        {
            if (imageIOControl1.Image1 == null) return;
            if (imageIOControl1.Image2 != null) {
                imageIOControl1.Image2.Dispose();
             }
            Image<Bgr, Byte> img = imageIOControl1.Image2 as Image<Bgr, Byte>;
            BaseFunc.AnchorTransformat<Bgr, Byte>(imageIOControl1.Image1 as Image<Bgr, Byte>, ref img, (float)nudAX.Value / 100, (float)nudAY.Value / 100, (float)nudLT.Value / 100, (int)nudOW.Value, (int)nudOH.Value);
                //imageIOControl1.OutputImage = GclrOpencvProces.BitmapTransformation(imageIOControl1.InputImage as Bitmap, TDepth, (double)nudAX.Value / 100, (double)nudAY.Value / 100, (int)nudOW.Value, (int)nudOH.Value);
             imageIOControl1.Image2 = img;
        }

        private void imageIOControl1_AfterImgLoaded(object sender, EventArgs e)
        {
          
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
