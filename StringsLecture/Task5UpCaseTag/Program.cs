using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5UpCaseTag
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 5: You are given a text. Write a program that changes the text in all regions
            // surrounded by the tags <upcase> and </upcase> to uppercase. The tags cannot be nested.

            string text = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            string opentag = "<upcase>";
            string closetag = "</upcase>";

            string result = UppercaseWhenAppropriate(text, opentag, closetag);

            Console.WriteLine(result);
        }

        static string UppercaseWhenAppropriate(string text, string opentag, string closetag)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(text);

            while (sb.ToString().Contains(opentag))
            {
                int startIndex = sb.ToString().IndexOf(opentag) + opentag.Length;
                int endIndex = sb.ToString().IndexOf(closetag);

                sb.Replace(sb.ToString().Substring(startIndex, endIndex - startIndex), sb.ToString().Substring(startIndex, endIndex - startIndex).ToUpper());

                sb.Remove(startIndex - opentag.Length, opentag.Length);
                endIndex = sb.ToString().IndexOf(closetag);
                sb.Remove(endIndex, closetag.Length);
            }

            return sb.ToString();
        }
    }
}
