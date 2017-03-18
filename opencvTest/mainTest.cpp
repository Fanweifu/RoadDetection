#include"TestFunction.h"
#include "myopencvfuns.h"
#include "opencv2/core/core.hpp"  
#include <opencv2/highgui/highgui.hpp>  
#include<opencv2/imgproc/imgproc.hpp>

#include <ctime>
#include <stdio.h>
#pragma comment(lib,"opencv_highgui249d.lib")
#define FUNSTEST 0 
using namespace std;
using namespace cv;


int main(int argc, char*argv[]){
#ifdef FUNSTEST

	//Mat result = GetColorLinesImg(projection_transformation(imread(CENTRELINE)));
	//HoughTest(result);
	//FillTest();
	//ContrastTest(imread(FUSHIIMG));
	//Mat input = GetBulrImage(imread(XULINE), 20, 4);
	//Mat sch = GetScharrImg(input);
	//int scnt = sch.channels();
	//NewWindowsShow("sch", sch);
	//NewWindowsShow("input", input);
	//Mat result = GetColorLinesImg(input);
	//NewWindowsShow("result", result);
	//waitKey();
	Mat model = imread(MODELIMG);
	Mat back(model.size(), false);
	vector<vector<Point>> consModel =   GetContours(GetBinaryImage(model, 100));
	NewWindowsShow("Result", DrawContours(consModel, back,0));
 	Mat aim = imread(AIMIMAGEBIGSIZE);
	
 	NewWindowsShow("Aim", aim);
 	Mat bw = GetBinaryImage(aim, 180); 	NewWindowsShow("bw", bw);
	vector<vector<Point>> consAim = GetContours(bw,100,3000);
	NewWindowsShow("Result", DrawContours(consAim, aim, 1));


#else


	Mat src = imread(LINESIMGPATH, 1);
	NewWindowsShow("proces0", src);

	clock_t begin, end;
	begin = clock();

	Mat drw = projection_transformation(src);
	NewWindowsShow("proces2", drw);

	Mat bur = GetBulrImage(drw);
	NewWindowsShow("proces1", bur);

	Mat jiaqiang = bur.clone();
	ImageStretchByHistogram(bur, jiaqiang);
	NewWindowsShow("加强", jiaqiang);

	//Mat sob = GetSobelXYImage(jiaqiang);
	//NewAutoWindosShow("proces3", sob);



	Mat bin = GetBinaryImage(jiaqiang, 200);
	NewWindowsShow("proces4", bin);

	Mat ed = GetErodeDilate(bin, 1, false);
	NewWindowsShow("proces5", ed);

	Mat ed1 = GetErodeDilate(ed, 1, true);
	NewWindowsShow("proces6", ed1);

	vector<vector<Point>> con = GetContours(ed1, 50, 1000);
	for (int i = 0; i < con.size(); i++)
	{
		approxPolyDP(con[i], con[i], 3, true);
	}
	Mat drawresult = DrawContours(con, drw);
	NewWindowsShow("proces7", drawresult);


	end = clock();
	double t = (double)(end - begin) / CLOCKS_PER_SEC;
	printf("Cost Time：%f", t);


	waitKey();
#endif

}

