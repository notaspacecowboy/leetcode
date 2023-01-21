#include <string>
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    vector<int> searchRange(vector<int>& nums, int target) {
        if(nums.size() == 0)
            return {-1, -1};

        int left = 0, right = nums.size() - 1, first = -1, second = -1;
        while(left <= right) {
            int middle = left + (right - left) / 2;
            if(nums[middle] < target)
                left = middle + 1;
            else if(nums[middle] > target)
                right = middle - 1;
            else if(middle == 0 || nums[middle - 1] < target) {
                first = middle;
                break;
            }
            else
                right = middle - 1;
        }

        if(first == -1)
            return {-1, -1};

        left = 0, right = nums.size() - 1;
        while(left <= right) {
            int middle = left + (right - left) / 2;
            if(nums[middle] < target)
                left = middle + 1;
            else if(nums[middle] > target)
                right = middle - 1;
            else if(middle == nums.size() - 1 || nums[middle + 1] > target) {
                second = middle;
                break;
            }
            else
                left = middle + 1;
        }

        return {first, second};
    }
};