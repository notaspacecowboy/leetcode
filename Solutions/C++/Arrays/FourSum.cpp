#include <vector>
#include <algorithm>
using namespace std;


class Solution {
public:
    vector<vector<int>> fourSum(vector<int>& nums, int target) {
        vector<vector<int>> res;

        if(nums.size() < 4)
            return res;

        sort(nums.begin(), nums.end());
        for(int i = 0; i < nums.size() - 3; i++) {
            if(nums[i] > target)
            if(i > 0 && nums[i] == nums[i - 1])
                continue;

            int threeSumTarget = target - nums[i];
            for(int j = i + 1; j < nums.size() - 2; j++) {
                if(j > i + 1 && nums[j] == nums[j - 1])
                    continue;

                int left = j + 1, right = nums.size() - 1, twoSumTarget = threeSumTarget - nums[j];
                while(left < right) {
                    if(nums[left] + nums[right] < twoSumTarget)
                        left++;
                    else if(nums[left] + nums[right] > twoSumTarget)
                        right--;
                    else {
                        res.emplace_back(vector<int> {nums[i], nums[j], nums[left++], nums[right--]});
                        while(left < right && nums[left] == nums[left - 1])
                            left++;
                        while(left < right && nums[right] == nums[right + 1])
                            right--;
                    }
                }
            }
        }

        return res;
    }
};

int main() {
    Solution s;
    vector<int> vec{0};
    s.fourSum(vec, 0);
}