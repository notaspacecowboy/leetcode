#include <vector>
#include <algorithm>
#include <unordered_map>

using namespace std;

class Solution {
public:
    vector<vector<int>> threeSum(vector<int>& nums) {
        std::sort(nums.begin(), nums.end());
        vector<vector<int>> res;

        for(int i = 0; i < nums.size() - 2; i++) {
            if(nums[i] > 0)
                break;

            if(i > 0 && nums[i] == nums[i - 1])
                continue;

            int toFind = -nums[i];

            int left = i + 1, right = nums.size() - 1;
            while(left < right) {
                int sum = nums[left] + nums[right];
                if(sum < toFind)
                    left++;
                else if(sum > toFind)
                    right--;
                else {
                    res.emplace_back(vector<int>{nums[i], nums[left], nums[right]});
                    left++;
                    right--;
                    while(left < right && nums[left] == nums[left - 1])
                        left++;
                    while(left < right && nums[right] == nums[right + 1])
                        right--;
                }
            }
        }

        return res;
    }
};