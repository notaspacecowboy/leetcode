#include "TreeNode.h"
#include <iostream>
#include <vector>
using namespace std;


class Solution {
public:
    int preOrderIndex = -1;
    TreeNode* help(vector<int> &preorder, const vector<int> &inorder, int left, int right) {
        if(preOrderIndex == preorder.size() || left > right)
            return nullptr;

        ++preOrderIndex;
        TreeNode *current = new TreeNode(preorder[preOrderIndex]);
        if(left == right)
            return current;

        int i = left;
        for(i; i <= right; i++) {
            if(inorder[i] == current->val)
                break;
        }

        current->left = help(preorder, inorder, left, i - 1);
        current->right = help(preorder, inorder, i + 1, right);
        return current;

    }

    TreeNode* buildTree(vector<int>& preorder, vector<int>& inorder) {
        return help(preorder, inorder, 0, inorder.size() - 1);
    }
};