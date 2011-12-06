using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IfStatementExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write an if statement that examines two integer variables
            // and exchanges their values if the first one is greater than the second one.
            
            int number1;
            int number2;
            bool switched = false;

            string number_str;
            Console.Write("Enter number1: ");
            number_str = Console.ReadLine();
            number1 = int.Parse(number_str);
            Console.Write("Enter number2: ");
            number_str = Console.ReadLine();
            number2 = int.Parse(number_str);

            if (number1 > number2)
            {
                int temp = number1;
                number1 = number2;
                number2 = temp;
                switched = true;
            }

            Console.WriteLine("number1 = {0}; number2 = {1}; switched = {2}", number1, number2, switched);
        }
    }
}
