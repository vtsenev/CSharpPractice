using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaximalSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that finds the maximal sequence of equal elements in an array.
		    // Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

            Console.Write("Enter array length = ");
            string input = Console.ReadLine();
            int n = int.Parse(input);
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                arr[i] = int.Parse(input);
            }

            int currentLength = 1;
            int maxLength = 1;
            int startIndex = 0;

            for (int i = 1; i < n; i++)
            {
                if (arr[i - 1] == arr[i])
                {
                    currentLength++;
                    if (i == n - 1 && currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        startIndex = n - maxLength;
                    }
                }
                else
                {
                    if (maxLength < currentLength)
                    {
                        maxLength = currentLength;
                        startIndex = i - maxLength;
                    }
                    currentLength = 1;
                }
            }

            int[] result = new int[maxLength];
            Console.WriteLine("Longest sequence of equal numbers:");
            for (int i = 0; i < maxLength; i++)
            {
                result[i] = arr[startIndex + i];
                if (i == result.Length - 1)
                    Console.WriteLine("{0}", result[i]);
                else
                    Console.Write("{0}, ", result[i]);
            }

        }
    }
}
