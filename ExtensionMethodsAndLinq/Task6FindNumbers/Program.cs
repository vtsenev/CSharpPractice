using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task6FindNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 6: Write a program that prints from given array of integers
            // all numbers that are divisible by 7 and 3. Use the built-in
            // extension methods and lambda expressions. Rewrite the same with LINQ.

            int[] numbers = { 14, 13, 321, 21, 5, 7, 9, 28, 63};

            int[] goodNumbers = numbers.DivisibleBySevenAndThree();
            foreach (int num in goodNumbers)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine();
            Console.WriteLine();
            goodNumbers = numbers.FindBestNumbers();
            foreach (int num in goodNumbers)
            {
                Console.WriteLine(num);
            }
        }
    }

    static class Extension
    {
        // LAMBDA
        public static int[] DivisibleBySevenAndThree(this int[] numbers)
        {
            List<int> numbersList = numbers.ToList();
            return numbersList.FindAll(num => (num % 7) == 0 && (num % 3) == 0).ToArray();
        }

        // LINQ
        public static int[] FindBestNumbers(this int[] numbers)
        {
            var goodNums =
                from num in numbers
                where num % 7 == 0 && num % 3 == 0
                select num;
            return goodNums.ToArray();
        }
    }
}
