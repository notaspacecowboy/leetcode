#include <iostream>
#include <vector>
#include <algorithm>
#include "ListNode.h"
using namespace std;

//use the idea of merge sort, recursively divide the linked list into two equal halves, sort each half individually,
//then merge them back together
//to divide the linked list into two equal halves, we need to find the mid point of a linked list, use two pointers
//to solve it (slow and fast pointers)
class Solution {
public:
    ListNode* sortList(ListNode* head) {
        if(head == nullptr || head->next == nullptr)
            return head;

        ListNode *tmp = nullptr, *slow = head, *fast = head;
        while(fast != nullptr && fast->next != nullptr) {
            tmp = slow;
            slow = slow->next;
            fast = fast->next->next;
        }

        tmp->next = nullptr;
        auto l1 = sortList(head);
        auto l2 = sortList(slow);

        return mergeList(l1, l2);
    }

    ListNode* mergeList(ListNode* first, ListNode* second) {
        ListNode* dummy = new ListNode(0, nullptr);
        ListNode* current = dummy;
        while(first != nullptr && second != nullptr) {
            if(first->val <= second->val) {
                current->next = first;
                first = first->next;
            }
            else {
                current->next = second;
                second = second->next;
            }
            current = current->next;
        }

        if(first != nullptr)
            current->next = first;

        if(second != nullptr)
            current->next = second;

        return dummy->next;
    }
};