using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DivideTwoIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            Console.WriteLine(s.Divide(-1384904293
                                       ,-153821790));
        }
    }

    public class Solution
    {
        private Stack<int> result = new Stack<int>();
        private Stack<int> multiplier = new Stack<int>();
        public int Divide(int dividend, int divisor)
        {
            bool flag = false;
            if (dividend == 0)
            {
                return 0;
            }

            if (divisor == -1 && dividend == int.MinValue)
                return int.MaxValue;

            if (divisor == 1 || divisor == -1)
                return (divisor == 1 ? dividend : -dividend);

            if ((dividend < 0 && divisor > 0) || (dividend > 0 && divisor < 0))
                flag = true;

            dividend = (dividend < 0 ? dividend : -dividend);
            divisor = (divisor < 0 ? divisor : -divisor);

            if (dividend > divisor)
            {
                return 0;
            }

            multiplier.Push(-1);
            result.Push(divisor);
            int topResult, topMultiplier;
            while (result.Peek() > dividend)
            {
                topResult = result.Peek();
                topMultiplier = multiplier.Peek();

                Console.WriteLine(topResult);
                if (topResult + topResult < dividend || topResult + topResult > 0)
                    break;

                result.Push(topResult + topResult);
                multiplier.Push(topMultiplier + topMultiplier);
            }

            if (result.Peek() == dividend)
                return (flag ? multiplier.Peek() : -multiplier.Peek());

            topResult = result.Pop();
            topMultiplier = multiplier.Pop();

            while (dividend - topResult <= divisor)
            {
                while (topResult + result.Peek() > 0 || topResult + result.Peek() < dividend)
                {
                    result.Pop();
                    multiplier.Pop();
                }
                topResult += result.Pop();
                topMultiplier += multiplier.Pop();
            }

            return (flag ? topMultiplier : -topMultiplier);
        }
    }
}
