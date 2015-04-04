using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSquareMatrix
{
    public sealed class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        public SquareMatrix(int size) : base(size) 
        {
            matrix = new T[size * size];
        }
        public SquareMatrix(T[,] elements)  : base(elements.GetLength(0))
        {
            matrix = new T[elements.GetLength(0) * elements.GetLength(0)];
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    matrix[i * Size + j] = elements[i, j];
        }
        protected override T GetElement(int i, int j)
        {
            return matrix[i * Size + j];
        }
        protected override void SetElement(int i, int j, T value)
        {
            matrix[i * Size + j] = value;
        }
    }
}
