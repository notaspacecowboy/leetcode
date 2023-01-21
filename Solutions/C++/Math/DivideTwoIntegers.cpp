#include <vector>
#include <string>
#include <iostream>
using namespace std;


class Solution {
public:
    int divide(int dividend, int divisor) {
        if(divisor == 1)
            return dividend;

        if(divisor == -1 && dividend == INT_MIN){
            return INT_MAX;
        }

        if(divisor == -1)
            return -dividend;

        bool isPositive = (dividend > 0 && divisor > 0) || (dividend < 0 && divisor < 0);
        long currentDividend = abs(dividend);
        long currentDivisor = abs(divisor);
        int count = 0, currentCount = 1;
        while(currentDividend >= currentDivisor) {
            if((currentDivisor << 1) > currentDividend) {
                count += currentCount;
                currentDividend -= currentDivisor;
                currentDivisor = abs(divisor);
                currentCount = 1;
            }
            else {
                currentDivisor <<= 1;
                currentCount <<= 1;
            }
        }

        if(!isPositive)
            return -count;

        return count;
    }
};