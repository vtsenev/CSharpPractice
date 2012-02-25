using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task8FindMajorant
{
    class Program
    {
        static List<int> sequence = new List<int>();

        static void Main(string[] args)
        {
            // Task 8: * The majorant of an array of size N is a value that occurs in it at least
            // N/2 + 1 times. Write a program to find the majorant of given array (if exists).
            // Example: {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3

            Input();
            int N = sequence.Count;
            var g = sequence.GroupBy(num => num);
            foreach (var grp in g)
            {
                if (grp.Count() >= (N / 2 + 1))
                {
                    Console.Write("{ ");
                    foreach (int number in sequence)
                    {
                        Console.Write("{0} ", number);
                    }
                    Console.WriteLine("} -> " + grp.Key);
                    break;
                }
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
