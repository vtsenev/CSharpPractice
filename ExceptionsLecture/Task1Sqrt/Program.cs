using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1Sqrt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Write a program that reads an integer number
            // and calculates and prints its square root. If the 
            // number is invalid or negative, print "Invalid number".
            // In all cases finally print "Good bye". Use try-catch-finally.

            Console.Write("Enter integer: ");
            string input = Console.ReadLine();
            int number = 0;

            try
            {
                number = int.Parse(input);
                double sqrt = CalcSqrt(number);
                Console.WriteLine("the square root of {0} is: {1:0.00}", number, sqrt);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        static double CalcSqrt(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Sqrt is not defined for negative numbers.");
            }
            return Math.Sqrt(number);
        }
    }
}
