using System;

namespace ZigZagConversion
{
    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (numRows == 1 || s.Length < numRows)
                return s;

            string ans = "";
            bool flag;

            for (int i = 0; i < numRows; i++)
            {
                flag = false;
                int j = i;
                while (j < s.Length)
                {
                    ans += s[j];
                    if (i == 0 || i == numRows - 1)
                        j += 2 * numRows - 2;

                    else
                    {
                        if (!flag)
                            j += 2 * numRows - 2 * i - 2;
                        else
                            j += 2 * i;

                        flag = !flag;
                    }
                }
            }

            return ans;
        }
    }
}
