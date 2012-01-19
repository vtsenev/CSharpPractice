using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 2: Write a method GetMax() with two parameters
            // that returns the bigger of two integers. Write a
            // program that reads 3 integers from the console and 
            // prints the biggest of them using the method GetMax().

            Console.Write("number1 = ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("number2 = ");
            int num2 = int.Parse(Console.ReadLine());
            Console.Write("number3 = ");
            int num3 = int.Parse(Console.ReadLine());

            int tmp = GetMax(num1, num2);

            Console.WriteLine("Biggest number: {0}", GetMax(tmp, num3));
        }

        static int GetMax(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
