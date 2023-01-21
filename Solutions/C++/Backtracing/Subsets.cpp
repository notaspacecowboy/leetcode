#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    void findSubsets(vector<vector<int>> &res, vector<int> &current, vector<int> &nums, int index) {
        if(index == nums.size()) {
            res.emplace_back(vector<int> {current});
            return;
        }

        current.emplace_back(nums[index]);
        findSubsets(res, current, nums, index + 1);
        current.pop_back();
        findSubsets(res, current, nums, index + 1);
    }

    vector<vector<int>> subsets(vector<int>& nums) {
        vector<vector<int>> res;
        vector<int> current;
        findSubsets(res, current, nums, 0);

        return res;
    }
};