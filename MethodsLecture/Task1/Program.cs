﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Write a method that asks the user for his name
            // and prints “Hello, <name>” (for example, “Hello, Peter!”).
            // Write a program to test this method.

            PrintName();
        }

        static void PrintName()
        {
            Console.WriteLine("What's your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
