using System;

namespace ValidParenthesis
{
    public class Solution
    {
        int currentPos = 0;

        public bool IsValid(string s)
        {
            if (s.Length % 2 == 1)
                return false;

            while (currentPos < s.Length)
            {
                if (!FindPair(s, s[currentPos]))
                    return false;
                currentPos++;
            }

            return true;
        }

        public bool FindPair(string s, char cmp)
        {
            currentPos++;

            if (currentPos >= s.Length)
                return false;

            if (s[currentPos] == '{' || s[currentPos] == '(' || s[currentPos] == '[')
            {
                return FindPair(s, s[currentPos]) && FindPair(s, cmp);
            }

            if ((s[currentPos] == ')' && cmp == '(') ||
                (s[currentPos] == ']' && cmp == '[') ||
                (s[currentPos] == '}' && cmp == '{'))
            {
                return true;
            }
            return false;

        }
    }
}
