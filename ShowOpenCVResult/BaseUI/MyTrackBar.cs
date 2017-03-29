using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowOpenCVResult
{
    public partial class MyTrackBar : UserControl
    {
        //public string Title {
        //    get {
        //        return label1.Text;
        //    }
        //    set {
        //        label1.Text = value;
        //    }
        //}



        //public int Maximum
        //{
        //    get
        //    {
        //        return trackBar1.Maximum;
        //    }
        //    set
        //    {
        //        trackBar1.Maximum =value;
        //        numericUpDown1.Maximum = value;
        //    }
        //}

        //public int Minimum
        //{
        //    get
        //    {
        //        return trackBar1.Minimum;
        //    }
        //    set
        //    {
        //        trackBar1.Minimum = value;
        //        numericUpDown1.Minimum = value;
        //    }
        //}

        //public int Value
        //{
        //    get
        //    {
        //        return trackBar1.Value;
        //    }
        //    set
        //    {
        //        trackBar1.Value = value;
        //    }
        //}

        //public event EventHandler ValueChanged;

        //public MyTrackBar()
        //{
        //    InitializeComponent();
        //    this.Load += MyTrackBar_Load;
        //}

        //private void MyTrackBar_Load(object sender, EventArgs e)
        //{
        //    setBindings();
        //}

        //void setBindings()
        //{
        //    numericUpDown1.DataBindings.Add("Value", trackBar1, "Value");
        //}

        //void trackBar1_ValueChanged(object sender, EventArgs e)
        //{
        //    if (ValueChanged != null) {
        //        ValueChanged(this, new EventArgs());
        //    }
        //}

        //private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        //{
        //    trackBar1.Value = (int)numericUpDown1.Value;
        //}

        public string Title
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }



        public int Maximum
        {
            get
            {
                return trackBar1.Maximum;
            }
            set
            {
                trackBar1.Maximum = value;
                numericUpDown1.Maximum = value;
            }
        }

        public int Minimum
        {
            get
            {
                return trackBar1.Minimum;
            }
            set
            {
                trackBar1.Minimum = value;
                numericUpDown1.Minimum = value;
            }
        }

        public int Value
        {
            get
            {
                return trackBar1.Value;
            }
            set
            {
                trackBar1.Value = value;
            }
        }

        public event EventHandler ValueChanged;

        public MyTrackBar()
        {
            InitializeComponent();
            numericUpDown1.DataBindings.Add("Value", trackBar1, "Value");
        }

        public MyTrackBar(string title, int max = 255)
        {
            InitializeComponent();
            numericUpDown1.DataBindings.Add("Value", trackBar1, "Value");
            this.trackBar1.ValueChanged += trackBar1_ValueChanged;
            Title = title;
            Maximum = max;

        }

        void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, new EventArgs());
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = (int)numericUpDown1.Value;
        }

    }
}
