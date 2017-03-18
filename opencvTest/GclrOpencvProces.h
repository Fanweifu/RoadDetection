#pragma once

public ref class GclrOpencvProces
{
public:
	GclrOpencvProces();
	GclrOpencvProces(System::String^);

private:
	System::String ^m_srcpath;
public:
	int EditReflectAngle(int t);

	int EditReflectAngle(cli::array<int> ^value);
	static System::Drawing::Bitmap^ BitmapTransformation(System::Drawing::Bitmap ^ srcpic, double lt, double x, double y, int w , int h );
	static bool BitmapTransformation(System::String^ srcpath, double lt, double x, double y, int w, int h);
	static System::Drawing::Bitmap^ BitmapGetRoadImg(System::Drawing::Bitmap ^ srcpic,int maxS,int minV);
	static System::Drawing::Bitmap^ BitmapGetBlurImg(System::Drawing::Bitmap ^ srcpic, int methodID, int size);
//	static System::Drawing::Bitmap^ BitmapGetConImg(System::Drawing::Bitmap ^ srcpic, int methodID, int size);
	static System::Drawing::Bitmap^ BitmapGetOpenCloseImg(System::Drawing::Bitmap ^ srcpic, bool isopen, int size);
};
