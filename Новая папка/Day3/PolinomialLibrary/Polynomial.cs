using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MathHelper
{
    public sealed class Polynomial : ICloneable, IEquatable<Polynomial>, IFormattable
    {
        private PolynomialElement[] elements;

        public Polynomial (double[] coefficients)
        {
            if (coefficients == null)
                throw new ArgumentNullException("Coefficients are null.");
            int length = coefficients.Length;
            elements = new PolynomialElement[length];
            for (int i = 0; i < length; i++)
                elements[i] = new PolynomialElement(coefficients[i], i);
        }
        public Polynomial (PolynomialElement[] elements)
        {
            if (elements == null)
                throw new ArgumentNullException("Elements are null.");

            this.elements = elements.CloneElements().OrderBy(element => element.degree).ToArray();

            CheckIfSimple();
        }
        public PolynomialElement this[int index]
        {
            get
            {
                if (index > Length - 1)
                {
                    throw new ArgumentException();
                }
                else
                {
                    return elements[index];
                }
            }
            set
            {
                if (index > Length - 1)
                {
                    throw new ArgumentException();
                }
                else
                {
                    elements[index] = value;
                    elements.OrderBy(element => element.degree);
                }
            }
        }
        public int Length
        {
            get { return elements.Length; }
        }
        public object Clone ()
        {
            return new Polynomial(elements);
        }
        private PolynomialElement[] SimplifyElements(PolynomialElement[] elem)
        {
            List<PolynomialElement> newElements = new List<PolynomialElement>();
            for (int i = 0; i < elem.Length; i++)
            {
                int index = newElements.FindIndex(element => element.degree == elem[i].degree);
                if (index != -1)
                    newElements[index] += elem[i];
                else newElements.Add(elem[i]);
            }
            return newElements.ToArray();
        }
        private void CheckIfSimple()
        {
            bool isSimple = true;
            int tempDegree = elements[0].degree;
            for (int i = 1; i < Length; i++)
            {
                if (tempDegree == elements[i].degree)
                {
                    //throw new ArgumentException("Argument have some elements with same degree.");
                    isSimple = false;
                    break;
                }
                tempDegree = elements[i].degree;
            }
            if (!isSimple)
                elements = SimplifyElements(elements);
        }
        public  bool Equals(Polynomial poly)
        {
            if (poly == null) return false;
            return this == poly;
        }
        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < Length; i++)
                hash += (int)this[i].coefficient*137 + this[i].degree*13;
            return hash;
        }
        public override string ToString()
        {
            return this.ToString("S", CultureInfo.CurrentCulture);
        }
        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (String.IsNullOrEmpty(format)) format = "S";
            if (format != "S")
                throw new FormatException(String.Format("Unknown format : {0}.", format));
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Length - 1; i++)
                if (this[i].coefficient != 0)
                    result.Append(String.Format("{0}*x^{1} + ", this[i].coefficient, this[i].degree));
            if (this[Length - 1].coefficient != 0)
                result.Append(String.Format("{0}*x^{1}", this[Length - 1].coefficient, this[Length - 1].degree));
            if (result.ToString() == "")
                return "0";
            return result.ToString();
        }


        #region Operators
        public static bool operator ==(Polynomial poly1, Polynomial poly2)
        {
            if (Object.Equals(poly1, null) && Object.Equals(poly2, null))
                return true;
            if (Object.Equals(poly1, null) || Object.Equals(poly2, null))
                return false;
            if (Object.ReferenceEquals(poly1, poly2) == true)
                return true;
            if (poly1.Length != poly2.Length) return false;
            for (int i = 0; i < poly1.Length; i++)
            {
                if (poly1[i] != poly2[i])
                    return false;
            }
            return true;
        }
        public static bool operator !=(Polynomial poly1, Polynomial poly2)
        {
            if (poly1 == null && poly2 == null)
                throw new ArgumentNullException("Both elements are null");
            return !(poly1 == poly2);
        }
        public static Polynomial operator +(Polynomial poly1, Polynomial poly2)
        {
            if (poly1 == null && poly2 == null)
                throw new ArgumentNullException("Can't sum null.");
            if (poly1 == null || poly2 == null)
                throw new ArgumentNullException("Can't add null.");

            List<PolynomialElement> newElements = new List<PolynomialElement>();

            int length1 = 0, length2 = 0;
            while (length1 < poly1.Length && length2 < poly2.Length)
            {
                if (poly1[length1].degree > poly2[length2].degree)
                {
                    newElements.Add(poly2[length2]);
                    length2++;
                    continue;
                }
                if (poly1[length1].degree < poly2[length2].degree)
                {
                    newElements.Add(poly1[length1]);
                    length1++;
                    continue;
                }

                newElements.Add(poly1[length1] + poly2[length2]);
                length2++;
                length1++;
            }

            if (length1 < poly1.Length)
                for (int i = length1; i < poly1.Length; i++)
                    newElements.Add(poly1[i]);

            if (length2 < poly2.Length)
                for (int i = length2; i < poly2.Length; i++)
                    newElements.Add(poly2[i]);

            return new Polynomial(newElements.ToArray());
        }
        public static Polynomial operator -(Polynomial poly)
        {
            if (poly == null)
                throw new ArgumentNullException("Can't operate with null");
            Polynomial newPoly = (Polynomial)poly.Clone();
            for (int i = 0; i < poly.Length; i++)
            {
                newPoly[i] = -poly[i];
            }
            return newPoly;
        }
        public static Polynomial operator -(Polynomial poly1, Polynomial poly2)
        {
            if (poly1 == null && poly2 == null)
                throw new ArgumentNullException("Cannot operate with null.");
            if (poly1 == null || poly2 == null)
                throw new ArgumentNullException("Can't substract polynomial and null.");
            Polynomial newPoly = poly1 + (-poly2);
            return newPoly;
        }
        public static Polynomial operator *(Polynomial poly1, Polynomial poly2)
        {
            if (poly1 == null && poly2 == null)
                throw new ArgumentNullException("Can't multiply null.");
            if (poly1 == null || poly2 == null)
                throw new ArgumentNullException("Can't multiply null.");

            List<PolynomialElement> newElements = new List<PolynomialElement>();
            for (int i = 0; i < poly1.Length; i++)
            {
                for (int j = 0; j < poly2.Length; j++)
                {
                    newElements.Add(poly1[i] * poly2[j]);
                }
            }
            return new Polynomial(newElements.ToArray());
        }
        public static Polynomial operator *(Polynomial poly, double coefficient)
        {
            if (poly == null)
                throw new ArgumentNullException("Can't multiply null.");
            PolynomialElement[] newElements = new PolynomialElement[poly.Length];
            for (int i = 0; i < newElements.Length; i++)
            {
                newElements[i] = poly[i] * coefficient;
            }
            return new Polynomial(newElements);
        }
        public static Polynomial operator /(Polynomial poly, double coefficient)
        {
            if (poly == null)
                throw new ArgumentNullException("Can't divide null.");
            if (coefficient == 0)
            {
                throw new DivideByZeroException();
            }
            PolynomialElement[] newElements = new PolynomialElement[poly.Length];
            for (int i = 0; i <= newElements.Length; i++)
            {
                newElements[i] = poly[i] / coefficient;
            }
            return new Polynomial(newElements);
        }
        #endregion

    }


    public struct PolynomialElement : ICloneable
        {
            public double coefficient;
            public int degree;
            public PolynomialElement(double coefficient, int degree)
            {
                this.coefficient = coefficient;
                this.degree = degree;
            }
            public object Clone()
            {
                return new PolynomialElement(coefficient, degree);
            }

            public static bool operator ==(PolynomialElement elem1, PolynomialElement elem2)
            {
                if (elem1.degree == elem2.degree && elem1.coefficient == elem2.coefficient)
                    return true;
                return false;
            }
            public static bool operator !=(PolynomialElement elem1, PolynomialElement elem2)
            {
                return !(elem1 == elem2);
            }
            public static PolynomialElement operator +(PolynomialElement elem1, PolynomialElement elem2)
            {
                if (elem1.degree != elem2.degree)
                    throw new ArgumentException("Can't sum elements with different degrees");
                return new PolynomialElement(elem1.coefficient + elem2.coefficient, elem1.degree);
            }
            public static PolynomialElement operator -(PolynomialElement elem)
            {
                return new PolynomialElement(elem.coefficient * (-1), elem.degree);
            }
            public static PolynomialElement operator -(PolynomialElement elem1, PolynomialElement elem2)
            {
                return new PolynomialElement(elem1.coefficient + (- elem2.coefficient), elem1.degree + (- elem2.degree));
            }
            public static PolynomialElement operator *(PolynomialElement elem1, PolynomialElement elem2)
            {
                return new PolynomialElement(elem1.coefficient * elem2.coefficient, elem1.degree + elem2.degree);
            }
            public static PolynomialElement operator *(PolynomialElement elem1, double coef)
            {
                return new PolynomialElement(elem1.coefficient * coef, elem1.degree);
            }
            public static PolynomialElement operator /(PolynomialElement elem1, double coef)
            {
                if (coef == 0)
                {
                    throw new DivideByZeroException();
                }
                return new PolynomialElement(elem1.coefficient / coef, elem1.degree);
            }
        }

    public static class PolynomialHelper
    {
        public static PolynomialElement[] CloneElements(this PolynomialElement[] elements)
        {
            PolynomialElement[] newElements = new PolynomialElement[elements.Length];
            for (int i = 0; i < elements.Length; i++)
                newElements[i] = (PolynomialElement)elements[i].Clone();
            return newElements;
        }
    }
}
