using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ShowOpenCVResult.MathOp
{

    public class MinTwoMulity
    {
        public int Cnt {
            get
            {
                return pts.Count;
            }
        }

        List<PointF> pts = new List<PointF>();



        void push(PointF xy)
        {
            pts.Add(xy);
        }
        float calc(float x)
        {
            int i = 0;
            float mean_x = 0;
            float mean_y = 0;
            float num1 = 0;
            float num2 = 0;
            float a = 0;
            float b = 0;
            int cnt = pts.Count;
            //求t,y的均值  
            for (i = 0; i < cnt; i++)
            {
                mean_x += pts[i].X;
                mean_y += pts[i].Y;
            }
            mean_x /= cnt;
            mean_y /= cnt;


            for (i = 0; i < cnt; i++)
            {
                num1 += (pts[i].X - mean_x) * (pts[i].Y - mean_y);
                num2 += (pts[i].X - mean_x) * (pts[i].X - mean_x);
            }

            b = num1 / num2;
            a = mean_y - b * mean_x;
            return (a + b * x);
        }

    }
}
