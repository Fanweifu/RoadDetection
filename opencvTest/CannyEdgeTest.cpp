#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include "TestFunction.h"
#include "myopencvfuns.h"
#include<iostream>

using namespace cv;
using namespace std;

	//载入原始图    
	//原图，原图的灰度版，目标图 
	Mat  g_srcGrayImage;

	//Canny边缘检测相关变量  
	Mat  g_cannyDetectedEdges;
	int g_cannyLowThreshold = 1;//TrackBar位置参数    

	//Sobel边缘检测相关变量  
	Mat g_sobelGradient_X, g_sobelGradient_Y;
	Mat g_sobelAbsGradient_X, g_sobelAbsGradient_Y;
	int g_sobelKernelSize = 1;//TrackBar位置参数    

	//Scharr滤波器相关变量  
	Mat g_scharrGradient_X, g_scharrGradient_Y;
	Mat g_scharrAbsGradient_X, g_scharrAbsGradient_Y;


	//-----------------------------------【全局函数声明部分】--------------------------------------  
	//      描述：全局函数声明  
	//-----------------------------------------------------------------------------------------------  
	static void ShowHelpText();
	static void on_Canny(int, void*);//Canny边缘检测窗口滚动条的回调函数  
	static void on_Sobel(int, void*);//Sobel边缘检测窗口滚动条的回调函数  
	void Scharr();//封装了Scharr边缘检测相关代码的函数  


	//-----------------------------------【main( )函数】--------------------------------------------  
	//      描述：控制台应用程序的入口函数，我们的程序从这里开始  
	//-----------------------------------------------------------------------------------------------  
	void CannyTest(Mat src )
	{
		//改变console字体颜色  
		system("color 2F");

		//显示欢迎语  
		ShowHelpText();

		//载入原图  
		g_sImage = src;
		if (!g_sImage.data) { printf("Oh，no，读取srcImage错误~！ \n"); return ; }

		//显示原始图  
		namedWindow("【原始图】");
		imshow("【原始图】", g_sImage);

		// 创建与src同类型和大小的矩阵(dst)  
		g_dstImage.create(g_sImage.size(), g_sImage.type());

		// 将原图像转换为灰度图像  
		cvtColor(g_sImage, g_srcGrayImage, CV_BGR2GRAY);
		// 创建显示窗口  
		namedWindow("【效果图】Canny边缘检测", CV_WINDOW_AUTOSIZE);
		namedWindow("【效果图】Sobel边缘检测", CV_WINDOW_AUTOSIZE);

		// 创建MyMethod()  
		createTrackbar("参数值：", "【效果图】Canny边缘检测", &g_cannyLowThreshold, 120, on_Canny);
		createTrackbar("参数值：", "【效果图】Sobel边缘检测", &g_sobelKernelSize, 3, on_Sobel);

		// 调用回调函数  
		on_Canny(0, 0);
		on_Sobel(0, 0);

		//调用封装了Scharr边缘检测代码的函数  
		Scharr();

		//轮询获取按键信息，若按下Q，程序退出  
		while ((char(waitKey(1)) != 'q')) {}

		return ;
	}


	//-----------------------------------【ShowHelpText( )函数】----------------------------------  
	//      描述：输出一些帮助信息  
	//----------------------------------------------------------------------------------------------  
	static void ShowHelpText()
	{
		//输出一些帮助信息  
		printf("\n\n\t嗯。运行成功，请调整滚动条观察图像效果~\n\n"
			"\t按下“q”键时，程序退出~!\n"
			"\n\n\t\t\t\t by浅墨");
	}


	//-----------------------------------【on_Canny( )函数】----------------------------------  
	//      描述：Canny边缘检测窗口滚动条的回调函数  
	//-----------------------------------------------------------------------------------------------  
	void on_Canny(int, void*)
	{
		// 先使用 3x3内核来降噪  
		blur(g_srcGrayImage, g_cannyDetectedEdges, Size(3, 3));

		// 运行我们的Canny算子  
		Canny(g_cannyDetectedEdges, g_cannyDetectedEdges, g_cannyLowThreshold, g_cannyLowThreshold * 3, 3);

		//先将g_dstImage内的所有元素设置为0   
		g_dstImage = Scalar::all(0);

		//使用Canny算子输出的边缘图g_cannyDetectedEdges作为掩码，来将原图g_sImage拷到目标图g_dstImage中  
		g_sImage.copyTo(g_dstImage, g_cannyDetectedEdges);

		//显示效果图  
		imshow("【效果图】Canny边缘检测", g_dstImage);
	}



	//-----------------------------------【on_Sobel( )函数】----------------------------------  
	//      描述：Sobel边缘检测窗口滚动条的回调函数  
	//-----------------------------------------------------------------------------------------  
	void on_Sobel(int, void*)
	{
		blur(g_srcGrayImage, g_cannyDetectedEdges, Size(3, 3));
		// 求 X方向梯度  
		Sobel(g_sImage, g_sobelGradient_X, CV_16S, 1, 0, (2 * g_sobelKernelSize + 1), 1, 1, BORDER_DEFAULT);
		convertScaleAbs(g_sobelGradient_X, g_sobelAbsGradient_X);//计算绝对值，并将结果转换成8位  

		// 求Y方向梯度  
		Sobel(g_sImage, g_sobelGradient_Y, CV_16S, 0, 1, (2 * g_sobelKernelSize + 1), 1, 1, BORDER_DEFAULT);
		convertScaleAbs(g_sobelGradient_Y, g_sobelAbsGradient_Y);//计算绝对值，并将结果转换成8位  

		// 合并梯度  
		addWeighted(g_sobelAbsGradient_X, 0.5, g_sobelAbsGradient_Y, 0.5, 0, g_dstImage); 
		Mat gray = g_dstImage.clone();
		cvtColor(g_dstImage, gray, CV_BGR2GRAY);
		threshold(gray, gray, 50, 255, CV_THRESH_BINARY);

		//显示效果图  
		imshow("【效果图】Sobel边缘检测", gray);

	}


	//-----------------------------------【Scharr( )函数】----------------------------------  
	//      描述：封装了Scharr边缘检测相关代码的函数  
	//-----------------------------------------------------------------------------------------  
	void Scharr()
	{
		// 求 X方向梯度  
		Scharr(g_sImage, g_scharrGradient_X, CV_16S, 1, 0, 1, 0, BORDER_DEFAULT);
		convertScaleAbs(g_scharrGradient_X, g_scharrAbsGradient_X);//计算绝对值，并将结果转换成8位  

		// 求Y方向梯度  
		Scharr(g_sImage, g_scharrGradient_Y, CV_16S, 0, 1, 1, 0, BORDER_DEFAULT);
		convertScaleAbs(g_scharrGradient_Y, g_scharrAbsGradient_Y);//计算绝对值，并将结果转换成8位  

		// 合并梯度  
		addWeighted(g_scharrAbsGradient_X, 0.4, g_scharrAbsGradient_Y, 0.6, 0, g_dstImage);

		//显示效果图  
		imshow("【效果图】Scharr滤波器", g_dstImage);
	}

