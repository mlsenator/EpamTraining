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
        public static void ConsolePrint<T>(this AbstractSquareMatrix<T> matrix)
        {
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                    Console.Write("{0}  ", matrix[i, j]);
                Console.WriteLine("\n");
            }
        }


        public static AbstractSquareMatrix<T> Sum<T, U>(this AbstractSquareMatrix<T> first, AbstractSquareMatrix<U> second)
        {
            if (first == null || second == null) throw new ArgumentNullException("Added matrix is null");
            if (first.Size != second.Size) throw new ArgumentException("Size of matrixes must be the same");
            dynamic firstMatrix = first;
            dynamic secondMatrix = second;
            return SumMatrix(firstMatrix, secondMatrix);
        }

        private static DiagonalMatrix<T> SumMatrix<T, U>(DiagonalMatrix<T> first, DiagonalMatrix<U> second)
        {
            DiagonalMatrix<T> sum = new DiagonalMatrix<T>(first.Size);
            for (int i = 0; i < first.Size; i++)
                sum[i, i] = TrySum(first[i, i], second[i, i]);
            return sum;
        }
        private static SymmetricMatrix<T> SumMatrix<T, U>(SymmetricMatrix<T> first, SymmetricMatrix<U> second)
        {
            SymmetricMatrix<T> sum = new SymmetricMatrix<T>(first.Size);
            for (int i = 0; i < first.Size; i++)
                for (int j = 0; j <= i; j++)
                    sum[i, j] = TrySum(first[i, j], second[i, j]);
            return sum;
        }
        private static SymmetricMatrix<T> SumMatrix<T, U>(SymmetricMatrix<T> first, DiagonalMatrix<U> second)
        {
            SymmetricMatrix<T> sum = new SymmetricMatrix<T>(first.Size);
            for (int i = 0; i < first.Size; i++)
                sum[i, i] = TrySum(first[i, i], second[i, i]);
            return sum;
        }
        private static SymmetricMatrix<T> SumMatrix<T, U>(DiagonalMatrix<T> first, SymmetricMatrix<U> second)
        {
            //can't use previous method, cause i need to have T type of result matrix
            SymmetricMatrix<T> sum = new SymmetricMatrix<T>(first.Size);
            for (int i = 0; i < first.Size; i++)
                sum[i, i] = TrySum(first[i, i], second[i, i]);
            return sum;
        }
        private static SquareMatrix<T> SumMatrix<T, U>(AbstractSquareMatrix<T> first, AbstractSquareMatrix<U> second)
        {
            SquareMatrix<T> sum = new SquareMatrix<T>(first.Size);
            for (int i = 0; i < first.Size; i++)
                for (int j = 0; j <first.Size; j++)
                    sum[i, j] = TrySum(first[i, j], second[i, j]);
            return sum;
        }
        private static T TrySum<T,U> (T first, U second)
        {
            T sum = default(T);
            dynamic a = first;
            dynamic b = second;
            try
            {
                sum = a + b;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Can't add different types", e);
            }
            return sum;
        }

    }
}
