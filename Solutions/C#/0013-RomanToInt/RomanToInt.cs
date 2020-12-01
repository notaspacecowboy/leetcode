using System;

namespace RomanToInt
{
    public class Solution
    {
        int[] digit = { 1, 5, 10, 50, 100, 500, 1000 };
        char[] symbol = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

        public int RomanToInt(string s)
        {
            return FindSum(s, 0, symbol.Length - 1);
        }

        public int FindSum(string s, int i, int j)  
        {
            if (i >= s.Length)
                return 0;

            if (s[i] != symbol[j])
                return FindSum(s, i, j - 1);

            if (s[i] == symbol[j] && i == s.Length - 1)
                return digit[j];

            if (s[i] == symbol[j] && (symbol[j] == 'I' || symbol[j] == 'X' || symbol[j] == 'C'))
            {
                if (s[i + 1] == symbol[j + 1])
                    return (digit[j + 1] - digit[j]) + FindSum(s, i + 2, j);

                if (s[i + 1] == symbol[j + 2])
                    return (digit[j + 2] - digit[j]) + FindSum(s, i + 2, j);
            }

            return digit[j] + FindSum(s, i + 1, j);
        }
    }
}
