using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ShowOpenCVResult
{
    public class Harris
    {
        Image<Gray, Byte> cornerStrength = new Image<Gray, Byte>(1,1);  //opencv harris函数检测结果，也就是每个像素的角点响应函数值
        Image<Gray, Byte> cornerTh = new Image<Gray, Byte>(1,1); //cornerStrength阈值化的结果
        Image<Gray, Byte> localMax = new Image<Gray, Byte>(1,1); //局部最大值结果
        int neighbourhood; //邻域窗口大小
        int aperture;//sobel边缘检测窗口大小（sobel获取各像素点x，y方向的灰度导数）
        double k;
        double maxStrength;//角点响应函数最大值
        double thresholdvalue;//阈值除去响应小的值
        int nonMaxSize;//这里采用默认的3，就是最大值抑制的邻域窗口大小
        Mat kernel;//最大值抑制的核，这里也就是膨胀用到的核
        public Harris(int _neighbourhood = 3, int _aperture = 3, double _k = 0.01, double _maxStrength = 0.0, double _thresholdvalue = 0.01, int _nonMaxSize = 3)
        {
            neighbourhood = _neighbourhood;
            aperture = _aperture;
            k = _k;
            maxStrength = _maxStrength;
            thresholdvalue = _thresholdvalue;
            nonMaxSize = _nonMaxSize;
        }

        public void SetLocalMaxWindowsize(int nonMaxSize)
        {
            this.nonMaxSize = nonMaxSize;
        }

        //计算角点响应函数以及非最大值抑制
        public void detect(Image<Gray,Byte> image)
        {
            //opencv自带的角点响应函数计算函数
            CvInvoke.CornerHarris(image, cornerStrength, neighbourhood, aperture, k);
            double minStrength = 0;
            Point minloc = new Point(), maxloc = new Point();
            CvInvoke.MinMaxLoc(cornerStrength, ref minStrength, ref maxStrength, ref minloc, ref maxloc);
            Image<Gray, Byte> dilated = cornerStrength.Dilate(1);
            //默认3*3核膨胀，膨胀之后，除了局部最大值点和原来相同，其它非局部最大值点被
            //3*3邻域内的最大值点取代

            //与原图相比，只剩下和原图值相同的点，这些点都是局部最大值点，保存到localMax
            CvInvoke.Compare(cornerStrength, dilated, localMax, Emgu.CV.CvEnum.CmpType.Equal);
        }

        //获取角点图
        public Mat getCornerMap(double qualityLevel)
        {
            Mat cornerMap = new Mat();
            // 根据角点响应最大值计算阈值
            thresholdvalue = qualityLevel * maxStrength;
            CvInvoke.Threshold(cornerStrength, cornerTh,
             thresholdvalue, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
            // 转为8-bit图
            cornerTh.Mat.ConvertTo(cornerMap, Emgu.CV.CvEnum.DepthType.Cv8U);
            // 和局部最大值图与，剩下角点局部最大值图，即：完成非最大值抑制
            CvInvoke.BitwiseAnd(cornerMap, localMax, cornerMap);
            return cornerMap;
        }

        public void GetCorners(VectorOfPoint vp,
                double qualityLevel)
        {
            //获取角点图
            Mat cornerMap = getCornerMap(qualityLevel);
            // 获取角点
            getCorners(vp, cornerMap);
        }

        // 遍历全图，获得角点
        private void getCorners(VectorOfPoint points, Mat cornerMap)
        {
            if (cornerMap.NumberOfChannels != 1 || cornerMap.Depth != Emgu.CV.CvEnum.DepthType.Cv8U) return;
            unsafe
            {
                byte* pt = (byte*)cornerMap.DataPointer;
                int w = cornerMap.Width, h = cornerMap.Height, step = cornerMap.Step;
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        byte value = *(pt + y * step + x);
                        if (value > 0)
                            points.Push(new Point[] { new Point(x, y) });
                    }
                }

            }
        }

        //用圈圈标记角点
        public void DrawOnImage(Mat image, VectorOfPoint vp, MCvScalar color, int radius = 3, int thickness = 2)
        {
            int cnt = vp.Size;
            for (int i = 0; i < cnt; i++)
            {
                CvInvoke.Circle(image, vp[i], radius, color, thickness);
            }


        }

    };
}
