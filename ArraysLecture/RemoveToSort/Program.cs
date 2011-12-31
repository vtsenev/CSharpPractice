using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoveToSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // * Write a program that reads an array of integers
            // and removes from it a minimal number of elements
            // in such way that the remaining array is sorted in
            // increasing order. Print the remaining sorted array.
            // Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}

            // int[] arr = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
            int[] arr = { 0, 4, 9, 27, 1, 2, 3, 4, 5 };

            int[] result = LongestIncSubsequence(arr);
            
            Console.Write("{");
            foreach (int num in result)
            {
                Console.Write(" {0}", num);
            }
            Console.WriteLine(" }");

        }

        static int[] LongestIncSubsequence(int[] array)
        {
            int[] increasingLengths = new int[array.Length];
            increasingLengths[0] = 1;
            for (int i = 1; i < increasingLengths.Length; i++)
            {
                int maxLength = 0;
                for (int j = 0; j < i; j++)
                {
                    if (array[j] <= array[i] && increasingLengths[j] > maxLength)
                    {
                        maxLength = increasingLengths[j];
                    }
                }
                increasingLengths[i] = maxLength + 1;
            }
            
            int[] sortedSubset = new int[increasingLengths.Max()];
            int serialNumber = increasingLengths.Max();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (serialNumber == increasingLengths[i])
                {
                    sortedSubset[serialNumber - 1] = array[i];
                    serialNumber--;
                }
            }

            return sortedSubset;
        }
    }
}
