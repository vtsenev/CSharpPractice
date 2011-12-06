using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindGreatestOfFive
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that finds the greatest of given 5 variables.

            int num1, num2, num3, num4, num5;
            string input;
            Console.WriteLine("Enter five integers:");
            input = Console.ReadLine();
            num1 = int.Parse(input);
            input = Console.ReadLine();
            num2 = int.Parse(input);
            input = Console.ReadLine();
            num3 = int.Parse(input);
            input = Console.ReadLine();
            num4 = int.Parse(input);
            input = Console.ReadLine();
            num5 = int.Parse(input);

            int temp;

            if (num1 > num2)
            {
                temp = num1;
                num1 = num2;
                num2 = temp;
            }
            if (num2 > num3)
            {
                temp = num2;
                num2 = num3;
                num3 = temp;
            }
            if (num1 > num3)
            {
                temp = num1;
                num1 = num3;
                num3 = temp;
            }
            if (num3 > num4)
            {
                temp = num3;
                num3 = num4;
                num4 = temp;
            }
            if (num4 > num5)
            {
                temp = num4;
                num4 = num5;
                num5 = temp;
            }

            Console.WriteLine("Biggest number is {0}", num5);
        }
    }
}
