#include <iostream>
#include <vector>
#include <algorithm>
#include "ListNode.h"
using namespace std;

class Solution {
public:
    vector<int> plusOne(vector<int>& digits) {
        bool hasRemainder = true;

        int i = digits.size() - 1;
        while(hasRemainder && i >= 0) {
            digits[i] += 1;
            hasRemainder = (digits[i] >= 10);
            digits[i] %= 10;
            i--;
        }

        if(hasRemainder)
            digits.insert(digits.begin(), 1);

        return digits;
    }
};