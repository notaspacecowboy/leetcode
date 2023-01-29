#include "TreeNode.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

class Solution {
public:
    TreeNode* help(vector<int> &nums, int left, int right) {
        if(left > right)
            return nullptr;

        int middle = left + (right - left) / 2;
        TreeNode *current = new TreeNode(nums[middle]);
        current->left = help(nums, left, middle - 1);
        current->right = help(nums, middle + 1, right);

        return current;
    }

    TreeNode* sortedArrayToBST(vector<int>& nums) {
        return help(nums, 0, nums.size() - 1);
    }
};