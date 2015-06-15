using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathHelper
{
    public static class NewtonSqrtMethod
    {
        public static double Solve(double number, int power, double epsilon)
	{
        double x0;
        double x1 = number/2;
		do
		{
            x0 = x1;
			double buf = Pow (x0, power-1);
            x1 = ((power - 1) * x0 + number / buf) / power;
		}
		while (Math.Abs(x0 - x1) > epsilon);
		return x1;
	}

        private static double Pow(double number, int power)
        {
            double result = 1;
            while (power-- > 0)
                result *= number;
            return result;
        }
    }
}
