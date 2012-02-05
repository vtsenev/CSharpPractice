using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2PrintRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 2: Write a program that generates and prints
            // to the console 10 random values in the range [100, 200].

            Random randgen = new Random();
            Console.WriteLine("10 random values in the range [100, 200]:");
            for (int i = 0; i < 10; i++)
            {
                int number = randgen.Next(100, 201);
                Console.WriteLine(number);
            }
        }
    }
}
