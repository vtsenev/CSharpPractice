using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaxIncSeq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that finds the maximal increasing sequence in an array.
            // Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

            Console.Write("Enter array length: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int currentLength = 1;
            int maxLength = 1;
            int startIndex = 0;

            for (int i = 1; i < n; i++)
            {
                if (numbers[i - 1] < numbers[i])
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
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        startIndex = i - maxLength;
                    }
                    currentLength = 1;
                }
            }

            int[] result = new int[maxLength];
            Console.WriteLine("Longest increasing sequence:");
            for (int i = 0; i < maxLength; i++)
            {
                result[i] = numbers[startIndex + i];
                Console.Write("{0} ", result[i]);
            }
        }
    }
}
