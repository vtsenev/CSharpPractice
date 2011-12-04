using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that calculates N!/K! for given N and K (1<N<K).

            Console.Write("Enter N(1<N): ");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            Console.Write("Enter K(1<N<K): ");
            input = Console.ReadLine();
            int k = int.Parse(input);

            if (n <= 1 || n > k)
            {
                Console.WriteLine("Invalid values for N and/or K. Should be 1<N<K...");
                return;
            }

            int result = 1;
            for (int i = n + 1; i <= k; i++)
            {
                result *= i;
            }

            Console.WriteLine("N!/K! = {0}", result);
        }
    }
}
