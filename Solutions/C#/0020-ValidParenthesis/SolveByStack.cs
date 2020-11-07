using System;
using System.Collections;
using System.Collections.Generic;

namespace ValidParenthesis
{
    public class Solution
    {
        private Dictionary<char, char> coSymbol = new Dictionary<char, char>();

        public bool IsValid(string s)
        {
            coSymbol.Add('(', ')');
            coSymbol.Add('{', '}');
            coSymbol.Add('[', ']');

            Stack<char> mStack = new Stack<char>();
            int i = 0;
            char current;
            while (i < s.Length)
            {
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    mStack.Push(s[i]);
                }

                else
                {
                    if (!mStack.TryPop(out current))
                        return false;

                    else if (coSymbol[current] != s[i])
                        return false;
                }

                i++;
            }

            if (mStack.TryPop(out current))
                return false;

            return true;
        }


    }
}
