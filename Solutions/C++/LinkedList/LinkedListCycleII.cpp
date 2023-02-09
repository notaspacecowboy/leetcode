#include <unordered_set>
#include <iostream>
#include "ListNode.h"

using namespace std;

class Solution {
public:

//    solve with set
//    ListNode *detectCycle(ListNode *head) {
//        unordered_set<ListNode*> nodes;
//
//        while(head != nullptr) {
//            if(nodes.count(head))
//                return head;
//
//            nodes.insert(head);
//            head = head->next;
//        }
//
//        return nullptr;
//    }


    //a more "clever" solution
    ListNode *detectCycle(ListNode *head) {
        if(head == nullptr)
            return nullptr;

        ListNode *fast = head, *slow = head;
        while(fast->next != nullptr) {
            fast = fast->next;
            if(fast->next == nullptr)
                break;

            fast = fast->next;
            slow = slow->next;

            if(fast != slow)
                continue;

            fast = head;
            while(fast != slow) {
                fast = fast->next;
                slow = slow->next;
            }

            return slow;
        }

        return nullptr;
    }
};