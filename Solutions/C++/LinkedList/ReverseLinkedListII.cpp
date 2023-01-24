#include <iostream>
#include <vector>
#include <algorithm>
#include "ListNode.h"
using namespace std;

class Solution {
public:
    ListNode* reverseBetween(ListNode* head, int left, int right) {
        if(left == right)
            return head;

        ListNode *dummyHead = new ListNode(0, head);
        ListNode *prev = dummyHead;

        //reach the node before the left node
        for(int i = 0; i < left - 1; i++)
            prev = prev->next;

        ListNode *current = prev->next, *next = prev->next->next;
        for(int i = 0; i < right - left; i++) {
            current->next = next->next;
            next->next = prev->next;
            prev->next = next;
            next = current->next;
        }

        return dummyHead->next;
    }
};