class Solution {
public:
    int myAtoi(string str)
    {
        int i = 0;
        long ans = 0;
        int multiplier = 1;

        while (str[i] == ' ')
            i++;

        if (str[i] == '-') {
            multiplier = -1;
            i++;
        }
        else if (str[i] == '+')
            i++;

        while (str[i] >= '0' && str[i] <= '9')
        {
            ans *= 10;
            if (ans > INT_MAX)
                break;
            ans += (str[i] - '0');
            i++;
        }

        if (ans > INT_MAX && multiplier == 1)
            return INT_MAX;

        if (ans > INT_MAX && multiplier == -1)
            return INT_MIN;

        if (multiplier == 1)
            return ans;

        else
            return -ans;
    }
};
