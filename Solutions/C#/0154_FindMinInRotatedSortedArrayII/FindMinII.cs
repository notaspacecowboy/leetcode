public class Solution
{
    public int FindMin(int[] nums)
    {
        int left = 0, right = nums.Length - 1, minn = nums[0], mid;
        while (left <= right)
        {
            if(left != right && nums[left] == nums[right])
            {
                right--;
                continue;
            }
            mid = (left + right) / 2;
            if (nums[mid] < minn)
                minn = nums[mid];

            if (nums[mid] >= nums[0])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return minn;
    }
}