using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that prints all the numbers from 1 to N.

            Console.Write("Enter n: ");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
