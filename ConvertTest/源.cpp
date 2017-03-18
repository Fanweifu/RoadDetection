#include "vectorTest.h"
#include "stdafx.h"
#include <vector>
using namespace std;
#define EXPORT extern "C" __declspec(dllexport)
typedef intptr_t ItemListHandle;

EXPORT bool GenerateItems(ItemListHandle* hItems, double** itemsFound, int* itemCount)
{
	auto items = new std::vector<double>();
	for (int i = 0; i < 500; i++)
	{
		items->push_back((double)i);
	}

	*hItems = reinterpret_cast<ItemListHandle>(items);
	*itemsFound = items->data();
	*itemCount = items->size();

	return true;
}

EXPORT bool ReleaseItems(ItemListHandle hItems)
{
	auto items = reinterpret_cast<std::vector<double>*>(hItems);
	delete items;

	return true;
}
