using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task9ForbiddenWords
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 9: We are given a string containing a list of forbidden words
            // and a text containing some of these words. Write a program that 
            // replaces the forbidden words with asterisks. 

            string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

            string[] forbiddenWords = { "PHP", "CLR", "Microsoft" };

            string newText = Revise(text, forbiddenWords);
        }

        static string Revise(string text, string[] forbiddenWords)
        {
            return string.Empty;
        }
    }
}
