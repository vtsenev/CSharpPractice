using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 13: Write a program that can solve these tasks:
            //      Reverses the digits of a number
            //      Calculates the average of a sequence of integers
            //      Solves a linear equation a * x + b = 0
            // Create appropriate methods.
		    // Provide a simple text-based menu for the user to choose which task to solve.
		    // Validate the input data:
            //      The decimal number should be non-negative
            //      The sequence should not be empty
            //      a should not be equal to 0

            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Press:");
            Console.WriteLine("1 - to reverse the digits of a number.");
            Console.WriteLine("2 - to calculate the average of a sequence of integers.");
            Console.WriteLine("3 - to solve a linear equation.");
            Console.WriteLine("4 - to exit.");

            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1: ReverseDigits(); break;
                case ConsoleKey.D2: CalculateAverageOfSequence(); break;
                case ConsoleKey.D3: SolveEquation(); break;
                case ConsoleKey.D4: Console.WriteLine(); Console.WriteLine("Have a nice day!"); return;
                default: Console.WriteLine("Wrong option."); break;
            }
        }

        static void ReverseDigits()
        {
            Console.WriteLine();
            Console.Write("number = ");
            decimal num = decimal.Parse(Console.ReadLine());

            if (num < 0)
            {
                throw new Exception("Number < 0 is not allowed.");
            }

            string numAsStr = num.ToString();
            char[] numAsArray = numAsStr.ToCharArray();
            Array.Reverse(numAsArray);
            numAsStr = new string(numAsArray);

            Console.WriteLine("{0} reversed = {1}", num, numAsStr);
        }

        static void CalculateAverageOfSequence()
        {
            Console.WriteLine();
            Console.Write("sequence length = ");
            int length = int.Parse(Console.ReadLine());

            if (length < 1)
            {
                throw new Exception("Sequence should not be empty.");
            }

            int[] sequence = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("sequence[{0}] = ", i);
                sequence[i] = int.Parse(Console.ReadLine());
            }

            int sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += sequence[i];
            }
            double average = (double)sum / (double)length;
            Console.WriteLine("The average of the sequence is: {0}.", average);
        }

        static void SolveEquation()
        {
            Console.WriteLine();
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            
            if (a == 0)
            {
                throw new Exception("a = 0 is not allowed. Division by zero.");
            }
            
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());

            double x = (-b) / a;
            Console.WriteLine("x = {0:0.00}", x);
        }
    }
}
