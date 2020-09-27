class Solution {
public:
    bool isPalindrome(int x) {
        if (x < 0)
            return false;

        int ori = x;
        int reverse = 0;
        while (x != 0)
        {
            if (reverse > INT_MAX / 10)
            {
                if (reverse % 10 != x)
                    return false;
                else
                {
                    ori /= 10;
                    break;
                }
            }
            reverse *= 10;
            reverse += (x % 10);
            x /= 10;
        }

        if (ori == reverse)
            return true;
        else
            return false;
    }
};
