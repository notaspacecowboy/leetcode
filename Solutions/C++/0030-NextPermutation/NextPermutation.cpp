#include <vector>
#include <string>
#include <iostream>
#include <algorithm>
using namespace std;

class Solution {
public:
    void nextPermutation(vector<int>& nums) {
        if(nums.size() == 1)
            return;

        int len = nums.size();
        if(nums[len - 1] > nums[len - 2])
        {
            auto tmp = nums[len - 1];
            nums[len - 1] = nums[len - 2];
            nums[len - 2] = tmp;
            return;
        }

        int i = len - 2;
        while(i >= 0) {
            if(nums[i] < nums[i + 1])
                break;
            i--;
        }

        if(i == -1)
        {
            std::reverse(nums.begin(), nums.end());
            return;
        }

        int j = i + 1;
        while(j < nums.size() - 1) {
            if(nums[j + 1] <= nums[i])
                break;
            j++;
        }

        auto tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;

        std::reverse(nums.begin() + i + 1, nums.end());
    }
};