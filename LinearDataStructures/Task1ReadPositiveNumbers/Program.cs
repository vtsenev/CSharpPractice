using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1ReadPositiveNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Write a program that reads from the console a sequence 
            // positive integer numbers. The sequence ends when empty line is
            // entered. Calculate and print the sum and average of the elements
            // of the sequence. Keep the sequence in List<int>.


            string input = Console.ReadLine();
            List<uint> sequence = new List<uint>();
            while (input != string.Empty)
            {
                uint number = 0;
                if (uint.TryParse(input, out number))
                    sequence.Add(number);
                input = Console.ReadLine();
            }

            decimal sum = sequence.Sum(num => num);
            double average = sequence.Average(num => num);
            Console.WriteLine("Sum of numbers in the sequence: {0}", sum);
            Console.WriteLine("Average of numbers in the sequence: {0}", average);
        }
    }
}
