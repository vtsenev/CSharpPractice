using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindBiggestOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that finds the biggest of three integers using nested if statements.

            int num1, num2, num3;
            Console.WriteLine("Enter 3 integers:");
            string input = Console.ReadLine();
            num1 = int.Parse(input);
            input = Console.ReadLine();
            num2 = int.Parse(input);
            input = Console.ReadLine();
            num3 = int.Parse(input);

            if (num1 > num2)
            {
                int temp = num1;
                num1 = num2;
                num2 = temp;
                if (num2 > num3)
                {
                    temp = num2;
                    num2 = num3;
                    num3 = temp;
                    if (num1 > num2)
                    {
                        temp = num1;
                        num1 = num2;
                        num2 = temp;
                    }
                }
            }

            if (num2 > num3)
            {
                int temp = num2;
                num2 = num3;
                num3 = temp;
                if (num1 > num2)
                {
                    temp = num1;
                    num1 = num2;
                    num2 = temp;
                }
            }

            Console.WriteLine("The biggest of the three numbers is: {0}.", num3);

        }
    }
}
