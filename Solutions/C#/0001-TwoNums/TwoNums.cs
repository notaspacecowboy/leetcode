using System;
using System.Collections.Generic;

namespace TwoNums
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numDic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                numDic[nums[i]] = i;
            }

            int secondNum;
            int[] ans = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                secondNum = target - nums[i];
                if (numDic.ContainsKey(secondNum) && numDic[secondNum] != i)
                {
                    ans[0] = i;
                    ans[1] = numDic[secondNum];
                    break;
                }
            }
            return ans;
        }
    }
}
