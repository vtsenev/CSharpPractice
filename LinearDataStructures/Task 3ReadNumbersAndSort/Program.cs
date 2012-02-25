using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_3ReadNumbersAndSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 3: Write a program that reads a sequence of integers (List<int>)
            // ending with an empty line and sorts them in an increasing order.

            string input = Console.ReadLine();
            List<int> sequence = new List<int>();
            while (input != string.Empty)
            {
                int number = 0;
                if (int.TryParse(input, out number))
                    sequence.Add(number);
                input = Console.ReadLine();
            }

            sequence.Sort();
            foreach (int num in sequence)
            {
                Console.WriteLine(num);
            }
        }
    }
}
