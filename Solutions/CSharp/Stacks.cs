namespace LeetCode;

public class Stacks
{
    #region 020 - Valid Parentheses

    public bool IsValid(string s)
    {
        if (s.Length % 2 == 1)
            return false;

        Stack<char> saves = new Stack<char>();
        Dictionary<char, char> lookup = new Dictionary<char, char>()
        {
            [')'] = '(',
            [']'] = '[',
            ['}'] = '{'
        };

        for (int i = 0; i < s.Length; i++)
        {
            if ((s[i] == ')' || s[i] == ']' || s[i] == '}'))
            {
                if (saves.Count == 0 || saves.Pop() != lookup[s[i]])
                    return false;
            }
            else
                saves.Push(s[i]);

        }

        if (saves.Count != 0)
            return false;

        return true;
    }

    #endregion

    #region 0032 - Longest Valid Parentheses

    public int LongestValidParentheses(string s)
    {
        if (s.Length < 2)
            return 0;

        var unmatches = new Stack<int>();
        for (int i = 0; i < s.Length; i++)
        {
            if(s[i] == '(')
                unmatches.Push(i);
            else
            {
                if(unmatches.Count == 0) 
                    unmatches.Push(i);
                else if (s[unmatches.Peek()] == '(')
                    unmatches.Pop();
                else
                    unmatches.Push(i);
            }
        }

        if (unmatches.Count == 0)
            return s.Length;

        int right = s.Length, left = 0, longest = 0;
        while (unmatches.Count != 0)
        {
            left = unmatches.Pop();
            longest = Math.Max(right - left - 1, longest);
            right = left;
        }

        longest = Math.Max(right, longest);

        return longest;
    }

    #endregion
}