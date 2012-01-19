using System;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 5: Write a method that checks if the element at given position in
            // given array of integers is bigger than its two neighbors (when such exist).

            int[] numbers = { 1, 1, 3, 3, 3, 3, 4, 5, 4, 4, 3, 3, 1, 1, 9, 10 };

            Console.Write("Enter element index: ");
            int position = int.Parse(Console.ReadLine());

            bool isBigger = CheckElementNeighbours(numbers, position);
            Console.WriteLine(isBigger);
        }

        static bool CheckElementNeighbours(int[] numbers, int pos)
        {
            if (pos + 1 < numbers.Length && pos - 1 >= 0)
            {
                if (numbers[pos] > numbers[pos - 1] && numbers[pos] > numbers[pos + 1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (pos + 1 >= numbers.Length && pos - 1 >= 0)
            {
                if (numbers[pos] > numbers[pos - 1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (pos + 1 < numbers.Length && pos - 1 < 0)
            {
                if (numbers[pos] > numbers[pos + 1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // element is only element in array
                return true;
            }
        }
    }
}
