using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSquareMatrix
{
    public static class GenericSquareMatrixExtensions
    {
        public static bool IsSymmetric<T>(this T[,] matrix)
        {
            for (int i = 1; i < matrix.GetLength(1); i++)
                for (int j = 0; j < i; j++)
                    if (!matrix[i, j].Equals(matrix[j, i]))
                        return false;
            return true;
        }
        public static bool IsSquare<T>(this T[,] matrix)
        {
            return matrix.GetLength(0) == matrix.GetLength(1);
        }
        public static SquareMatrix<T> Add<T, U>(this AbstractSquareMatrix<T> x, AbstractSquareMatrix<U> y)
        {
            if (y == null) throw new ArgumentNullException("Can't add null");
            if (x.Size != y.Size) throw new ArgumentException("Size of matrixes must be the same");
            var sum = new SquareMatrix<T>(x.Size);
            for (int i = 0; i < x.Size; i++)
                for (int j = 0; j < x.Size; j++)
                {
                    dynamic a = x[i, j];  //How Dmitry told us, it works!
                    dynamic b = y[i, j];
                    try
                    {
                        sum[i, j] = a + b;
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException("Can't add different types", e);
                    }
                }
            return sum;
        }
        public static SquareMatrix<T> Add<T, U>(this AbstractSquareMatrix<T> x, AbstractSquareMatrix<U> y, Func<T, U, T> addMethod)
        {
            if (y == null) throw new ArgumentNullException("SumMatrices");
            if (x.Size != y.Size) throw new ArgumentException("Size of matrixes must be the same");
            if (addMethod == null) return Add(x, y);
            for (int i = 0; i < x.Size; i++)
                for (int j = 0; j < x.Size; j++)
                    x[i,j] = addMethod(x[i, j], y[i, j]);
            return (SquareMatrix<T>)x;
        }
    }
}
