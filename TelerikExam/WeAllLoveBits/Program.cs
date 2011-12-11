using System;

namespace WeAllLoveBits
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(input);

            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                numbers[i] = int.Parse(input);
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(Mitko(numbers[i]));
            }
        }

        static int Mitko(int p)
        {
            int result;
            int pInverted = Invert(p);
            int pReversed = Revert(p);
            result = (p ^ pInverted) & pReversed;
            return result;
        }

        static int Invert(int p)
        {
            int result = 0;
            int[] binP = ConvertToBin(p);

            for (int i = 0; i < binP.Length; i++)
            {
                if (binP[i] == 0)
                {
                    binP[i] = 1;
                }
                else
                {
                    binP[i] = 0;
                }
            }

            result = ConvertToDec(binP);
            return result;
        }

        static int Revert(int p)
        {
            int result;
            int[] binP = ConvertToBin(p);
            int[] invertedBin = new int[binP.Length];

            int j = binP.Length - 1;
            for (int i = 0; i < invertedBin.Length; i++)
            {
                invertedBin[i] = binP[j];
                j--;
            }

            result = ConvertToDec(invertedBin);
            return result;
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
