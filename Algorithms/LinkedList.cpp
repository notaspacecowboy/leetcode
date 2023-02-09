#include "ListNode.h"


//given a linked list, return the nodes that is at the middle of the list
//notice how it treats the following two cases equally
//1 -> 2 -> 3 -> 4 -> nullptr => 3
//1 -> 2 -> 3 -> 4 -> 5 -> nullptr => 3
ListNode* MiddleOfLinkedList(ListNode* head) {
    ListNode *fast = head, *slow = head;
    while(fast != nullptr && fast->next != nullptr) {
        fast = fast->next->next;
        slow = slow->next;
    }

    return slow;
}


//given a linked list, reverse from the k'th list
//1 -> 2 -> 3 -> 4, pos = 0 => 4 -> 3 -> 2 -> 1
//1 -> 2 -> 3 -> 4, pos = 2 => 1 -> 2 -> 4 -> 3
ListNode* reverseList(ListNode* head, int k) {
    auto *dummy = new ListNode(0, head), *prev = dummy;
    while(k > 0) {
        if(prev == nullptr) {
            delete dummy;
            return head;
        }

        prev = prev->next;
        k--;
    }

    auto *current = prev->next, *next = current;
    while(current != nullptr && current->next != nullptr) {
        next = current->next;

        current->next = next->next;
        next->next = prev->next;
        prev->next = next;
    }

    head = dummy->next;
    delete dummy;
    return head;
}


