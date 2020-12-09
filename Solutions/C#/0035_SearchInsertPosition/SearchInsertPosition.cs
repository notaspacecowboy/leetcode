using System;

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1, mid;

        while (left < right)
        {
            mid = (left + right) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }

            if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        if (nums[left] == target)
        {
            return left;
        }

        if (nums[left] > target)
        {
            return left;
        }

        return left + 1;
    }
}
