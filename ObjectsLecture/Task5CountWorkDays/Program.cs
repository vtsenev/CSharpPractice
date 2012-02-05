using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5CountWorkDays
{
    class Program
    {
        static DateTime[] holidays;

        static void Main(string[] args)
        {
            // Task 5: Write a method that calculates the number
            // of workdays between today and given date, passed 
            // as parameter. Consider that workdays are all days
            // from Monday to Friday except a fixed list of public
            // holidays specified preliminary as array.

            holidays = new DateTime[2];
            DateTime testHoliday = new DateTime(2012, 1, 25);
            holidays[0] = testHoliday;
            testHoliday = new DateTime(2012, 1, 26);
            holidays[1] = testHoliday;

            DateTime current = DateTime.Now;

            Console.Write("Enter year = ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter month = ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter day = ");
            int day = int.Parse(Console.ReadLine());

            DateTime endDate = new DateTime(year, month, day);

            int workDays = 0;
            while (current.Year != endDate.Year || current.Month != endDate.Month || current.Day != endDate.Day)
            {
                current = current.AddDays(1);
                if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday && !IsHoliday(current))
                {
                    workDays++;
                }
            }

            Console.WriteLine(workDays);
        }

        static bool IsHoliday(DateTime current)
        {
            bool result = false;
            foreach (DateTime day in holidays)
            {
                if (day.Day == current.Day && day.Month == current.Month && day.Year == current.Year)
                {
                    return true;
                }
            }
            return result;
        }
    }
}
