#include <iostream>
#include <vector>
#include "TreeNode.h"
#include <algorithm>
using namespace std;

class Solution {
public:
    int totalLength = 0;

    void help(TreeNode *root, int current) {
        current = current * 10 + root->val;

        if(!root->left && !root->right) {
            totalLength += current;
            return;
        }

        if(root->left)
            help(root->left, current);

        if(root->right)
            help(root->right, current);
    }

    int sumNumbers(TreeNode* root) {
        help(root, 0);
        return totalLength;
    }
};