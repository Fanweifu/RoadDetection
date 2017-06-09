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
            imageBoxInput.DragDrop+= imageBox1_DragDrop;
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

        [DefaultValue(true)]
        public bool AutoDispose
        {
            get;
            set;
        }

        public IImage InImage
        {
            get
            {
                return imageBoxInput.Image;
            }
            set
            {
                if (imageBoxInput.Image!=null&&AutoDispose)
                {
                    imageBoxInput.Image.Dispose();
                }

                imageBoxInput.Image = value;
            }
        }
        public IImage OutImage
        {
            get
            {
                return imageBoxOutput.Image;
            }
            set
            {
                if (imageBoxOutput.Image != null && AutoDispose)
                {
                    imageBoxOutput.Image.Dispose();
                }


                imageBoxOutput.Image = value;
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
            imageBoxInput.Image = img;
            onAfterImgLoaded();
            DoChange();
        }

        public void DoChange() {
            if(DoImgChange!=null)
                DoImgChange.Invoke(this, null);
        }

    }
}
