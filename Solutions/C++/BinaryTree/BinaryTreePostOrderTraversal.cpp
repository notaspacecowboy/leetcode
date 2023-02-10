#include "TreeNode.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

class Solution {
public:
    void help(TreeNode* root, vector<int>& res) {
        if(root == nullptr)
            return;

        help(root->left, res);
        help(root->right, res);
        res.emplace_back(root->val);
    }

    vector<int> postorderTraversal(TreeNode* root) {
        vector<int> res;
        help(root, res);
        return res;
    }
};