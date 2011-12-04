using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that, for a given two integer numbers N and X, calculates the sum
            // S = 1 + 1!/X + 2!/X2 + … + N!/XN

            Console.Write("Enter N: ");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            Console.Write("Enter X: ");
            input = Console.ReadLine();
            int x = int.Parse(input);

            double sum = 1;

            for (int i = 1; i <= n; i++)
            {
                double sequenceMember = (double)Factorial(i) / (double)(x * i);
                sum += sequenceMember;
            }

            Console.WriteLine("S = 1 + 1!/X + 2!/X2 + … + N!/XN\n");
            Console.WriteLine("For N = {0} and X = {1}, S = {2:0.00}\n", n, x, sum);
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
