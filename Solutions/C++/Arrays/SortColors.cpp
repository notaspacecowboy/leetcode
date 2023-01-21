#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    void sortColors(vector<int>& nums) {
        int zeroStartPos = -1, twoStartPos = nums.size(), i = 0;
        while (i < twoStartPos) {
            if(nums[i] == 0 && i > zeroStartPos)
                swap(nums[i], nums[++zeroStartPos]);
            else if(nums[i] == 2 && i < twoStartPos)
                swap(nums[i], nums[--twoStartPos]);
            else
                i++;
        }
    }
};