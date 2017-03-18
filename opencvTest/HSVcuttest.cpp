#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include "TestFunction.h"
#include"myopencvfuns.h"
#include<iostream>

using namespace cv;
using namespace std;

int cvThresholdOtsu(IplImage* src);

//Mat GetLinesImg(Mat roadimg);
//
//Mat GetColorLinesImg(Mat src,bool isShowProc){
//	Mat en = projection_transformation(src);
//	Mat sharp = en.clone();
//	Sharpen(en, sharp);
//
//
//	Mat bulr = GetBulrImage(sharp, 20, 4);
//
//
//	Mat img = GetLinesImg(bulr);
//
//	Mat d1 = GetErodeDilate(img, 1, false);
//	
//	Mat d2 = GetErodeDilate(d1, 2, true);
//
//	if (isShowProc){
//		NewWindowsShow("sharp", sharp);
//		NewWindowsShow("bulr", bulr);
//		NewWindowsShow("img", img);
//		NewWindowsShow("d1", d1);
//		NewWindowsShow("d2", d2);
//		waitKey();
//	}
//	return d2;
//}
//
//Mat GetLinesImg(Mat roadimg){
//	int yellowHLeft = 15;
//	int yellowHRight = 35;
//	int yellowMinS = 43;
//	int yellowMinV = 100;
//	int writeMaxS = 100;
//	int writeMinV = 170;
//
//	vector<Mat> channels;
//	Mat hsvimg;
//	cvtColor(roadimg, hsvimg,CV_BGR2HSV);
//	for (int i = 0; i < hsvimg.rows;i++)
//	{
//		for (int j = 0; j < hsvimg.cols; j++)
//		{
//			Vec3b v = hsvimg.at<Vec3b>(i, j);
//			bool isw = v[1] <= writeMaxS && v[2] >= writeMinV;
//			bool isy = v[0] >= yellowHLeft && v[0] <= yellowHRight && v[1] >= yellowMinS && v[2] >= yellowMinV;
//			if(!(isw||isy)){
//				hsvimg.at<Vec3b>(i, j) = Vec3b(0, 0, 0);
//			}
//		
//		}
//	}
//	Mat result;
//	cvtColor(hsvimg, result, CV_HSV2BGR);
//	return result;
//
//}



