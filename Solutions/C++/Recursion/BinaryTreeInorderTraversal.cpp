#include <iostream>
#include <vector>
#include <TreeNode.h>
using namespace std;

class Solution {
public:
    void recursiveInorder(vector<int> &res, TreeNode *current) {
        if(current == nullptr)
            return;
        recursiveInorder(res, current->left);
        res.emplace_back(current->val);
        recursiveInorder(res, current->right);
    }

    vector<int> inorderTraversal(TreeNode* root) {
        vector<int> res;
        recursiveInorder(res, root);
        return res;
    }
};