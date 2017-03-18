#include <opencv2/opencv.hpp>  
#include <opencv2/highgui/highgui.hpp>  
#include <opencv2/imgproc/imgproc.hpp>  
#include "TestFunction.h";



//-----------------------------------【命名空间声明部分】--------------------------------------  
//      描述：包含程序所使用的命名空间  
//-----------------------------------------------------------------------------------------------   
using namespace std;
using namespace cv;

void LineReconTest()

{


	IplImage* src;

	if ( (src = cvLoadImage(LINESIMGPATH , 0)) != 0)

	{


		IplImage* dst = cvCreateImage(cvGetSize(src), 8, 1);

		IplImage* color_dst = cvCreateImage(cvGetSize(src), 8, 3);

		CvMemStorage* storage = cvCreateMemStorage(0);

		CvSeq* lines = 0;

		int i;

		cvCanny(src, dst, 50, 200, 3);

		cvCvtColor(dst, color_dst, CV_GRAY2BGR);



#if 1



		CvRect rect;

		rect.x = 0;

		rect.y = int((src->height) / 40 * 9);

		rect.width = (src->width) / 8 * 7;

		rect.height = int((src->height) / 5 * 4);

		printf(" %d %d %d %d  \n", rect.x, rect.y, rect.width, rect.height);

		//printf(" %d    lin1Y: %d\n", line[1].x, line[1].y );



		cvSetImageROI(dst, rect);







		lines = cvHoughLines2(dst, storage, CV_HOUGH_PROBABILISTIC, 1, CV_PI / 180, 60, 25, 35);

		double ARR[10000];

		ARR[0] = 0;

		int ACC;

		int j = 0;

		for (int i = 0; i < lines->total; i++)

		{


			CvPoint* line = (CvPoint*)cvGetSeqElem(lines, i);

			double slope = ((double)(line[0].y - line[1].y)) / ((double)(line[0].x - line[1].x));  

			double AngL = 180 * atan(slope) / CV_PI;

			if ((AngL >-65 && AngL< -25) || (AngL >25 && AngL< 65))

			{
			

				//double Len2=pow(double(line[0].y - line[1].y),2)+pow(double(line[0].x - line[1].x),2);



				double Len = (double)((line[0].x - line[1].x)*(line[0].x - line[1].x) + (line[0].y - line[1].y)*(line[0].y - line[1].y));

				ARR[i] = Len;

				//double b=(double)(line[0].x - line[1].x)*(line[0].x - line[1].x);

				printf("lin0X: %d    lin0Y: %d\n", line[0].x, line[0].y);

				printf("lin1X: %d    lin1Y: %d\n", line[1].x, line[1].y);

				printf("LEN: %f\n", Len);

				printf("LEN: %f\n", ARR[i]);

				printf("ANG: %f\n", 180 * atan(slope) / CV_PI);

				/*line[0].y =line[0].y+rect.y;

				line[1].y =line[1].y+rect.y;

				cvLine (color_dst, line[0], line[1], CV_RGB(255,0,0),2,8);  */

				//cvLine (src, line[0], line[1], CV_RGB(255,0,0),2,8);//;u�Q�~r��v�~



				if (ARR[i]>ARR[j])

				{


					ACC = i;

					j = i;


				}

				printf("ACC: %d\n", ACC);


			}




		}



		CvPoint* line = (CvPoint*)cvGetSeqElem(lines, ACC);

		line[0].x = line[0].x + rect.x;

		line[1].x = line[1].x + rect.x;

		line[0].y = line[0].y + rect.y;

		line[1].y = line[1].y + rect.y;

		cvLine(color_dst, line[0], line[1], CV_RGB(255, 0, 0), 2, 8);



#else 

		lines = cvHoughLines2(dst, storage,

			CV_HOUGH_PROBABILISTIC, 1, CV_PI / 180, 80, 30, 10);

		for (i = 0; i <� lines->total; i++)

		{


			CvPoint* line = (CvPoint*)cvGetSeqElem(lines, i);

			cvLine(color_dst, line[0], line[1], CV_RGB(255, 0, 0), 3, 8);


		}

#endif 



		cvNamedWindow("Source", 1);

		cvShowImage("Source", src);

		cvNamedWindow("Hough", 1);

		cvShowImage("Hough", color_dst);

		/*cvNamedWindow( "Judge", 1 );

		cvShowImage( "Judge", ttt ); */

		cvResetImageROI(dst);

		cvWaitKey(0);


	}


}