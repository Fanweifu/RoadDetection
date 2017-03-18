#include "opencv2/core/core.hpp"  
#include "opencv2/features2d/features2d.hpp"  
#include "opencv2/highgui/highgui.hpp"  
#include <opencv2/nonfree/nonfree.hpp>  
#include<opencv2/imgproc/imgproc.hpp>
#include<opencv2/legacy/legacy.hpp> 
#include "myopencvfuns.h"
#include "TestFunction.h"
using namespace cv;
using namespace std;

Mat GetBinaryImage(Mat imgsrc, double thresholdpar){
	assert(thresholdpar >= 0 && thresholdpar <= 255);
	Mat newimg;
	if (imgsrc.channels()!=1)
		cvtColor(imgsrc, imgsrc, CV_BGR2GRAY);
	threshold(imgsrc, newimg, thresholdpar, 255, THRESH_BINARY);
	return newimg;
}

Mat GetSobelXYImage(Mat imgsrc ,int kernalsize){
	Mat sobelGradient_X = imgsrc.clone(), sobelGradient_Y = imgsrc.clone(), result = imgsrc.clone();

	Sobel(imgsrc, sobelGradient_X, CV_16S, 1, 0, (2 * kernalsize + 1), 1, 1, BORDER_DEFAULT);
	convertScaleAbs(sobelGradient_X, sobelGradient_X);

	Sobel(imgsrc, sobelGradient_Y, CV_16S, 0, 1, (2 * kernalsize + 1), 1, 1, BORDER_DEFAULT);
	convertScaleAbs(sobelGradient_Y, sobelGradient_Y);

	addWeighted(sobelGradient_X, 0.5, sobelGradient_Y, 0.5, 0, result);
	
	return result;
}

vector<vector<Point>> GetContours(Mat binaryimg, int minpts , int maxpts ){
	vector < vector<Point>> cons;
	findContours(binaryimg, cons, CV_RETR_EXTERNAL, CV_CHAIN_APPROX_NONE);
	if (minpts == -1 ||maxpts == 1)
	{
		return cons;
	}
	else{
		int  a = 0;
		int b = a + 1;
	/*	vector<vector<Point>>::const_iterator itc = cons.begin();
		while (itc != cons.end())
		{
			if (itc->size() < minpts || itc->size() > maxpts){
				itc = cons.erase(itc);
			}
			else
				++itc;
		}*/
		return cons;
	}
}

Mat DrawContours(vector<vector<Point>> &cons, Mat &backimg , Scalar color,int drawIndex){
	int s = cons.size();
	assert(drawIndex <= s);
	Mat backimgcl = backimg.clone();
	drawContours(backimgcl, cons, drawIndex, color, 1);
	return backimgcl;
}

Mat GetBulrImage(Mat imgsrc, int kernalsize , int methodID ) {
	if (kernalsize <= 0)
		throw new Exception();

	Mat result = imgsrc.clone();

	switch (methodID)
	{
	case 0:
		boxFilter(imgsrc, result, -1, Size(kernalsize, kernalsize));
		break;
	case 1:
		blur(imgsrc, result, Size(kernalsize, kernalsize), Point(-1, -1));
		break;
	case 2:
		GaussianBlur(imgsrc, result, Size(kernalsize * 2 + 1, kernalsize * 2 + 1), 0, 0);
		break;
	case 3:
		medianBlur(imgsrc, result, kernalsize * 2 + 1);
		break;
	case 4:
		bilateralFilter(imgsrc, result, kernalsize, kernalsize * 2, kernalsize / 2);
		break;
	default:
		throw new Exception();
		break;
	}
	return result;
}



Mat GetErodeDilate(Mat imgsrc, int kernalsize , bool isEode){
	Mat result((imgsrc.size(), CV_8U, Scalar(0)));
	Mat element = getStructuringElement(MORPH_RECT, Size(2 * kernalsize + 1, 2 * kernalsize + 1), Point(kernalsize, kernalsize));
	if (!isEode){
		erode(imgsrc, result, element);
	}
	else
	{
		dilate(imgsrc, result, element);
	}
	return result;
}

void NewWindowsShow(string windowsname, Mat imgtoshow){

	try{
		namedWindow(windowsname, 1);
	}
	catch(Exception e){
		
	}
	imshow(windowsname, imgtoshow);
	waitKey();
}
void ImageStretchByHistogram(Mat src, Mat &dst){

	assert(src.size() == dst.size());
	vector<Mat> splits(src.channels());
	split(src, splits);
	for (int i = 0; i < src.channels();i++)
	{
		equalizeHist(splits[i], splits[i]);
	}
	merge(splits, dst);
}



