using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortThreeDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sort 3 real values in descending order using nested if statements.


            double num1, num2, num3;
            Console.WriteLine("Enter 3 real numbers:");
            string input = Console.ReadLine();
            num1 = double.Parse(input);
            input = Console.ReadLine();
            num2 = double.Parse(input);
            input = Console.ReadLine();
            num3 = double.Parse(input);

            if (num1 > num2)
            {
                double temp = num1;
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
                double temp = num2;
                num2 = num3;
                num3 = temp;
                if (num1 > num2)
                {
                    temp = num1;
                    num1 = num2;
                    num2 = temp;
                }
            }

            Console.WriteLine("{0}, {1}, {2}", num3, num2, num1);
        }
    }
}
