using System;

public class Solution
{
    public double MyPow(double x, int n)
    {
        if (x == 1 || n == 0)
        {
            return 1;
        }



        if (n < 0)
        {
            long p = (long)n;
            return 1 / FindPow(x, -p);
        }

        return FindPow(x, n);
    }


    double FindPow(double x, long n)
    {
        if (n == 1)
            return x;

        if (n % 2 == 1)
        {
            return x * FindPow(x * x, (n - 1) / 2);
        }

        return FindPow(x * x, n / 2);
    }
}