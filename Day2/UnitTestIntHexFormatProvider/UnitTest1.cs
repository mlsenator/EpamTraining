using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntHexFormatProviderLibrary;

namespace UnitTestIntHexFormatProvider
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IFormatProvider fp = new IntHexFormatProvider();
            string a = 100.ToString("X");
            string b = string.Format(fp, "{0:H}", 100);

            Assert.AreEqual(a, b);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestMethod2()
        {
            IFormatProvider fp = new IntHexFormatProvider();
            string a = 100.ToString("X");
            string b = string.Format(fp, "{0:H}", "fds");

        }
    }
}
