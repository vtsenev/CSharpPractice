using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5SubsetOfStrings
{
    class Program
    {
        static string[] setOfStrings;

        static void Main(string[] args)
        {
            // Task 5: Write a program for generating and printing 
            // all subsets of k strings from given set of strings.
	        // Example: s = {test, rock, fun}, k=2
	        // (test rock),  (test fun),  (rock fun)

            Console.Write("set length = ");
            int length = int.Parse(Console.ReadLine());
            setOfStrings = new string[length];

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("string[{0}]:", i);
                setOfStrings[i] = Console.ReadLine();
            }

            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            int[] array = new int[k];
            FindCombinations(array, 0, 0, length);
        }

        static void FindCombinations(int[] vector, int index, int start, int end)
        {
            if (index >= vector.Length)
            {
                Print(vector);
            }
            else
            {
                for (int i = start; i < end; i++)
                {
                    vector[index] = i;
                    FindCombinations(vector, index + 1, i + 1, end);
                }
            }
        }

        static void Print(int[] vector)
        {
            Console.Write("(");
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write("{0}", setOfStrings[vector[i]]);
                if (i != vector.Length - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(")");
            Console.WriteLine();
        }
    }
}
