using System;

namespace MergeKLists
{
    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;

            return DoMergeList(lists, 0, lists.Length - 1);
        }

        ListNode DoMergeList(ListNode[] lists, int start, int end)
        {
            if (start > end)
                return null;

            if (start == end)
                return lists[start];

            if (end - start == 1)
            {
                return Merge2Lists(lists[start], lists[end]);
            }

            int mid = (end - start) / 2;
            return Merge2Lists(DoMergeList(lists, start, mid), DoMergeList(lists, mid + 1, end));
        }

        ListNode Merge2Lists(ListNode first, ListNode second)
        {
            if (first == null && second == null)
                return null;

            ListNode head = new ListNode();
            ListNode current = head;
            while (first != null || second != null)
            {
                if(first == null)
                {
                    current.val = second.val;
                    second = second.next;
                }
                else if(second == null)
                {
                    current.val = first.val;
                    first = first.next;
                }
                else if (first.val > second.val)
                {
                    current.val = second.val;
                    second = second.next;
                }
                else
                {
                    current.val = first.val;
                    first = first.next;
                }

                if (first == null && second == null)
                {
                    break;
                }

                current.next = new ListNode();
                current = current.next;
            }

            current = head;
            //while (current != null)
            //{
            //    Console.Write(current.val + " ");
            //    current = current.next;
            //}
            //Console.WriteLine();

            return head;
        }
    }
}
