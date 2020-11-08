using System;
using System.Collections.Generic;

namespace implementStrStr
{
    public class Solution
    {
        private List<int> next = new List<int>();
        public int StrStr(string haystack, string needle)
        {
            GetNext(needle);

            int i = 0;
            int j = 0;
            while (i < haystack.Length && j < needle.Length)
            {
                if (j == -1 || haystack[i] == needle[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = next[j];
                }
            }

            if (j == needle.Length)
            {
                return i - j;
            }

            else
            {
                return -1;
            }
        }


        void GetNext(string needle)
        {
            next.Add(-1);

            int i = 0, j = -1;
            while (i < needle.Length)
            {
                if (j == -1 || needle[j] == needle[i])
                {
                    i++;
                    j++;
                    next.Add(j);
                }

                else
                {
                    j = next[j];
                }
            }
        }
    }
}
