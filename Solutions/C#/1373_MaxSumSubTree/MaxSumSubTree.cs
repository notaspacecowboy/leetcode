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
    private int max = 0;
    public int MaxSumBST(TreeNode root) {
        int count = 0;
        findSum(root, ref count);
        
        return max;
    }
    
    public bool findSum(TreeNode root, ref int count)
    {
        count = 0;
        if(root.left == null && root.right == null)
        {
            count = root.val;
            UpdateMax(count);
            return true;
        }
        
        int countLeft = 0, countRight = 0;
        if(root.left == null)
        {
            if(findSum(root.right, ref countRight) && root.val < Smallest(root.right))
            {
                count = countRight + root.val;
                UpdateMax(count);
                return true;
            }
            else
                return false;
        }
        
        if(root.right == null)
        {
            if(findSum(root.left, ref countLeft) && root.val > Largest(root.left))
            {
                count = countLeft + root.val;
                UpdateMax(count);
                return true;
            }
            else
                return false;
        }
        
        bool isBST = true;
        if(findSum(root.left, ref countLeft) && root.val > Largest(root.left))
        {
            count = countLeft;
        }
        else
        {
            isBST = false;
        }
        
        if(findSum(root.right, ref countRight) && root.val < Smallest(root.right))
        {
            if(isBST)
            {
                count += countRight + root.val;   
                UpdateMax(count);
                return true;
            }
        }
        
        return false;
    }
    
    private void UpdateMax(int sum)
    {
        if(sum > max)
            max = sum;
    }
    
    private int Smallest(TreeNode root)
    {
        while(root.left != null)
        {
            root = root.left;
        }
        
        return root.val;
    }
    
    private int Largest(TreeNode root)
    {
        while(root.right != null)
        {
            root = root.right;
        }
        
        return root.val;
    }
}