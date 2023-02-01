#include <iostream>
#include <vector>
#include <unordered_set>
#include <algorithm>
using namespace std;

class Solution {
public:
    int longestConsecutive(vector<int>& nums) {
        unordered_set<int> numSet;
        int longest = 0;

        for(int i = 0; i < nums.size(); i++)
            numSet.emplace(nums[i]);

        for(int i = 0; i < nums.size(); i++) {
            if(numSet.find(nums[i] - 1) != numSet.end())
                continue;

            int current = nums[i] + 1;
            while(numSet.find(current) != numSet.end()) {
                ++current;
            }

            longest = max(longest, current - nums[i]);
        }

        return longest;
    }
};