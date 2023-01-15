#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;


class Solution {
public:
    // 2 ^ 10 = 4 ^ 5 = 16 ^ 2 * 4 = 256 ^ 1 * 4 = 256 * 4 = 1024
    double myPow(double x, int n) {
        if(n == 0)
            return 1;

        bool isInverse = (n < 0);
        double remainder = 1;
        if(n == INT_MIN)
        {
            remainder *= x;
            n += 1;
        }

        n = abs(n);

        while(n != 1) {
            if(n % 2 == 1) {
                remainder *= x;
                n--;
            }

            n /= 2;
            x *= x;
        }

        x *= remainder;
        if(isInverse)
            x = 1 / x;

        return x;
    }
};