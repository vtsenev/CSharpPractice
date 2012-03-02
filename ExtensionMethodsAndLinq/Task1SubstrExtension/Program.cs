using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1SubstrExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Implement an extension method Substring(int index, int length)
            // for the class StringBuilder that returns new StringBuilder and has the
            // same functionality as Substring in the class String.
            
            string text = "test string\nhas two lines";

            StringBuilder sb = new StringBuilder(text);
            StringBuilder subSB = sb.Substring(7, 2);
            Console.WriteLine(subSB);
        }
    }

    static class StrBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            return new StringBuilder(sb.ToString().Substring(index, length));
        }
    }
}
