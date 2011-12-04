using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program to calculate the Nth Catalan number by given N.

            Console.Write("Enter N: ");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            ulong numerator = Factorial(2 * n);
            ulong denominator = Factorial(n + 1) * Factorial(n);

            ulong result = numerator / denominator;

            Console.WriteLine("Catalan number [{0}] = {1}", n, result);
        }

        static ulong Factorial(int n)
        {
            ulong result = 1;

            if (n < 1)
            {
                Console.WriteLine("Invalid value for variable n.");
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            for (int i = 2; i <= n; i++)
            {
                result *= (ulong)i;
            }

            return result;
        }
    }
}
