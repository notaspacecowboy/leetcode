#include <iostream>
#include <vector>
#include <ListNode.h>
using namespace std;

class Solution {
public:
    ListNode* partition(ListNode* head, int x) {
        ListNode *dummy1 = new ListNode(0, nullptr);
        ListNode *dummy2 = new ListNode(0, nullptr);
        ListNode *current = head, *currentDummy1 = dummy1, *currentDummy2 = dummy2;
        while(current != nullptr) {
            if(current->val < x) {
                currentDummy1->next = current;
                currentDummy1 = currentDummy1->next;
            }
            else {
                currentDummy2->next = current;
                currentDummy2 = currentDummy2->next;
            }


            ListNode *tmp = current->next;
            current->next = nullptr;
            current = tmp;
        }

        currentDummy1->next = dummy2->next;
        return dummy1->next;
    }
};
