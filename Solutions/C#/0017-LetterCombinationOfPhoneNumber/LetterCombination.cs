using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace LetterCombinationOfPhoneNumber
{
    public class a
    {
        public static void Main()
        {
            Solution s = new Solution();
            IList<string> ans = s.LetterCombinations("23");
            for (int i = 0; i < ans.Count; i++)
            {
                Console.WriteLine(ans[i]);
            }
        }
    }

    public class Solution
    {
        IList<string> ans = new List<string>();
        Dictionary<char, string> phoneBook = new Dictionary<char, string>();

        public IList<string> LetterCombinations(string digits)
        {
            phoneBook.Add('2', "abc");
            phoneBook.Add('3', "def");
            phoneBook.Add('4', "ghi");
            phoneBook.Add('5', "jkl");
            phoneBook.Add('6', "mno");
            phoneBook.Add('7', "pqrs");
            phoneBook.Add('8', "tuv");
            phoneBook.Add('9', "wxyz");

            if (digits.Length == 0)
                return ans;

            
            SearchPossibleCombination("", digits, 0);
                return ans;
        }

        void SearchPossibleCombination(string current, string digits, int position)
        {
            Console.WriteLine(current);
            if (digits.Length <= position)
            {
                ans.Add(current);
                return;
            }

            string toAdd = phoneBook[digits[position]];
            for (int i = 0; i < toAdd.Length; i++)
            {
                SearchPossibleCombination(current + toAdd[i], digits, position + 1);
            }

            return;
        }
    }
}
