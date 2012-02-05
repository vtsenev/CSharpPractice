using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1LeapYear
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Write a program that reads a year from the console
            // and checks whether it is a leap. Use DateTime.

            Console.Write("Enter year = ");
            int year = int.Parse(Console.ReadLine());

            bool isLeap = DateTime.IsLeapYear(year);

            Console.WriteLine("{0} year is leap: {1}.", year, isLeap);
        }
    }
}
