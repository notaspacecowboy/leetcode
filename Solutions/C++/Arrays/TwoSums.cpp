#include <iostream>
#include <unordered_map>
#include <vector>

using namespace std;

class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target)
    {
        unordered_map<int, int> lookup;
        for(int i = 0; i < nums.size(); i++) {
            int second = target - nums[i];
            if(lookup.count(second)) {
                return {lookup[second], i};
            }
            lookup.insert(std::make_pair(nums[i], i));
        }

        return {};
    }
};