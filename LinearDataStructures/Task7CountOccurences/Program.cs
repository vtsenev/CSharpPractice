using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task7CountOccurences
{
    class Program
    {
        // Task 7: Write a program that finds in given array of integers (all belonging
        // to the range [0..1000]) how many times each of them occurs.
        // Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
        //    2 -> 2 times
        //    3 -> 4 times
        //    4 -> 3 times

        static List<int> sequence = new List<int>();

        static void Main(string[] args)
        {
            Input();

            var g = sequence.GroupBy(num => num);
            foreach (var grp in g)
            {
                Console.WriteLine("{0} -> {1} times", grp.Key, grp.Count());
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
