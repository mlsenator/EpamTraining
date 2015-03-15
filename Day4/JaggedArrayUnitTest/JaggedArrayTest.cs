using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathHelper;

namespace JaggedArrayUnitTest
{
    [TestClass]
    public class JaggedArrayTest
    {
        int[][] arr = new int[][] {
                                    new int[] {1,2,3,4},
                                    new int[] {-60, 20, 10}, 
                                    new int[] {7, 15, 22},
                                    new int[] {1}, 
                                    new int[] {19},
                                    new int[] {100, 50, 200},
                                    null,
                                    null

        };

        [TestMethod()]
        public void QuickSortSumAZTest()
        {
            int[][] expected = new int[][]{
                                    null,
                                    null,
                                    arr[1],
                                    arr[3], 
                                    arr[0],
                                    arr[4],
                                    arr[2],
                                    arr[5]
        };

            int[][] actual = (int[][])arr.Clone();
            actual.QuickSort(0, arr.Length - 1, new SumComparerAZ());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortSumZATest()
        {
            int[][] expected = new int[][]{
                                    arr[5],
                                    arr[2], 
                                    arr[4],
                                    arr[0],
                                    arr[3],
                                    arr[1],
                                    null,
                                    null
        };

            int[][] actual = (int[][])arr.Clone(); 
            actual.QuickSort(0, arr.Length - 1, new SumComparerZA());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortMaxAZTest()
        {
            int[][] expected = new int[][]{
                                    null,
                                    null,
                                    arr[3],
                                    arr[0], 
                                    arr[4],
                                    arr[1],
                                    arr[2],
                                    arr[5]
        };

            int[][] actual = (int[][])arr.Clone();
            actual.QuickSort(0, arr.Length - 1, new MaxComparerAZ());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void QuickSortMaxZATest()
        {
            int[][] expected = new int[][]{
                                    arr[5],
                                    arr[2], 
                                    arr[1],
                                    arr[4],
                                    arr[0],
                                    arr[3],
                                    null,
                                    null
        };

            int[][] actual = (int[][])arr.Clone();
            actual.QuickSort(0, arr.Length - 1, new MaxComparerZA());
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionTest()
        {
            arr.QuickSort(0, arr.Length - 1, null);
        }
    }
}
