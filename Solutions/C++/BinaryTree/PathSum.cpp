#include "TreeNode.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;


class Solution {
public:
    bool hasPathSum(TreeNode* root, int targetSum) {
        if(root == nullptr)
            return false;

        targetSum -= root->val;
        if(root->left == nullptr && root->right == nullptr)
            return targetSum == 0;
        return hasPathSum(root->left, targetSum) || hasPathSum(root->right, targetSum);
    }
};