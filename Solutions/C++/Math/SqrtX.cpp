#include <iostream>
#include <vector>
#include <algorithm>
#include "ListNode.h"
#include <string>

class Solution {
public:
    int mySqrt(int x) {
        if(x == 0 || x == 1)
            return x;
        int left  = 1, right = x;
        while(left <= right) {
            int middle = left + (right - left) / 2;
            int res = x / middle;
            if(res == middle)
                return middle;
            else if(res < middle)
                right = middle - 1;
            else
                left = middle + 1;
        }

        return right;
    }
};