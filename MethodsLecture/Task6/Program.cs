using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 6: Write a method that returns the index 
            // of the first element in array that is bigger 
            // than its neighbors, or -1, if there’s no such element.
            // Use the method from the previous exercise.

            int[] numbers = { 1, 1, 3, 3, 3, 3, 4, 5, 4, 4, 3, 3, 1, 1, 9, 10 };

            int index = GetIndex(numbers);

            Console.WriteLine("Index of first element that is bigger than its neighbours: {0}.", index);
        }

        private static int GetIndex(int[] numbers)
        {
            int suitableIndex = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (CheckElementNeighbours(numbers, i))
                {
                    return i;
                }
            }

            return suitableIndex;
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
