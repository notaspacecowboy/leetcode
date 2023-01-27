#include <TreeNode.h>
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    bool help(TreeNode *left, TreeNode *right) {
        if(!left && !right)
            return true;

        if(!left || !right || left->val != right->val)
            return false;

        return help(left->left, right->right) && help(left->right, right->left);

    }

    bool isSymmetric(TreeNode* root) {
        return help(root->left, root->right);
    }
};