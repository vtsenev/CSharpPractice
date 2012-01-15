using System;
using System.IO;

namespace BinToDec
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 2: Write a program to convert binary numbers to their decimal representation.

            Console.WriteLine("Enter the binary number: ");
            int[] binArr = Input();
            
            int decNum = ConvertToDec(binArr);

            Console.WriteLine(decNum);
        }

        static int[] Input()
        {
            string str = Console.ReadLine();
            int[] binNum = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '1' || str[i] == '0')
                {
                    binNum[str.Length - i - 1] = int.Parse(str[i].ToString());
                }
                else
                {
                    throw new InvalidDataException("Invalid binary digit.");
                }
            }

            return binNum;
        }

        static int ConvertToDec(int[] binArr)
        {
            int result = 0;

            for (int i = 0; i < binArr.Length; i++)
            {
                if (binArr[i] == 1)
                {
                    result += (int)Math.Pow(2, i);
                }
            }

            return result;
        }
    }
}
