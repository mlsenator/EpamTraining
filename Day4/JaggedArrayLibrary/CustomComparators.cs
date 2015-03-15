﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathHelper
{
    public class MinComparerAZ : ICustomComparer
    {
        int ICustomComparer.Compare(int[] x, int[] y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Min().CompareTo(y.Min());
        }
    }

    public class MaxComparerAZ : ICustomComparer
    {
        int ICustomComparer.Compare(int[] x, int[] y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Max().CompareTo(y.Max());
        }
    }

    public class SumComparerAZ : ICustomComparer
    {
        int ICustomComparer.Compare(int[] x, int[] y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Sum().CompareTo(y.Sum());
        }
    }

    public class MinComparerZA : ICustomComparer
    {
        int ICustomComparer.Compare(int[] x, int[] y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            return y.Min().CompareTo(x.Min());
        }
    }

    public class MaxComparerZA : ICustomComparer
    {
        int ICustomComparer.Compare(int[] x, int[] y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            return y.Max().CompareTo(x.Max());
        }
    }

    public class SumComparerZA : ICustomComparer
    {
        int ICustomComparer.Compare(int[] x, int[] y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;
            return y.Sum().CompareTo(x.Sum());
        }
    }
}
