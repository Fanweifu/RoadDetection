#include "GclrOpencvProces.h"

#include"TestFunction.h"
#include "myopencvfuns.h"
#include "opencv2/core/core.hpp"  
#include <opencv2/highgui/highgui.hpp>  
#include<opencv2/imgproc/imgproc.hpp>

#include <ctime>
#include <stdio.h>
#include <atlstr.h>
#include <windows.h>
using namespace std;
using namespace cv;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::IO;
using namespace System;



GclrOpencvProces::GclrOpencvProces()
{
}
GclrOpencvProces::GclrOpencvProces(System::String ^val)
{
	m_srcpath = val;
}



int GclrOpencvProces::EditReflectAngle(int t)
{
	HoughTest(projection_transformation(imread(LINESIMGPATH, 1)));
	return 2 * t;
}

int GclrOpencvProces::EditReflectAngle(cli::array<int> ^value)
{
	pin_ptr<int> p = &value[0];
	int *pp = p;

	return 0;
}

System::Drawing::Bitmap^ GclrOpencvProces::BitmapTransformation(System::Drawing::Bitmap ^ srcpic, double lt, double x, double y, int w, int h){
	Mat src;
	ConvertBitmapToMat(srcpic, src);
	Mat tranresult = projection_transformation(src, lt, x, y, w, h);
	System::Drawing::Bitmap^ finalresult = ConvertMatToBitmap(tranresult);
	src.release();
	tranresult.release();
	return finalresult;

}
bool GclrOpencvProces::BitmapTransformation(System::String^ path, double lt, double x, double y, int w, int h){
	char* ch1 = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(path);
	Mat src = imread(ch1);
	Mat tranresult = projection_transformation(src, lt, x, y, w, h);
	//char * dr, *dir, *fname, *ext;
	//_splitpath(ch2, dr, dir, fname, ext);
	//string outpath = ""+dr+ dir + fname + "_Transformat" + ext;
	System::String ^ outpath = System::String::Format("{0}{1}_Transformat{2}", Path::GetDirectoryName(path), Path::GetFileNameWithoutExtension(path), Path::GetExtension(path));
	File::Create(outpath);
	char* ch2 = (char*)(void*)System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(path);
	return imwrite(ch2, tranresult);
}
System::Drawing::Bitmap^  GclrOpencvProces::BitmapGetRoadImg(System::Drawing::Bitmap ^ srcpic, int maxS, int minV){
	Mat src;
	ConvertBitmapToMat(srcpic, src);
	Mat tranresult = GetLinesImg(src,maxS,minV);
	System::Drawing::Bitmap^ finalresult = ConvertMatToBitmap(tranresult);
	src.release();
	tranresult.release();
	return finalresult;
}

System::Drawing::Bitmap^  GclrOpencvProces::BitmapGetBlurImg(System::Drawing::Bitmap ^ srcpic, int method, int size){
	Mat src;
	ConvertBitmapToMat(srcpic, src);
	Mat tranresult = GetBulrImage(src, size, method);
	System::Drawing::Bitmap^ finalresult = ConvertMatToBitmap(tranresult);
	src.release();
	tranresult.release();
	return finalresult;
}
System::Drawing::Bitmap^ GclrOpencvProces::BitmapGetOpenCloseImg(System::Drawing::Bitmap ^ srcpic, bool isopen, int size){
	Mat src;
	ConvertBitmapToMat(srcpic, src);
	Mat tranresult = GetErodeDilate(src, size, isopen);
	System::Drawing::Bitmap^ finalresult = ConvertMatToBitmap(tranresult);
	src.release();
	tranresult.release();
	return finalresult;
}