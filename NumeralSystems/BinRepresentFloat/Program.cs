using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinRepresentFloat
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 9: * Write a program that shows the internal binary representation 
            // of given 32-bit signed floating-point number in IEEE 754 format (the C#
            // type float).
            // Example: -27,25 -> sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.

            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            Console.Write("f = ");
            float f = float.Parse(Console.ReadLine());

            byte[] raw = BitConverter.GetBytes(f);
            int[] binArray = new int[32];
            for (int i = 0; i < 4; i++)
            {
                int[] byteI = ConvertToBin(raw[i]);
                int index = 0;
                for (int j = i * 8; j < i * 8 + 8; j++)
                {
                    binArray[j] = byteI[index];
                    index++;
                }
            }

            int sign = binArray[31];
            Console.WriteLine("sign = {0}", sign);

            int[] exponent = new int[8];
            for (int i = 0; i < 8; i++)
            {
                exponent[i] = binArray[30 - i];
            }
            Console.Write("exponent = ");
            Print(exponent);

            int[] mantissa = new int[23];
            for (int i = 0; i < 23; i++)
            {
                mantissa[i] = binArray[22 - i];
            }
            Console.Write("mantissa = ");
            Print(mantissa);
        }

        static int[] ConvertToBin(int dec)
        {
            int[] result = new int[8];
            int decTmp = dec;
            for (int i = 0; i < 8; i++)
            {
                result[i] = decTmp % 2;
                decTmp /= 2;
            }
            return result;
        }

        static void Print(int[] binNum)
        {
            for (int i = 0; i < binNum.Length; i++)
            {
                Console.Write("{0}", binNum[i]);
            }
            Console.WriteLine();
        }
    }
}
