using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task8LargestConnectedArea
{
    class Program
    {
        static char[,] lab =
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', '*', '*', ' ', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        };

        static int maxCount = 0;
        static int currentCount = 0;

        static void Main(string[] args)
        {
            // Task 8: Write a program to find the largest connected area of adjacent empty cells in a matrix.

            PrintLab();
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (lab[row, col] != ' ')
                    {
                        continue;
                    }
                    else
                    {
                        currentCount = 0;
                        FindAllPaths(row, col);
                        if (currentCount > maxCount)
                        {
                            maxCount = currentCount;
                        }
                    }
                }
            }
            Console.WriteLine("The largest connected area is: {0}", maxCount);
        }

        static void FindAllPaths(int row, int col)
        {
            if ((row < 0 || row >= lab.GetLength(0)) || (col < 0 || col >= lab.GetLength(1)))
            {
                return;
            }
            if (lab[row, col] == ' ')
            {
                lab[row, col] = 's';
                currentCount++;
                FindAllPaths(row, col + 1);
                FindAllPaths(row + 1, col);
                FindAllPaths(row, col - 1);
                FindAllPaths(row - 1, col);
            }
        }

        static void PrintLab()
        {
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    if (lab[row, col] == ' ')
                    {
                        Console.Write(" - ", lab[row, col]);
                    }
                    else
                    {
                        Console.Write(" {0} ", lab[row, col]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
