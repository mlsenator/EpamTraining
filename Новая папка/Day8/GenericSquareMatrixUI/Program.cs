using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericSquareMatrix;

namespace GenericSquareMatrixUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n****** Empty square matrix *******\n");
            var square = new SquareMatrix<int>(5);
            square[4, 3] = 100;
            square.ConsolePrint();

            Console.WriteLine("\n******  Array initialized square matrix *******\n");
            var square2 = new SquareMatrix<double>(new double[,] { { 1.1, 1.2, 1.3 }, { 1.1, 1.2, 1.3 }, { 1.1, 1.2, 1.3 } });
            square2.ConsolePrint();

            Console.WriteLine("\n******  Empty symmetric matrix *******\n");
            var symmetric = new SymmetricMatrix<string>(4);
            symmetric[0, 1] = "F";
            symmetric.ConsolePrint();

            Console.WriteLine("\n******  Array initialized symmetric matrix *******\n");
            var symmetric2 = new SymmetricMatrix<int>(new int[,] { { 1, 2, 3 }, { 2, 3, 1 }, { 3, 1, 2 } });
            symmetric2.ConsolePrint();

            Console.WriteLine("\n******  Empty diagonal matrix *******\n");
            var diagonal = new DiagonalMatrix<string>(4);
            diagonal[0, 0] = "F";
            diagonal.ConsolePrint();

            Console.WriteLine("\n******  Array initialized diagonal matrix *******\n");
            var diagonal2 = new DiagonalMatrix<int>(new int[] {1,2,3});
            diagonal2.ConsolePrint();

            Console.WriteLine("\n******  Add method test *******\n");
            square2.Add(symmetric2).ConsolePrint();

            Console.WriteLine("\n******  Add method test2 *******\n");
            var s = new SymmetricMatrix<int>(4);
            s[1, 1] = 5;
            var d = new DiagonalMatrix<double>(4);
            d[1, 1] = 0.5;
            var sum = d.Add(s);
            sum.ConsolePrint();


            Console.ReadLine();
        }
    }
}
