#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    void findSubset(vector<vector<int>> &res, vector<int> &current, vector<int> &nums, int index) {
        res.emplace_back(current);

        for(int i = index; i < nums.size(); i++) {
            if(i != index && nums[i] == nums[i - 1])
                continue;
            current.emplace_back(nums[i]);
            findSubset(res, current, nums, i + 1);
            current.pop_back();
        }
    }

    vector<vector<int>> subsetsWithDup(vector<int>& nums) {
        std::sort(nums.begin(), nums.end());
        vector<vector<int>> res;
        vector<int> current;
        findSubset(res, current, nums, 0);
        return res;
    }
};