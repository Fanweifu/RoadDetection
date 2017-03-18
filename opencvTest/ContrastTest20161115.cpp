#include <opencv2/opencv.hpp>  
#include <opencv2/highgui/highgui.hpp>  
#include <opencv2/imgproc/imgproc.hpp>  
#include "TestFunction.h";
#include "myopencvfuns.h"
using namespace cv;
using namespace std;

int alpha = 100; /**< 控制对比度 */
int beta = 0;  /**< 控制亮度 */
int thresholdp = 100;
Mat imgclone, showimg;
void on_change(int, void*){
	for (int y = 0; y < imgclone.rows; y++)
	{
		for (int x = 0; x < imgclone.cols; x++)
		{
			for (int c = 0; c < 3; c++)
			{
				showimg.at<Vec3b>(y, x)[c] = saturate_cast<uchar>(alpha *0.01*((imgclone.at<Vec3b>(y, x)[c] - thresholdp) + beta));
			}
		}
	}
	imshow("RESULT", showimg);
}


void ContrastTest(Mat src){
	imgclone = src.clone();
	showimg = src.clone();
	NewWindowsShow("SRC", imgclone);
	namedWindow("RESULT", 1);
	createTrackbar("alpha", "RESULT", &alpha, 300, on_change);
	createTrackbar("beta", "RESULT", &beta, 300, on_change);
	createTrackbar("thresholdp", "RESULT", &thresholdp, 300, on_change);
	on_change(0, 0);
	waitKey();
}