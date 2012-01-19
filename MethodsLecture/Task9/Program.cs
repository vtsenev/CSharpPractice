using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 9: Write a method that returns the maximal element
            // in a portion of array of integers starting at given
            // index. Using it write another method that sorts an
            // array in ascending / descending order.

            int[] numbers = { 123, 1, 12, 3, 3, 3, 3, 24, 5, 42, 4, 311, 3, 1, 11, 9, 100, 2 };

            Console.Write("starting index = ");
            int index = int.Parse(Console.ReadLine());

            int indexOfMax;
            int maxElement = GetMaxInArrayFrom(numbers, index, out indexOfMax);

            Console.WriteLine("maximal element = {0}", maxElement);

            int[] sortedNumsAscending = SortArray(numbers);

            PrintArray(sortedNumsAscending);

            int[] sortedNumsDescending = SortArray(numbers, "desc");

            PrintArray(sortedNumsDescending);
        }

        static int GetMaxInArrayFrom(int[] numbers, int index, out int indexOfMax)
        {
            int max = numbers[index];
            indexOfMax = index;

            for (int i = index; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                    indexOfMax = i;
                }
            }

            return max;
        }

        // the options parameter is optianal and by default the method will sort the array in ascending order
        // if options is given a value of "desc" it will sort it in descending order
        static int[] SortArray(int[] numbers, string options = "asc")
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int indexOfMax;
                int currentMax = GetMaxInArrayFrom(numbers, i, out indexOfMax);

                if (options != "desc")
                {
                    numbers = MoveMaxAndShift(numbers, indexOfMax);
                }
                else
                {
                    numbers = MoveMaxAndShift(numbers, indexOfMax, i);
                }
            }

            return numbers;
        }

        // if shift is 0 moves the max element to position 0 and shifts the others accordingly
        // if shift is anything else the max element is moved to a more precise position
        private static int[] MoveMaxAndShift(int[] numbers, int indexOfMax, int shift = 0)
        {
            int[] result = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (shift == 0)
                {
                    if (i == 0)
                    {
                        result[i] = numbers[indexOfMax];
                        continue;
                    }
                    if (i < indexOfMax + 1)
                    {
                        result[i] = numbers[i - 1];
                    }
                    else
                    {
                        result[i] = numbers[i];
                    }
                }
                else
                {
                    if (i == shift)
                    {
                        result[i] = numbers[indexOfMax];
                        continue;
                    }
                    if (i < shift)
                    {
                        result[i] = numbers[i];
                    }
                    else if (i > shift && i < indexOfMax + 1)
                    {
                        result[i] = numbers[i - 1];
                    }
                    else
                    {
                        result[i] = numbers[i];
                    }
                }
            }

            return result;
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" {0} ", arr[i]);
            }
            Console.WriteLine();
        }
    }
}
