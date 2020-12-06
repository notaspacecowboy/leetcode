public class Solution {
    public int Search(int[] nums, int target) {
        int left = 0;
        int right = nums.Length - 1;
        int mid;
        while(left <= right)
        {
            mid = (left + right) / 2;
            
            if(target == nums[mid])
                return mid;
            
            if(nums[left] <= nums[mid])
            {
                if(target < nums[mid] && target >= nums[left])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else
            {
                if(target > nums[mid] && target <= nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }
        
        return -1;
    }
}