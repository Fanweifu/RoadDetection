#include<opencv2/core/core.hpp>
#include<opencv2/highgui/highgui.hpp>
#include<opencv2/imgproc/imgproc.hpp>
#include "TestFunction.h"
#include<iostream>
using namespace cv;
int g_nTrackbarNumer = 0;//0��ʾ��ʴerode, 1��ʾ����dilate  
int g_nStructElementSize = 3; //�ṹԪ��(�ں˾���)�ĳߴ�  

//-----------------------------------��ȫ�ֺ����������֡�--------------------------------------  
//            ������ȫ�ֺ�������  
//-----------------------------------------------------------------------------------------------  
void Process();//���ͺ͸�ʴ�Ĵ�����  
void on_TrackbarNumChange(int, void *);//�ص�����  
void on_ElementSizeChange(int, void *);//�ص�����  


//-----------------------------------��main( )������--------------------------------------------  
//            ����������̨Ӧ�ó������ں��������ǵĳ�������￪ʼ  
//-----------------------------------------------------------------------------------------------  
void  ErodeTest()
{

	//�ı�console������ɫ  
	system("color5E");

	//����ԭͼ  
	 g_sImage = imread(IMGPATH);
	if (!g_sImage.data) { printf("Oh��no����ȡsrcImage����~��\n"); return ; }

	//��ʾԭʼͼ  
	namedWindow("��ԭʼͼ��");
	imshow("��ԭʼͼ��", g_sImage);

	//���г��θ�ʴ��������ʾЧ��ͼ  
	namedWindow("��Ч��ͼ��");
	//��ȡ�Զ����  
	Mat element = getStructuringElement(MORPH_RECT, Size(2 * g_nStructElementSize + 1, 2 * g_nStructElementSize + 1), Point(g_nStructElementSize, g_nStructElementSize));
	erode(g_sImage, g_dstImage, element);
	imshow("��Ч��ͼ��", g_dstImage);

	//�����켣��  
	createTrackbar("��ʴ/����", "��Ч��ͼ��", &g_nTrackbarNumer, 1, on_TrackbarNumChange);
	createTrackbar("�ں˳ߴ�", "��Ч��ͼ��", &g_nStructElementSize, 21, on_ElementSizeChange);

	//���һЩ������Ϣ  
	cout << endl << "\t�š����гɹ���������������۲�ͼ��Ч��~\n\n"
		<< "\t���¡�q����ʱ�������˳�~!\n"
		<< "\n\n\t\t\t\tbyǳī";

	//��ѯ��ȡ������Ϣ������q���������˳�  
	while (char(waitKey(1)) != 'q') {}

	return ;
}

//-----------------------------��Process( )������------------------------------------  
//            �����������Զ���ĸ�ʴ�����Ͳ���  
//-----------------------------------------------------------------------------------------  
void Process()
{
	//��ȡ�Զ����  
	Mat element = getStructuringElement(MORPH_RECT, Size(2 * g_nStructElementSize + 1, 2 * g_nStructElementSize + 1), Point(g_nStructElementSize, g_nStructElementSize));

	//���и�ʴ�����Ͳ���  
	if (g_nTrackbarNumer == 0) {
		erode(g_sImage, g_dstImage, element);
	}
	else{
		dilate(g_sImage, g_dstImage, element);
	}

	//��ʾЧ��ͼ  
	imshow("��Ч��ͼ��", g_dstImage);
}


//-----------------------------��on_TrackbarNumChange( )������------------------------------------  
//            ��������ʴ������֮���л����صĻص�����  
//-----------------------------------------------------------------------------------------------------  
void on_TrackbarNumChange(int, void *)
{
	//��ʴ������֮��Ч���Ѿ��л����ص��������������һ��Process������ʹ�ı���Ч��������Ч����ʾ����  
	Process();
}


//-----------------------------��on_ElementSizeChange( )������-------------------------------------  
//            ��������ʴ�����Ͳ����ں˸ı�ʱ�Ļص�����  
//-----------------------------------------------------------------------------------------------------  
void on_ElementSizeChange(int, void *)
{
	//�ں˳ߴ��Ѹı䣬�ص��������������һ��Process������ʹ�ı���Ч��������Ч����ʾ����  
	Process();
}
