namespace LeetCode;

public class HashTable
{
    #region 003 - Longest Substring Without Repeating Characters

    public int LengthOfLongestSubstring(string s)
    {
        int longest = 0, count = 0, start = 0;
        Dictionary<char, int> lookup = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (s.Length - start <= longest)
                break;

            // if s[i] is a new character
            if (!lookup.ContainsKey(s[i]) || lookup[s[i]] < start)
            {
                count++;
                longest = (longest < count ? count : longest);
            }
            else
            {
                count = (i - lookup[s[i]]);
                start = lookup[s[i]] + 1;
            }

            lookup[s[i]] = i;
        }

        return longest;
    }

    // same idea but looks better
    public int LengthOfLongestSubstring_v2(string s)
    {
        int left = 0, right = 0, longest = 0;
        Dictionary<char, int> lookup = new Dictionary<char, int>();

        while (right < s.Length)
        {
            if (!lookup.ContainsKey(s[right]))
                lookup[s[right]] = 1;
            else
                lookup[s[right]]++;

            while (lookup[s[right]] > 1)
            {
                lookup[s[left]]--;
                left++;
            }

            longest = Math.Max(longest, right - left + 1);
            right++;
        }

        return longest;
    }

    #endregion

    #region 012 - Integer to Roman

    public string IntToRoman(int num)
    {
        int[] digits = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
        string[] symbols = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
        string result = "";

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            while (num >= digits[i])
            {
                result += symbols[i];
                num -= digits[i];
            }
        }

        return result;
    }

    #endregion

    #region 013 - Roman To Integer

    public int RomanToInt(string s)
    {
        Dictionary<char, int> lookup = new Dictionary<char, int>();
        lookup.Add('I', 1);
        lookup.Add('V', 5);
        lookup.Add('X', 10);
        lookup.Add('L', 50);
        lookup.Add('C', 100);
        lookup.Add('D', 500);
        lookup.Add('M', 1000);

        int result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (i + 1 < s.Length && lookup[s[i]] < lookup[s[i + 1]])
                result -= lookup[s[i]];
            else
                result += lookup[s[i]];

        }

        return result;
    }

    #endregion

    #region 017 - Letter Combinations of a Phone Number

    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
            return new List<string>();

        Dictionary<char, List<char>> lookup = new Dictionary<char, List<char>>()
        {
            {'1', new List<char>()},
            {'2', new List<char>() {'a', 'b', 'c'}},
            {'3', new List<char>() {'d', 'e', 'f'}},
            {'4', new List<char>() {'g', 'h', 'i'}},
            {'5', new List<char>() {'j', 'k', 'l'}},
            {'6', new List<char>() {'m', 'n', 'o'}},
            {'7', new List<char>() {'p', 'q', 'r', 's'}},
            {'8', new List<char>() {'t', 'u', 'v'}},
            {'9', new List<char>() {'w', 'x', 'y', 'z'}},
        };

        var result = new List<string>();
        int total = 1;
        for (int i = 0; i < digits.Length; i++)
        {
            total *= lookup[digits[i]].Count;
        }
        for (int i = 0; i < total; i++)
            result.Add("");


        int current = total;
        for (int i = 0; i < digits.Length; i++)
        {
            current = current / lookup[digits[i]].Count;
            for (int j = 0; j < total; j++)
            {
                result[j] = result[j] + lookup[digits[i]][j / current % lookup[digits[i]].Count];
            }
        }

        return result;
    }

    #endregion

    #region 0049 - Group Anagrams

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> lookup = new();
        foreach (var str in strs)
        {
            char[] tmp = str.ToCharArray();
            Array.Sort(tmp);
            string key = new(tmp);
            if (!lookup.ContainsKey(key))
            {
                lookup.Add(key, new List<string>());
            }
            lookup[key].Add(str);
        }

        List<IList<string>> results = new List<IList<string>>();
        foreach (var list in lookup.Values)
        {
            results.Add(list);
        }

        return results;
    }

    #endregion

}