using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task13
{
    class Program
    {
        static int[,] spiral;
        static int n;

        static void Main(string[] args)
        {
            // * Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
            // Example for N = 4
            // 1    2   3   4
            // 12   13  14  5
            // 11   16  15  6
            // 10   9   8   7

            Console.Write("N = ");
            string input = Console.ReadLine();
            n = int.Parse(input);

            spiral = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    spiral[i, j] = 0;

            if (n >= 20 || n < 1)
            {
                Console.WriteLine("N is a positive integer number (N < 20).");
                return;
            }


            GetSpiralArray(n);

            Print();
        }

        static void GetSpiralArray(int dimension)
        {
            int numConcentricSquares = (int)Math.Ceiling((dimension) / 2.0);
            int j;
            int sideLen = dimension;
            int currNum = 0;

            for (int i = 0; i < numConcentricSquares; i++)
            {
                // do top side
                for (j = 0; j < sideLen; j++)
                {
                    spiral[i, i + j] = ++currNum;
                }

                // do right side
                for (j = 1; j < sideLen; j++)
                {
                    spiral[i + j, dimension - 1 - i] = ++currNum;
                }

                // do bottom side
                for (j = sideLen - 2; j > -1; j--)
                {
                    spiral[dimension - 1 - i, i + j] = ++currNum;
                }

                // do left side
                for (j = sideLen - 2; j > 0; j--)
                {
                    spiral[i + j, i] = ++currNum;
                }

                sideLen -= 2;
            }

        }


        static void Print()
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (col < n - 1)
                        Console.Write("{0,3} ", spiral[row, col]);
                    else
                        Console.WriteLine("{0,3}", spiral[row, col]);
                }
            }
        }

    }
}