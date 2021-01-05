/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode left = head, right = head;
        for(int i = 0; i < n; i++)
        {
            right = right.next;
        }
        
        if(right == null)
        {
            head = left.next;
            return head;
        }
        
        while(right.next != null)
        {
            left = left.next;
            right = right.next;
        }
        
        left.next = left.next.next;
        return head;
    }
}