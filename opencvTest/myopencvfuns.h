#include "opencv2/core/core.hpp"  
using namespace cv;
using namespace std;

extern Mat GetBinaryImage(Mat imgsrc, double thresholdpar);

extern Mat GetSobelXYImage(Mat imgsrc, int kernalsize = 1);

extern vector<vector<cv::Point>> GetContours(Mat binaryimg, int minpts = -1, int maxpts = -1);

extern Mat GetBulrImage(Mat imgsrc, int kernalsize = 10, int methodID = 4);

extern Mat DrawContours(vector<vector<cv::Point>> &cons, Mat &backimg, Scalar color = Scalar(255), int drawIndex = -1 );

extern Mat GetErodeDilate(Mat imgsrc, int kernalsize = 1, bool isEode = true);

extern void NewWindowsShow(string windowsname, Mat imgtoshow);

extern void ImageStretchByHistogram(Mat src, Mat &dst);

extern Mat KirschCheck(Mat src);

extern void EdgeEnhance(Mat&, Mat&);

extern int cvThresholdOtsu(IplImage*);

extern void Sharpen(const Mat&, Mat&);

extern Mat GetLinesImg(Mat roadimg, int maxS = 50, int minV = 180);

extern Mat GetColorLinesImg(Mat src, bool isShowProc = true);

extern Mat GetScharrImg(Mat);

extern Mat projection_transformation(Mat src, double ltk , double xk = 0.25, double yk = 0.5, int outwidth = 1024, int outheight = 1024);

extern System::Drawing::Bitmap^ ConvertMatToBitmap(cv::Mat cvImg);

extern int ConvertBitmapToMat(System::Drawing::Bitmap^ bmpImg, cv::Mat& cvImg);
