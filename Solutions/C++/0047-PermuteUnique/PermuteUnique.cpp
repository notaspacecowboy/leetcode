#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class Solution {
public:
    void findPermute(vector<vector<int>> &res, vector<int> &nums, vector<int> &current, vector<bool> &used) {
        if(current.size() == nums.size()) {
            vector<int> tmp = current;
            res.emplace_back(current);
            return;
        }

        for(int i = 0; i < nums.size(); i++) {
            if(used[i])
                continue;

            used[i] = true;
            current.emplace_back(nums[i]);
            findPermute(res, nums, current, used);
            used[i] = false;
            current.pop_back();

            for(i; i < nums.size() - 1; i++) {
                if(nums[i] == nums[i + 1])
                    continue;

                break;
            }
        }
    }

    vector<vector<int>> permuteUnique(vector<int>& nums) {
        sort(nums.begin(), nums.end());

        vector<vector<int>> res;
        vector<int> current;
        vector<bool> used(nums.size(), false);
        findPermute(res, nums, current, used);
        return res;
    }
};

