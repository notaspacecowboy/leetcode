#include <iostream>
#include <vector>
#include <ListNode.h>
using namespace std;

class Solution {
public:
    ListNode* deleteDuplicates(ListNode* head) {
        if(head == nullptr)
            return nullptr;

        ListNode *prev = head, *current = head->next;

        while(current != nullptr) {
            if(current->val == prev->val) {
                current = current->next;
            }
            else {
                prev->next = current;
                prev = current;
                current = current->next;
            }
        }

        prev->next = current;

        return head;
    }
};