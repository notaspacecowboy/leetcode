public class Solution {
    public int CalculateMinimumHP(int[][] dungeon) 
    {
        if(dungeon.Length == 0 || dungeon[0].Length == 0)
            return 1;
        
        int[,] dp = new int[dungeon.Length, dungeon[0].Length];
        return dfs(dungeon, 0, 0, dp);
 
    }
    
    private int dfs(int[][] dungeon, int i, int j, int[,] dp)
    {
        if(i == dungeon.Length - 1 && j == dungeon[0].Length - 1)
        {
            return (dungeon[i][j] > 0 ? 1 : -dungeon[i][j] + 1);
        }
        
        if(dp[i, j] != 0)
            return dp[i, j];
        
        if(i == dungeon.Length - 1)
        {
            dp[i, j] = Math.Max(1, dfs(dungeon, i, j + 1, dp) - dungeon[i][j]);
            return dp[i, j];
        }
        else if(j == dungeon[0].Length - 1)
        {
            dp[i, j] = Math.Max(1, dfs(dungeon, i + 1, j, dp) - dungeon[i][j]);
            return dp[i, j];
        }
        else
        {
            dp[i, j] = Math.Max(1, Math.Min(dfs(dungeon, i, j + 1, dp) - dungeon[i][j], 
                                        dfs(dungeon, i + 1, j, dp) - dungeon[i][j]));
            return dp[i, j];
        }
    }
}