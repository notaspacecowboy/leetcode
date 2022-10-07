using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace LeetCode;

public class Strings
{
    #region 006 - Zigzag Conversion

    public string Convert(string s, int numRows)
    {
        if (numRows == 1 || s.Length <= numRows)
            return s;

        StringBuilder sb = new StringBuilder(s.Length);
        for (int i = 0; i < numRows; i++)
        {
            int j = i, lastAdded = -1;
            bool flag = true;
            while (j < s.Length)
            {
                if (lastAdded != j)
                {
                    sb.Append(s[j]);
                    lastAdded = j;
                }

                if (flag || i == 0)
                    j += (numRows - i - 1) * 2;
                else
                    j += i * 2;

                flag = !flag;
            }
        }

        return sb.ToString();
    }

    #endregion

    #region 008 - String to Integer

    public int MyAtoi(string s)
    {
        int i = 0;
        int result = 0;
        bool isPositive = true;
        while (i < s.Length && s[i] == ' ')
            i++;

        if (i >= s.Length)
            return 0;

        if (s[i] == '-')
        {
            i++;
            isPositive = false;
        }
        else if (s[i] == '+')
        {
            i++;
            isPositive = true;
        }

        while (i < s.Length)
        {
            if (s[i] >= '0' && s[i] <= '9')
            {
                int addon = s[i] - '0';
                if (isPositive && result > (Int32.MaxValue - addon) / 10)
                    return Int32.MaxValue;
                else if (!isPositive && result < (Int32.MinValue + addon) / 10)
                    return Int32.MinValue;

                result = result * 10 + (isPositive ? 1 : -1) * addon;
            }
            else
                return result;

            i++;
        }

        return result;
    }

    #endregion

    #region 0014 - Longest Common Prefix

    public string LongestCommonPrefix(string[] strs)
    {
        if (strs[0].Length == 0)
            return "";

        int i = 0;
        string result = "";
        while (i < strs[0].Length)
        {
            for (int j = 1; j < strs.Length; j++)
            {
                if (strs[j].Length <= i || strs[0][i] != strs[j][i])
                    return result;
            }

            result += strs[0][i];
            i++;
        }

        return result;
    }

    #endregion

    #region 0028 - Implement strStr()
    
    public int StrStr(string haystack, string needle)
    {
        int[] next = new int[needle.Length];
        next[0] = -1;

        int k = -1, i = 0;
        while (i < needle.Length - 1)
        {
            if (k == -1 || needle[i] == needle[k])
            {
                i++;
                k++;
                next[i] = k;
            }
            else
                k = next[k];
        }

        k = 0;
        i = 0;
        while (i < haystack.Length && k < needle.Length)
        {
            if (k == -1 || haystack[i] == needle[k])
            {
                i++;
                k++;
            }
            else
                k = next[k];
        }

        if (k == needle.Length)
            return i - k;

        return -1;
    }


    #endregion

    #region 0030 - Substring with Concatenation of All Words


    //sliding window + hash map
    public IList<int> FindSubstring(string s, string[] words)
    {
        int wordLength = words[0].Length;
        int totalWords = words.Length;
        Dictionary<string, int> wordCount = new Dictionary<string, int>();
        foreach (var word in words)
        {
            if (!wordCount.ContainsKey(word))
                wordCount.Add(word, 1);
            else
                wordCount[word]++;
        }

        Dictionary<string, int> wordUsed = new Dictionary<string, int>();
        List<int> results = new List<int>();
        int currentCount = 0;
        for (int i = 0; i < wordLength; i++)
        {
            int left = i;
            for (int right = left; right <= s.Length - wordLength; right += wordLength)
            {
                string word = s.Substring(right, wordLength);
                if (!wordCount.ContainsKey(word))
                {
                    currentCount = 0;
                    wordUsed.Clear();
                    left = right + wordLength;
                    right = left - wordLength;
                }
                else
                {
                    if (!wordUsed.ContainsKey(word))
                        wordUsed.Add(word, 1);
                    else
                        wordUsed[word]++;
                    
                    while (wordUsed[word] > wordCount[word] || left == right + wordLength)
                    {
                        string toRemove = s.Substring(left, wordLength);
                        left += wordLength;
                        wordUsed[toRemove]--;
                        currentCount--;
                    }

                    currentCount++;
                    //if we find a match
                    if (currentCount == totalWords)
                    {
                        results.Add(left);
                        string toRemove = s.Substring(left, wordLength);
                        left += wordLength;
                        wordUsed[toRemove]--;
                        currentCount--;
                    }
                }
            }

            wordUsed.Clear();
            currentCount = 0;
        }


        return results;
    }

