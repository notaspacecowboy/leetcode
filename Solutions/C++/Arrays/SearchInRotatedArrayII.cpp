#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    bool search(vector<int>& nums, int target) {
        int left = 0, right = nums.size() - 1;
        while(left <= right) {
            int middle = left + (right - left) / 2;
            if(nums[middle] == target)
                return true;

            //we are either at situation 222222 or 2223222, either case, drop left and right
            if(nums[left] == nums[middle] && nums[middle] == nums[right]) {
                left++;
                right--;
            }
            //if we are in first half
            else if(nums[middle] >= nums[left]) {
                if(target >= nums[left] && target < nums[middle]) {
                    right = middle - 1;
                }
                else
                    left = middle + 1;
            }
            //if we are in second half
            else {
                if(target > nums[middle] && target <= nums[right])
                    left = middle + 1;
                else
                    right = middle - 1;
            }
        }

        return false;
    }
};