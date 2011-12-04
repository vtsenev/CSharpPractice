using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that reads from the console a sequence
            // of N integer numbers and returns the minimal and maximal of them.

            Console.Write("Enter n: ");
            string input = Console.ReadLine();
            int n = int.Parse(input);
            int[] sequence = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter sequence[{0}]: ", i);
                input = Console.ReadLine();
                sequence[i] = int.Parse(input);
            }

            for (int iPos = 0; iPos < n; iPos++)
            {
                for (int jPos = iPos + 1; jPos < n; jPos++)
                {
                    if (sequence[jPos] < sequence[iPos])
                    {
                        int temp = sequence[jPos];
                        sequence[jPos] = sequence[iPos];
                        sequence[iPos] = temp;
                    }
                }
            }

            Console.WriteLine("Min = {0}", sequence[0]);
            Console.WriteLine("Max = {0}", sequence[n-1]);
        }
    }
}
