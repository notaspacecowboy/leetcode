public class Solution {
    public int MinSubArrayLen(int s, int[] nums) {
        int minn = nums.Length + 1, left = 0, right = 0, acc = 0;
        while(right < nums.Length)
        {
            acc += nums[right];
            while(acc >= s)
            {
                minn = (minn > (right - left + 1) ? (right - left + 1) : minn);
                acc -= nums[left++];
            }
            right++;
        }
        
        return (minn == nums.Length + 1 ? 0 : minn);
    }
}