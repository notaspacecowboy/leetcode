public class Solution {
    public int[] TwoSum(int[] numbers, int target) 
    {
        int left = 0, right = numbers.Length - 1;
        int[] ans = new int[2]{-1, -1};
        
        while(left <= right)
        {
            if(numbers[left] + numbers[right] == target)
            {
                ans[0] = left + 1;
                ans[1] = right + 1;
                return ans;
            }
            else if(numbers[left] + numbers[right] < target)
                left++;
            else
                right--;
        }
        
        return ans;
    }
}