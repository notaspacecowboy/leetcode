#include "TreeNode.h"
#include "Node.h"
#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
using namespace std;

class Solution {
public:
    void help(Node* root) {
        if(!root)
            return;

        Node *nextToConnect = nullptr, *next = root->next;
        while(!nextToConnect && next) {
            if(next->left)
                nextToConnect = next->left;
            else if(next->right)
                nextToConnect = next->right;
            else
                next = next->next;
        }

        if(root->left && root->right) {
            root->left->next = root->right;
            root->right->next = nextToConnect;
        }
        else if(root->right)
            root->right->next = nextToConnect;
        else if(root->left)
            root->left->next = nextToConnect;

        help(root->right);
        help(root->left);
    }

    Node* connect(Node* root) {
        help(root);
        return root;
    }
};