    #endregion

    #region 0038 - Count and Say

    public string CountAndSay(int n)
    {
        if (n == 1)
            return "1";

        int[] nums = new int[9];
        string current = "1";
        for (int i = 2; i <= n; i++)
        {
            int num = 0;
            int count = 0;
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < current.Length; j++)
            {
                if (current[j] - '0' != num)
                {
                    if (count != 0)
                    {
                        sb.Append(count);
                        sb.Append(num);
                    }
                    num = current[j] - '0';
                    count = 1;
                }
                else
                    count++;
            }

            if (count != 0)
            {
                sb.Append(count);
                sb.Append(num);
            }

            current = sb.ToString();
        }

        return current;
    }

    #endregion

    #region 0043 - Multiply Strings

    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0")
            return "0";

        StringBuilder sb = new StringBuilder(num1.Length + num2.Length + 1);
        for (int i = 0; i < num1.Length + num2.Length + 1; i++)
            sb.Append('0');

        for (int i = num1.Length - 1; i >= 0; i--)
        {
            for (int j = num2.Length - 1; j >= 0; j--)
            {
                int digit = sb.Length - (num1.Length - i - 1) - (num2.Length - j - 1) - 1;
                int cur = (num1[i] - '0') * (num2[j] - '0');
                int secondDigit = sb[digit] - '0' + (cur % 10);
                bool addOne = (secondDigit >= 10);
                int tmp = digit;
                while (addOne)
                {
                    tmp--;
                    int oneMore = sb[tmp] - '0' + 1;
                    sb[tmp] = (char) (oneMore % 10 + '0');
                    addOne = oneMore >= 10;

                }
                sb[digit] = (char)(secondDigit % 10 + '0');
                int firstDigit = sb[digit - 1] - '0' + (cur / 10);
                addOne = (firstDigit >= 10);
                tmp = digit - 1;
                while (addOne)
                {
                    tmp--;
                    int oneMore = sb[tmp] - '0' + 1;
                    sb[tmp] = (char)(oneMore % 10 + '0');
                    addOne = oneMore >= 10;

                }
                sb[digit - 1] = (char)(firstDigit % 10 + '0');
            }
        }

        while (sb[0] == '0')
            sb.Remove(0, 1);

        return sb.ToString();
    }

    #endregion

    #region 0044 - Wildcard Matching

    public bool IsMatch(string s, string p)
    {
        int sPos = 0, pPos = 0, lastIndexOfStar = -1, sRestartPos = 0;
        while (sPos < s.Length)
        {
            if (pPos < p.Length && s[sPos] == p[pPos] || pPos < p.Length && p[pPos] == '?')
            {
                sPos++;
                pPos++;
            }
            else if (pPos < p.Length && p[pPos] == '*')
            {
                lastIndexOfStar = pPos;
                sRestartPos = sPos;
                pPos++;
            }     
            else if (lastIndexOfStar != -1)
            {
                sPos = ++sRestartPos;
                pPos = lastIndexOfStar + 1;
            }
            else
                return false;
        }

        while (pPos < p.Length)
        {
            if (p[pPos] != '*')
                return false;

            pPos++;
        }

        return true;
    }

    #endregion

    #region 0058 - Length of Last Word

    public int LengthOfLastWord(string s)
    {
        int index = s.Length - 1;
        while (s[index] == ' ')
            --index;

        int length = 0;
        while (index >= 0 && s[index] != ' ')
        {
            --index;
            ++length;
        }

        return length;
    }

    #endregion

    #region 0071 - Simplify Path

    public string SimplifyPath(string path)
    {
        Stack<string> lookup = new Stack<string>();

        string[] s = path.Split('/');

        int acc = 0;
        string result = "";
        for (int i = s.Length - 1; i >= 0; --i)
        {
            if (s[i] == "" || s[i] == ".")
                continue;
            else if (s[i] == "..")
                acc++;
            else if (acc > 0)
                acc--;
            else
                result = "/" + s[i] + result;
        }

        if (result == "")
            return "/";

        return result;
    }

    #endregion
}