using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSquareMatrix
{
    public sealed class SymmetricMatrix<T> : AbstractSquareMatrix<T>
    {
        public SymmetricMatrix(int size) : base(size) {}
        public SymmetricMatrix(T[,] elements) : base(elements.GetLength(0))
        {

            if (!elements.IsSquare() | !elements.IsSymmetric())
                throw new ArgumentException("Entered matrix is not symmetric");
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    matrix[i, j] = elements[i,j];
        }
        protected override void SetValue(int i, int j, T value)
        {
            matrix[i, j] = value;
            matrix[j, i] = value;
        }
    }
}
