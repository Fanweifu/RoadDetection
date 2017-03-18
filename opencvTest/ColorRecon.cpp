#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include "TestFunction.h"
#include<iostream>

using namespace cv;
using namespace std;

int iLowH = 100;
int iHighH = 140;

int iLowS = 90;
int iHighS = 255;

int iLowV = 90;
int iHighV = 255;
Mat hsvimg;
Mat imgThresholded;

static void On_Change(int, void *);

void ColorRecon(){
	Mat scimg = imread(LINESIMGPATH);
	hsvimg = scimg.clone();
	cvtColor(scimg, hsvimg, COLOR_BGR2HSV);
	vector<Mat> channels;
	split(hsvimg, channels);
	equalizeHist(channels[2], channels[2]);
	merge(channels, hsvimg);

	namedWindow("原图",1);
	imshow("原图", scimg);

	namedWindow("直方图", 1);
	imshow("直方图",hsvimg);


	namedWindow("Control",1);

	createTrackbar("LowH", "Control", &iLowH, 360, On_Change); //Hue (0 - 179)  
	createTrackbar("HighH", "Control", &iHighH, 360, On_Change);

	createTrackbar("LowS", "Control", &iLowS, 255, On_Change); //Saturation (0 - 255)  
	createTrackbar("HighS", "Control", &iHighS, 255, On_Change);

	createTrackbar("LowV", "Control", &iLowV, 255, On_Change); //Value (0 - 255)  
	createTrackbar("HighV", "Control", &iHighV, 255, On_Change);

	 imgThresholded = hsvimg.clone();
	 namedWindow("Thresholded Image", 1);
	 On_Change(iLowH, 0);


	waitKey();

}

static void On_Change(int, void *){

	inRange(hsvimg, Scalar(iLowH, iLowS, iLowV), Scalar(iHighH, iHighS, iHighV), imgThresholded); //Threshold the image  

	//开操作 (去除一些噪点)  
	//Mat element = getStructuringElement(MORPH_RECT, Size(5, 5));
	//morphologyEx(imgThresholded, imgThresholded, MORPH_OPEN, element);

	////闭操作 (连接一些连通域)  
	//morphologyEx(imgThresholded, imgThresholded, MORPH_CLOSE, element);

	imshow("Thresholded Image", imgThresholded); //show the thresholded image  
}

