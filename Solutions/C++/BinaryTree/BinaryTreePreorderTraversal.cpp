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

        res.emplace_back(root->val);
        help(root->left, res);
        help(root->right, res);
    }

    vector<int> preorderTraversal(TreeNode* root) {
        vector<int> res;
        help(root, res);
        return res;
    }
};