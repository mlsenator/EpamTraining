using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathHelper;

namespace PolynomialUnitTest
{
    [TestClass]
    public class PolynomialTest
    {
        [TestMethod]
        public void PolynomialSimplifyerTest()
        {
            PolynomialElement[] el = new PolynomialElement[4] { new PolynomialElement(1, 3), new PolynomialElement(5, 5), new PolynomialElement(2, 2), new PolynomialElement(2, 3)};
            PolynomialElement[] el2 = new PolynomialElement[3] { new PolynomialElement(2, 2), new PolynomialElement(3, 3), new PolynomialElement(5, 5)};
            Polynomial poly = new Polynomial(el);
            Polynomial poly2 = new Polynomial(el2);
            Assert.AreEqual(poly2, poly);
        }

        [TestMethod()]
        public void PolynomialCtorsTest()
        {
            PolynomialElement[] el = new PolynomialElement[4] { new PolynomialElement(2, 0), new PolynomialElement(4, 1), new PolynomialElement(6, 2), new PolynomialElement(8, 3)};
            Polynomial poly2 = new Polynomial(el);
            Polynomial poly = new Polynomial(new double[] { 2, 4, 6, 8 });
            Assert.AreEqual(poly2, poly);
        }

        [TestMethod()]
        public void PolynomialOrderByTest()
        {
            PolynomialElement[] el = new PolynomialElement[3] { new PolynomialElement(3, 3), new PolynomialElement(5, 5), new PolynomialElement(2, 2)};
            PolynomialElement[] el2 = new PolynomialElement[3] { new PolynomialElement(2, 2), new PolynomialElement(3, 3), new PolynomialElement(5, 5)};
            Polynomial poly = new Polynomial(el);
            Polynomial poly2 = new Polynomial(el2);
            Assert.AreEqual(poly2, poly);
        }    

        [TestMethod()]
        public void PolynomialMultiplyTest()
        {
            PolynomialElement[] el = new PolynomialElement[5] { new PolynomialElement(3.1, 3), 
                                                                new PolynomialElement(5.1, 5), 
                                                                new PolynomialElement(2.1, 2), 
                                                                new PolynomialElement(100.1, 100), 
                                                                new PolynomialElement(50.1, 50) };
            Polynomial poly = new Polynomial(new double[] { 2.1, 4.1, 6.1, 8.1 });
            Polynomial poly2 = new Polynomial(el);
            var actual = poly * poly2;
            Polynomial expected = new Polynomial(new PolynomialElement[15] { new PolynomialElement(4.41, 2), 
                                                                             new PolynomialElement(15.12, 3), 
                                                                             new PolynomialElement(25.52, 4), 
                                                                             new PolynomialElement(46.63, 5), 
                                                                             new PolynomialElement(46.02, 6),
                                                                             new PolynomialElement(31.11, 7), 
                                                                             new PolynomialElement(41.31, 8), 
                                                                             new PolynomialElement(105.21, 50), 
                                                                             new PolynomialElement(205.41, 51), 
                                                                             new PolynomialElement(305.61, 52),
                                                                             new PolynomialElement(405.81, 53), 
                                                                             new PolynomialElement(210.21, 100), 
                                                                             new PolynomialElement(410.41, 101), 
                                                                             new PolynomialElement(610.61, 102), 
                                                                             new PolynomialElement(810.81, 103)});
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PolynomialMultiplyNullExceptionTest()
        {
            Polynomial poly = new Polynomial(new double[] { 2.1, 4.1, 6.1, 8.1 });
            var actual = poly * null;
        }


        [TestMethod()]
        public void PolynomialMultiplyTest2()
        {
            Polynomial poly = new Polynomial(new double[] { 2.1, 4.1, 6.1, 8.1 });
            poly = poly * 2;
            Polynomial expected = new Polynomial(new double[] { 4.2, 8.2, 12.2, 16.2 });
            Assert.AreEqual(expected, poly);
        }

        [TestMethod()]
        public void PolynomialSumTest()
        {
            Polynomial poly = new Polynomial(new double[] { 2.1, 4.1, 6.1, 8.1 });
            Polynomial poly2 = new Polynomial(new double[] { 4.2, 8.2, 12.2, 16.2 });
            Polynomial expected = new Polynomial(new double[] { 6.3, 12.3, 18.3, 24.3 });
            Assert.AreEqual(expected, poly + poly2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PolynomialSumNullExceptionTest()
        {
            Polynomial poly = new Polynomial(new double[] { 2.1, 4.1, 6.1, 8.1 });
            var actual = poly + null;
        }

        [TestMethod()]
        public void PolynomialSubstractTest()
        {
            Polynomial poly = new Polynomial(new double[] { 6.3, 12.3, 18.3, 24.3 });
            Polynomial poly2 = new Polynomial(new double[] { 4.2, 8.2, 12.2, 16.2 });
            Polynomial expected = new Polynomial(new double[] { 2.1, 4.1, 6.1, 8.1 });
            var actual = poly - poly2;
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PolynomialDivisionNullExceptionTest()
        {
            Polynomial poly = null;
            var actual = poly / 2;
        }
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void PolynomialDivisionZeroTest()
        {
            Polynomial poly = new Polynomial(new double[] { 2.1, 4.1, 6.1, 8.1 });
            var actual = poly / 0;
        }
        [TestMethod()]
        public void PolynomialEqualsTest()
        {
            Polynomial poly = new Polynomial(new double[] { 2.1, 4.1, 6.1, 8.1 });
            Polynomial poly2 = new Polynomial(new double[] { 2.1, 4.1, 6.1, 8.1 });
            var expected = poly.Equals(poly2);
            Assert.AreEqual(expected, true);
        }
    }
}
