using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;

namespace ShowOpenCVResult
{
    public partial class ImageIO : UserControl
    {
        public ImageIO()
        {
            InitializeComponent();
            imageBox1.DargOnNull = false;
            imageBox1.DragDrop+= imageBox1_DragDrop;
        }

        public Orientation SpOrientation
        {
            get
            {
                return splitContainer1.Orientation;
            }
            set
            {
                splitContainer1.Orientation = value;
            }

        }

        public IImage Image1 {
            get {
                return imageBox1.Image;
            }
            set
            {
                imageBox1.Image = value;
            }
        }



        public IImage Image2
        {
            get
            {
                return imageBox2.Image;
            }
            set
            {
                imageBox2.Image = value;
            }
        }


        public event EventHandler DoImgChange;
        public event EventHandler AfterImgLoaded;
        private void splitContainer1_Resize(object sender, EventArgs e)
        {
          
        }
        private void onAfterImgLoaded() {
            if (AfterImgLoaded != null) {
                AfterImgLoaded(this,new EventArgs());
            }
        }

        private void imageBox1_DragDrop(object sender, DragEventArgs e)
        {
            onAfterImgLoaded();
            DoChange();

        }

        public void SetInput(IImage img) {
            if (img == null) return;
            imageBox1.Image = img;
            onAfterImgLoaded();
            DoChange();

        }
        public void DoChange() {
            if (DoImgChange != null)
            {
                DoImgChange(this, null);
            }
        }

    }
}
