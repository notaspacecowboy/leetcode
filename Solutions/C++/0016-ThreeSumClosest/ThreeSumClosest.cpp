#include <vector>
#include <algorithm>
#include <unordered_map>

using namespace std;

class Solution {
public:
    int threeSumClosest(vector<int>& nums, int target) {
        std::sort(nums.begin(), nums.end());

        int smallestDiff = INT_MAX;
        for(int i = 0; i < nums.size() - 2; i++) {
            if(i > 0 && nums[i] == nums[i - 1])
                continue;

            int toFind = target - nums[i], left = i + 1, right = nums.size() - 1;
            while(left < right) {
                int sum = nums[left] + nums[right];
                if(sum == toFind)
                    return target;
                else if(sum < toFind)
                    left++;
                else
                    right--;

                int diff = sum - toFind;
                smallestDiff = abs(diff) < abs(smallestDiff) ? diff : smallestDiff;
            }
        }

        return target + smallestDiff;
    }
};