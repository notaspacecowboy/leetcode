#include "TreeNode.h"
#include "Node.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

class Solution {
public:
    Node* connect(Node* root) {
        if(root == nullptr || root->left == nullptr)
            return root;

        auto left = root->left, right = root->right, next = root->next;
        if(left) {
            left->next = right;
            if(next)
                right->next = next->left;
        }

        connect(root->left);
        connect(root->right);
        return root;
    }
};