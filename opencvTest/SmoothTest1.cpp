#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include "TestFunction.h"
#include<iostream>
using namespace cv;
using namespace std;

Mat  g_dstImage1, g_dstImage2, g_dstImage3, g_dstImage4, g_dstImage5;//�洢ͼƬ��Mat����  
int g_nBoxFilterValue = 3;  //�����˲�����ֵ  
int g_nMeanBlurValue = 3;  //��ֵ�˲�����ֵ  
int g_nGaussianBlurValue = 3;  //��˹�˲�����ֵ
int g_nMedianBlurValue = 10;  //��ֵ�˲�����ֵ  
int g_nBilateralFilterValue = 10;  //˫���˲�����ֵ 

static void on_BoxFilter(int, void *);            //�����˲�  
static void on_MeanBlur(int, void *);           //��ֵ�˲�  
static void on_GaussianBlur(int, void *);
static void on_MedianBlur(int, void *);               //��ֵ�˲���  
static void on_BilateralFilter(int, void*);                    //˫���˲���  

 void SmoothTest1(){

	g_sImage = imread(IMGPATH, CV_LOAD_IMAGE_ANYDEPTH | CV_LOAD_IMAGE_ANYCOLOR);
	if (!g_sImage.data){ printf("��ȡʧ��"); }

	//�ı�console������ɫ  
	//system("color5E");



	//��¡ԭͼ������Mat������  
	g_dstImage1 = g_sImage.clone();
	g_dstImage2 = g_sImage.clone();
	g_dstImage3 = g_sImage.clone();
	g_dstImage4 = g_sImage.clone();
	g_dstImage5 = g_sImage.clone();

	//��ʾԭͼ  
	namedWindow("��<0>ԭͼ���ڡ�", 1);
	imshow("��<0>ԭͼ���ڡ�", g_sImage);


	//=================��<1>�����˲���==================  
	//��������  
	namedWindow("��<1>�����˲���", 1);
	//�����켣��  
	createTrackbar("�ں�ֵ��", "��<1>�����˲���", &g_nBoxFilterValue, 40, on_BoxFilter);
	on_MeanBlur(g_nBoxFilterValue, 0);
	imshow("��<1>�����˲���", g_dstImage1);
	//================================================  

	//=================��<2>��ֵ�˲���==================  
	//��������  
	namedWindow("��<2>��ֵ�˲���", 1);
	//�����켣��  
	createTrackbar("�ں�ֵ��", "��<2>��ֵ�˲���", &g_nMeanBlurValue, 40, on_MeanBlur);
	on_MeanBlur(g_nMeanBlurValue, 0);
	//================================================  

	//=================��<3>��˹�˲���=====================  
	//��������  
	namedWindow("��<3>��˹�˲���", 1);
	//�����켣��  
	createTrackbar("�ں�ֵ��", "��<3>��˹�˲���", &g_nGaussianBlurValue, 40, on_GaussianBlur);
	on_GaussianBlur(g_nGaussianBlurValue, 0);
	//================================================  

	//=================��<4>��ֵ�˲���===========================  
	//��������  
	namedWindow("��<4>��ֵ�˲���", 1);
	//�����켣��  
	createTrackbar("����ֵ��", "��<4>��ֵ�˲���", &g_nMedianBlurValue, 50, on_MedianBlur);
	on_MedianBlur(g_nMedianBlurValue, 0);
	//=======================================================  


	//=================��<5>˫���˲���===========================  
	//��������  
	namedWindow("��<5>˫���˲���", 1);
	//�����켣��  
	createTrackbar("����ֵ��", "��<5>˫���˲���", &g_nBilateralFilterValue, 50, on_BilateralFilter);
	on_BilateralFilter(g_nBilateralFilterValue, 0);
	//=======================================================  



	//���һЩ������Ϣ  
	cout << endl << "\t�š����ˣ�������������۲�ͼ��Ч��~\n\n"
		<< "\t���¡�q����ʱ�������˳�~!\n"
		<< "\n\n\t\t\t\tbyǳī";

	//���¡�q����ʱ�������˳�  
	while (char(waitKey(1)) != 'q') {}

	return;

}



	 //-----------------------------��on_BoxFilter( )������------------------------------------  
	 //     �����������˲������Ļص�����  
	 //-----------------------------------------------------------------------------------------------  
	 static void on_BoxFilter(int, void *)
	 {
		 //�����˲�����  
		 boxFilter(g_sImage, g_dstImage1, -1, Size(g_nBoxFilterValue + 1, g_nBoxFilterValue + 1));
		 //��ʾ����  
		 imshow("��<1>�����˲���", g_dstImage1);
	 }


	 //-----------------------------��on_MeanBlur( )������------------------------------------  
	 //     ��������ֵ�˲������Ļص�����  
	 //-----------------------------------------------------------------------------------------------  
	 static void on_MeanBlur(int, void *)
	 {
		 //��ֵ�˲�����  
		 blur(g_sImage, g_dstImage2, Size(g_nMeanBlurValue + 1, g_nMeanBlurValue + 1), Point(-1, -1));
		 //��ʾ����  
		 imshow("��<2>��ֵ�˲���", g_dstImage2);
	 }


	 //-----------------------------��on_GaussianBlur( )������------------------------------------  
	 //     ��������˹�˲������Ļص�����  
	 //-----------------------------------------------------------------------------------------------  
	 static void on_GaussianBlur(int, void *)
	 {
		 //��˹�˲�����  
		 GaussianBlur(g_sImage, g_dstImage3, Size(g_nGaussianBlurValue * 2 + 1, g_nGaussianBlurValue * 2 + 1), 0, 0);
		 //��ʾ����  
		 imshow("��<3>��˹�˲���", g_dstImage3);
	 }
	
	 //-----------------------------��on_MedianBlur( )������------------------------------------  
	 //            ��������ֵ�˲������Ļص�����  
	 //-----------------------------------------------------------------------------------------------  
	 static void on_MedianBlur(int, void *)
	 {
		 medianBlur(g_sImage, g_dstImage4, g_nMedianBlurValue * 2 + 1);
		 imshow("��<4>��ֵ�˲���", g_dstImage4);
	 }


	 //-----------------------------��on_BilateralFilter( )������------------------------------------  
	 //            ������˫���˲������Ļص�����  
	 //-----------------------------------------------------------------------------------------------  
	 static void on_BilateralFilter(int, void *)
	 {
		 bilateralFilter(g_sImage, g_dstImage5, g_nBilateralFilterValue, g_nBilateralFilterValue * 2, g_nBilateralFilterValue / 2);
		 imshow("��<5>˫���˲���", g_dstImage5);
	 }

	  