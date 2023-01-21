#include <string>
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    int searchInsert(vector<int>& nums, int target) {
        int left = 0, right = nums.size() - 1;
        if(nums[left] > target)
            return 0;

        if(nums[right] < target)
            return right + 1;

        while(left <= right) {
            int middle = left + (right - left) / 2;
            if(nums[middle] == target)
                return middle;

            if(nums[middle] < target) {
                if(nums[middle + 1] > target)
                    return middle + 1;

                left = middle + 1;
            }
            else {
                if(nums[middle - 1] < target)
                    return middle;
                right = middle - 1;
            }
        }

        return -1;
    }
};