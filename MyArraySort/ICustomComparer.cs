using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArraySort
{
    public interface ICustomComparer
    {
        int Compare(int[] x, int[] y);
    }
}
