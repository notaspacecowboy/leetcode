public class Solution
{
    public int MySqrt(int x)
    {
        if (x == 1 || x == 0)
            return x;

        long left = 1, right = x / 2 + 1, mid, val;
        while (left < right)
        {
            mid = left + (right - left) / 2;
            val = mid * mid;

            if (val == x)
                return (int)mid;
            else if (val > x || val < 0)
                right = mid;
            else
                left = mid + 1;
        }

        return (int)left - 1;
    }
}
