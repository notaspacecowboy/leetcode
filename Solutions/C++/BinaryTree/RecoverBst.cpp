#include "TreeNode.h"
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    TreeNode *prev;
    TreeNode *first;
    TreeNode *second;

    void inorder(TreeNode* current) {
        if(current == nullptr)
            return;

        inorder(current->left);

        if(prev == nullptr) {
            prev = current;
        }
        else {
            if(first == nullptr && current->val < prev->val)
                first = prev;

            if(first != nullptr && current->val < prev->val)
                second = current;

            prev = current;
        }

        inorder(current->right);
    }

    void recoverTree(TreeNode* root) {
        inorder(root);

        int tmp = first->val;
        first->val = second->val;
        second->val = tmp;
    }
};