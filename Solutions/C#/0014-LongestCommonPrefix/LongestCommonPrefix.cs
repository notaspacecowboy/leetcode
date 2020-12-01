using System;

namespace LongestCommonPrefix
{
    public class Solution 
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";

            string result = "";
            for (int i = 0; i < strs[0].Length; i++)
            {
                for (int j = 0; j < strs.Length; j++)
                {
                    if (i >= strs[j].Length || strs[j][i] != strs[0][i])
                        return result;
                }

                result += strs[0][i];
            }

            return result;
        }
    }
}
