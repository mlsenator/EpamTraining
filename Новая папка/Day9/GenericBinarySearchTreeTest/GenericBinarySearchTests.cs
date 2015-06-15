using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericBinarySearchTree;
using System.Linq;
using BookHelper;

namespace GenericBinarySearchTreeTest
{
    [TestClass]
    public class GenericBinarySearchTests
    {
        private struct Point2D
        {
            public int x;
            public int y;
            public Point2D (int a, int b)
            {
                x = a;
                y = b;
            }
        }

        [TestMethod]
        public void InsertTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(5);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(4);
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            CollectionAssert.AreEqual(expected, bst.ToArray());
        }
        [TestMethod]
        public void RemoveTest1()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(5);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(4);
            bst.Remove(3);
            var expected = new int[] { 1, 2, 4, 5, 6, 7, 8, 9 };
            var actual = bst.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveTest2()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(5);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(4);
            bst.Remove(2);
            var expected = new int[] { 1, 3, 4, 5, 6, 7, 8, 9 };
            var actual = bst.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveTest3()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(5);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(4);
            bst.Remove(5);
            var expected = new int[] { 1, 2, 3, 4, 6, 7, 8, 9 };
            var actual = bst.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveTest4()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(5);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(4);
            bst.Remove(7);
            var expected = new int[] { 1, 2, 3, 4, 5, 6, 8, 9 };
            var actual = bst.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CamparerTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>((x, y) => y.CompareTo(x));
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(5);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(4);
            var expected = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var actual = bst.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PreOrderTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(5);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(4);
            var expected = new int[] { 3, 1, 2, 7, 6, 5, 4, 8, 9 };
            var actual = bst.PreOrder().ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void PostOrderTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(5);
            bst.Insert(8);
            bst.Insert(9);
            bst.Insert(2);
            bst.Insert(4);
            var expected = new int[] { 2, 1, 4, 5, 6, 9, 8, 7, 3 };
            var actual = bst.PostOrder().ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StringCustomComparerTest()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>((x, y) => y.CompareTo(x));
            bst.Insert("A");
            bst.Insert("E");
            bst.Insert("B");
            bst.Insert("C");
            bst.Insert("D");
            var expected = new string[] { "E", "D", "C", "B", "A" };
            CollectionAssert.AreEqual(expected, bst.ToArray());
        }
        [TestMethod]
        public void StringDefaultComparerTest()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>();
            bst.Insert("A");
            bst.Insert("D");
            bst.Insert("E");
            bst.Insert("B");
            bst.Insert("C");
            var expected = new string[] { "A", "B", "C", "D", "E" };
            CollectionAssert.AreEqual(expected, bst.ToArray());
        }

        [TestMethod]
        public void BookCustomComparerTest()
        {
            BinarySearchTree<Book> bst = new BinarySearchTree<Book>((x, y) => x.Pages.CompareTo(y.Pages));
            Book[] books = new Book[] { new Book("authorC", "titleC", 1992, 103),new Book("authorD", "titleD", 1993, 102),
                                        new Book("authorA", "titleA", 1990, 105), new Book("authorB", "titleB", 1991, 104),
                                        new Book("authorE", "titleE", 1994, 101),new Book("authorF", "titleF", 1995, 100)};
            foreach (var book in books)
                bst.Insert(book);
            Array.Sort(books, (x, y) => x.Pages.CompareTo(y.Pages));
            CollectionAssert.AreEqual(books, bst.ToArray());
        }
        [TestMethod]
        public void BookDefaultComparerTest()
        {
            BinarySearchTree<Book> bst = new BinarySearchTree<Book>();
            Book[] books = new Book[] { new Book("authorC", "titleC", 1992, 100),new Book("authorD", "titleD", 1993, 100),
                                        new Book("authorA", "titleA", 1990, 100), new Book("authorB", "titleB", 1991, 100),
                                        new Book("authorE", "titleE", 1994, 100),new Book("authorF", "titleF", 1995, 100)};
            for (int i = 0; i < books.Length; i++)
                bst.Insert(books[books.Length - i - 1]);
            Array.Sort(books);
            CollectionAssert.AreEqual(books, bst.ToArray());
        }

        [TestMethod]
        public void Point2DCustomComparerTest()
        {
            BinarySearchTree<Point2D> bst = new BinarySearchTree<Point2D>((x, y) => x.x.CompareTo(y.x));
            Point2D[] points = new Point2D[]
            {
                new Point2D { x = 0, y = 0 },
                new Point2D { x = 1, y = 1 },
                new Point2D { x = 2, y = 2 }
            };
            foreach (var point in points)
                bst.Insert(point);
            CollectionAssert.AreEqual(points.ToArray(), bst.ToArray());
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Point2DTryDefaultComparerTest()
        {
            BinarySearchTree<Point2D> bst = new BinarySearchTree<Point2D>();
            Point2D[] points = new Point2D[]
            {
                new Point2D { x = 0, y = 0 },
                new Point2D { x = 1, y = 1 },
                new Point2D { x = 2, y = 2 }
            };
            foreach (var point in points)
                bst.Insert(point);
        }
    }
}
