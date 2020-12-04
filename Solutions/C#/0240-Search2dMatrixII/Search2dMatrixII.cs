using System;

namespace Search2dMatrixII
{
    public class Solution
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int i = matrix.Length - 1;
            int j = 0;

            while (i >= 0  && j < matrix[0].Length)
            {
                if (matrix[i][j] == target)
                    return true;

                if (matrix[i][j] > target)
                {
                    i--;
                }
                else
                {
                    j++;
                }
            }

            return false;
        }
    }
}
