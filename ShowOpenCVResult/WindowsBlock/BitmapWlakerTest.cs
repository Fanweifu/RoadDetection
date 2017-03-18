using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowOpenCVResult
{
    public partial class BitmapWlakerTest : MoveBlock
    {
        public BitmapWlakerTest()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var input = OpencvForm.GetImage();
            if (input == null) return;
            imageIO1.SetInput((input as Image<Bgr, Byte>));
            int time=0;
            imageIO1.Image2=PedestrianDetection.FindPedestrian.Run((imageIO1.Image1 as Image<Bgr, Byte>).Mat,out time);
        }

        
        

    }
}
