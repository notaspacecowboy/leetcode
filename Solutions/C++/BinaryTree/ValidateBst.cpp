#include "TreeNode.h"
#include <iostream>
#include <vector>
using namespace std;

class Solution {
public:
    //suppose we have:
    //root a with left child b and right child c
    //b with left child d and right child e
    //c with left child f anf right child g
    //therefore,
    //a is in (-inf, +inf)
    //b is in (-inf, a)
    //c is in (a, +inf)
    //d is in (-inf, b)
    //e is in (b, a)
    //...
    //try visualizing it and it's super clear!
    bool help(TreeNode *current, long leftBound, long rightBound) {
        if(current == nullptr)
            return true;

        if(current->val <= leftBound || current->val >= rightBound)
            return false;

        return help(current->left, leftBound, current->val) && help(current->right, current->val, rightBound);
    }

    bool isValidBST(TreeNode* root) {

        return help(root, LONG_MIN, LONG_MAX);
    }
};