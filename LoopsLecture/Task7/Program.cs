using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that reads a number N and calculates the sum 
            //of the first N members of the sequence of Fibonacci: 
            // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

            Console.Write("Enter N: ");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            ulong[] fibSequence = new ulong[n];
            fibSequence[0] = 0;
            fibSequence[1] = 1;

            ulong sum = 1;

            for (int i = 2; i <= n-1; i++)
            {
                fibSequence[i] = fibSequence[i - 1] + fibSequence[i - 2];
                sum += fibSequence[i];
            }

            Console.WriteLine("Sum({0}) = {1}", n, sum);
        }
    }
}
