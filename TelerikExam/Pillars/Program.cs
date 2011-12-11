using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pillars
{
    class Program
    {
        static byte[] n;
        static int leftBits;
        static int rightBits;

        static void Main(string[] args)
        {
            n = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                string input = Console.ReadLine();
                n[i] = byte.Parse(input);
            }

            if (n.All(element => element == 255 || element == 0))
            {
                Console.WriteLine("7");
                Console.WriteLine("0");
                return;
            }

            if (n.All(element => element == 0 || element == 1))
            {
                Console.WriteLine("0");
                Console.WriteLine("0");
                return;
            }

            for (int col = 7; col >= 0; col--)
            {
                PutPillar(col);
                if (leftBits == rightBits)
                {
                    Console.WriteLine(col);
                    Console.WriteLine(leftBits);
                    return;
                }
            }
            Console.WriteLine("No");
        }

        static void PutPillar(int p)
        {
            // check bits on the left
            leftBits = 0;
            rightBits = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = p + 1; j < 8; j++)
                {
                    if (CheckBit(n[i], j) == 1)
                    {
                        leftBits++;
                    }
                }
                for (int j = 0; j < p; j++)
                {
                    if (CheckBit(n[i], j) == 1)
                    {
                        rightBits++;
                    }
                }
            }
        }

        static int CheckBit(byte num, int pos)
        {
            int mask = num & (int)Math.Pow(2, pos);
            int result = mask >> pos;
            return result;
        }

    }
}