void Kirsch(IplImage *&dst,IplImage *src)
{
	dst = cvCloneImage(src);
	//cvConvert(src,srcMat); //将图像转化成矩阵处理
	int x, y;
	float a, b, c, d;
	float p1, p2, p3, p4, p5, p6, p7, p8, p9;
	uchar* ps = (uchar*)src->imageData; //ps为指向输入图片数据的指针
	uchar* pd = (uchar*)dst->imageData; //pd为指向输出图片数据的指针
	int w = dst->width;
	int h = dst->height;
	int step = dst->widthStep;

	for (x = 0; x < w - 2; x++)      //取以（x+1，y+1)为中心的9个邻域像素  1 4 7
	{                                                            // 2 5 8
		for (y = 0; y < h - 2; y++)                                     // 3 6 9
		{
			p1 = ps[y*step + x];
			p2 = ps[y*step + (x + 1)];
			p3 = ps[y*step + (x + 2)];
			p4 = ps[(y + 1)*step + x];
			p5 = ps[(y + 1)*step + (x + 1)];
			p6 = ps[(y + 1)*step + (x + 2)];
			p7 = ps[(y + 2)*step + x];
			p8 = ps[(y + 2)*step + (x + 1)];
			p9 = ps[(y + 2)*step + (x + 2)];//得到(i+1,j+1)周围九个点的灰度值

			a = fabs(float(-5 * p1 - 5 * p2 - 5 * p3 + 3 * p4 + 3 * p6 + 3 * p7 + 3 * p8 + 3 * p9));    //计算4个方向的梯度值
			b = fabs(float(3 * p1 - 5 * p2 - 5 * p3 + 3 * p4 - 5 * p6 + 3 * p7 + 3 * p8 + 3 * p9));
			c = fabs(float(3 * p1 + 3 * p2 - 5 * p3 + 3 * p4 - 5 * p6 + 3 * p7 + 3 * p8 - 5 * p9));
			d = fabs(float(3 * p1 + 3 * p2 + 3 * p3 + 3 * p4 - 5 * p6 + 3 * p7 - 5 * p8 - 5 * p9));
			a = max(a, b);                                         //取各个方向上的最大值作为边缘强度
			a = max(a, c);
			a = max(a, d);
			pd[(y + 1)*step + (x + 1)] = a;
		}
	}
}
Mat KirschCheck(Mat src){
	IplImage *ipimg = &IplImage(src);
	IplImage *ipimgcl;
	Kirsch(ipimgcl,ipimg);
	return Mat(ipimgcl, true);
}

void EdgeEnhance(Mat& srcImg, Mat& dstImg)
{
	if (!dstImg.empty())
	{
		dstImg.release();
	}

	std::vector<cv::Mat> rgb;

	if (srcImg.channels() == 3)        // rgb image  
	{
		cv::split(srcImg, rgb);
	}
	else if (srcImg.channels() == 1)   // gray image  
	{
		rgb.push_back(srcImg);
	}

	// 分别对R、G、B三个通道进行边缘增强  
	for (size_t i = 0; i < rgb.size(); i++)
	{
		cv::Mat sharpMat8U;
		cv::Mat sharpMat;
		cv::Mat blurMat;

		// 高斯平滑  
		cv::GaussianBlur(rgb[i], blurMat, cv::Size(3, 3), 0, 0);

		// 计算拉普拉斯  
		cv::Laplacian(blurMat, sharpMat, CV_16S);

		// 转换类型  
		sharpMat.convertTo(sharpMat8U, CV_8U);
		cv::add(rgb[i], sharpMat8U, rgb[i]);
	}


	cv::merge(rgb, dstImg);
}

int cvThresholdOtsu(IplImage* src)
{
	int height = src->height;
	int width = src->width;

	//histogram   
	float histogram[256] = { 0 };
	for (int i = 0; i < height; i++) {
		unsigned char* p = (unsigned char*)src->imageData + src->widthStep*i;
		for (int j = 0; j < width; j++) {
			histogram[*p++]++;
		}
	}
	//normalize histogram   
	int size = height*width;
	for (int i = 0; i < 256; i++) {
		histogram[i] = histogram[i] / size;
	}

	//average pixel value   
	float avgValue = 0;
	for (int i = 0; i < 256; i++) {
		avgValue += i*histogram[i];
	}

	int threshold;
	float maxVariance = 0;
	float w = 0, u = 0;
	for (int i = 0; i < 256; i++) {
		w += histogram[i];
		u += i*histogram[i];

		float t = avgValue*w - u;
		float variance = t*t / (w*(1 - w));
		if (variance > maxVariance) {
			maxVariance = variance;
			threshold = i;
		}


	}

	return threshold;
}

