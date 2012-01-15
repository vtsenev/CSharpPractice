using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecToHex
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 3: Write a program to convert decimal numbers to their hexadecimal representation.

            Console.Write("Enter a decimal number: ");
            int decNum = int.Parse(Console.ReadLine());

            string hexNum = ConvertToHex(decNum);

            Console.WriteLine(hexNum);
        }

        static string ConvertToHex(int dec)
        {
            string result = "";

            while (dec != 0)
            {
                int digit = dec % 16;
                
                if (digit < 10)
                {
                    result += digit.ToString();
                }
                else if (digit == 10)
                {
                    result += "A";
                }
                else if (digit == 11)
                {
                    result += "B";
                }
                else if (digit == 12)
                {
                    result += "C";
                }
                else if (digit == 13)
                {
                    result += "D";
                }
                else if (digit == 14)
                {
                    result += "E";
                }
                else if (digit == 15)
                {
                    result += "F";
                }
                dec /= 16;
            }

            char[] charArray = result.ToCharArray();
            Array.Reverse(charArray);
            return new string (charArray);
        }
    }
}
