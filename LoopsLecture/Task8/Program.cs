using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that calculates the greatest common divisor (GCD)
            // of given two numbers. Use the Euclidean algorithm (find it in Internet).

            Console.Write("Enter a: ");
            string input = Console.ReadLine();
            int a = int.Parse(input);

            Console.Write("Enter b: ");
            input = Console.ReadLine();
            int b = int.Parse(input);

            int predecessor = a;
            int latestRemainder = b;

            while (latestRemainder != 0)
            {
                int temp = latestRemainder;
                latestRemainder = predecessor % latestRemainder;
                predecessor = temp;
            }

            Console.WriteLine("GCD({0}, {1}) = {2}", a, b, predecessor);
        }
    }
}
