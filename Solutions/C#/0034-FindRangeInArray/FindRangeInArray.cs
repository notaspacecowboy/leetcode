public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        int[] ans = { -1, -1 };
        if (nums.Length == 0)
        {
            return ans;
        }

        int left = 0, right = nums.Length - 1, mid, tmp;

        while (left <= right)
        {
            if (left > right)
            {
                return ans;
            }

            mid = (left + right) / 2;
            if (nums[mid] == target)
            {
                tmp = mid;
                while (tmp - 1 >= 0 && nums[tmp - 1] == target)
                {
                    tmp--;
                }
                ans[0] = tmp;

                tmp = mid;
                while (tmp + 1 < nums.Length && nums[tmp + 1] == target)
                {
                    tmp++;
                }
                ans[1] = tmp;

                return ans;
            }

            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return ans;
    }
}
