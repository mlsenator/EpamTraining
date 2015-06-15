using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollectionExtension;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] collection1 = {0,1,2,3,4,5,6,7,8,9};
            string[] collection2 = { "Zero", "One", "Two", "Three", "Four", "Five" };

            foreach (var item in collection1.CustomEnumerator(null, null))
                Console.Write(item + "  ");
            Console.WriteLine("\n");

            foreach (var item in collection1.CustomEnumerator(null, x => (x % 2 == 0)))
                Console.Write(item + "  ");
            Console.WriteLine("\n");

            foreach (var item in collection1.CustomEnumerator(x => x > 5, null))
                Console.Write(item + "  ");
            Console.WriteLine("\n");

            foreach (var item in collection2)
                Console.Write(item + "  ");
            Console.WriteLine("\n");

            foreach (var item in collection2.CustomEnumerator(x => x[0] == 'F', null))
                Console.Write(item + "  ");
            Console.WriteLine("\n");

            foreach (var item in collection2.CustomEnumerator(x => x.Length > 3, null))
                Console.Write(item + "  ");
            Console.WriteLine("\n");

            Console.ReadLine();
        }
    }
}
