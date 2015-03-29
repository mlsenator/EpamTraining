using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSquareMatrix
{
    public sealed class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        public SquareMatrix(int size) : base(size) {}
        public SquareMatrix(T[,] elements) : base(elements.GetLength(0))
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    matrix[i, j] = elements[i,j];
        }
        protected override void SetValue(int i, int j, T value)
        {
            matrix[i, j] = value;
        }
    }
}
