using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task7ArithmeticalExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 7: * Write a program that calculates the value of given arithmetical expression. 
            // The expression can contain the following elements only:
            // Real numbers, e.g. 5, 18.33, 3.14159, 12.6
            // Arithmetic operators: +, -, *, / (standard priorities)
            // Mathematical functions: ln(x), sqrt(x), pow(x,y)
            // Brackets (for changing the default priorities)
            // Examples:
            // (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) -> ~ 10.6
            // pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) -> ~ 21.22
            // Hint: Use the classical "shunting yard" algorithm and "reverse Polish notation".

            Console.WriteLine("Enter an arithmetical expression:");
            string expression = Console.ReadLine();

            ParseExpression(expression);
        }

        static void ParseExpression(string expression)
        {
            for (int i = 0; i < expression.Length; i++)
            {

            }
        }
    }
}
