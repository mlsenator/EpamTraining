using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNRoot;

namespace UnitTestNewton
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestNewton1()
        {
            Assert.AreEqual(3, NRoot.Solve(27, 3, 0.000000000001));
        }

        [TestMethod]
        public void TestNewton2()
        {
            Assert.AreEqual(10, NRoot.Solve(100, 2, 0.000000000001));
        }

        [TestMethod]
        public void TestNewton3()
        {
            Assert.AreEqual(-3, NRoot.Solve(-27, 3, 0.000000000001));
        }

        [TestMethod]
        public void TestNewton4()
        {
            Assert.AreEqual(5, NRoot.Solve(125, 3, 0.000000000001));
        }
    }
}
