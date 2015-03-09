using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreatestCommonDivisorLibrary;

namespace UnitTestGCD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EvklidMethodTest()
        {
            GreatestCommonDivisor gcd = new GreatestCommonDivisor();
            int a = 40;
            int b = 37;
            int expected = 1;
            Assert.AreEqual(expected, gcd.Evklid(a, b));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EvklidMethodExceptionTest()
        {
            GreatestCommonDivisor gcd = new GreatestCommonDivisor();
            int a = 4;
            int b = -1;
            int actual = gcd.Evklid(a, b);
        }

        [TestMethod]
        public void EvklidParamsMethodTest()
        {
            GreatestCommonDivisor gcd = new GreatestCommonDivisor();
            int expected = 7;
            Assert.AreEqual(expected, gcd.Evklid(70, 21, 14, 7));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EvklidParamsMethodExceptionTest()
        {
            GreatestCommonDivisor gcd = new GreatestCommonDivisor();
            int actual = gcd.Evklid(43, 34, -1);
        }

        [TestMethod]
        public void EvklidMethodZeroTest()
        {
            GreatestCommonDivisor gcd = new GreatestCommonDivisor();
            int expected = 7;
            Assert.AreEqual(expected, gcd.Evklid(0, 70, 14, 7));
        }

        [TestMethod]
        public void SteinaMethodTest()
        {
            GreatestCommonDivisor gcd = new GreatestCommonDivisor();
            int a = 40;
            int b = 37;
            int expected = gcd.Evklid(a, b);
            Assert.AreEqual(expected, gcd.Stein(a, b));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SteinaMethodExceptionTest()
        {
            GreatestCommonDivisor gcd = new GreatestCommonDivisor();
            int a = 4;
            int b = -1;
            int actual = gcd.Stein(a, b);
        }

        [TestMethod]
        public void SteinParamsMethodTest()
        {
            GreatestCommonDivisor gcd = new GreatestCommonDivisor();
            int expected = gcd.Evklid(70, 21, 14, 7);
            Assert.AreEqual(expected, gcd.Stein(70, 21, 14, 7));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SteinParamsMethodExceptionTest()
        {
            GreatestCommonDivisor gcd = new GreatestCommonDivisor();
            int actual = gcd.Stein(432, 234, -1);
        }

        [TestMethod]
        public void SteinMethodZeroTest()
        {
            GreatestCommonDivisor gcd = new GreatestCommonDivisor();
            int expected = gcd.Evklid(0, 70, 14, 7);
            Assert.AreEqual(expected, gcd.Stein(0, 70, 14, 7));
        }
    }
}
