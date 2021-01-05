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
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        if(l1 == null)
            return l2;
        if(l2 == null)
            return l1;
        
        ListNode head = new ListNode();
        ListNode current = head;
        
        while(l1 != null && l2 != null)
        {
            if(l1.val <= l2.val)
            {
                current.val = l1.val;
                l1 = l1.next;
            }
            else
            {
                current.val = l2.val;
                l2 = l2.next;
            }
            
            current.next = new ListNode();
            current = current.next;
        }
        
        while(l1 != null)
        {
            current.val = l1.val;
            if(l1.next == null)
                break;
    
            l1 = l1.next;
            current.next = new ListNode();
            current = current.next;
        }
        
        while(l2 != null)
        {
            current.val = l2.val;
            if(l2.next == null)
                break;
            
            l2 = l2.next;
            current.next = new ListNode();
            current = current.next;
        }
        
        return head;
    }
}