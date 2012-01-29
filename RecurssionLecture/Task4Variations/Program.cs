using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4Variations
{
    class Program
    {
        static int n;
        static int k;
        static int[] elements;

        static void Main(string[] args)
        {
            // Task 4: Write a recursive program for generating and printing 
            // all ordered k-element subsets from n-element set (variations Vkn).
	        // Example: n=3, k=2
	        // (1 1), (1 2), (1 3), (2 1), (2 2), (2 3), (3 1), (3 2), (3 3)

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            k = int.Parse(Console.ReadLine());
            elements = new int[k];

            GenerateCombinations(0);
        }

        static void GenerateCombinations(int startIndex)
        {
            if (startIndex == k)
            {
                Print(elements);
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                elements[startIndex] = i;
                GenerateCombinations(startIndex + 1);
            }
        }

        static void Print(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write("{0} ", elements[i]);
            }
            Console.WriteLine();
        }
    }
}
