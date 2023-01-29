#include "TreeNode.h"
#include "ListNode.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;


class Solution {
public:
    ListNode *current = nullptr;

    TreeNode* help(int left, int right) {
        if(left > right)
            return nullptr;

        int middle = left + (right - left) / 2;

        auto leftChild = help(left, middle - 1);

        auto parent = new TreeNode(current->val);
        current = current->next;

        auto rightChild = help(middle + 1, right);

        parent->left = leftChild;
        parent->right = rightChild;

        return parent;
    }

    TreeNode* sortedListToBST(ListNode* head) {
        ListNode *current = head;
        int n = 0;
        while(current) {
            n++;
            current = current->next;
        }

        current = head;
        return help(0, n);
    }
};