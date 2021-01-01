public class Solution {
    public int LengthOfLIS(int[] nums) {
        int[] dp = new int[nums.Length];
        int maxn = 1;

        dp[0] = 1;
        for(int i = 1; i < nums.Length; i++)
        {
            dp[i] = 1;
            for(int j = 0; j < i; j++)
            {
                if(nums[j] < nums[i] && dp[j] >= dp[i])
                {
                    dp[i] = dp[j] + 1;
                }
            }
            
            if(dp[i] > maxn)
                maxn = dp[i];
        }
        return maxn;
    }
}