﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            int power;
            do
            {
                do
                {
                    Console.WriteLine("Enter number");
                }
                while (!int.TryParse(Console.ReadLine(), out number));

                do
                {
                    Console.WriteLine("Enter power");
                }
                while (!int.TryParse(Console.ReadLine(), out power));

                Console.WriteLine("Answer: \n");
                Console.WriteLine("{0}", NRoot.Solve(number, power, 0.000000000001));
                Console.WriteLine("----------");
                Console.WriteLine("{0}", Math.Pow(number, 1.0 / power));
                Console.WriteLine("\n\ntype \"q\" to quit");
                Console.WriteLine("type anything to continue");
            }
            while (Console.ReadLine() != "q");      

            
        }
    }
}
