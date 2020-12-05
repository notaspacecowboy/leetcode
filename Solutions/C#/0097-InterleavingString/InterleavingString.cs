using System;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace InterleavingString
{
    public class Solution
    {
        private bool[,] dp;
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
                return false;

            dp = new bool[s1.Length + 1, s2.Length + 1];
            dp[0, 0] = true;
            int i, j;
            for (i = 1; i <= s1.Length; i++)
            {
                dp[i, 0] = dp[i - 1, 0] && s1[i - 1] == s3[i - 1];
            }

            for (j = 1; j <= s2.Length; j++)
            {
                dp[0, j] = dp[0, j - 1] && s2[j - 1] == s3[j - 1];
            }

            for (i = 1; i <= s1.Length; i++)
            {
                for (j = 1; j <= s2.Length; j++)
                {
                    dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) ||
                               (dp[i, j - 1] && s2[j - 1] == s3[i + j - 1]);
                }
            }

            return dp[s1.Length, s2.Length];
        }
    } 
}
