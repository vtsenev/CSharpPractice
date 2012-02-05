using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4SubstringCount
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 4: Write a program that finds how many times a substring
            // is contained in a given text (perform case insensitive search).

            string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string substr = "in";

            int occurences = CountOccurences(substr, text);

            Console.WriteLine("\"{0}\" can be found {1} times.", substr, occurences);
        }

        static int CountOccurences(string substr, string text)
        {
            text = text.ToLower();
            substr = substr.ToLower();
            int count = 0;
            bool contained = text.Contains(substr);
            while (contained)
            {
                int index = text.IndexOf(substr) + substr.Length;
                text = text.Substring(index);
                contained = text.Contains(substr);
                count++;
            }
            return count;
        }
    }
}
