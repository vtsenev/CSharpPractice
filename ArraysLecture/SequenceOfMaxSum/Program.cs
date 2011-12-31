using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SequenceOfMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that finds the sequence of maximal sum in given array.
            // Example: {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
	        // Can you do it with only one loop (with single scan through the elements of the array)?

            int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
            int currentSum = 0;
            int beststum = int.MinValue;
            int startSequence = 0;
            int endSequence = 0;

            for (int index = 0; index < arr.Length; index++)
            {
                currentSum += arr[index];
                if (currentSum > beststum)
                {
                    endSequence = index;
                    beststum = currentSum;
                }
                else if (currentSum <= 0)
                {
                    currentSum = 0;
                    startSequence = index + 1;
                }
            }

            Console.Write("{");
            for (int i = startSequence; i < endSequence; i++)
            {
                Console.Write("{0}, ", arr[i]);
            }
            Console.Write("{0}", arr[endSequence]);
            Console.WriteLine("}");
        }
    }
}
