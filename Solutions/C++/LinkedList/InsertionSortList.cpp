#include <vector>
#include <ListNode.h>
#include <unordered_map>
#include <climits>

using namespace std;


class Solution {
public:
    ListNode* insertionSortList(ListNode* head) {
        ListNode *dummy = new ListNode(INT_MIN, head);
        ListNode *prev = dummy, *current = head;
        while(current != nullptr) {
            if(current->val >= prev->val) {
                prev = current;
                current = current->next;
                continue;
            }

            ListNode *tmp = dummy;
            while(tmp->next->val <= current->val)
                tmp = tmp->next;

            prev->next = current->next;
            current->next = tmp->next;
            tmp->next = current;

            current = prev->next;
        }

        return dummy->next;
    }
};