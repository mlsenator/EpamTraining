using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathHelper
{
    public static class JaggedArraySort
    {
        public static void Bubble(this int[][] arr, ICustomComparer comparator)
        {
            if (comparator == null)
                throw new ArgumentNullException();
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

        public static void QuickSort(this int[][] a, int l, int r, ICustomComparer comparator)
        {
            int[] temp;
            int[] x = a[l + (r - l) / 2];

            int i = l;
            int j = r;

            while (i <= j)
            {
                while (comparator.Compare(a[i], x) < 0) i++;
                while (comparator.Compare(a[j], x) > 0) j--;
                if (i <= j)
                {
                    temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;
                    j--;
                }
            }
            if (i < r)
                QuickSort(a, i, r, comparator);

            if (l < j)
                QuickSort(a, l, j, comparator);
        }
    }
}
