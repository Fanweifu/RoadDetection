//-----------------------------------【程序说明】----------------------------------------------  
//      程序名称:：《【OpenCV入门教程之十四】OpenCV霍夫变换：霍夫线变换，霍夫圆变换合辑 》 博文配套源码   
//      开发所用IDE版本：Visual Studio 2010  
//          开发所用OpenCV版本：   2.4.9  
//      2014年5月26日 Created by 浅墨  
//----------------------------------------------------------------------------------------------  

//-----------------------------------【头文件包含部分】---------------------------------------  
//      描述：包含程序所依赖的头文件  
//----------------------------------------------------------------------------------------------   
#include <opencv2/opencv.hpp>  
#include <opencv2/highgui/highgui.hpp>  
#include <opencv2/imgproc/imgproc.hpp>  
#include "TestFunction.h";
#include "myopencvfuns.h"
#define ADOP
//-----------------------------------【命名空间声明部分】--------------------------------------  
//      描述：包含程序所使用的命名空间  
//-----------------------------------------------------------------------------------------------   
using namespace std;
using namespace cv;


//-----------------------------------【全局变量声明部分】--------------------------------------  
//      描述：全局变量声明  
//-----------------------------------------------------------------------------------------------  
Mat  g_sImage, g_dstImage, g_midImage,gray,g_strImg;//原始图、中间图和效果图  
Mat g_blurImage;
vector<Vec4i> g_lines;//定义一个矢量结构g_lines用于存放得到的线段矢量集合  
//变量接收的TrackBar位置参数  
int g_nthreshold = 150;
int g_rho = 0;
int g_grap = 1;
int g_minDis = 1;
int g_nMedianBlurValue1 = 30;

int blockSize = 3;
int constValue = 3;
int maxVal = 255;

//-----------------------------------【全局函数声明部分】--------------------------------------  
//      描述：全局函数声明  
//-----------------------------------------------------------------------------------------------  

static void on_HoughLines(int, void*);//回调函数  
static void on_HoughLinesrho(int, void*);
static void on_AdaptiveThreshold(int, void*);
static void ShowHelpText();
static void on_MedianBlur(int, void*);


//-----------------------------------【main( )函数】--------------------------------------------  
//      描述：控制台应用程序的入口函数，我们的程序从这里开始  
//-----------------------------------------------------------------------------------------------  
void HoughTest(Mat img)
{
	//改变console字体颜色  
	system("color 3F");

	ShowHelpText();
	g_sImage = img;
	//载入原始图和Mat变量定义  
	g_dstImage = g_sImage.clone();
	cvtColor(g_sImage, gray, CV_BGR2GRAY);
	NewWindowsShow("【灰度图】", gray);


#ifdef ADOP

	threshold(gray, g_midImage, 50, 255, 0);

	vector<vector<Point>> contours;
	// find
	findContours(g_midImage, contours, CV_RETR_EXTERNAL, CV_CHAIN_APPROX_NONE);
	// draw
	Mat result(g_midImage.size(), CV_8U, Scalar(0));
	drawContours(result, contours, -1, Scalar(255), 1);
	NewWindowsShow("result",result);
	waitKey();
	g_midImage = result;

	Mat modelimg = imread("‪E:\\Users\\fwf\\Desktop\\道路标线\\导向箭头\\WBX0000060.jpg",1);
	Mat bw;
	threshold(modelimg, bw, 100, 255, CV_THRESH_BINARY_INV);
	vector<vector<Point>> contours2;
	// find
	findContours(bw, contours2, CV_RETR_EXTERNAL, CV_CHAIN_APPROX_NONE);
	Mat result2(bw.size(), CV_8U, Scalar(0));
	drawContours(result2, contours2, -1, Scalar(255), 1);
	NewWindowsShow("result2", result2);

#else


#endif


	namedWindow("【效果图】", 1);
	createTrackbar("值g_nthreshold", "【效果图】", &g_nthreshold, 400, on_HoughLines);
	createTrackbar("值rho", "【效果图】", &g_rho, 100, on_HoughLines);
	createTrackbar("值grap", "【效果图】", &g_grap, 300, on_HoughLines);
	createTrackbar("值g_minDis", "【效果图】", &g_minDis, 500, on_HoughLines);


	on_HoughLines(g_nthreshold, 0);

	waitKey();

	return ;

}


//-----------------------------------【on_HoughLines( )函数】--------------------------------  
//     
//----------------------------------------------------------------------------------------------  
static void on_HoughLines(int, void*)
{
	Mat dstImage = g_dstImage.clone();
	Mat midImage = g_midImage.clone();
	

	//调用HoughLinesP函数  
	HoughLinesP(midImage, g_lines, g_rho + 1, CV_PI / 180, g_nthreshold + 1, g_minDis, g_grap);

	//循环遍历绘制每一条线段  
	for (size_t i = 0; i < g_lines.size(); i++) 
	{
		Vec4i l = g_lines[i];
		line(dstImage, Point(l[0], l[1]), Point(l[2], l[3]), Scalar(255, 0, 0), 1, CV_AA);
	}
	//显示图像  
	imshow("【效果图】", dstImage);
}

static void on_AdaptiveThreshold(int, void*){
	adaptiveThreshold(gray, g_midImage, maxVal, ADAPTIVE_THRESH_MEAN_C, CV_THRESH_BINARY_INV, blockSize*2+1, constValue);
	imshow("adaptiveThreshold", g_midImage);
}

//-----------------------------------【ShowHelpText( )函数】----------------------------------  
//      描述：输出一些帮助信息  
//----------------------------------------------------------------------------------------------  
static void ShowHelpText()
{
	//输出一些帮助信息  
	printf("\n\n\n\t请调整滚动条观察图像效果~\n\n");
}


