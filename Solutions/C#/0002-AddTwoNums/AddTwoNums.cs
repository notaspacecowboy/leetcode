using System;

namespace AddTwoNums
{
    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode ans = new ListNode(0);
            ListNode current = ans;
            ListNode tail = ans;
            bool addOne = false;
            int x, y;
            while (l1 != null || l2 != null || addOne)
            {
                x = (l1 == null) ? 0 : l1.val;
                y = (l2 == null) ? 0 : l2.val;
                current.val = x + y;
                if (addOne)
                {
                    current.val++;
                    addOne = false;
                }
                if (current.val >= 10)
                {
                    current.val -= 10;
                    addOne = true;
                }
                if (l1 != null)
                    l1 = l1.next;
                if (l2 != null)
                    l2 = l2.next;

                current.next = new ListNode(0);
                tail = current;
                current = current.next;
            }
            tail.next = null;
            return ans;
        }
    }
}
