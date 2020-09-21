using System;
using System.Collections.Generic;

namespace longestSubstring
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, bool> mDic = new Dictionary<char, bool>();
            string currentString = "";
            int longestRun = 0;

            int i = 0;
            char temp;
            while (i < s.Length)
            {
                temp = s[i];
                if (!mDic.ContainsKey(temp) || !mDic[temp])
                {
                    mDic[temp] = true;
                    currentString += temp;
                }
                else
                {
                    if (currentString.Length > longestRun)
                        longestRun = currentString.Length;

                    currentString += temp;
                    int cutoff = 0;
                    for (int j = 0; currentString[j] != temp; j++)
                    {
                        cutoff++;
                        mDic[currentString[j]] = false;
                    }
                    currentString = currentString.Substring(cutoff + 1);

                }
                i++;
            }

            if (currentString.Length > longestRun)
                return currentString.Length;
            else
                return longestRun;
        }
    }
}
