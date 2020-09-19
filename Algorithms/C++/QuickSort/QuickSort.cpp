#include <vector>

class QuickSortSolution
{
public:
	void QuickSort(std::vector<int>& nums, int begin, int end)
	{
		if (begin >= end)
			return;

		int boundary = Boundary(nums, begin, end);

		QuickSort(nums, begin, boundary - 1);
		QuickSort(nums, boundary + 1, end);
	}

private:
	int Boundary(std::vector<int>& nums, int begin, int end)
	{
		int leftPtr = begin;
		int rightPtr = end;
		int standard = nums[begin];

		while(leftPtr < rightPtr)
		{
			while(leftPtr < rightPtr && nums[rightPtr] >= standard)
				rightPtr--;
		
			nums[leftPtr] = nums[rightPtr];

			while (leftPtr < rightPtr && nums[leftPtr] <= standard)
				leftPtr++;

			nums[rightPtr] = nums[leftPtr];
		}

		nums[leftPtr] = standard;
		return leftPtr;
	}
};