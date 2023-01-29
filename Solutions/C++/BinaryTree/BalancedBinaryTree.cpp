#include "TreeNode.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

class Solution {
public:
    bool balanced = true;
    int help(TreeNode *root) {
        if(root == nullptr)
            return 0;

        int leftCount = help(root->left), rightCount = help(root->right);
        if(abs(leftCount - rightCount) > 1)
            balanced = false;

        return 1 + max(leftCount, rightCount);
    }

    bool isBalanced(TreeNode* root) {
        help(root);
        return balanced;
    }
};