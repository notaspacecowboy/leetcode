
 struct ListNode {
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}ListNode(int x) : val(x), next(nullptr) {}

    ListNode(int x, ListNode *next) : val(x), next(next) {}

};
 class Solution {
 public:
     ListNode* removeNthFromEnd(ListNode* head, int n) {
         ListNode* dummyHead = new ListNode(0, head);

         ListNode *previous = dummyHead, *current = dummyHead;
         while(current != nullptr && n > 0) {
             current = current->next;
             n--;
         }

         if(current == nullptr)
             return dummyHead->next;

         while(true) {
             current = current->next;
             if(current == nullptr)
             {
                 previous->next = previous->next->next;
                 break;
             }

             previous = previous->next;
         }

         return dummyHead->next;
     }
 };