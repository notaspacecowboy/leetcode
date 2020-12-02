using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace N_Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.SolveNQueens(1);
        }
    }


    public class Solution 
    {
        private IList<IList<string>> ans = new List<IList<string>>();
        private bool[] row;
        private bool[] column;
        private bool[] diagonal;
        private bool[] antiDiagonal;
        public IList<IList<string>> SolveNQueens(int n)
        {
            row = new bool[n];
            for (int i = 0; i < n; i++)
            {
                row[i] = false;
            }

            column = new bool[n];
            for (int i = 0; i < n; i++)
            {
                column[i] = false;
            }

            diagonal = new bool[n * 2 - 1];
            for (int i = 0; i < n * 2 - 1; i++)
            {
                diagonal[i] = false;
            }

            antiDiagonal = new bool[n * 2 - 1];
            for (int i = 0; i < n * 2 - 1; i++)
            {
                antiDiagonal[i] = false;
            }

            //initialize string list
            List<char[]> current = new List<char[]>();
            for (int i = 0; i < n; i++)
            {
                current.Add(new char[n]);
                for (int j = 0; j < n; j++)
                {
                    current[i][j] = '.';
                }
            }

            dfs(current, n, 0, 0);
            return ans;
        }

        void dfs(List<char[]> current, int n, int i, int j)
        {
            if (n == 0)
            {
                List<string> tmp = new List<string>();
                for (int acc = 0; acc < current.Count; acc++)
                {
                    tmp.Add(new string(current[acc]));
                }
                ans.Add(tmp);
                return;
            }

            if (i >= current.Count)
            {
                return;
            }
            else if (j >= current.Count)
            {
                dfs(current, n, i + 1, 0);
                return;
            }

            if (!puttable(current, i, j))
            {
                dfs(current, n, i, j + 1);
                return;
            }

            current[i][j] = 'Q';
            dfs(current, n - 1, i, j + 1);

            row[i] = false;
            column[j] = false;
            diagonal[current.Count - 1 - (i - j)] = false;
            antiDiagonal[i + j] = false;

            current[i][j] = '.';
            dfs(current, n, i, j + 1);
            return;
        }


        bool puttable(List<char[]> current, int i, int j)
        {
            if (row[i])
                return false;

            if (column[j])
                return false;

            if (diagonal[current.Count - 1 - (i - j)])
                return false;

            if (antiDiagonal[i + j])
                return false;

            row[i] = true;
            column[j] = true;
            diagonal[current.Count - 1 - (i - j)] = true;
            antiDiagonal[i + j] = true;

            return true;

        }
    }
}
