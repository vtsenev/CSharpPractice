using System;

namespace DecToBin
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Write a program to convert decimal numbers to their binary representation.

            Console.Write("Enter decimal number: ");
            int decNum = int.Parse(Console.ReadLine());

            int[] binNum = ConvertToBin(decNum);

            Print(binNum);
        }

        static int[] ConvertToBin(int dec)
        {
            int decTmp = dec;
            int power = 0;
            while (decTmp > 0)
            {
                decTmp /= 2;
                power++;
            }
            int[] result = new int[power];
            decTmp = dec;
            for (int i = 0; i < power; i++)
            {
                result[i] = decTmp % 2;
                decTmp /= 2;
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