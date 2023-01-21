#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    bool canJump(vector<int>& nums) {
        int boundary = 0;
        for(int i = 0; i < nums.size() - 1; i++) {
            if(i == boundary && nums[i] == 0)
                return false;

            boundary = max(boundary, i + nums[i]);
        }

        return true;
    }
};