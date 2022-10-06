using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Sort
    {
        public void MergeSort<T>(T[] array) where T: IComparable
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private void MergeSort<T>(T[] array, int l, int r) where T : IComparable
        {
            if (l >= r)
                return;

            int m = (l + r) / 2;
            MergeSort(array, l, m);
            MergeSort(array, m + 1, r);
            Merge(array, l, m + 1, r);
        }

        private void Merge<T>(T[] array, int leftStart, int rightStart, int end) where T : IComparable
        {
            int n = rightStart - leftStart;
            int m = end - rightStart + 1;

            T[] tmp = new T[m + n];
            int i = leftStart, j = rightStart, current = 0;
            while (i <= rightStart - 1 && j <= end)
            {
                if (array[i].CompareTo(array[j]) <= 0)
                    tmp[current++] = array[i++];
                else
                    tmp[current++] = array[j++];
            }

            while(i <= rightStart - 1)
                tmp[current++] = array[i++];

            while (j <= end)
                tmp[current++] = array[j++];

            current = 0;
            for (i = leftStart; i <= end; i++)
                array[i] = tmp[current++];
        }

    }
}
