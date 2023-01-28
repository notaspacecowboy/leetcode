#include "TreeNode.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

class Solution {
public:

    vector<vector<int>> zigzagLevelOrder(TreeNode* root) {
        queue<TreeNode*> q1, q2;
        q1.push(root);

        vector<vector<int>> res;
        vector<int> current;
        while(true) {
            while(!q1.empty()) {
                auto node = q1.front();
                q1.pop();

                if(node == nullptr)
                    continue;

                current.emplace_back(node->val);
                q2.push(node->left);
                q2.push(node->right);
            }
            if(current.empty())
                break;
            res.emplace_back(vector<int>{current});
            current.clear();

            while(!q2.empty()) {
                auto node = q2.front();
                q2.pop();

                if(node == nullptr)
                    continue;

                current.emplace_back(node->val);
                q1.push(node->left);
                q1.push(node->right);
            }
            if(current.empty())
                break;

            std::reverse(current.begin(), current.end());
            res.emplace_back(vector<int>{current});
            current.clear();
        }

        return res;
    }
};