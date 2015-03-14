using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntHexFormatProviderLibrary;
using System.Globalization;

namespace UnitTestIntHexFormatProvider
{
    [TestClass]
    public class IntHexFormatProviderTest
    {
        [TestMethod]
        public void IHFPIntegerTest()
        {
            IFormatProvider fp = new IntHexFormatProvider();
            string expected = 100.ToString("X");
            string actual = string.Format(fp, "{0:H}", 100);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IHFPStringTest()
        {
            IFormatProvider fp = new IntHexFormatProvider();
            string actual = string.Format(fp, "{0:H}", "fds");

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void IHFPDoubleTest()
        {
            IFormatProvider fp = new IntHexFormatProvider();
            string actual = string.Format(fp, "{0:H}", "10.5");
        }


        [TestMethod()]
        public void IHFPZeroTest()
        {
            IFormatProvider fp = new IntHexFormatProvider();
            string expected = 0.ToString("X");
            string actual = string.Format(fp, "{0:H}", 0);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod()]
        public void IHFPMaxIntTest()
        {
            IFormatProvider fp = new IntHexFormatProvider();
            string expected = int.MaxValue.ToString("X");
            string actual = string.Format(fp, "{0:H}", int.MaxValue);

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod()]
        public void IHFPCultureTest()
        {
            IFormatProvider fp = new IntHexFormatProvider(CultureInfo.GetCultureInfo("en-US"));
            Assert.AreEqual("$1,234.00", String.Format(fp, "{0:C}", 1234));
        }

    }
}
