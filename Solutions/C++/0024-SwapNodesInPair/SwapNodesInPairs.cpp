
struct ListNode {
    int val;
    ListNode *next;
    ListNode() : val(0), next(nullptr) {}ListNode(int x) : val(x), next(nullptr) {}

    ListNode(int x, ListNode *next) : val(x), next(next) {}

};

class Solution {
public:
    ListNode* swapPairs(ListNode* head) {
        if(head == nullptr)
            return head;

        auto dummyHead = new ListNode(0, head);
        auto previous = dummyHead, first = previous->next, second = first->next;

        while(second != nullptr) {
            first->next = second->next;
            previous->next = second;
            second->next = first;

            auto tmp = first;
            first = second;
            second = tmp;

            previous = second;
            first = previous->next;
            if(first == nullptr)
                break;
            second = first->next;
        }

        return dummyHead->next;
    }
};