using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FallDown
{
    class Program
    {

        static byte[] numbers;

        static void Main(string[] args)
        {
            numbers = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                string input = Console.ReadLine();
                numbers[i] = byte.Parse(input);
            }

            for (int col = 0; col < 8; col++)
            {
                for (int row = 6; row >= 0; row--)
                {
                    int fallToBit = CalcFall(row, col);
                    //Console.WriteLine("bit[{0}][{1}] will fall {2} positions / number[{0}] = {3}", row, col, fallToBit, numbers[row]);
                    SwitchBits(row, col, fallToBit + row);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }

        static int CalcFall(int row, int col)
        {
            int result = 0;

            for (int i = row + 1; i < 8; i++)
            {
                if (CheckBit(numbers[i], col) == 0)
                {
                    result++;
                }
            }

            return result;
        }

        static int CheckBit(byte num, int pos)
        {
            int mask = num & (int)Math.Pow(2, pos);
            int result = mask >> pos;
            return result;
        }

        static void SwitchBits(int fromRow, int col, int toRow)
        {
            int mask1 = numbers[fromRow] & (int)Math.Pow(2, col);
            numbers[fromRow] -= (byte)mask1;
            numbers[toRow] += (byte)mask1;
        }
    }
}
