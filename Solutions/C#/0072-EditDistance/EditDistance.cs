using System;
using System.Globalization;
using Microsoft.VisualBasic.CompilerServices;

namespace EditDistance
{
    public class Solution 
    {
        //dp function
        //dp[i,j] denotes minimum steps to convert first i characters in word1 to first j characters in word2
        //dp = max(word1.length, word2.length)         if min(word1.length, word2.length) = 0
        //     this is because if one of the string is empty, the minimum steps to convert one to another is to
        //     insert/remove exact number of characters in the non-empty string
        //dp = min(dp[i - 1, j] + 1, dp[i, j - 1] + 1, dp[i - 1, j - 1] + 1{word1[i] == word2[j])
        //dp[i - 1, j] + 1 simulates the delete operation of word1[i]
        //dp[i, j - 1] + 1 simulates the insert operation of word2[j]
        //dp[i - 1, j - 1] + 1 simulates the replace operation of word1[i] to word2[j]

        private int[,] dp;
        public int MinDistance(string word1, string word2)
        {
            if (word1.Length == 0)
                return word2.Length;

            if (word2.Length == 0)
                return word1.Length;

            dp = new int[word1.Length + 1, word2.Length + 1];
            int i, j, tmp;
            for (i = 0; i <= word1.Length; i++)
            {
                dp[i, 0] = i;
            }

            for (j = 0; j <= word2.Length; j++)
            {
                dp[0, j] = j;
            }

            for (i = 1; i <= word1.Length; i++)
            {
                for (j = 1; j <= word2.Length; j++)
                {
                    tmp = (word1[i - 1] != word2[j - 1] ? 1 : 0);
                    dp[i, j] = compareThree(dp[i - 1, j] + 1, dp[i, j - 1] + 1, dp[i - 1, j - 1] + tmp);

                }
            }

            return dp[word1.Length, word2.Length];
        }


        int compareThree(int a, int b, int c)
        {
            if (a <= b && a <= c)
                return a;
            if (b <= a && b <= c)
                return b;
            return c;
        }
    }
}
