using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 4: Write a method that counts how many times
            // given number appears in given array. Write a test
            // program to check if the method is working correctly.

            int[] numbers = { 1, 1, 3, 3, 3, 3, 4, 5, 4, 4, 3, 3, 1, 1, 9, 0 };

            Console.Write("number = ");
            int num = int.Parse(Console.ReadLine());

            int count = CountOccurences(num, numbers);
            Console.WriteLine("The number {0} appears {1} times in the array.", num, count);
        }

        static int CountOccurences(int num, int[] numbers)
        {
            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == num)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
