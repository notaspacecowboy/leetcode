public class Solution
{
    public IList<int> CountSmaller(int[] nums)
    {
        List<int> dp = new List<int>(nums.Length);
        int[] ans = new int[nums.Length];

        int n = nums.Length;
        if (n == 0)
            return dp;

        int i = n - 1;
        while (i >= 0)
        {
            int position = BinaryInsert(dp, nums[i]);
            ans[i] = dp.Count - 1 - position;

            i--;
        }
        return ans;
    }

    private int BinaryInsert(List<int> dp, int t)
    {
        int left = 0, right = dp.Count - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (t <= dp[mid])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        dp.Insert(left, t);
        return left;
    }
}