void Sharpen(const Mat &img, Mat &result)
{

	result.create(img.size(), img.type());
	//处理边界内部的像素点, 图像最外围的像素点应该额外处理
	for (int row = 1; row < img.rows - 1; row++)
	{
		//前一行像素点
		const uchar* previous = img.ptr<const uchar>(row - 1);
		//待处理的当前行
		const uchar* current = img.ptr<const uchar>(row);
		//下一行
		const uchar* next = img.ptr<const uchar>(row + 1);
		uchar *output = result.ptr<uchar>(row);
		int ch = img.channels();
		int starts = ch;
		int ends = (img.cols - 1) * ch;
		for (int col = starts; col < ends; col++)
		{
			//输出图像的遍历指针与当前行的指针同步递增, 以每行的每一个像素点的每一个通道值为一个递增量, 因为要考虑到图像的通道数
			*output++ = saturate_cast<uchar>(5 * current[col] - current[col - ch] - current[col + ch] - previous[col] - next[col]);
		}
	} //end loop
	//处理边界, 外围像素点设为 0
	result.row(0).setTo(Scalar::all(0));
	result.row(result.rows - 1).setTo(Scalar::all(0));
	result.col(0).setTo(Scalar::all(0));
	result.col(result.cols - 1).setTo(Scalar::all(0));
}

Mat GetLinesImg(Mat roadimg, int maxS, int minV){
	int yellowHLeft = 15;
	int yellowHRight = 35;
	int yellowMinS = 43;
	int yellowMinV = 100;
	int writeMaxS = maxS > 255 ? 255 : (maxS < 0 ? 0 : maxS);
	int writeMinV = minV > 255 ? 255 : (minV < 0 ? 0 : minV);
	vector<Mat> channels;


	Mat hsvimg;
	cvtColor(roadimg, hsvimg, CV_BGR2HSV);

	for (int i = 0; i < hsvimg.rows; i++)
	{
		for (int j = 0; j < hsvimg.cols; j++)
		{
			Vec3b v = hsvimg.at<Vec3b>(i, j);
			bool isw = v[1] <= writeMaxS && v[2] >= writeMinV;
			bool isy = v[0] >= yellowHLeft && v[0] <= yellowHRight && v[1] >= yellowMinS && v[2] >= yellowMinV;
			if (!(isw || isy)){
				hsvimg.at<Vec3b>(i, j) = Vec3b(0, 0, 0);
			}

		}
	}
	Mat result;
	cvtColor(hsvimg, result, CV_HSV2BGR);
	return result;

}


Mat GetColorLinesImg(Mat src, bool isShowProc){

	//Mat d1 = GetErodeDilate(src, 1, false);
	//Mat d2 = GetErodeDilate(d1, 1);
	Mat bulr = GetBulrImage(src, 20, 4);

	Mat img = GetLinesImg(bulr);


	waitKey();
	if (isShowProc){
		NewWindowsShow("bulr", bulr);;
		NewWindowsShow("img", img);
		//NewWindowsShow("d2", d2);
		waitKey();
	}
	return img(Rect(img.cols / 6, 0, img.cols * 4 / 6, img.rows));
}

Mat GetScharrImg(Mat inputimg){
	Mat g_scharrGradient_X, g_scharrGradient_Y;
	Mat g_scharrAbsGradient_X, g_scharrAbsGradient_Y;
	Mat result(inputimg.size(), false);
	Scharr(inputimg, g_scharrGradient_X, CV_16S, 1, 0, 1, 0, BORDER_DEFAULT);
	convertScaleAbs(g_scharrGradient_X, g_scharrAbsGradient_X);//计算绝对值，并将结果转换成8位  

	// 求Y方向梯度  
	Scharr(inputimg, g_scharrGradient_Y, CV_16S, 0, 1, 1, 0, BORDER_DEFAULT);
	convertScaleAbs(g_scharrGradient_Y, g_scharrAbsGradient_Y);//计算绝对值，并将结果转换成8位  

	// 合并梯度  
	addWeighted(g_scharrAbsGradient_X, 0.4, g_scharrAbsGradient_Y, 0.6, 0, result);

	//显示效果图  
	return result;

}

