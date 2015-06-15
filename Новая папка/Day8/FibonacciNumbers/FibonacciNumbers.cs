using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    public static class FibonacciNumbersCalc
    {
        public static IEnumerable<Int64> FibonacciCalc(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Wrong input. Count veriable canbe positive only");
            }
            Int64 f0 = 0;
            Int64 f1 = 1;
            int counter = 1;
            yield return f0;
            while (counter++ < count)
            {
                yield return f1;
                
                swap(ref f0, ref f1);
                try
                {
                    f1 = checked(f0 + f1);
                }
                catch
                {
                    throw new OverflowException("kokoko");
                }
            }
        }
        private static void swap(ref Int64 a, ref Int64 b)
        {
            Int64 temp = a;
            a = b;
            b = temp;
        }
    }
}
