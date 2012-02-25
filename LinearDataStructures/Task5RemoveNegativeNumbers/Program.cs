using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5RemoveNegativeNumbers
{
    class Program
    {
        static List<int> sequence = new List<int>();

        static void Main(string[] args)
        {
            // Task 5: Write a program that removes from given sequence all negative numbers.

            Input();
            sequence.RemoveAll(num => num < 0);

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
