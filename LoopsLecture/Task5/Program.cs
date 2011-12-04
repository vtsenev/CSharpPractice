using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

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

            ulong factN = Factorial(n);
            ulong factK = Factorial(k);
            ulong factKSubtrN = Factorial(k - n);

            ulong result = (factN * factK) / factKSubtrN;

            Console.WriteLine("{0}! * {1}! / ({2} - {3})! = {4}", n, k, k, n, result);
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
