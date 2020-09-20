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
        bool addOne = false;
        ListNode* ans = new ListNode();
        ListNode* current = ans;
        ListNode* tail = ans;
        int x, y;
        while (l1 != nullptr || l2 != nullptr)
        {
            if (l1 != nullptr)
                x = l1->val;
            else
                x = 0;

            if (l2 != nullptr)
                y = l2->val;
            else
                y = 0;
            current->val = x + y;
            if (addOne) {
                current->val++;
                addOne = false;
            }
            if (current->val >= 10)
            {
                addOne = true;
                current->val -= 10;
            }

            if (l1 != nullptr)
                l1 = l1->next;
            if (l2 != nullptr)
                l2 = l2->next;
            current->next = new ListNode();
            tail = current;
            current = current->next;
        }

        if (addOne)
            current->val = 1;
        else
            tail->next = nullptr;
        return ans;
    }
};