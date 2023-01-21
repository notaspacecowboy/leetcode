#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    int maxSubArray(vector<int>& nums) {
        int maxLength = nums[0], current = 0;

        for(int i = 0; i < nums.size(); i++) {
            if(current == 0 && nums[i] < 0)
                continue;

            current += nums[i];
            maxLength = (maxLength >= current ? maxLength : current);
            if(current < 0)
                current = 0;
        }

        return maxLength;
    }
};