using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that prints all the numbers from 1 to N, 
            // that are not divisible by 3 and 7 at the same time.

            Console.Write("Enter n: ");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            for (int i = 1; i <= n; i++)
            {
                if (i % 7 != 0 && i % 3 != 0)
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}
