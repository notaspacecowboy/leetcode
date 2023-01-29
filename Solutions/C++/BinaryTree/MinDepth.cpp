#include "TreeNode.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

class Solution {
public:
    int help(TreeNode* root, int depth) {
        if(root->left == nullptr && root->right == nullptr)
            return depth;

        int minDepth = INT_MAX;
        if(root->left != nullptr)
            minDepth = min(minDepth, help(root->left, depth + 1));

        if(root->right != nullptr)
            minDepth = min(minDepth, help(root->right, depth + 1));

        return minDepth;
    }

    int minDepth(TreeNode* root) {
        if(root == nullptr)
            return 0;
        return help(root, 1);
    }
};