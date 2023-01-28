#include <iostream>
#include <vector>
#include "TreeNode.h"
using namespace std;

class Solution {
public:
    vector<TreeNode *> findTree(int left, int right) {
        vector<TreeNode *> res;
        if(left > right) {
            res.emplace_back(nullptr);
            return res;
        }

        for(int i = left; i <= right; i++) {
            auto leftChilds = findTree(left, i - 1);
            auto rightChilds = findTree(i + 1, right);

            for(int j = 0; j < leftChilds.size(); j++) {
                for(int k = 0; k < rightChilds.size(); k++) {
                    TreeNode *current = new TreeNode(i, leftChilds[j], rightChilds[k]);
                    res.emplace_back(current);
                }
            }
        }

        return res;
    }

    vector<TreeNode*> generateTrees(int n) {
        return findTree(1, n);
    }
};