using System;

namespace MaximumSubarray
{
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            int[] dp = new int[nums.Length]; 

            dp[0] = nums[0];

            int max = dp[0], tmp;
            for (int i = 1; i < nums.Length; i++)
            {
                tmp = dp[i - 1] + nums[i];
                dp[i] = (tmp > nums[i] ? tmp : nums[i]);

                if (dp[i] > max)
                {
                    max = dp[i];
                }
            }

            return max;
        }
    }
}
