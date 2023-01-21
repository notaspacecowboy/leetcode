//
// Created by 14389 on 1/16/2023.
//

#ifndef C___LISTNODE_H
#define C___LISTNODE_H

struct ListNode {
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}ListNode(int x) : val(x), next(nullptr) {}

    ListNode(int x, ListNode *next) : val(x), next(next) {}

};


#endif //C___LISTNODE_H
