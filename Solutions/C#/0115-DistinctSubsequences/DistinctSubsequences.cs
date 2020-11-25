using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DistinctSubsequence
{
    public class Solution
    {
        private int[,] dp;
        public int NumDistinct(string s, string t)
        {
            if (s.Length == 0 || t.Length > s.Length)
                return 0;

            if (t.Length == 0)
                return 1;

            dp = new int[s.Length,t.Length];

            int i, j;
            for (i = 0; i < s.Length; i++)
            {
                for (j = 0; j < s.Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = (s[0] == t[0] ? 1 : 0);
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j] + (s[i] == t[j] ? 1 : 0);
                    }
                    else if (i < j)
                    {
                        dp[i, j] = 0;
                    }
                    else
                    {
                        if (s[i] != t[j])
                        {
                            dp[i, j] = dp[i - 1, j];
                        }
                        else
                        {
                            dp[i, j] = dp[i - 1, j] + dp[i - 1, j - 1];
                        }
                    }
                }
            }

            return dp[s.Length, t.Length];
        }
    }
}
