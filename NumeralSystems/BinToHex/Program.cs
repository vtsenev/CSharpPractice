using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinToHex
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 6: Write a program to convert binary numbers to hexadecimal numbers (directly).

            int[] binaryNum = { 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1 };

            if (binaryNum.Length % 4 != 0)
            {
                binaryNum = AddZeroes(binaryNum);
            }

            string[] hexNum = ConvertBinToHex(binaryNum);

            Print(hexNum);
        }

        // adding zeroes in front to make the binary array splittable into groups of four digits
        private static int[] AddZeroes(int[] binaryNum)
        {
            int zeroes = 4 - binaryNum.Length % 4;
            int[] result = new int[binaryNum.Length + zeroes];

            for (int i = 0; i < result.Length; i++)
            {
                if (i < zeroes)
                {
                    result[i] = 0;
                }
                else
                {
                    result[i] = binaryNum[i - zeroes];
                }
            }

            return result;
        }

        static string[] ConvertBinToHex(int[] binNum)
        {
            string[] hexNum = new string[binNum.Length/4];

            int hexIndex = 0;
            while (hexIndex < hexNum.Length)
            {
                int binIndex = hexIndex * 4;
                int counter = 3;
                int digit = 0;
                while (counter >= 0 && binIndex < binNum.Length)
                {
                    digit += binNum[binIndex] * (int)Math.Pow(2, counter);
                    binIndex++;
                    counter--;
                }
                if (digit < 10)
                {
                    hexNum[hexIndex] = digit.ToString();
                }
                else if (digit == 10)
                {
                    hexNum[hexIndex] = "A";
                }
                else if (digit == 11)
                {
                    hexNum[hexIndex] = "B";
                }
                else if (digit == 12)
                {
                    hexNum[hexIndex] = "C";
                }
                else if (digit == 13)
                {
                    hexNum[hexIndex] = "D";
                }
                else if (digit == 14)
                {
                    hexNum[hexIndex] = "E";
                }
                else if (digit == 15)
                {
                    hexNum[hexIndex] = "F";
                }
                hexIndex++;
            }

            return hexNum;
        }

        static void Print(string[] hexNum)
        {
            for (int i = 0; i < hexNum.Length; i++)
            {
                Console.Write(hexNum[i]);
            }
            Console.WriteLine();
        }
    }
}
