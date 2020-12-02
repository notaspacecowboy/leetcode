using System;

namespace GenerateParenthesis
{
    public class Solution
    {
        public List<string> ans = new List<string>();
        public IList<string> GenerateParenthesis(int n) 
        {
            if (n == 0)
                return ans;

            else
                FindParenthesis("(", n, 1, 0);

            return ans;
        }

        public void FindParenthesis(string currentStr, int total, int left, int right)
        {
            if (right > left)
                return;

            if (left == total)
            {
                for (int i = right + 1; i <= total; i++)
                {
                    currentStr += ')';
                }
                ans.Add(currentStr);
                return;
            }

            if (right == left)
            {
                FindParenthesis(currentStr + '(', total, left + 1, right);
                return;
            }

            FindParenthesis(currentStr + '(', total, left + 1, right);
            FindParenthesis(currentStr + ')', total, left, right + 1);
            return;
        }
    }
}
