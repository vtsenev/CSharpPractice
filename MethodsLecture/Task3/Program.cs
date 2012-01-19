using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 3: Write a method that returns the last digit 
            // of given integer as an English word.
            // Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".

            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            string lastDigit = GetDigit(number);

            Console.WriteLine(lastDigit);
        }

        static string GetDigit(int num)
        {
            int digit = num % 10;
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "Error.";
            }
        }


    }
}
