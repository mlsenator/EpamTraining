using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSquareMatrix
{
    public sealed class DiagonalMatrix<T> : AbstractSquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size) 
        {
            matrix = new T[size];
        }
        public DiagonalMatrix(T[] elements) : base (elements.Length)
        {
            matrix = new T[elements.Length];
            for (int i = 0; i < elements.Length; i++)
                matrix[i] = elements[i];
        }
        protected override void SetElement(int i, int j, T value)
        {
            if (i != j)
            {
                throw new ArgumentException("In diagonal matrix i must equals j");
            }
            else
            {
                matrix[i] = value;
            }
        } 

        protected override T GetElement(int i, int j)
        {
            if (i == j) return matrix[i];
            else return default(T);
        }
        //as example
        protected override void ElementChangedReaction(object sender, MatrixEventArgs<T> e)
        {
            Console.WriteLine("Diagonal matrix element [{0}, {1}] was set as {2}", e.Row, e.Column, e.Value);
        }
        protected override void OnMatrixElementChanged(MatrixEventArgs<T> e)
        {
            Console.WriteLine("New event reaction!!!");
            base.OnMatrixElementChanged(e);
        }
    }
}
