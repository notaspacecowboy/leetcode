using System;
using System.Collections.Generic;

namespace MajorityElement
{
    public class Solution
    {
        Dictionary<int, int> elements = new Dictionary<int, int>();

        public int MajorityElement(int[] nums)
        {
            bool flag = false;
            int max = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (elements.ContainsKey(nums[i]))
                {
                    elements[nums[i]]++;
                }
                else
                {
                    elements.Add(nums[i], 1);
                }

                if (!flag || elements[max] < elements[nums[i]])
                {
                    flag = true;
                    max = nums[i];
                }

                if (elements[nums[i]] > nums.Length / 2)
                {
                    return max;
                }
            }

            return max;
        }
    }
}
