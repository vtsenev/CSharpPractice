using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3PrintDay
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 3: Write a program that prints to the console
            // which day of the week is today. Use System.DateTime.

            System.DateTime currentDateTime = DateTime.Now;
            System.DayOfWeek day = currentDateTime.DayOfWeek;
            Console.WriteLine(day);
        }
    }
}
