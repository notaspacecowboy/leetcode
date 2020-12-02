using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GroupAnagrams
{
    public class Solution
    {
        IList<IList<string>> ans = new List<IList<string>>();
        Dictionary<string, List<int>> positionDic = new Dictionary<string, List<int>>();

        public IList<IList<string>> GroupAnagrams(string[] strs) 
        {
            for (int i = 0; i < strs.Length; i++)
            {

                char[] charArray = strs[i].ToCharArray();
                Array.Sort(charArray);
                string tmp = new string(charArray);
                if (positionDic.ContainsKey(tmp))
                {
                    positionDic[tmp].Add(i);
                }
                else
                {
                    positionDic.Add(tmp, new List<int>() { i });
                }
            }

            foreach (var positionList in positionDic.Values)
            {
                List<string> tmp = new List<string>();
                for (int i = 0; i < positionList.Count; i++)
                {
                    tmp.Add(strs[positionList[i]]);
                }
                ans.Add(tmp);
            }

            return ans;
        }
    }
}
