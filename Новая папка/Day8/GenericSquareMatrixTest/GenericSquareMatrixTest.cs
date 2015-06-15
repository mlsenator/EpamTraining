using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericSquareMatrix;

namespace GenericSquareMatrixTest
{
    [TestClass]
    public class GenericSquareMatrixTest
    {
        [TestMethod]
        public void SquareMatrixSetValueTest()
        {
            var square = new SquareMatrix<int>(5);
            square[1, 2] = 7;
            Assert.AreEqual(7, square[1, 2]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SquareMatrixOutOfRangeIndexerTest()
        {
            var square = new SquareMatrix<double>(5);
            double buf = square[7, 10];
        }

        [TestMethod]
        public void SymmetricMatrixSetValueTest()
        {
            var symmetric = new SymmetricMatrix<string>(4);
            symmetric[2, 3] = "F";
            Assert.AreEqual("F", symmetric[3, 2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SymmetricMatrixArgumentExceptionInCtorTest()
        {
            var symmetric = new SymmetricMatrix<int>(new int[,] { { 1, 2 }, { 3, 3 } });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DiagonalMatrixArgumentExceptionInSetMethodTest()
        {
            var diagonal = new DiagonalMatrix<string>(5);
            diagonal[0, 1] = "kokoko";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddMethodTest1()
        {
            var symmetric = new SymmetricMatrix<string>(4);
            var diagonal = new DiagonalMatrix<string>(4);
            symmetric.Add(diagonal).ConsolePrint();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddMethodTest2()
        {
            var symmetric = new SymmetricMatrix<int>(4);
            var diagonal = new DiagonalMatrix<double>(6);
            symmetric.Add(diagonal).ConsolePrint();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddMethodTest3()
        {
            var symmetric = new SymmetricMatrix<int>(4);
            var diagonal = new DiagonalMatrix<double>(4);
            symmetric.Add(diagonal).ConsolePrint();
        }

        [TestMethod]
        public void AddMethodTest4()
        {
            var square = new SquareMatrix<double>(new double[,] { { 1.1, 1.2, 1.3 }, { 1.1, 1.2, 1.3 }, { 1.1, 1.2, 1.3 } });
            var symmetric = new SymmetricMatrix<int>(new int[,] { { 1, 2, 3 }, { 2, 3, 1 }, { 3, 1, 2 } });
            var sum = square.Add(symmetric);
            Assert.AreEqual(4.2, sum[1, 1]);
        }
    }
}
