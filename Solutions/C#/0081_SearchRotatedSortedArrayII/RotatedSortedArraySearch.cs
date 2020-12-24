public class Solution {
    public bool Search(int[] nums, int target) {
        if(nums.Length == 0)
            return false;
        
        int left = 0, right = nums.Length - 1, mid;
        while(left <= right)
        {
            mid = (left + right) / 2;
            if(nums[mid] == target || nums[left] == target || nums[right] == target)
                return true;
            
            if(nums[left] == nums[right])
            {
                left++;
                right--;
            }
            else if(nums[mid] >= nums[left])
            {
                if(target < nums[mid]  && target > nums[left])
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
                if(target > nums[left])
                {
                    right = mid - 1;
                }
                else if(target < nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
                
            }
            
        }
        
        return false;
    }
}