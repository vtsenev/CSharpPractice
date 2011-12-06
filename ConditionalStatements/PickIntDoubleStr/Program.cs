using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PickIntDoubleStr
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that, depending on the user's choice inputs int, 
            // double or string variable. If the variable is integer or double, 
            // increases it with 1. If the variable is string, appends "*" at 
            // its end. The program must show the value of that variable as a 
            // console output. Use switch statement.

            int choice;
            string input;
            int integer;
            double realNum;
            string str;

            Console.WriteLine("Menu:");
            Console.WriteLine("Press '1' - for integer");
            Console.WriteLine("Press '2' - for real number");
            Console.WriteLine("Press '3' - for string");
            input = Console.ReadLine();
            choice = int.Parse(input);

            switch (choice)
            {
                case 1:
                    Console.Write("Enter integer: ");
                    input = Console.ReadLine();
                    integer = int.Parse(input) + 1;
                    Console.WriteLine("new integer = {0}", integer);
                    break;
                case 2:
                    Console.Write("Enter real number: ");
                    input = Console.ReadLine();
                    realNum = double.Parse(input) + 1;
                    Console.WriteLine("new real number = {0}", realNum);
                    break;
                case 3:
                    Console.Write("Enter string: ");
                    input = Console.ReadLine() + "*";
                    Console.WriteLine("new string = {0}", input);
                    break;
                default:
                    Console.WriteLine("{0} is not a valid choice.", choice);
                    break;
            }
        }
    }
}
