using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindSequenceOfSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that finds in given array of
            // integers a sequence of given sum S (if present).
            // Example:	{4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}

            int[] arr = { 4, 3, 1, 4, 2, 5, 8 };
            int sum = 11;
            int currentSum = 0;
            int startIndex = 0;
            int endIndex = 0;
            bool found = false;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    currentSum += arr[j];
                    if (currentSum == sum)
                    {
                        endIndex = j;
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    startIndex = i;
                    break;
                }
                else
                {
                    currentSum = 0;
                }
            }

            Console.Write("{ ");
            for (int i = startIndex; i < endIndex; i++)
            {
                Console.Write("{0}, ", arr[i]);
            }
            Console.Write("{0} ", arr[endIndex]);
            Console.WriteLine("}");
        }
    }
}
