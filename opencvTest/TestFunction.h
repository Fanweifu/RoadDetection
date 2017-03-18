#include<iostream>
#include<opencv2/core/core.hpp>
using namespace std;
using namespace cv;

#define IMGPATH  "E:\\Users\\fwf\\Desktop\\TestFiles\\K`7}LVYYBRL(L[UZ3V6}62O.png"
#define LINESIMGPATH "E:\\Users\\fwf\\Desktop\\TestFiles\\WalkLines.png"
#define FUSHIIMG "E:\\Users\\fwf\\Desktop\\TestFiles\\fushi.png"
#define AIMIMAGE2 "‪E:\\Users\\fwf\\Desktop\\TestFiles\\Aim.png"
#define CENTRELINE "E:\\Users\\fwf\\Desktop\\实习素材\\S302A\\S302A-004+426810-004+426810.jpg"
#define XULINE "E:\\Users\\fwf\\Desktop\\TestFiles\\xulines.png"
#define FUSHIIMG2 "E:\\Users\\fwf\Desktop\\TestFiles\\xulines2.png"
#define CARHEAHIMG "‪E:\\Users\\fwf\\Desktop\\实习素材\\Tran3\\2015-05-06093327_TRANSFORMAT.jpg"
#define MODELIMG "E:\\Users\\fwf\\Desktop\\道路标线\\导向箭头\\WBX0000050.jpg"
#define AIMIMAGE "‪E:\\Users\\fwf\\Desktop\\实习素材\\Tran3\\2015-05-06093316_TRANSFORMAT.jpg"
#define AIMIMAGEBIGSIZE "E:\\Users\\fwf\\Desktop\\实习素材\\Tran2\\2015-05-06093320_TRANSFORMAT.jpg"
#pragma once

extern  Mat g_sImage;
extern  Mat g_dstImage;
 
extern void  SmoothTest1();

extern void  ErodeTest();

extern void CannyTest(Mat);

extern void HoughTest(Mat);

extern void matchTest();

extern vector<vector<Point>> ContoursFind(Mat,int min =30,int max = 2000);

extern void LineReconTest();

extern void ColorRecon();

extern Mat  projection_transformation(Mat);

extern void ContrastTest(Mat src);

extern void FillTest();