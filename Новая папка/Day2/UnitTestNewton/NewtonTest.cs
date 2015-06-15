using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathHelper;

namespace UnitTestNewton
{
    [TestClass]
    public class NewtonTest
    {
        [TestMethod]
        public void TestNewton1()
        {
            Assert.AreEqual(3, NewtonSqrtMethod.Solve(27, 3, 0.000000000001));
        }

        [TestMethod]
        public void TestNewton2()
        {
            Assert.AreEqual(10, NewtonSqrtMethod.Solve(100, 2, 0.000000000001));
        }

        [TestMethod]
        public void TestNewton3()
        {
            Assert.AreEqual(-3, NewtonSqrtMethod.Solve(-27, 3, 0.000000000001));
        }

        [TestMethod]
        public void TestNewton4()
        {
            Assert.AreEqual(5, NewtonSqrtMethod.Solve(125, 3, 0.000000000001));
        }

        [TestMethod]
        public void TestNewton5()
        {
            Assert.AreEqual(0.5, NewtonSqrtMethod.Solve(0.125, 3, 0.000000000001));
        }
    }
}
