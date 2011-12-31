using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermutationsRecursive
{
    class Program
    {
        private static int[] intArray;
        private static int[] used;

        static void Main(string[] args)
        {
            Console.Write("Enter the number N: ");
            int n = int.Parse(Console.ReadLine());
            intArray = new int[n];
            used = new int[n];
            Permute(0);

        }

        private static void Permute(int pStartIndex)
        {
            if (pStartIndex >= intArray.Length)
            {
                Print();
                return;
            }

            for (int i = 0; i < intArray.Length; i++)
            {
                if (used[i] == 0)
                {
                    used[i] = 1;
                    intArray[pStartIndex] = i + 1;
                    Permute(pStartIndex + 1);
                    used[i] = 0;
                }
            }
        }

        private static void Print()
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i]);
            }
            Console.WriteLine();
        }
    }
}
