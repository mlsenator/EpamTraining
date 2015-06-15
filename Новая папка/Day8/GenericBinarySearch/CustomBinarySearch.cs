using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCustomBinarySearch
{
    public static class GenericCustomBinarySearch
    {
        public static int CustomBinarySearch<T>(this T[] array, T value)
        {
            if (array == null)
                throw new NullReferenceException("Array is null.");

            if (value is IComparable)
            {
                return CustomBinarySearch(array, value, (T t1, T t2) => { return ((IComparable)t1).CompareTo(t2); });
            }
            else throw new InvalidOperationException("Not comparable type.");
        }

        public static int CustomBinarySearch<T>(this T[] array, T value, Func<T, T, int> comparer)
        {
            if (array == null)
                throw new NullReferenceException("Array is null.");
            if (comparer == null)
                return CustomBinarySearch(array, value);

            int left = 0;
            int right = array.Length - 1;
            int middle = (right + left) / 2;
            while (right >= left)
            {
                if (comparer(array[middle], value) < 0)
                {
                    if (right - left < 2)
                        if (comparer(array[right], value) != 0) return -1;
                        else return right;
                    left = middle;
                    middle = (right + left) / 2;
                }
                else if (comparer(array[middle], value) > 0)
                {
                    if (right - left < 2)
                        if (comparer(array[right], value) != 0) return -1;
                        else return right;
                    right = middle;
                    middle = (right + left) / 2;
                }
                else
                {
                    return middle;
                }
            }
            return -1;
        }
    }
}
