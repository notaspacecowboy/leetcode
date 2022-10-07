using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Sort
    {
        #region merge sort

        public void MergeSort<T>(T[] array) where T : IComparable
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

            while (i <= rightStart - 1)
                tmp[current++] = array[i++];

            while (j <= end)
                tmp[current++] = array[j++];

            current = 0;
            for (i = leftStart; i <= end; i++)
                array[i] = tmp[current++];
        }

        #endregion

        #region quick sort

        public void QuickSort<T>(T[] array) where T: IComparable
        {
            QuickSort(array, 0, array.Length - 1);
        }

        void QuickSort<T>(T[] array, int start, int end) where T : IComparable
        {
            if (start >= end)
                return;

            int partition = Partition(array, start, end);
            QuickSort(array, start, partition - 1);
            QuickSort(array, partition + 1, end);
        }

        int Partition<T>(T[] array, int start, int end) where T: IComparable
        {
            if (start >= end)
                return start;

            T pivot = array[start];
            int left = start, right = end;
            while (left < right)
            {
                while (left < right && array[right].CompareTo(pivot) >= 0)
                    right--;
                array[left] = array[right];

                while (left < right && array[left].CompareTo(pivot) <= 0)
                    left++;
                array[right] = array[left];
            }

            array[left] = pivot;
            return left;
        }

        #endregion
    }
}
