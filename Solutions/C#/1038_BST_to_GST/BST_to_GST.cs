/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public TreeNode BstToGst(TreeNode root) 
    {
        Stack<TreeNode> nodes = new Stack<TreeNode>();
        nodes.Push(null);
        InOrderTraverse(root, nodes);
        
        TreeNode current = nodes.Pop();
        int count = 0;
        while(current != null)
        {
            count += current.val;
            current.val = count;
            
            current = nodes.Pop();
        }
        
        return root;
    }
    
    private void InOrderTraverse(TreeNode root, Stack<TreeNode> nodes)
    {
        if(root == null)
            return;
        
        InOrderTraverse(root.left, nodes);
        nodes.Push(root);
        InOrderTraverse(root.right, nodes);
    }
}