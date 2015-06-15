using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSquareMatrix
{
    public sealed class MatrixEventArgs<T> : EventArgs
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public T Value { get; private set; }
        public MatrixEventArgs(int row, int column, T value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

    }

    public static class EventHelper
    {
        public static void Raise<T>(this EventHandler<MatrixEventArgs<T>> handler, MatrixEventArgs<T> args, object sender = null)
        {
            var local = handler;
            if (local != null)
            {
                local(sender, args);
            }
        }
    }
}
