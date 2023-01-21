#include <iostream>
#include <vector>
using namespace std;


class Solution {
public:
    int removeDuplicates(vector<int>& nums) {
        if(nums.size() <= 2)
            return nums.size();

        int pos = 1;
        for(int i = 2; i < nums.size(); i++) {
            if(nums[i] == nums[pos] && nums[i] == nums[pos - 1])
                continue;

            nums[++pos] = nums[i];
        }

        return pos + 1;
    }
};