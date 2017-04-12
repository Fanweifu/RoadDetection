using Emgu.CV;
using Emgu.CV.Stitching;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowOpenCVResult
{
    public partial class Stitching : MoveBlock
    {
        OrbFeaturesFinder _orb = new OrbFeaturesFinder(new Size(3,1));
        Stitcher _sticher = new Stitcher(false);
        
        VectorOfMat sti_image = new VectorOfMat();
        public Stitching()
        {
            InitializeComponent();
            _sticher.SetFeaturesFinder(_orb);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string[] files = OpencvForm.SelectImgs();
            if (files == null) return;

            LoadImgs(files);
            toolStripButton2.Enabled = true;
        }

        void LoadImgs(string [] files) {
            sti_image.Clear();
            treeView1.Nodes.Clear();
            
            int cnt = files.Count();
            for (int i = 0; i < cnt;i++ )
            {
                Image<Bgr, Byte> img = new Image<Bgr, byte>(files[i]);
                sti_image.Push(img.Mat);
                treeView1.Nodes.Add(new TreeNode(Path.GetFileName(files[i])));
            }
            treeView1.SelectedNode = treeView1.Nodes[0];
            imageIOControl1.Image1 = sti_image[0];

         
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int index = e.Node.Index;
            if (index < sti_image.Size)
            {
                imageIOControl1.Image1 = sti_image[index];
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Mat outmat = new Mat();
            if (_sticher.Stitch(sti_image, outmat))
            {
                imageIOControl1.Image2 = outmat;
            }
            else
            {
                MessageBox.Show("拼接失败", "提示");
            }
        }

        private void myTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            _orb.Dispose();
            _orb = new OrbFeaturesFinder(new Size(myTrackBar4.Value, myTrackBar5.Value), myTrackBar1.Value, (float)myTrackBar3.Value / 100, myTrackBar2.Value);
            _sticher.SetFeaturesFinder(_orb);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            imageIOControl1.Image2 = null;
        }
    }
}
