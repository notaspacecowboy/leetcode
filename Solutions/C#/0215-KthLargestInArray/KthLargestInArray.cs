using System;

namespace KthLargestInArray
{
    public class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            QuickSort(nums, 0, nums.Length - 1);

            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }

            return nums[nums.Length - k];
        }

        void QuickSort(int[] nums, int begin, int end)
        {
            if (begin >= end)
                return;

            int mid = Boundary(nums, begin, end);
            QuickSort(nums, begin, mid);
            QuickSort(nums, mid + 1, end);
        }

        int Boundary(int[] nums, int begin, int end)
        {
            int leftPtr = begin;
            int rightPtr = end;
            int standard = nums[begin];

            while (leftPtr < rightPtr)
            {
                while (leftPtr < rightPtr && nums[rightPtr] >= standard)
                {
                    rightPtr--;
                }
                nums[leftPtr] = nums[rightPtr];

                while (leftPtr < rightPtr && nums[leftPtr] <= standard)
                {
                    leftPtr++;
                }
                nums[rightPtr] = nums[leftPtr];
            }

            nums[leftPtr] = standard;
            return leftPtr;
        }
    }
}