Mat projection_transformation(Mat src, double ltk , double xk , double yk , int outwidth , int outheight ){
	assert(src.data);
	assert(outwidth >= 1 && outheight >= 1);
	Mat rot_mat(2, 3, CV_32FC1);
	int inw = src.cols;
	int inh = src.rows;
	Point2f _srcTri[4];
	Point2f _dstTri[4];
	_srcTri[0] = Point2f(xk*inw, yk*inh);
	_srcTri[1] = Point2f(inw - xk*inw, yk*inh);
	_srcTri[2] = Point2f(ltk*inw + (inw / 2 + 1), inh - 1);
	_srcTri[3] = Point2f((inw / 2) - ltk*inw, inh - 1);

	_dstTri[0] = Point2f(0, 0);
	_dstTri[1] = Point2f(outwidth - 1, 0);
	_dstTri[2] = Point2f(outwidth - 1, outheight - 1);
	_dstTri[3] = Point2f(0, outheight - 1);
	Mat dst = Mat::zeros(outheight, outwidth, src.type());
	Mat warpmat(2, 3, CV_32FC1);
	warpmat = getPerspectiveTransform(_srcTri, _dstTri);
	warpPerspective(src, dst, warpmat, dst.size(), INTER_LINEAR, BORDER_CONSTANT);
	return dst;
}


int ConvertBitmapToMat(System::Drawing::Bitmap^ bmpImg, cv::Mat& cvImg)
{
	int retVal = 0;
	
	//锁定Bitmap数据  
	System::Drawing::Imaging::BitmapData^ bmpData = bmpImg->LockBits(
		System::Drawing::Rectangle(0, 0, bmpImg->Width, bmpImg->Height),
		System::Drawing::Imaging::ImageLockMode::ReadWrite, bmpImg->PixelFormat);

	//若cvImg非空，则清空原有数据  
	if (!cvImg.empty())
	{
		cvImg.release();
	}
		

	//将 bmpImg 的数据指针复制到 cvImg 中，不拷贝数据  
	if (bmpImg->PixelFormat == System::Drawing::Imaging::PixelFormat::Format8bppIndexed)  // 灰度图像  
	{
		cvImg = cv::Mat(bmpImg->Height, bmpImg->Width, CV_8UC1, (char*)bmpData->Scan0.ToPointer());
	}
	else if (bmpImg->PixelFormat == System::Drawing::Imaging::PixelFormat::Format24bppRgb)   // 彩色图像  
	{
		cvImg = cv::Mat(bmpImg->Height, bmpImg->Width, CV_8UC3, (char*)bmpData->Scan0.ToPointer());
	}

	//解锁Bitmap数据  
	bmpImg->UnlockBits(bmpData);

	return (retVal);
}

System::Drawing::Bitmap^ ConvertMatToBitmap(cv::Mat srcImg)
{
	int stride = srcImg.size().width * srcImg.channels();//calc the srtide
	int hDataCount = srcImg.size().height;

	System::Drawing::Bitmap^ retImg;

	System::IntPtr ptr(srcImg.data);

	//create a pointer with Stride
	if (stride % 4 != 0){//is not stride a multiple of 4?
		//make it a multiple of 4 by fiiling an offset to the end of each row

		//to hold processed data
		uchar *dataPro = new uchar[((srcImg.size().width * srcImg.channels() + 3) & -4) * hDataCount];

		uchar *data = srcImg.ptr();

		//current position on the data array
		int curPosition = 0;
		//current offset
		int curOffset = 0;

		int offsetCounter = 0;

		//itterate through all the bytes on the structure
		for (int r = 0; r < hDataCount; r++){
			//fill the data
			for (int c = 0; c < stride; c++){
				curPosition = (r * stride) + c;

				dataPro[curPosition + curOffset] = data[curPosition];
			}

			//reset offset counter
			offsetCounter = stride;

			//fill the offset
			do{
				curOffset += 1;
				dataPro[curPosition + curOffset] = 0;

				offsetCounter += 1;
			} while (offsetCounter % 4 != 0);
		}

		ptr = (System::IntPtr)dataPro;//set the data pointer to new/modified data array

		//calc the stride to nearest number which is a multiply of 4
		stride = (srcImg.size().width * srcImg.channels() + 3) & -4;

		retImg = gcnew System::Drawing::Bitmap(srcImg.size().width, srcImg.size().height,
			stride,
			System::Drawing::Imaging::PixelFormat::Format24bppRgb,
			ptr);
	}
	else{

		//no need to add a padding or recalculate the stride
		retImg = gcnew System::Drawing::Bitmap(srcImg.size().width, srcImg.size().height,
			stride,
			System::Drawing::Imaging::PixelFormat::Format24bppRgb,
			ptr);
	}

	array<uchar>^ imageData;
	System::Drawing::Bitmap^ output;

	// Create the byte array.
	{
		System::IO::MemoryStream^ ms = gcnew System::IO::MemoryStream();
		retImg->Save(ms, System::Drawing::Imaging::ImageFormat::Png);
		imageData = ms->ToArray();
		delete ms;
	}

	// Convert back to bitmap
	{
		System::IO::MemoryStream^ ms = gcnew System::IO::MemoryStream(imageData);
		output = (System::Drawing::Bitmap^)System::Drawing::Bitmap::FromStream(ms);
	}

	return output;

}
