using System;
using System.Numerics;

namespace median
{
    public class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length, n = nums2.Length;

            if (m == 0)
            {
                if (n % 2 == 1)
                    return 1.0 * nums2[n / 2];

                return (nums2[n / 2 - 1] + nums2[n / 2]) / 2.0;
            }

            if (n == 0)
            {
                if (m % 2 == 1)
                    return 1.0 * nums1[m / 2];

                return (nums1[m / 2 - 1] + nums1[m / 2]) / 2.0;
            }

            if ((m + n) % 2 == 1)
                return findKthNbr(nums1, 0, nums2, 0, (m + n) / 2 + 1);

            return (findKthNbr(nums1, 0, nums2, 0, (m + n) / 2) +
                    findKthNbr(nums1, 0, nums2, 0, (m + n) / 2 + 1)) / 2.0;
        }

        int findKthNbr(int[] nums1, int i, int[] nums2, int j, int k)
        {
            if (i >= nums1.Length)
                return nums2[j + k - 1];

            if (j >= nums2.Length)
                return nums1[i + k - 1];

            if (k == 1)
            {
                if (nums1[i] < nums2[j])
                    return nums1[i];
                else
                    return nums2[j];
            }

            int k1 = Int32.MaxValue, k2 = Int32.MaxValue;
            if (i + k / 2 - 1 < nums1.Length)
                k1 = nums1[i + k / 2 - 1];
            if (j + k / 2 - 1 < nums2.Length)
                k2 = nums2[j + k / 2 - 1];

            if (k1 < k2)
                return findKthNbr(nums1, i + k / 2, nums2, j, k - k / 2);

            return findKthNbr(nums1, i, nums2, j + k / 2, k - k / 2);
        }
    }
}
