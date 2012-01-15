using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinRepresentShort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 8: Write a program that shows the binary representation
            // of given 16-bit signed integer number (the C# type short).

            Console.Write("Enter a 16-bit signed integer (short): ");
            short number = short.Parse(Console.ReadLine());

            int[] binRepresentation = new int[16];

            if (number > 0)
            {
                binRepresentation[15] = 0;
                int[] binNum = ConvertDecToBin(number);
                for (int i = 14; i >= 0; i--)
                {
                    binRepresentation[i] = binNum[i];
                }
            }
            else if (number < 0)
            {
                binRepresentation[15] = 1;
                int[] binNum = ConvertDecToBin(32768 + number);
                for (int i = 14; i >= 0; i--)
                {
                    binRepresentation[i] = binNum[i];
                }
            }

            Print(binRepresentation);
        }

        static int[] ConvertDecToBin(int dec)
        {
            int[] result = new int[15];
            for (int i = 0; i < 15; i++)
            {
                result[i] = dec % 2;
                dec /= 2;
            }
            return result;
        }

        static void Print(int[] binNum)
        {
            for (int i = binNum.Length - 1; i >= 0; i--)
            {
                Console.Write(binNum[i]);
            }
            Console.WriteLine();
        }
    }
}
