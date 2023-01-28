#include "TreeNode.h"
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    vector<vector<int>> res;

    void help(TreeNode *current, int level) {
        if(current == nullptr)
            return;

        if(level >= res.size())
            res.emplace_back(vector<int>());

        res[level].emplace_back(current->val);

        help(current->left, level + 1);
        help(current->right, level + 1);
    }

    vector<vector<int>> levelOrder(TreeNode* root) {
        help(root, 0);
        return res;
    }
};