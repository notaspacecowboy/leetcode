using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;

namespace LongestValidParentheses
{
    public class Solution
    {
        /// <summary>
        /// i'th element of dp stores the longest valid parenthesis ends at ith
        /// element of string s
        /// </summary>
        public int[] dp;     
        public int LongestValidParentheses(string s)
        {
            int max = 0;
            dp = new int[s.Length];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 0;
            }

            for (int i = 1; i < s.Length; i++)
            {
                //if s[i] = ')', then it could be the end of a valid parenthesis
                if (s[i] == ')')
                {
                    //parenthesis looks like "((...))" where "(...)" is valid parenthesis
                    if (i - 1 - dp[i - 1] >= 0 && s[i - 1 - dp[i - 1]] == '(')
                    {
                        dp[i] = dp[i - 1] + 2;
                        if (i - 1 - dp[i - 1] - 1 > 0)
                            dp[i] += dp[i - 1 - dp[i - 1] - 1];
                    }

                    //if parenthesis look like ")(...))", then it is not valid
                    //if it is the case, leave dp[i] as 0
                }

                //if s[i] = '(', then it could not be the end of a valid parenthesis
                //hence if that is the case, leave dp[i] as 0

                if (dp[i] > max)
                    max = dp[i];
            }
            return max;
        }
    }
}
