using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArraySort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = { new[] { 7, 8 }, new[] { 9, 10 }, new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 }};

            arr.MyQuickSort(0, arr.Length - 1, new MinComparerAZ());
            //ArraySort.Bubble(arr, new MinComparer());
            Print(arr);
            Console.ReadKey();
        }

        static void Print(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0}.", i);
                foreach (var x in arr[i])
                    Console.Write("  {0},", x);
                Console.Write("\n");
            }
        }
    }
}
