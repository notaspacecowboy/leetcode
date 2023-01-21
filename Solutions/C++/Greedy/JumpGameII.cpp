#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    int jump(vector<int>& nums) {
        int step = 0, maxPos = 0, margin = 0;
        for(int i = 0; i < nums.size() - 1; i++) {
            maxPos = max(maxPos, i + nums[i]);

            if(i == margin) {
                step++;
                margin = maxPos;
            }
        }

        return step;
    }
};