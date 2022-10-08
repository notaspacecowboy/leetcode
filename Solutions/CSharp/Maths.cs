namespace LeetCode;

public class Maths
{
    #region 007 - Reverse Integer

    public int Reverse(int x)
    {
        if (x == 0)
            return x;

        bool isPositive = x > 0;
        int result = 0;
        while (x != 0)
        {
            int addon = x % 10;
            if (isPositive && result > (Int32.MaxValue - addon) / 10)
                return 0;
            else if (!isPositive && result < (Int32.MinValue - addon) / 10)
                return 0;

            result = result * 10 + addon;
            x /= 10;
        }

        return result;
    }

    #endregion

    #region 009 - Palindrome Number

    public bool IsPalindrome(int x)
    {
        if (x < 0)
            return false;

        int palindrome = 0;
        int current = x;
        while (current != 0)
        {
            int addon = current % 10;
            if (palindrome > (Int32.MaxValue - addon) / 10)
                return false;

            palindrome = palindrome * 10 + addon;
            current /= 10;
        }

        if (palindrome == x)
            return true;
        return false;
    }

    #endregion

    #region 0029 - Divide Two Integers

    public int Divide(int dividend, int divisor)
    {
        if (dividend == 0)
            return 0;

        if (divisor == 1)
            return dividend;

        if (dividend == divisor)
            return 1;

        if (divisor == Int32.MinValue)
            return 0;

        int result = 0;
        if (dividend == Int32.MinValue)
        {
            if (divisor == -1)
                return Int32.MaxValue;

            dividend += Math.Abs(divisor);
            result++;
        }


        bool isNegative = (dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0);
        dividend = Math.Abs(dividend);
        divisor = Math.Abs(divisor);

        int count = -1;
        while (dividend >= divisor)
        {
            if(count == 29)
                Console.WriteLine();

            if (divisor << (count + 1) <= 0 || dividend < divisor << (count + 1))
            {
                result += (int)Math.Pow(2, count);
                dividend -= (divisor << count);
                count = -1;
            }
            else
                count++;
        }

        return (isNegative ? -result : result);

    }

    #endregion

    #region 0048 - Rotate Image

    public void Rotate(int[][] matrix)
    {
        for (int i = 0; i <= matrix.Length / 2; i++)
        {
            for (int j = i; j < matrix.Length - i - 1; j++)
            {
                (matrix[i][j], matrix[j][matrix.Length - i - 1], matrix[matrix.Length - i - 1][matrix.Length -j - 1], matrix[matrix.Length - j - 1][i]) =
                    (matrix[matrix.Length - j - 1][i], matrix[i][j], matrix[j][matrix.Length - i - 1], matrix[matrix.Length - i - 1][matrix.Length - j - 1]);

            }
        }

        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix.Length; j++)
            {
                Console.Write($"{matrix[i][j]}  ");
            }

            Console.WriteLine();
        }
    }

    #endregion

    #region 0050 - Pow(x,n)

    public double MyPow(double x, int n)
    {
        if (x == 0)
            return 0;
        if (x == 1 || n == 0)
            return 1;

        long count = n;
        if (count < 0)
            return 1 / FindPow(x, -n);
        return FindPow(x, n);

    }

    public double FindPow(double x, int n)
    {
        if (n == 1)
            return x;

        if (n % 2 == 1)
            return x * FindPow(x * x, (n - 1) / 2);

        return FindPow(x * x, n / 2);
    }

    #endregion

    #region 0054 - Spiral Matrix

    public IList<int> SpiralOrder(int[][] matrix)
    {
        int x = -1, y = 0;
        int[,] dirs = new int[,]
        {
            {0, 1},
            {1, 0},
            {0, -1},
            {-1, 0}
        };

        int countX = matrix[0].Length, countY = matrix.Length - 1, currentDir = 0;
        List<int> result = new();
        while (countX >= 0 && countY >= 0)
        {
            if (currentDir % 2 == 0)
            {
                for (int i = 0; i < countX; i++)
                {
                    x += dirs[currentDir, 1];
                    y += dirs[currentDir, 0];
                    result.Add(matrix[y][x]);
                }

                countX--;
            }
            else
            {
                for (int i = 0; i < countY; i++)
                {
                    x += dirs[currentDir, 1];
                    y += dirs[currentDir, 0];
                    result.Add(matrix[y][x]);
                }

                countY--;
            }
            currentDir = (currentDir + 1) % 4;
        }

        return result;
    }

    #endregion

    #region 0059 - Spiral Matrix II

    public int[][] GenerateMatrix(int n)
    {
        int[][] results = new int[n][];
        for (int i = 0; i < n; i++)
            results[i] = new int[n];

        int[] index = new int[] {0, -1};
        int[][] dirs = new int[][]
        {
            new int[] {0, 1},
            new int[] {1, 0},
            new int[] {0, -1},
            new int[] {-1, 0}
        };

        int columnCount = n, rowCount = n - 1, current = 0, num = 0;
        while (columnCount >= 0 && rowCount >= 0)
        {
            if (current % 2 == 0)
            {
                for (int i = 0; i < columnCount; i++)
                {
                    index[0] += dirs[current][0];
                    index[1] += dirs[current][1];
                    results[index[0]][index[1]] = ++num;
                }

                --columnCount;
            }
            else
            {
                for (int i = 0; i < rowCount; i++)
                {
                    index[0] += dirs[current][0];
                    index[1] += dirs[current][1];
                    results[index[0]][index[1]] = ++num;
                }

                --rowCount;
            }

            ++current;
            current = current % 4;
        }

        return results;
    }

    #endregion

    #region 0069 - Sqrt(x)

    public int MySqrt(int x)
    {
        long left = 0, right = x, middle = 0;
        while (left < right)
        {
            middle = left + (right - left) / 2;
            if (middle * middle == x)
                return (int)middle;
            else if (middle * middle > x)
                right = middle - 1;
            else
                left = middle + 1;
        }

        if (left * left > x)
            --left;
            
        return (int)left;
    }

    #endregion

    #region 0073 - Set Matrix Zeroes

    public void SetZeroes(int[][] matrix)
    {
        bool isColZero = false;
        bool isRowZero = false;
        int m = matrix.Length, n = matrix[0].Length;
        for (int i = 0; i < m; i++)
            if (matrix[i][0] == 0)
                isColZero = true;

        for (int i = 0; i < n; i++)
            if (matrix[0][i] == 0)
                isRowZero = true;

        for (int i = 1; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = matrix[0][j] = 0;
                }
            } 
        }


        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                    matrix[i][j] = 0;
            }
        }

        for (int i = 0; i < m; i++)
            if (isColZero)
                matrix[i][0] = 0;

        for (int i = 0; i < n; i++)
            if (isRowZero)
                matrix[0][i] = 0;
    }

    #endregion

    #region 0074 - Searches a 2D Matrix

    public bool SearchMatrix(int[][] matrix, int target)
    {
        int m = matrix.Length, n = matrix[0].Length;
        if (target < matrix[0][0] || target > matrix[m - 1][n - 1])
            return false;

        int left = 0, right = m * n - 1, middle = 0;
        while (left <= right)
        {
            middle = left + (right - left) / 2;
            int row = middle / n;
            int col = middle % n;
            if (matrix[row][col] == target)
                return true;
            else if (matrix[row][col] < target)
                left = middle + 1;
            else
                right = middle - 1;
        }

        return false;
    }

    #endregion
}