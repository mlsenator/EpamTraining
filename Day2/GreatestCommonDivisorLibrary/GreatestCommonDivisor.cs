using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MathHelper
{
    public class GreatestCommonDivisor
    {
        public delegate int GCDMethod(int[] args);
        public int Evklid(int a, int b)
        {
            if (a <= -1 || b <= -1) throw new ArgumentException();
            if (a == 0) return b;
            if (b == 0) return a;

            int buffer;
            if (a < b)
                Swap(ref a,ref b);

            while (b != 0)
            {
                buffer = b;
                b = a % b;
                a = buffer;
            }

            return a;
        }

        public int Evklid(params int[] array)
        {
            if (array.Length == 2) return Evklid(array[0], array[1]);
            return Evklid(array[0], Evklid(array.Skip(1).ToArray()));
        }

        public int Stein(int a, int b)
        {
            int count = 0;
            return SteinCalculation(a, b, ref count);
        }

        public int Stein(params int[] array)
        {
            if (array.Length == 2) return Stein(array[0], array[1]);
            return Stein(array[0], Stein(array.Skip(1).ToArray()));
        }

        private int SteinCalculation(int a, int b, ref int count)
        {
            if (a <= -1 || b <= -1) throw new ArgumentException();
            if (a == 0) return b;
            if (b == 0) return a;

            if (a == b) return (a * Convert.ToInt32(Math.Pow(2, count)));

            if ((a % 2) == 0 && (b % 2) == 0)
            {
                count++;
                return SteinCalculation(a / 2, b / 2, ref count);
            }
            if ((a % 2) == 0 && (b % 2) == 1) return SteinCalculation(a / 2, b, ref count);
            if ((a % 2) == 1 && (b % 2) == 0) return SteinCalculation(a, b / 2, ref count);
            if ((a % 2) == 1 && (b % 2) == 1)
            {
                if (a < b) return SteinCalculation((b - a) / 2, a, ref count);
                else if (a > b) return SteinCalculation((a - b) / 2, b, ref count);
                return -1;
            }

            return -1;

        }

        private void Swap (ref int a, ref int b)
        {
            int buffer = a;
            a = b;
            b = buffer;     
        }

        public static int ElapsedTicks(GCDMethod method, out long time, params int[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            method(args);
            watch.Stop();
            time = new TimeSpan(watch.ElapsedTicks).Ticks;
            return args[args.Length - 1];
        }
    }
}
