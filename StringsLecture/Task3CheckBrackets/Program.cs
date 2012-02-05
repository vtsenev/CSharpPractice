using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3CheckBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 3: Write a program to check if in a given expression the brackets are put correctly.
            // Example of correct expression: ((a+b)/5-d).
            // Example of incorrect expression: )(a+b)).

            Console.Write("Enter expression: ");
            string expression = Console.ReadLine();

            bool correctness = CheckBrackets(expression);

            if (correctness)
            {
                Console.WriteLine("Brackets are put correctly.");
            }
            else
            {
                Console.WriteLine("Brackets are NOT put correctly.");
            }
        }

        static bool CheckBrackets(string expression)
        {
            if (expression[0] == ')')
            {
                return false;
            }
            if (expression[expression.Length - 1] == '(')
            {
                return false;
            }

            int leftBrackets = 0;
            int rightBrackets = 0;

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == ')')
                {
                    rightBrackets++;
                    if (leftBrackets < rightBrackets)
                    {
                        return false;
                    }
                }
                else if (expression[i] == '(')
                {
                    leftBrackets++;
                    if (i + 1 <= expression.Length - 1)
                    {
                        if (expression[i + 1] == ')')
                        {
                            return false;
                        }
                    }
                }
            }

            if (leftBrackets != rightBrackets)
            {
                return false;
            }

            return true;
        }
    }
}
