using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 2: Write a program that reads a string, reverses it and prints it on the console.
            // Example: "sample" -> "elpmas".

            Console.Write("Enter string: ");
            string str = Console.ReadLine();

            string reversedStr = ReverseString(str);

            Console.WriteLine(reversedStr);
        }

        static string ReverseString(string str)
        {
            StringBuilder sbuilder = new StringBuilder(str.Length);
            for (int i = str.Length - 1; i >= 0; i--)
            {
                sbuilder.Append(str[i]);
            }
            return sbuilder.ToString();
        }
    }
}
