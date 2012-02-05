using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task6Read20CharString
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 6: Write a program that reads from the console a string of maximum 20 characters.
            // If the length of the string is less than 20, the rest of the characters should be 
            // filled with '*'. Print the result string into the console.

            Console.Write("Enter string (max 20 symbols): ");
            string str = Console.ReadLine();
            int length = str.Length;

            if (length > 20)
            {
                Console.WriteLine("String is too big.");
                return;
            }
            else
            {
                if (length == 20)
                {
                    Console.WriteLine(str);
                }
                else
                {
                    Console.Write(str);
                    string extraChars = new string('*', 20 - length);
                    Console.WriteLine(extraChars);
                }
            }

        }
    }
}
