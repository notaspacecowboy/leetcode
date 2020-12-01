using System;
using System.Linq;

namespace IntToRoman
{
    public class Solution
    {
        public string IntToRoman(int num)
        {
            int[] digit = { 1, 5, 10, 50, 100, 500, 1000 };
           
            string symbol = "IVXLCDM";
            string result = "";

            int i = digit.Length - 1;
            while(num != 0)
            {
                if (i > 0 && num - (9 * digit[i - 1]) >= 0)
                {
                    num -= 9 * digit[i - 1];
                    result += symbol[i - 1];
                    result += symbol[i + 1];
                }

                else if (num - digit[i] >= 0)
                {
                    num -= digit[i];
                    result += symbol[i];
                }

                else if (i > 0 && num - (4 * digit[i - 1]) >= 0)
                {
                    num -= 4 * digit[i - 1];
                    result += symbol[i - 1];
                    result += symbol[i];
                }

                else
                {
                    i--;
                }
            }

            return result;
        }
    }
}
