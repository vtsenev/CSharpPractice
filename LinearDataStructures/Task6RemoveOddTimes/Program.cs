using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task6RemoveOddTimes
{
    class Program
    {
        static List<int> sequence = new List<int>();

        static void Main(string[] args)
        {
            // Task 6: Write a program that removes from given sequence all numbers that occur odd number of times.
            // Example: {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}

            Input();
            
            var g = sequence.GroupBy(num => num);
            foreach (var grp in g)
            {
                if (grp.Count() % 2 != 0)
                {
                    sequence.RemoveAll(num => num == grp.Key);
                }
            }

            foreach (int num in sequence)
            {
                Console.WriteLine(num);
            }
        }

        static void Input()
        {
            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int number = 0;
                if (int.TryParse(input, out number))
                    sequence.Add(number);

                input = Console.ReadLine();
            }
        }
    }
}
