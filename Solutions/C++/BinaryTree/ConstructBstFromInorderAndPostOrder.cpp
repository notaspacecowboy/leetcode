#include "TreeNode.h"
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    int index = 0;

    TreeNode *help(vector<int> &postorder, vector<int> &inorder, int leftBound, int rightBound) {
        if(index <= 0 || leftBound > rightBound)
            return nullptr;

        --index;

        TreeNode *current = new TreeNode(postorder[index]);

        if(left == right)
            return current;

        int i = leftBound;
        for(i; i <= rightBound; i++) {
            if(inorder[i] == current->val)
                break;
        }

        current->right = help(postorder, inorder, i + 1, rightBound);
        current->left = help(postorder, inorder, leftBound, i - 1);
        return current;
    }

    TreeNode* buildTree(vector<int>& inorder, vector<int>& postorder) {
        index = postorder.size();
        return help(postorder, inorder, 0, inorder.size() - 1);
    }
};