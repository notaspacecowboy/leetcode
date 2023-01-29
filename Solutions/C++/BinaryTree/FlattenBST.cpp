#include "TreeNode.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

class Solution {
public:
    TreeNode* help(TreeNode* root) {
        if(root == nullptr)
            return nullptr;

        if(root->left == nullptr && root->right == nullptr)
            return root;

        if(root->left == nullptr)
            return help(root->right);

        if(root->right == nullptr) {
            root->right = root->left;
            root->left = nullptr;
            return help(root->right);
        }

        auto newParentForRightChild = help(root->left);
        auto newRightMost = help(root->right);
        auto tmp = root->right;

        root->right = root->left;
        root->left = nullptr;
        newParentForRightChild->right = tmp;

        return newRightMost;
    }


    void flatten(TreeNode* root) {
        help(root);
    }
};