using System;
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
            return x.Min().CompareTo(y.Min());
        }
    }

    public class MaxComparerAZ : ICustomComparer
    {
        int ICustomComparer.Compare(int[] x, int[] y)
        {
            return x.Max().CompareTo(y.Max());
        }
    }

    public class SumComparerAZ : ICustomComparer
    {
        int ICustomComparer.Compare(int[] x, int[] y)
        {
            return x.Sum().CompareTo(y.Sum());
        }
    }

    public class MinComparerZA : ICustomComparer
    {
        int ICustomComparer.Compare(int[] x, int[] y)
        {
            return y.Min().CompareTo(x.Min());
        }
    }

    public class MaxComparerZA : ICustomComparer
    {
        int ICustomComparer.Compare(int[] x, int[] y)
        {
            return y.Max().CompareTo(x.Max());
        }
    }

    public class SumComparerZA : ICustomComparer
    {
        int ICustomComparer.Compare(int[] x, int[] y)
        {
            return y.Sum().CompareTo(x.Sum());
        }
    }
}
