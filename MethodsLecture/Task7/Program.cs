using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 7: Write a method that reverses the digits of given decimal number.
            // Example: 256 -> 652

            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            int reversedNum = ReverseDigits(number);
            Console.WriteLine(reversedNum);
        }

        static int ReverseDigits(int number)
        {
            int numLength = CountDigits(number);
            int result = 0;

            for (int digit = numLength - 1; digit > 0; digit--)
            {
                result += (number % 10) * (int)Math.Pow(10, digit);
                number /= 10;
            }

            return result + number;
        }

        static int CountDigits(int number)
        {
            int result = 1;
            while (number / 10 != 0)
            {
                number /= 10;
                result++;
            }
            return result;
        }
    }
}
