using System;
using System.IO;

namespace HexToDec
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 4: Write a program to convert hexadecimal numbers to their decimal representation.

            Console.WriteLine("Enter the hex number: ");
            string hexNum = Console.ReadLine();

            int decNum = ConvertToDec(hexNum);

            Console.WriteLine(decNum);
        }

        static int ConvertToDec(string hex)
        {
            int result = 0;

            int power = 0;
            for (int i = hex.Length - 1; i >= 0; i--)
            {
                if (hex[i] == 'A' || hex[i] == 'a')
                {
                    result += ((int)Math.Pow(16, power)) * 10;
                }
                else if (hex[i] == 'B' || hex[i] == 'b')
                {
                    result += ((int)Math.Pow(16, power)) * 11;
                }
                else if (hex[i] == 'C' || hex[i] == 'c')
                {
                    result += ((int)Math.Pow(16, power)) * 12;
                }
                else if (hex[i] == 'D' || hex[i] == 'd')
                {
                    result += ((int)Math.Pow(16, power)) * 13;
                }
                else if (hex[i] == 'E' || hex[i] == 'e')
                {
                    result += ((int)Math.Pow(16, power)) * 14;
                }
                else if (hex[i] == 'F' || hex[i] == 'f')
                {
                    result += ((int)Math.Pow(16, power)) * 15;
                }
                else
                {
                    result += ((int)Math.Pow(16, power)) * (int.Parse(hex[i].ToString()));
                }
                power++;
            }

            return result;
        }
    }
}