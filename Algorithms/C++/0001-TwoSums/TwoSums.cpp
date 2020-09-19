#include <iostream>
#include <vector>
#include <map>
using namespace std;

class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target)
    {
        vector<int> ans;
        map<int, int> hash_table;

        for (int i = 0; i < nums.size(); i++)
            hash_table[nums[i]] = i;

        for (int i = 0; i < nums.size(); i++)
        {
            int diff = target - nums[i];
            if (hash_table[diff] && hash_table[diff] != i)
            {
                ans = { hash_table[diff], i };
            }
        }
        return ans;
    }
};