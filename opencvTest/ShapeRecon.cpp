#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include "TestFunction.h"
#include "myopencvfuns.h"
#include<iostream>

using namespace cv;
using namespace std;

double contours_judge = 0.3 ;

vector<vector<Point>> ContoursFind(Mat input, int minpts , int maxpts)
{

	Mat image = projection_transformation(input);

	if (image.data==NULL)
	{
		throw new Exception();
	}
	namedWindow("image");
	imshow("image", image);
	NewWindowsShow("image", image);
	Mat bilaimg = image.clone();
	bilateralFilter(image, bilaimg, 10, 10 * 2, 10 / 2);
	//medianBlur(image, bilaimg, 5 * 2 + 1);
	NewWindowsShow("bilateral_image",bilaimg);


	//转成灰度图
	cvtColor(bilaimg, bilaimg, CV_BGR2GRAY);
	//转为二值图
	Mat bwimg = image.clone();
	//threshold(bilaimg, bwimg, cvThresholdOtsu(new IplImage(bilaimg)), 255, CV_THRESH_BINARY);
	adaptiveThreshold(bilaimg, bwimg, 255, ADAPTIVE_THRESH_MEAN_C, CV_THRESH_BINARY_INV, 3 * 2 + 1, 3);
	NewWindowsShow("adaptiveThreshold", bwimg);
	cvMoveWindow("adaptiveThreshold", 100, 100);

	//bwimg = KirschCheck(bilaimg);
	//threshold(bilaimg, bwimg, 125, 255, CV_THRESH_BINARY);
	//NewWindowsShow("bwimg", bwimg);
	bwimg = GetErodeDilate(bwimg, 1,false);
	bwimg = GetErodeDilate(bwimg, 1, true);

	NewWindowsShow("闭运算", bwimg);


	//轮廓检测
	vector<vector<Point>> contours;
	// find
	findContours(bwimg, contours, CV_RETR_EXTERNAL, CV_CHAIN_APPROX_NONE);
	// draw
	Mat result(image.size(), CV_8U, Scalar(0));
	drawContours(result, contours, -1, Scalar(255), 1);
	
	NewWindowsShow("结果初始图", result);

	//轮廓刷选
	std::vector<vector<Point>>::const_iterator itc = contours.begin();
	while (itc != contours.end())
	{
		if (itc->size() < minpts || itc->size() > maxpts)
			itc = contours.erase(itc);
		else
			++itc;
	}
	Mat result1(image.size(), CV_8U, Scalar(0));
	drawContours(result1, contours, -1, Scalar(255), 1);
	NewWindowsShow("结果刷选图", result1);


	//轮廓多边化.
	itc = contours.begin();
	for (int i = 0; i < contours.size();i++)
	{
		approxPolyDP(contours[i], contours[i], 3, true);
	}
	
	Mat result3(image.size(), CV_8U, Scalar(0));
	drawContours(result3, contours, -1, Scalar(255), 1);
	NewWindowsShow("多边形图", result1);
	waitKey();


	vector<Point> manroad;
	manroad.push_back(Point(0.0, 0.0));
	manroad.push_back(Point(1, 0));
	manroad.push_back(Point(1, 3));
	manroad.push_back(Point(0, 3));

	double comres = 0;
	int csize = contours.size();

	int i = 0;
	itc = contours.begin();
	while (itc != contours.end())
	{
		
		comres = matchShapes(manroad, *itc, CV_CONTOURS_MATCH_I3, 0.0);
		printf("%d: %f\n", i, comres);
		i++;
		if (comres>contours_judge)
			itc = contours.erase(itc);
		else
			++itc;
	}
	Mat result2(image.size(), CV_8U, Scalar(0));
	drawContours(result2, contours, -1, Scalar(255), 1);
	namedWindow("contours2", 1);
	imshow("contours2", result2);
	
	


	waitKey();

	return contours;
}