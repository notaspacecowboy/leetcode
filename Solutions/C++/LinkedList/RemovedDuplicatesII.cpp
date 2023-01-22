#include <iostream>
#include <vector>
#include <ListNode.h>
using namespace std;

class Solution {
public:
    ListNode* deleteDuplicates(ListNode* head) {
        if(head == nullptr)
            return head;

        ListNode *dummy = new ListNode(0, head);
        ListNode *prev = dummy, *current = head;
        while(current != nullptr) {
            int currentVal = current->val;
            if(current->next == nullptr || current->next->val != current->val) {
                prev = current;
                current = current->next;
            }
            else {
                while(current->next != nullptr && current->next->val == current->val)
                    current = current->next;

                prev->next = current->next;
                current = current->next;
            }
        }

        return dummy->next;
    }
};