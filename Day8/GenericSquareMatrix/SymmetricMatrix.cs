using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSquareMatrix
{
    public sealed class SymmetricMatrix<T> : AbstractSquareMatrix<T>
    {
        public SymmetricMatrix(int size) : base(size) 
        {
            matrix = new T[size * (size + 1) / 2];
        }
        public SymmetricMatrix(T[,] elements) : base(elements.GetLength(0))
        {
            matrix = new T[elements.GetLength(0) * (elements.GetLength(0) + 1) / 2];
            if (!elements.IsSquare() | !elements.IsSymmetric())
                throw new ArgumentException("Entered matrix is not symmetric");
            for (int i = 0; i < Size; i++)
                for (int j = 0; j <= i; j++)
                    SetElement(i, j, elements[i,j]);
        }
        protected override T GetElement(int i, int j)
        {
            if (i < j) Swap(ref i, ref j);
            return matrix[i * (i + 1) / 2 + j];
        }
        protected override void SetElement(int i, int j, T value)
        {
            if (i < j) Swap(ref i, ref j);
            matrix[i * (i + 1) / 2 + j] = value;
        }

        private void Swap (ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
    }
}
