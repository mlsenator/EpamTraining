using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSquareMatrix
{
    public abstract class AbstractSquareMatrix<T> : IEquatable<AbstractSquareMatrix<T>>
    {
        public event EventHandler<MatrixEventArgs<T>> ElementChanged;
        protected T[] matrix;
        public int Size { get; protected set; }
        public AbstractSquareMatrix(int size)
        {
            ElementChanged += ElementChangedReaction;
            Size = size;
        }
        public virtual T this[int i, int j]
        {
            get
            {
                if (i < Size && j < Size)
                {
                    return GetElement(i,j);
                }
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (i < Size && j < Size)
                {
                    SetElement(i, j, value);
                    OnMatrixElementChanged(new MatrixEventArgs<T>(i, j, value));
                }
                else
                    throw new IndexOutOfRangeException();
            }
        }
        protected abstract void SetElement(int i, int j, T value);
        protected abstract T GetElement(int i, int j);

        protected virtual void OnMatrixElementChanged(MatrixEventArgs<T> e)
        {
            ElementChanged.Raise(e, this);
        }
        protected virtual void ElementChangedReaction(object sender, MatrixEventArgs<T> e)
        {
            Console.WriteLine("Matrix element [{0}, {1}] was set as {2}", e.Row, e.Column, e.Value);
        }

        public bool Equals(AbstractSquareMatrix<T> other)
        {
            if (other == null)
                return false;
            if (this.Size != other.Size)
                return false;
            for (int i = 0; i < this.Size; i++)
                for (int j = 0; j < this.Size; j++)
                    if (!this[i, j].Equals(other[i, j]))
                        return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            AbstractSquareMatrix<T> matrixObj = obj as AbstractSquareMatrix<T>;
            if (matrixObj == null)
                return false;
            else
                return Equals(matrixObj);   
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
