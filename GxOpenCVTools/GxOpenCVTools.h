// GxOpenCVTools.h

#pragma once

using namespace System;

namespace GxOpenCVTools {

	public ref class Class1
	{
		// TODO:  �ڴ˴���Ӵ���ķ�����
	public:
		int DoSomething(int t)
		{
			return 2 * t;
		}

		int DoSomething(cli::array<int> ^value)
		{
			pin_ptr<int> p = &value[0];
			int *pp = p;

			return 0;
		}
	};
}
