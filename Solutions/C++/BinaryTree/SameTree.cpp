#include "TreeNode.h"
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    bool preOrder(TreeNode *root1, TreeNode *root2) {
        if(!root1 && !root2)
            return true;

        if(!root1 || !root2 || root1->val != root2->val)
            return false;

        return preOrder(root1->left, root2->left) && preOrder(root1->right, root2->right);
    }

    bool isSameTree(TreeNode* p, TreeNode* q) {
        preOrder(p, q);
    }
};