using System;
using System.IO;

namespace HexToBin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 5: Write a program to convert hexadecimal numbers to binary numbers (directly).

            Console.WriteLine("Enter the hex number: ");
            string hexNum = Console.ReadLine();

            int[] binNum = ConvertToBin(hexNum);

            Print(binNum);
        }

        static int[] ConvertToBin(string hex)
        {
            int[] binNum = new int[hex.Length * 4];

            
            for (int hexIndex = hex.Length - 1; hexIndex >= 0; hexIndex--)
            {
                int binIndex = hexIndex * 4;
                switch (hex[hexIndex])
                {
                    case 'f':
                    case 'F': binNum[binIndex] = 1; binNum[binIndex + 1] = 1; binNum[binIndex + 2] = 1; binNum[binIndex + 3] = 1; break;
                    case 'e':
                    case 'E': binNum[binIndex] = 1; binNum[binIndex + 1] = 1; binNum[binIndex + 2] = 1; binNum[binIndex + 3] = 0; break;
                    case 'd':
                    case 'D': binNum[binIndex] = 1; binNum[binIndex + 1] = 1; binNum[binIndex + 2] = 0; binNum[binIndex + 3] = 1; break;
                    case 'c':
                    case 'C': binNum[binIndex] = 1; binNum[binIndex + 1] = 1; binNum[binIndex + 2] = 0; binNum[binIndex + 3] = 0; break;
                    case 'b':
                    case 'B': binNum[binIndex] = 1; binNum[binIndex + 1] = 0; binNum[binIndex + 2] = 1; binNum[binIndex + 3] = 1; break;
                    case 'a':
                    case 'A': binNum[binIndex] = 1; binNum[binIndex + 1] = 0; binNum[binIndex + 2] = 1; binNum[binIndex + 3] = 0; break;
                    case '9': binNum[binIndex] = 1; binNum[binIndex + 1] = 0; binNum[binIndex + 2] = 0; binNum[binIndex + 3] = 1; break;
                    case '8': binNum[binIndex] = 1; binNum[binIndex + 1] = 0; binNum[binIndex + 2] = 0; binNum[binIndex + 3] = 0; break;
                    case '7': binNum[binIndex] = 0; binNum[binIndex + 1] = 1; binNum[binIndex + 2] = 1; binNum[binIndex + 3] = 1; break;
                    case '6': binNum[binIndex] = 0; binNum[binIndex + 1] = 1; binNum[binIndex + 2] = 1; binNum[binIndex + 3] = 0; break;
                    case '5': binNum[binIndex] = 0; binNum[binIndex + 1] = 1; binNum[binIndex + 2] = 0; binNum[binIndex + 3] = 1; break;
                    case '4': binNum[binIndex] = 0; binNum[binIndex + 1] = 1; binNum[binIndex + 2] = 0; binNum[binIndex + 3] = 0; break;
                    case '3': binNum[binIndex] = 0; binNum[binIndex + 1] = 0; binNum[binIndex + 2] = 1; binNum[binIndex + 3] = 1; break;
                    case '2': binNum[binIndex] = 0; binNum[binIndex + 1] = 0; binNum[binIndex + 2] = 1; binNum[binIndex + 3] = 0; break;
                    case '1': binNum[binIndex] = 0; binNum[binIndex + 1] = 0; binNum[binIndex + 2] = 0; binNum[binIndex + 3] = 1; break;
                    case '0': binNum[binIndex] = 0; binNum[binIndex + 1] = 0; binNum[binIndex + 2] = 0; binNum[binIndex + 3] = 0; break;
                    default: throw new InvalidDataException("Invalid binary digit.");
                }
            }

            return binNum;
        }

        static void Print(int[] binNum)
        {
            for (int i = 0; i < binNum.Length; i++)
            {
                Console.Write(binNum[i]);
            }
            Console.WriteLine();
        }
    }
}
