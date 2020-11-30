using System;

namespace LongestPalindromicSubstring
{
    class Solution
    {
        public string longestPalindrome(string s)
        {
            if (s == "")
                return s;

            int max = 0;
            int len = s.Length;
            string ans = "";

            bool[,] dp = new bool[len, len];
            bool flag = false;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    flag = (s[i] == s[j]);

                    if (i == j)
                        dp[j, i] = true;

                    else if (i == j + 1)
                        dp[j, i] = (flag ? true : false);

                    else
                        dp[j, i] = (dp[j + 1, i - 1] && flag);

                    if (dp[j, i] && i - j + 1 > max)
                    {
                        max = i - j + 1;
                        ans = s.Substring(j, i - j + 1);
                    }
                }
            }

            return ans;
        }
    }
}
