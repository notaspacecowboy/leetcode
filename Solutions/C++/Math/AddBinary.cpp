#include <iostream>
#include <vector>
#include <algorithm>
#include "ListNode.h"
#include <string>

using namespace std;


class Solution {
public:
    string addBinary(string a, string b) {
        int i = a.length() - 1;
        int j = b.length() - 1;
        int remainder = 0, len = max(i, j) + 2, currentIdx = len - 1;
        string res(len, '0');
        while(i >= 0 && j >= 0) {
            int val = (a[i] - '0') + (b[j] - '0') + remainder;
            remainder = (val >= 2 ? 1 : 0);
            val %= 2;

            res[currentIdx] = val + '0';
            currentIdx--;
            i--;
            j--;
        }

        while(i >= 0) {
            int val = (a[i] - '0') + remainder;
            remainder = (val >= 2 ? 1 : 0);
            val %= 2;

            res[currentIdx] = val + '0';
            currentIdx--;
            i--;
        }

        while(j >= 0) {
            int val = (b[j] - '0') + remainder;
            remainder = (val >= 2 ? 1 : 0);
            val %= 2;

            res[currentIdx] = val + '0';
            currentIdx--;
            i--;
        }

        if(remainder == 1)
            res[0] = 1;
        else
            res.erase(0);

        return res;
    }
};