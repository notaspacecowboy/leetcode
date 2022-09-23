namespace LeetCode;

public class DivideAndConquer
{
    #region 004 - Median of Two Sorted Arrays

    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int totalLength = (nums1.Length + nums2.Length);
        if (totalLength % 2 == 0)
            return (FindKthNumber(nums1, nums2, totalLength / 2) +
                    FindKthNumber(nums1, nums2, totalLength / 2 + 1)) / 2;

        return FindKthNumber(nums1, nums2, totalLength / 2 + 1);
    }

    public double FindKthNumber(Span<int> nums1, Span<int> nums2, int k)
    {
        if (nums1.Length == 0)
            return nums2[k - 1];

        if (nums2.Length == 0)
            return nums1[k - 1];

        if (k == 1)
            return Math.Min(nums1[0], nums2[0]);

        if (nums1.Length > nums2.Length)
            return FindKthNumber(nums2, nums1, k);

        if (nums1.Length == 1 && nums2.Length == 1)
            return Math.Max(nums1[0], nums2[0]);


        int m = Math.Min(k / 2, nums1.Length);
        int n = k - m;

        if (nums1[m - 1] == nums2[n - 1])
        {
            return nums1[m - 1];
        }
        else if (nums1[m - 1] < nums2[n - 1])
            return FindKthNumber(nums1[m..], nums2[..n], k - m);
        else
            return FindKthNumber(nums1[..m], nums2[n..], k - n);

    }

    #endregion
}