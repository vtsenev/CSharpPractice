using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuadEquation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that enters the coefficients a, b and c of a quadratic equation
		    // a*x2 + b*x + c = 0
		    // and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.

            Console.WriteLine("Enter queficients a, b and c:");
            string input = Console.ReadLine();
            double a = double.Parse(input);
            input = Console.ReadLine();
            double b = double.Parse(input);
            input = Console.ReadLine();
            double c = double.Parse(input);

            double det = (b * b) - (4 * a * c);
            double x1, x2;

            if (a == 0)
            {
                if (b == 0)
                {
                    Console.WriteLine("Every real number is a root.");
                }
                else
                {
                    Console.WriteLine("The equation is linear.");
                    x1 = (-c) / b;
                    Console.WriteLine("The root is: x = {0:0.000}", x1);
                }
            }
            else
            {
                if (det > 0)
                {
                    Console.WriteLine("The equation has two roots.");
                    x1 = ((-b) - System.Math.Sqrt(det)) / (2 * a);
                    x2 = ((-b) + System.Math.Sqrt(det)) / (2 * a);
                    Console.WriteLine("The two roots are: x1 = {0:0.000}, x2 = {1:0.000}", x1, x2);
                }
                else if (det == 0)
                {
                    Console.WriteLine("The equation has one root.");
                    x1 = (-b) / (2 * a);
                    Console.WriteLine("The root is: x = {0:0.000}", x1);
                }
                else
                {
                    Console.WriteLine("The equation has no real roots.");
                }
            }
        }
    }
}
