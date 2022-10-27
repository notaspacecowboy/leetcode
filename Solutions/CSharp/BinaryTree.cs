namespace LeetCode;


public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}


public class BinaryTree
{
    #region 0094 - Binary Tree Inorder Traversal

    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> results = new List<int>();
        traverse(results, root);

        return results;
    }

    void traverse(List<int> results, TreeNode current)
    {
        if (current == null)
            return;

        traverse(results, current.left);
        results.Add(current.val);
        traverse(results, current.right);
    }

    #endregion

    #region 0095 - Unique Binary Search Trees II

    public IList<TreeNode> GenerateTrees(int n)
    {
        return RecursiveGenerate(1, n);
    }

    public List<TreeNode> RecursiveGenerate(int left, int right)
    {
        List<TreeNode> trees = new List<TreeNode>();
        if (left > right)
        {
            trees.Add(null);
            return trees;
        }

        for (int i = left; i <= right; i++)
        {
            var leftSubTrees = RecursiveGenerate(left, i - 1);
            var rightSubTrees = RecursiveGenerate(i + 1, right);

            foreach (var leftChild in leftSubTrees)
            {
                foreach (var rightChild in rightSubTrees)
                {
                    TreeNode head = new TreeNode(i);
                    head.left = leftChild;
                    head.right = rightChild;

                    trees.Add(head);
                }
            }
        }

        return trees;
    }

    #endregion

    #region 0096 - Unique Binary Search Trees

    public int NumTrees(int n)
    {
        int[] dp = new int[n + 1];
        dp[0] = 1;
        dp[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                dp[i] += dp[j - 1] * dp[i - j];
            }
        }

        return dp[n];
    }
    

    #endregion
}