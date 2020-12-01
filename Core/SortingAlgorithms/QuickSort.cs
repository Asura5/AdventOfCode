using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode_2020.Core.SortingAlgorithms
{
    public static class QuickSort
    {
        public static void quickSort(int[] dataArray, int left, int right)
        {
            if (left > right || left < 0 || right < 0) return;

            int index = partition(dataArray, left, right);

            if (index != -1)
            {
                quickSort(dataArray, left, index - 1);
                quickSort(dataArray, index + 1, right);
            }
        }

        private static int partition(int[] dataArray, int left, int right)
        {
            if (left > right) return -1;

            int end = left;

            int pivot = dataArray[right];

            for (int i = left; i < right; i++)
            {
                if (dataArray[i] < pivot)
                {
                    swap(dataArray, i, end);
                    end++;
                }
            }

            swap(dataArray, end, right);

            return end;
        }

        private static void swap(int[] dataArray, in int left, in int right)
        {
            int tmp = dataArray[left];
            dataArray[left] = dataArray[right];
            dataArray[right] = tmp;
        }
    }
}
