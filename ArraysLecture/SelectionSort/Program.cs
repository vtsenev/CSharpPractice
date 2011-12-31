using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sorting an array means to arrange its elements
            // in increasing order. Write a program to sort an
            // array. Use the "selection sort" algorithm: Find
            // the smallest element, move it at the first
            // position, find the smallest from the rest, move
            // it at the second position, etc.

            Console.Write("number of elements: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("numbers[{0}] = ", i);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            int min;
            for (int i = 0; i < n; i++)
            {
                min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (numbers[j] < numbers[min])
                    {
                        min = j;
                    }
                }
                int temp = numbers[i];
                numbers[i] = numbers[min];
                numbers[min] = temp;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", numbers[i]);
            }
            Console.WriteLine();
        }
    }
}
