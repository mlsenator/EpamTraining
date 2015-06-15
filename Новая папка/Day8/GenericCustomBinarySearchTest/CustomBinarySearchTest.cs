using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericCustomBinarySearch;

namespace GenericCustomBinarySearchTest
{
    [TestClass]
    public class CustomBinarySearchTest
    {
        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void BinarySearchNullReferenceExceptionTest()
        {
            int[] array = null;
            array.CustomBinarySearch<int>(3);
        }

        [TestMethod()]
        public void BinarySearchNotFoundTest()
        {
            int[] array = new int[] { };
            int index = array.CustomBinarySearch<int>(3);
            Assert.AreEqual(-1, index);
        }
        [TestMethod()]
        public void BinarySearchTest1()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            int actual = array.CustomBinarySearch<int>(3);
            Assert.AreEqual(2, actual);
        }
        [TestMethod()]
        public void BinarySearchTest2()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5};
            int actual = array.CustomBinarySearch<int>(1);
            Assert.AreEqual(0, actual);
        }
        [TestMethod()]
        public void BinarySearchTest3()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5};
            int actual = array.CustomBinarySearch<int>(5);
            Assert.AreEqual(4, actual);
        }
    }
}
