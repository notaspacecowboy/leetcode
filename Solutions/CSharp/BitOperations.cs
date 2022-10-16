namespace LeetCode;

public class BitOperations
{
    #region 0089 - Gray Code

    public IList<int> GrayCode(int n)
    {
        List<int> results = new List<int>() {0};
        for (int i = 0; i < n; i++)
        {
            for (int j = results.Count - 1; j >= 0; j--)
            {
                results.Add(results[j] | 1 << i);
            }
        }

        return results;
    }

    #endregion
}