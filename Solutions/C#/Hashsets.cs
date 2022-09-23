namespace LeetCode;

public class Hashsets
{
    #region 0036 - Valid Sudoku

    public bool IsValidSudoku(char[][] board)
    {
        HashSet<char> lookupRow = new HashSet<char>();
        HashSet<char> lookupCol = new HashSet<char>();
        HashSet<char> lookupBox = new HashSet<char>();
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] != '.' && !lookupRow.Add(board[i][j]))
                    return false;

                if (board[j][i] != '.' && !lookupCol.Add(board[j][i]))
                    return false;

                int x = (i % 3) * 3 + j % 3;
                int y = (i / 3) * 3 + j / 3;
                if (board[x][y] != '.' && !lookupBox.Add(board[x][y]))
                    return false;
            }

            lookupRow.Clear();
            lookupCol.Clear();
            lookupBox.Clear();
        }

        return true;
    }

    #endregion

    #region 0037 - Sudoku Solver

    public void SolveSudoku(char[][] board)
    {
        HashSet<string> lookup = new HashSet<string>();


        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[i].Length; j++)
            {
                if (board[i][j] == '.')
                    continue;
                string checkRow = board[i][j] + "(" + j + ")";
                string checkColumn = "(" + i + ")" + board[i][j];
                string checkBox = j / 3 + "(" + board[i][j] + ")" + i / 3;
                if (!lookup.Add(checkRow) || !lookup.Add(checkColumn) || !lookup.Add(checkBox))
                {
                    return;
                }
            }
        }

        SolveSudokuRecursively(board, 0, lookup);
    }

    public bool SolveSudokuRecursively(char[][] board, int index, HashSet<string> lookup)
    {
        if (index >= 81)
            return true;

        int i = index / 9;
        int j = index % 9;

        if (board[i][j] != '.') 
            return SolveSudokuRecursively(board, index + 1, lookup);

        for (int val = 1; val <=9;  val++)
        {
            string rowCheck = val + "(" + j + ")";
            string colCheck = "(" + i + ")" + val;
            string boxCheck = i / 3 + "(" + val + ")" + j / 3;

            bool hasRow = lookup.Contains(rowCheck);
            bool hasCol = lookup.Contains(colCheck);
            bool hasBox = lookup.Contains(boxCheck);

            if (hasRow || hasCol || hasBox)
                continue;

            if (lookup.Add(rowCheck) && lookup.Add(colCheck) && lookup.Add(boxCheck))
            {
                board[i][j] = (char)('0' + val);
                if (SolveSudokuRecursively(board, index + 1, lookup))
                    return true;
            }

            board[i][j] = '.';
            lookup.Remove(rowCheck);
            lookup.Remove(colCheck);
            lookup.Remove(boxCheck);
        }

        return false;
    }

    #endregion
}