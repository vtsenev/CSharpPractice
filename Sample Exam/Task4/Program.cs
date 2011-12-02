using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            byte b = byte.Parse(input);
            input = Console.ReadLine();
            int n = int.Parse(input);
            uint[] numbers = new uint[n];
            byte[] binDigits = new byte[n];

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                numbers[i] = uint.Parse(input);
                binDigits[i] = CountBinDigits(numbers[i], b);
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(binDigits[i]);
            }
        }

        static byte CountBinDigits(uint decNumber, byte binDigit)
        {
            byte result = 0;
            byte[] binNumber = ConvertToBin(decNumber);
            for (int i = 0; i < binNumber.Length; i++)
            {
                if (binNumber[i] == binDigit)
                {
                    result++;
                }
            }
            return result;
        }

        static byte[] ConvertToBin(uint number)
        {
            byte power = 0;
            uint numberCopy = number;
            while (numberCopy > 0)
            {
                numberCopy /= 2;
                power++;
            }
            byte[] result = new byte[power];

            for (int i = 0; i < power; i++)
            {
                if (number % 2 == 0)
                {
                    result[i] = 0;
                }
                else
                {
                    result[i] = 1;
                }
                number /= 2;
            }
            
            return result;
        }
    }
}
