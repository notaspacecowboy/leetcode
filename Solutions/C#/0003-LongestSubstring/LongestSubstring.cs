using System;
using System.Collections.Generic;

namespace longestSubstring
{
    public class Solution
    {
    public int LengthOfLongestSubstring(string s)
    {
        var charLastSeenDic = new Dictionary<char, int>();
        int longest = 0;
        int acc = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (charLastSeenDic.TryGetValue(s[i], out int index))   
            {
                if(index >= i - acc) {      //if char s[i] is actually in our currently "maintained" substring s[i - acc, i - 1], 
                    acc = i - index;        //s' = s[i - index, i]
                }
                else {
                    acc++;
                }
                charLastSeenDic[s[i]] = i;
            }
            else
            {
                acc++;
                charLastSeenDic.Add(s[i], i);
            }
            
            longest = (acc > longest ? acc : longest);
        }


        return longest;
    }
    }
}
