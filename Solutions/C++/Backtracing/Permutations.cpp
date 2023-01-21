#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:

    void findPermute(vector<vector<int>> &res, vector<int> &nums, int index) {
        if(index == nums.size() - 1) {
            vector<int> tmp = nums;
            res.emplace_back(nums);
            return;
        }

        for(int i = index; i < nums.size(); i++) {
            swap(nums[index], nums[i]);
            findPermute(res, nums, index + 1);
            swap(nums[index], nums[i]);
        }
    }

    vector<vector<int>> permute(vector<int>& nums) {
        vector<vector<int>> res;

        findPermute(res, nums, 0);
        return res;
    }
};