#include <iostream>
#include <vector>
#include <bitset>
using namespace std;

class Solution {
public:
    void findNextCode(vector<int> &res, bitset<32> &bits, int index) {
        if(index == 0) {
            res.emplace_back(bits.to_ulong());
            return;
        }

        findNextCode(res, bits, index - 1);
        bits.flip(index - 1);
        findNextCode(res, bits, index - 1);
    }

    vector<int> grayCode(int n) {
        vector<int> res;
        bitset<32> bits;
        findNextCode(res, bits, n);
        return res;
    }
};