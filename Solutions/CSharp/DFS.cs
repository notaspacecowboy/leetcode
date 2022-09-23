namespace LeetCode;

public class DFS
{
    #region 0040 - Combination Sum II
    
    List<IList<int>> results = new List<IList<int>>();
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        Array.Sort(candidates);
        DPS(candidates, 0, target, new List<int>());
        return results;
    }

    void DPS(int[] candidates, int index, int target, List<int> current)
    {
        if (target == 0)
        {
            results.Add(new List<int>(current));
            return;
        }

        if (index >= candidates.Length)
            return;

        for (int i = index; i < candidates.Length; i++)
        {
            if (i > index && candidates[i] == candidates[i - 1])
                continue;

            if (target < candidates[i])
                break;

            current.Add(candidates[i]);
            DPS(candidates, i + 1, target - candidates[i], current);

            current.RemoveAt(current.Count - 1);
        }
    } 

    #endregion
}