struct ListNode {
     int val;
     ListNode *next;
     ListNode() : val(0), next(nullptr) {}
     ListNode(int x) : val(x), next(nullptr) {}
     ListNode(int x, ListNode *next) : val(x), next(next) {}
 };
 

/// <summary>
/// The idea is to simulate the process of sum two number by hand.
/// </summary>
class Solution {
public:
    ListNode* addTwoNumbers(ListNode* l1, ListNode* l2)
    {
        int addOne = 0;
        ListNode *dummyHead = new ListNode(), *current = dummyHead;
        while(l1 != nullptr && l2 != nullptr) {
            int res = addOne;
            res += l1->val;
            res += l2->val;
            l1 = l1->next;
            l2 = l2->next;

            addOne = res / 10;
            res %= 10;

            current->next = new ListNode(res);
            current = current->next;
        }

        while(l1 != nullptr) {
            int res = addOne;
            res += l1->val;
            l1 = l1->next;

            addOne = (res >= 10 ? 1 : 0);
            res %= 10;

            current->next = new ListNode(res);
            current = current->next;
        }

        while(l2 != nullptr) {
            int res = addOne;
            res += l2->val;
            l2 = l2->next;

            addOne = (res >= 10 ? 1 : 0);
            res %= 10;

            current->next = new ListNode(res);
            current = current->next;
        }

        if(addOne) {
            current->next = new ListNode(1);
        }

        return dummyHead->next;
    }
};



//ListNode* addTwoNumbers(ListNode* l1, ListNode* l2)
//{
//    int addOne = 0;
//    ListNode *head = nullptr, *current = nullptr;
//    while(l1 != nullptr || l2 != nullptr || addOne) {
//        int res = addOne;
//        if(l1 != nullptr) {
//            res += l1->val;
//            l1 = l1->next;
//        }
//        if(l2 != nullptr) {
//            res += l2->val;
//            l2 = l2->next;
//        }
//
//        addOne = (res >= 10 ? 1 : 0);
//        res %= 10;
//
//        if(head == nullptr) {
//            head = new ListNode(res);
//            current = head;
//        }
//        else {
//            current->next = new ListNode(res);
//            current = current->next;
//        }
//    }
//
//    return head;
//}