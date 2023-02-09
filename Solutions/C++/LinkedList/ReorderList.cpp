#include <unordered_set>
#include <iostream>
#include "ListNode.h"

using namespace std;

class Solution {
public:
    void reorderList(ListNode* head) {
        auto slow = head, fast = head;

        //find middle of list
        while(fast != nullptr && fast->next != nullptr) {
            fast = fast->next->next;
            slow = slow->next;
        }

        //reverse the list after slow
        auto prev = slow;
        auto current = slow->next, next = current;
        while(current != nullptr && current->next != nullptr) {
            next = current->next;

            current->next = next->next;
            next->next = prev->next;
            prev->next = next;
        }

        //re-structure the list as first_0 -> second_0 -> first_1 -> second_1 -> ...
        auto first = head, second = slow->next;
        while(second != nullptr) {
            slow->next = second->next;
            second->next = first->next;
            first->next = second;
            first = second->next;
            second = slow->next;
        }
    }
};