using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Task7Capitalize
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 7: Write extension method to the String class that capitalizes
            //the first letter of each word. Use the method TextInfo.ToTitleCase().

            string text = "This test text is created for testing purposes.";
            Console.WriteLine(text.Capitalize());
        }
    }

    static class Extension
    {
        public static string Capitalize(this string text)
        {
            TextInfo tinfo = CultureInfo.InvariantCulture.TextInfo;
            return tinfo.ToTitleCase(text);
        }
    }
}
