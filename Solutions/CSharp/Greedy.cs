namespace LeetCode;

public class Greedy
{
    #region 0045 - Jump Game II

    public int Jump(int[] nums)
    {
        int step = 0, margin = 0, maxPos = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            maxPos = Math.Max(maxPos, i + nums[i]);
            if (i == margin)
            {
                margin = maxPos;
                step++;
            }
        }

        return step;
    }

    #endregion

    #region 0055 - Jump Game

    public bool CanJump(int[] nums)
    {
        int maxPos = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (maxPos == -1)
                maxPos = nums[i];
            else if (maxPos < i)
                return false;
            else
                maxPos = Math.Max(maxPos, i + nums[i]);    
        }

        return true;
    }

    #endregion
}