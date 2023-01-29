#include "TreeNode.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;


class Solution {
public:
    void help(TreeNode* root, vector<vector<int>>& res, vector<int>& current, int targetSum) {
        if(root == nullptr)
            return;

        targetSum -= root->val;
        current.emplace_back(root->val);
        if(root->left == nullptr && root->right == nullptr) {
            if(targetSum == 0)
                res.emplace_back(vector<int>(current));
            current.pop_back();
            return;
        }

        help(root->left, res, current, targetSum);
        help(root->right, res, current, targetSum);

        current.pop_back();
    }

    vector<vector<int>> pathSum(TreeNode* root, int targetSum) {
        vector<vector<int>> res;

        vector<int> current;
        help(root, res, current, targetSum);

        return res;
    }
};