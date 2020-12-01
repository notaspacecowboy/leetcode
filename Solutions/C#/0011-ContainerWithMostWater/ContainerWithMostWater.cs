using System;

namespace ContainerWithMostWater
{
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;

            int max = 0;
            while (i < j)
            {
                int currentArea = (j - i) * (height[i] > height[j] ? height[j] : height[i]);
                if (currentArea > max)
                    max = currentArea;

                if (height[i] >= height[j])
                    j--;
                else
                    i++;
            }

            return max;
        }
    }
}
