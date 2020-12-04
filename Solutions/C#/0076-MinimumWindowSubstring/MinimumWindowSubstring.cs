using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;

namespace MinimumWindowSubstring
{
    class Program
    {
        static void Main(string[] args)
        { 
            Solution s = new Solution();
            Console.WriteLine(s.MinWindow("cabwefgewcwaefgcf","cae"));
        }
    }


    public class Solution
    {
        public string MinWindow(string s, string t)
        {
            Dictionary<char, int> tAlpha = new Dictionary<char, int>();
            Dictionary<char, int> windowAlpha = new Dictionary<char, int>();

            int tCount = 0;             //total number of unique characters in t
            for (int i = 0; i < t.Length; i++)
            {
                if (!tAlpha.ContainsKey(t[i]))
                {
                    tCount++;
                    tAlpha.Add(t[i], 1);
                }
                else
                {
                    tAlpha[t[i]] += 1;
                }
            }

            int windowCount = 0;
            int left = 0, right = 0;
            int[] ans = { -1, 0, 0 };

            while (right < s.Length)
            {
                if (!windowAlpha.ContainsKey(s[right]))
                {
                    windowAlpha.Add(s[right], 1);
                }
                else
                {
                    windowAlpha[s[right]] += 1;
                }

                if (tAlpha.ContainsKey(s[right]) && tAlpha[s[right]] == windowAlpha[s[right]])
                {
                    windowCount++;
                }

                while (left <= right && windowCount == tCount)
                {
                    if (ans[0] == -1 || right - left + 1 < ans[0])
                    {
                        ans[0] = right - left + 1;
                        ans[1] = left;
                        ans[2] = right;
                    }

                    windowAlpha[s[left]]--;
                    if (tAlpha.ContainsKey(s[left]) && windowAlpha[s[left]] < tAlpha[s[left]])
                    {
                        windowCount--;
                    }

                    left++;
                }

                right++;
            }

            if (ans[0] == -1)
                return "";

            return s.Substring(ans[1], ans[2] - ans[1] + 1);
        }
    }
}
