using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Emgu.CV.UI;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ShowOpenCVResult
{
    public partial class DrawImageBox : ImageBox
    {

        public bool DargOnNull
        {
            get;
            set;
        }

       
        Rectangle m_Rectangle;
        public DrawImageBox()
        {
            InitializeComponent();
            AllowDrop = true;
            SizeMode = PictureBoxSizeMode.Zoom;
            BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            DargOnNull = true;
            this.MouseDown += DrawImageBox_MouseDown;
            this.MouseMove += DrawImageBox_MouseMove;
            this.DragEnter += DrawImageBox_DragEnter;
            this.DragDrop += DrawImageBox_DragDrop;
            this.DragLeave+= DrawImageBox_DragLeave;
        }

        void DrawImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Image == null) return;
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {

                this.DoDragDrop(this.Image.Bitmap, DragDropEffects.All | DragDropEffects.Link);
            }
            
        }

        void DrawImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Image != null)
            {
                Size dragSize = SystemInformation.DragSize;
                m_Rectangle = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else {
                m_Rectangle = Rectangle.Empty;
            }
        }

        void DrawImageBox_DragDrop(object sender, DragEventArgs e)
        {
            if (Image != null && DargOnNull) return;

            if (e.Effect == DragDropEffects.Copy || e.Effect == DragDropEffects.Move)
            {
                if (e.Data.GetDataPresent(DataFormats.Bitmap))
                {

                    Object item = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                    if (item == null) return;
                    Image = new Emgu.CV.Image<Bgr,Byte>(item as Bitmap);
                    this.Focus();
                }

                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] files = e.Data.GetData(DataFormats.FileDrop, false) as string[];
                    string[] exs = new string[4] { ".jpg", ".bmp", ".png",".jpeg" };
                    if (exs.Contains(Path.GetExtension(files[0]))) {
                        Image = new Emgu.CV.Image<Bgr, Byte>(files[0]);
                        this.Focus();
                    }
                }
            }

        }
        void DrawImageBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) || e.Data.GetDataPresent(DataFormats.Bitmap))  
                e.Effect = DragDropEffects.Move;
        }

        void DrawImageBox_DragLeave(object sender, EventArgs e)
        {
            if (this.Image != null)
            {
                this.DoDragDrop(this.Image.Bitmap, DragDropEffects.All | DragDropEffects.Link);
            }

        }

        protected Point TranslateZoomMousePosition(Point coordinates)
        {
            if (Image == null) return coordinates;
            // Make sure our control width and height are not 0 and our 
            // image width and height are not 0
            if (Width == 0 || Height == 0 || Image.Size.Width == 0 || Image.Size.Height == 0) return coordinates;
            // This is the one that gets a little tricky. Essentially, need to check 
            // the aspect ratio of the image to the aspect ratio of the control
            // to determine how it is being rendered
            float imageAspect = (float)Image.Size.Width / Image.Size.Height;
            float controlAspect = (float)Width / Height;
            float newX = coordinates.X;
            float newY = coordinates.Y;
            if (imageAspect > controlAspect)
            {
                // This means that we are limited by width, 
                // meaning the image fills up the entire control from left to right
                float ratioWidth = (float)Image.Size.Width / Width;
                newX *= ratioWidth;
                float scale = (float)Width / Image.Size.Width;
                float displayHeight = scale * Image.Size.Height;
                float diffHeight = Height - displayHeight;
                diffHeight /= 2;
                newY -= diffHeight;
                newY /= scale;
            }
            else
            {
                // This means that we are limited by height, 
                // meaning the image fills up the entire control from top to bottom
                float ratioHeight = (float)Image.Size.Height / Height;
                newY *= ratioHeight;
                float scale = (float)Height / Image.Size.Height;
                float displayWidth = scale * Image.Size.Width;
                float diffWidth = Width - displayWidth;
                diffWidth /= 2;
                newX -= diffWidth;
                newX /= scale;
            }
            return new Point((int)newX, (int)newY);
        }


    }

//    public partial class Form1 : Form { 
//        public Form1() 
//        { 
//            //InitializeComponent();
//            foreach (Control c in this.Controls) 
//            { if (c is PictureBox) 
//            { c.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove); 
//                c.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown); 
//            } 
//            } 
//        } 
//        private void Form1_Load(object sender, EventArgs e) 
//        { this.pictureBox1.Image = Image.FromFile(@"E:\Images\test.jpg"); } 
        
//        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
//        { if (wselected) 
//        { driftX = p.X - e.X;
//            driftY = p.Y - e.Y;
//            mx = mx - driftX;
//            my = my - driftY; 
//            Bitmap JPEG = new Bitmap(this.pictureBox1.Image);
//            Graphics g = pictureBox1.CreateGraphics();
//            g.Clear(pictureBox1.BackColor);
//            g.DrawImage(JPEG, mx, my);
//            p.X = e.X; 
//            p.Y = e.Y; 
//            JPEG.Dispose(); 
//            g.Dispose();/*图像移动的距离*/ } } 
//        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) 
//        { pictureBox1.Cursor = Cursors.Hand; /*按下鼠标时，将鼠标形状改为手型*/
//            wselected = true; p.X = e.X; p.Y = e.Y; } 
//        private void button1_Click(object sender, EventArgs e) 
//        { Graphics g = this.CreateGraphics();//生成图形对象
//            SolidBrush BlueBrush = new SolidBrush(Color.Blue);//生成填充用的画刷
//            int x = 15;//定义外接矩形的左上角坐标和高度及宽度 
//            int y = 15; int width = 200; int height = 100; Rectangle rect = new Rectangle(x, y, width, height);//定义矩形
//            g.FillRectangle(BlueBrush, rect);//填充矩形 
//        }
       
//        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) 
//        { pictureBox1.Cursor = Cursors.Default; //松开鼠标时，形状恢复为箭头 wselected = false; this.pictureBox1.Cursor = Cursors.Default; } }
//}
}
