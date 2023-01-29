#include "TreeNode.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;


class Solution {
public:
    vector<vector<int>> levelOrderBottom(TreeNode* root) {
        queue<TreeNode *> current, next;
        current.push(root);

        vector<vector<int>> res;
        vector<int> currentLevel;
        while(true) {
            while(!current.empty()) {
                auto node = current.front();
                current.pop();

                if(node == nullptr)
                    continue;

                currentLevel.emplace_back(node->val);
                next.push(node->left);
                next.push(node->right);
            }

            if(next.empty())
                break;

            res.emplace_back(vector<int>(currentLevel));
            currentLevel.clear();
            current = next;
            while(!next.empty())
                next.pop();
        }

        std::reverse(res.begin(), res.end());
        return res;
    }
};