#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include "TestFunction.h"
#include "myopencvfuns.h"
#include<iostream>


int leftbuttomtocenter = 0;
int pt2x = 0;
int pt2y = 0;
int height = 0;
int width = 0;
Point2f srcTri[4];
Point2f dstTri[4];
int w, h;
Mat warp_src, warp_dst, warp_rotate_dst;
void On_parchange(int ,void*){
	srcTri[0] = Point2f(pt2x, pt2y);
	srcTri[1] = Point2f(w - pt2x, pt2y);
	srcTri[2] = Point2f(leftbuttomtocenter+(w/2+1) , h - 1);
	srcTri[3] = Point2f((w /2) - leftbuttomtocenter, h - 1);

	dstTri[0] = Point2f(0, 0);
	dstTri[1] = Point2f(width, 0);
	dstTri[2] = Point2f(width, height - 1);
	dstTri[3] = Point2f(0, height - 1);
	Mat warp_mat(2, 3, CV_32FC1);
	warp_dst = Mat::zeros(height,width, warp_src.type());
	warp_mat = getPerspectiveTransform(srcTri, dstTri);
	warpPerspective(warp_src, warp_dst, warp_mat, warp_dst.size(), INTER_LINEAR, BORDER_CONSTANT);
	imshow("Dst", warp_dst);
}

Mat  projection_transformation(Mat imgsrc){
		Mat rot_mat(2, 3, CV_32FC1);
		

		//∂¡»ÎÕºœÒ  
		warp_src = imgsrc.clone();

		if (!warp_src.data){
			throw new Exception();
		}

		w = warp_src.cols;
		h = warp_src.rows;

		leftbuttomtocenter = w;
		pt2x = w / 4;
		pt2y = h / 4;
		height = h * 2;
		width = w;
		namedWindow("Src",1);
		namedWindow("Dst", 1);
		imshow("Src", warp_src);

		
		createTrackbar("LT", "Src", &leftbuttomtocenter, w * 5, On_parchange);
		createTrackbar("X", "Src", &pt2x, w/2, On_parchange);
		createTrackbar("Y", "Src", &pt2y, h, On_parchange);
		createTrackbar("H", "Src", &height, h*5, On_parchange);
		createTrackbar("W", "Src", &width, w*2, On_parchange);

		On_parchange(0,NULL);
		waitKey();

		return warp_dst;
}
