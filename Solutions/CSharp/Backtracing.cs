using System.Text;

namespace LeetCode;

public class Recursions
{

    #region 0022 - Generate Parentheses

    public IList<string> GenerateParenthesis(int n)
    {
        List<string> results = new List<string>();
        GenerateParenthesisRecursive(n, 0, results, "");
        return results;
    }

    public void GenerateParenthesisRecursive(int n, int toFill, List<string> results, string current)
    {
        if (n == 0 && toFill == 0)
        {
            results.Add(current);
            return;
        }

        if (toFill > 0)
            GenerateParenthesisRecursive(n, toFill - 1, results, current + ')');

        if (n > 0)
            GenerateParenthesisRecursive(n - 1, toFill + 1, results, current + '(');
    }

    #endregion

    #region 0025 - Reverse Nodes in K-Group

    public ListNode ReverseKGroup(ListNode head, int k)
    {
        if (head == null || k == 1)
            return head;

        ListNode dummyHead = new(0, head);
        ListNode start = dummyHead, end = head;

        int count = 0;
        while (end != null)
        {
            count++;
            if (count == k)
            {
                Reverse(start, start.next, end);
                count = 0;
                start = end;
                end = start.next;
            }
            else
                end = end.next;
        }

        return dummyHead.next;
    }

    private void Reverse(ListNode start, ListNode current, ListNode end)
    {
        if (current == end)
            return;

        ListNode newCurrent = current.next, second = start.next;
        start.next = current;
        current.next = second;
        Reverse(start, newCurrent, end);
    }



    #endregion

    #region 0039 - Combination Sum

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> results = new List<IList<int>>();
        Array.Sort(candidates);
        FindCombinations(results, candidates, target, 0, 0, new List<int>());
        return results;
    }

    void FindCombinations(List<IList<int>> results, int[] candidates, int target, int index, int sum, List<int> list)
    {
        if (index >= candidates.Length)
            return;

        if (sum + candidates[index] == target)
        {
            list.Add(candidates[index]);
            results.Add(new List<int>(list));
            list.RemoveAt(list.Count - 1);
            return;
        }

        if (sum + candidates[index] < target)
        {
            list.Add(candidates[index]);
            FindCombinations(results, candidates, target, index, sum + candidates[index], list);
            list.RemoveAt(list.Count - 1);
            FindCombinations(results, candidates, target, index + 1, sum, list);
        }

    }

    #endregion

    #region 0046 - Permutation

    public IList<IList<int>> Permute(int[] nums)
    {
        List<IList<int>> results = new List<IList<int>>();
        Permute(nums, 0, results);

        return results;
    }

    void Permute(int[] nums, int index, List<IList<int>> results)
    {
        if (index == nums.Length - 1)
        {
            results.Add(new List<int>(nums));
            return;
        }

        for (int i = index; i < nums.Length; i++)
        {
            (nums[i], nums[index]) = (nums[index], nums[i]);
            Permute(nums, index + 1, results);
            (nums[i], nums[index]) = (nums[index], nums[i]);
        }
    }

    #endregion

    #region 0047 - Permutation II

    List<IList<int>> results = new List<IList<int>>();
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        Array.Sort(nums);

        bool[] used = new bool[nums.Length];
        PermuteUnique(nums, new List<int>(), used);

        return results;
    }

    void PermuteUnique(int[] nums, List<int> cur, bool[] used)
    {
        if (cur.Count == nums.Length)
        {
            results.Add(new List<int>(cur));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i])
                continue;

            if (i != 0 && nums[i] == nums[i - 1] && !used[i - 1])
                continue;

            used[i] = true;
            cur.Add(nums[i]);
            PermuteUnique(nums, cur, used);
            used[i] = false;
            cur.RemoveAt(cur.Count - 1);

        }
    }

    #endregion

    #region 0060 - Permutation Sequence

    private int current = 0;
    public string GetPermutation(int n, int k)
    {
        StringBuilder sb = new StringBuilder(n);
        for (int i = 1; i <= n; i++)
            sb.Append((char)(i + '0'));

        FindPermutation(sb, k, 0);
        return sb.ToString();
    }

    bool FindPermutation(StringBuilder sb, int k, int index)
    {
        if (index >= sb.Length - 1)
        {
            ++current;
            if (current == k)
                return true;

            return false;
        }

        for (int i = index; i < sb.Length; i++)
        {
            (sb[index], sb[i]) = (sb[i], sb[index]);
            if (FindPermutation(sb, k, index + 1))
                return true;

            (sb[index], sb[i]) = (sb[i], sb[index]);
        }

        return false;
    }



    #endregion

    #region 0077 - Combinations

    public IList<IList<int>> Combine(int n, int k)
    {
        List<IList<int>> results = new List<IList<int>>();
        FindCombine(results, new List<int>(), n, k, 1);
        return results;
    }

    public void FindCombine(List<IList<int>> results, List<int> result, int n, int k, int currentIndex)
    {
        if (k == 0)
        {
            results.Add(new List<int>(result));
            return;
        }

        if (n - currentIndex + 1 < k)
            return;

        for (int i = currentIndex; i <= n - k + 1; i++)
        {
            result.Add(i);
            FindCombine(results, result, n, k - 1, i + 1);
            result.RemoveAt(result.Count - 1);
        }
    }

    #endregion

}