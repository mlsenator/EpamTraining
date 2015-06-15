using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArraySort
{
    public static class ArraySort
    {
        private static int Partition(int[][] numbers, int left, int right, ICustomComparer comparator)
        {
            int[] pivot = numbers[left];
            while (true)
            {
                while (comparator.Compare(numbers[left], pivot) < 0)
                    left++;
                while (comparator.Compare(numbers[right], pivot) > 0)
                    right--;

                if (left < right)
                {
                    int[] temp = numbers[right];
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        public static void MyQuickSort(this int[][] arr, int left, int right, ICustomComparer comparator)
        {

            if (left < right)
            {
                int pivot = Partition(arr, left, right, comparator);

                if (pivot > 1)
                    MyQuickSort(arr, left, pivot - 1, comparator);

                if (pivot + 1 < right)
                    MyQuickSort(arr, pivot + 1, right, comparator);
            }
        }

        public static void Bubble(int[][] arr, ICustomComparer comparator)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i; j++)
                {
                    if (comparator.Compare(arr[j], arr[j+1]) > 0)
                    {
                        int[] temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
    }
}
