#include <string>
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    int find_min(vector<int>& nums) {
        int left = 0, right = nums.size() - 1;
        if(nums.size() == 1 || nums[left] < nums[right])
            return 0;

        while(left < right) {
            int middle = left + (right - left) / 2;
            if(nums[middle] > nums[right])
                left = middle + 1;
            else
                right = middle;
        }

        return left;
    }

    int search(vector<int>& nums, int target) {
        int rotate_point = find_min(nums);
        cout << rotate_point;
        int left = 0, right = nums.size() - 1;
        if(target > nums[right]) {
            left = 0;
            right = rotate_point - 1;
        }
        else {
            left = rotate_point;
            right = nums.size() - 1;
        }

        while(left <= right) {
            int middle = left + (right - left) / 2;
            if(nums[middle] == target)
                return middle;
            else if(nums[middle] < target)
                left = middle + 1;
            else
                right = middle - 1;
        }

        return -1;
    }
};