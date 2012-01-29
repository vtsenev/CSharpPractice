using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3Permutations
{
    class Program
    {
        static int n;
        static int[] permutation;

        static void Main(string[] args)
        {
            // Task 3: Write a recursive program for generating and printing
            // all permutations of the numbers 1, 2, ..., n for given integer
            // number n. Example:
            // n=3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            permutation = new int[n];

            GeneratePermutations(0);
        }

        private static void GeneratePermutations(int currentIndex)
        {
            if (currentIndex == n)
            {
                Print(permutation);
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                if (currentIndex > 0)
                {
                    int[] tmpArray = new int[currentIndex];
                    Array.Copy(permutation, tmpArray, currentIndex);
                    if (tmpArray.Contains(i))
                    {
                        continue;
                    }
                }
                permutation[currentIndex] = i;
                GeneratePermutations(currentIndex + 1);
            }
        }

        static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
    }
}
