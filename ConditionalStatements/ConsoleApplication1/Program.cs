using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that shows the sign of the product
            // of three real numbers without calculating it. Use a sequence of if statements.

            double realNum1, realNum2, realNum3;
            Console.WriteLine("Enter 3 real numbers: ");
            string input = Console.ReadLine();
            realNum1 = double.Parse(input);
            input = Console.ReadLine();
            realNum2 = double.Parse(input);
            input = Console.ReadLine();
            realNum3 = double.Parse(input);

            string positive = "Sign is positive.";
            string negative = "Sign is negative.";

            if (realNum1 > 0 && realNum2 > 0 && realNum3 > 0)
            {
                Console.WriteLine(positive);
            }
            if (realNum1 < 0 && realNum2 < 0 && realNum3 > 0)
            {
                Console.WriteLine(positive);
            }
            if (realNum1 > 0 && realNum2 < 0 && realNum3 < 0)
            {
                Console.WriteLine(positive);
            }
            if (realNum1 < 0 && realNum2 > 0 && realNum3 < 0)
            {
                Console.WriteLine(positive);
            }
            if (realNum1 < 0 && realNum2 < 0 && realNum3 < 0)
            {
                Console.WriteLine(negative);
            }
            if (realNum1 > 0 && realNum2 < 0 && realNum3 > 0)
            {
                Console.WriteLine(negative);
            }
            if (realNum1 > 0 && realNum2 > 0 && realNum3 < 0)
            {
                Console.WriteLine(negative);
            }
            if (realNum1 < 0 && realNum2 > 0 && realNum3 > 0)
            {
                Console.WriteLine(negative);
            }
        }
    }
}