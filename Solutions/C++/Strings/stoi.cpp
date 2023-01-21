#include <string>
using namespace std;


class Solution {
public:
    int myAtoi(string str)
    {
        long res = 0;
        int i = 0;
        while(i < str.length()) {
            if(str[i] != ' ')
                break;

            i++;
        }

        bool isNegative = false;
        if(i < str.length() && str[i] == '-')
        {
            isNegative = true;
            i++;
        }
        else if(i < str.length() && str[i] == '+')
            i++;

        for(i; i < str.length(); i++) {
            if(str[i] > '9' || str[i] < '0')
                break;

            res *= 10;
            res += (str[i] - '0');

            if(!isNegative && res > INT_MAX)
                return INT_MAX;
            else if(isNegative && -res < INT_MIN)
                return INT_MIN;
        }

        return (isNegative ? -res : res);
    }
};
