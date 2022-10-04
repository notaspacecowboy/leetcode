using System.Security.AccessControl;

namespace LeetCode;

public class DynamicProgramming
{
    #region 005 - Longest Palindromic Substring

    public string LongestPalindrome(string s)
    {
        var dp = new bool[s.Length, s.Length];

        for (int i = 0; i < dp.Length; i++)
            dp[i, i] = true;

        int start = 0, length = 1;
        for (int i = 0; i < dp.Length - 1; i++)
        {
            dp[i, i + 1] = (s[i] == s[i + 1]);
            if (dp[i, i + 1])
            {
                length = 2;
                start = i;
            }
        }

        for (int j = 0; j < s.Length; j++)
        {
            for (int i = 0; i < j - 1; i++)
            {
                if (s[i] == s[j] && dp[i + 1, j - 1])
                {
                    dp[i, j] = true;
                }

                if (dp[i, j] && j - i + 1 > length)
                {
                    start = i;
                    length = j - i + 1;
                }
            }
        }

        return s.Substring(start, length);
    }

    #endregion

    #region 010 - Regular Expression Matching

    public bool IsMatch(string s, string p)
    {
        //base case
        if (p == ".*")
            return true;

        bool[,] dp = new bool[s.Length + 1, p.Length + 1];

        //two empty strings always match
        dp[0, 0] = true;

        for (int i = 1; i <= p.Length; i++)
        {
            //it is guaranteed that * won't appear at first index of p
            if (p[i - 1] == '*')
                dp[0, i] = dp[0, i - 2];
        }

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 1; j <= p.Length; j++)
            {
                //if j's element of p is not a wildcard
                if (p[j - 1] != '*')
                {
                    if (dp[i - 1, j - 1] && (s[i - 1] == p[j - 1] || p[j - 1] == '.'))
                        dp[i, j] = true;
                }
                //if j's element of p is a wildcard
                else
                {
                    if (dp[i, j - 2])
                        dp[i, j] = true;
                    else if (p[j - 2] != '.' && s[i - 1] != p[j - 2])
                        dp[i, j] = dp[i, j - 2];
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }
        }

        return dp[s.Length, p.Length];

    }

    #endregion

    #region 0062 - Unique Paths

    public int UniquePaths(int m, int n)
    {
        int[,] dp = new int[m + 1, n + 1];

        for (int i = m - 2; i >= 0; i--)
        {
            for (int j = n - 2; j >= 0; j--)
            {
                if (i == m - 1 && j == n - 1)
                    dp[i, j] = 1;
                else
                    dp[i, j] = dp[i + 1, j] + dp[i, j + 1];
            }
        }

        return dp[0, 0];
    }

    #endregion

    #region 0063 - Unique Paths II

    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        int[,] dp = new int[m + 1, n + 1];

        for (int i = m - 1; i >= 0; i--)
        {
            for (int j = n - 1; j >= 0; j--)
            {
                if (i == m - 1 && j == n - 1)
                    dp[i, j] = 1;
                else if (obstacleGrid[i][j] == 1)
                    dp[i, j] = 0;
                else
                dp[i, j] = dp[i + 1, j] + dp[i, j + 1];
            }
        }

        return dp[0, 0];
    }

    #endregion

    #region 0064 - Minimum Path Sum

    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int[,] dp = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 && j == 0)
                    dp[i, j] = grid[i][j];
                else if (i == 0)
                    dp[i,j] = dp[i, j - 1] + grid[i][j];
                else if (j == 0)
                    dp[i,j] = dp[i - 1, j] + grid[i][j];
                else
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
            } 
        }

        return dp[m - 1, n - 1];
    }

    #endregion

}