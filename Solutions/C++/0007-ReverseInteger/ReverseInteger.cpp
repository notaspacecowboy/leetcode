#include <bits/stdc++.h>

class Solution {
public:
    int reverse(int x) {
        if(x == INT_MIN || x == 0)
            return 0;

        int res = 0;
        bool sign = x > 0;

        while(x != 0) {
            int mod = x % 10;

            if(sign && res > (INT_MAX - mod) / 10 )
                return 0;
            else if(!sign && res < (INT_MIN + mod) / 10)
                return 0;

            res *= 10;
            res = (sign ? res + mod : res - mod);
            x /= 10;
        }

        return res;
    }
};