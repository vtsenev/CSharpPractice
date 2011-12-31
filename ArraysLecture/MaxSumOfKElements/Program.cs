using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxSumOfKElements
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that reads two integer numbers N and K
            // and an array of N elements from the console. Find in the
            // array those K elements that have maximal sum.

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];
            Console.WriteLine("Enter n integers:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);

            int[] result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = numbers[n - k + i];
            }

            Console.Write("The {0} elements having the greatest sum (equal to {1}) are: ", k, result.Sum());
            for (int i = 0; i < k; i++)
            {
                Console.Write("{0} ", result[i]);
            }
            Console.WriteLine();
        }
    }
}
