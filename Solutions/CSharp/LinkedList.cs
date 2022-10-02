using System.Diagnostics.CodeAnalysis;

namespace LeetCode;

public class LinkedList
{
    #region 002 - Add Two Numbers

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode result = null, current = null;
        bool addOne = false;

        while (l1 != null || l2 != null || addOne)
        {
            if (result == null)
            {
                result = current = new ListNode();
            }
            else
            {
                current.next = new ListNode();
                current = current.next;
            }

            int sum = (addOne ? 1 : 0);
            sum += (l1 != null ? l1.val : 0);
            sum += (l2 != null ? l2.val : 0);

            addOne = (sum > 9);
            current.val = (sum % 10);

            if (l1 != null)
                l1 = l1.next;
            if (l2 != null)
                l2 = l2.next;

        }

        return result;
    }


    #endregion

    #region 021 - Merge Two Sorted Lists

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null && list2 == null)
            return null;

        if (list1 == null)
            return list2;

        if (list2 == null)
            return list1;

        ListNode head;

        if (list1.val <= list2.val)
        {
            head = list1;
            list1 = list1.next;
        }
        else
        {
            head = list2;
            list2 = list2.next;
        }

        ListNode current = head, temp = null;
        while (list1 != null || list2 != null)
        {
            if (list1 == null)
            {
                current.next = list2;
                break;
            }

            if (list2 == null)
            {
                current.next = list1;
                break;
            }

            if (list1.val <= list2.val)
            {
                temp = list1;
                list1 = list1.next;
                temp.next = null;
                current.next = temp;
            }
            else
            {
                temp = list2;
                list2 = list2.next;
                temp.next = null;
                current.next = temp;
            }

            current = current.next;
        }

        return head;
    }

    #endregion

    #region 0023 - Merge K Sorted Lists **
    public ListNode MergeKLists_v2(ListNode[] lists)
    {
        if (lists.Length == 0)
            return null;

        var pq = new PriorityQueue<ListNode>();
        for (int i = 0; i < lists.Length; i++)
        {
            if (lists[i] != null)
                pq.Push(lists[i].val, lists[i]);
        }


        ListNode result = new();
        ListNode dummy = result;

        while (pq.Count != 0)
        {
            var min = pq.Pop();
            result.next = min;
            result = result.next;
            if (min.next != null)
                pq.Push(min.next.val, min.next);
        }

        return dummy.next;
    }

    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists.Length == 0)
            return null;

        return MergeLists(lists, 0, lists.Length - 1);
    }

    public ListNode MergeLists(ListNode[] lists, int start, int end)
    {
        if (start == end)
            return lists[start];

        int middle = start + (end - start) / 2;
        var l1 = MergeLists(lists, start, middle);
        var l2 = MergeLists(lists, middle + 1, end);

        return Merge(l1, l2);

    }

    public ListNode Merge(ListNode l1, ListNode l2)
    {
        ListNode result = new();
        ListNode dummyHead = result;

        while (l1 != null && l2 != null)
        {
            if (l1.val <= l2.val)
            {
                result.next = l1;
                l1 = l1.next;
            }
            else
            {
                result.next = l2;
                l2 = l2.next;
            }

            result = result.next;
        }

        if (l1 != null)
            result.next = l1;
        else if (l2 != null)
            result.next = l2;

        return dummyHead.next;
    }

    #endregion

    #region 0024 - Swap Nodes in Pairs

    public ListNode SwapPairs(ListNode head)
    {
        if (head == null)
            return null;

        if (head.next == null)
            return head;

        ListNode right = head.next, left = head, previous = null, temp = null;
        head = head.next;

        bool doSwap = true;

        while (right != null)
        {
            if (doSwap)
            {
                if (previous != null)
                {
                    previous.next = right;
                }

                left.next = right.next;
                right.next = left;

                temp = right;
                right = left;
                left = temp;

            }

            doSwap = !doSwap;
            previous = left;
            left = left.next;
            right = right.next;
        }

        return head;
    }

    #endregion

    #region 0061 - Rotate List

    public ListNode RotateRight(ListNode head, int k)
    {
        if (k == 0 || head == null || head.next == null)
            return head;

        ListNode current = head;
        int total = 1;
        while (current.next != null)
        {
            total++;
            current = current.next;
        }

        current.next = head;
        k %= total;

        int kFromStart = total - k;
        current = new ListNode(0, head);   //dummy head
        while (kFromStart > 0)
        {
            kFromStart--;
            current = current.next;
        }

        head = current.next;
        current.next = null;
        return head;
    }
    #endregion
}