using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateVariations
{
    class Program
    {

        static int k, n;
        static int[] combo;

        static void Main(string[] args)
        {
            // Write a program that reads two numbers N and K 
            // and generates all the variations of K elements
            // from the set [1..N]. Example:
	        // N = 3, K = 2 -> {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            k = int.Parse(Console.ReadLine());

            combo = new int[k];

            GenerateCombo(0);            
        }

        static void GenerateCombo(int startIndex)
        {
            if (startIndex >= k)
            {
                Print(combo);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                combo[startIndex] = i + 1;
                GenerateCombo(startIndex + 1);
            }
        }

        static void Print(int[] arr)
        {
            Console.Write("{");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" {0}", arr[i]);
            }
            Console.WriteLine(" }");
        }

    }
}
