using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task6CalculateSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 6: You are given a sequence of positive integer values
            // written into a string, separated by spaces. Write a function 
            // that reads these values from given string and calculates
            // their sum. Example:
		    // string = "43 68 9 23 318" -> result = 461

            Console.WriteLine("Enter numbers separated by spaces:");
            string numbersStr = Console.ReadLine();

            string[] numbersArray = numbersStr.Split(' ');

            int sum = 0;
            foreach (string numberAsStr in numbersArray)
            {
                int number = int.Parse(numberAsStr);
                sum += number;
            }

            Console.WriteLine("result = {0}", sum);
        }
    }
}
