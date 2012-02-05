using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Task2Sudoku
{
    class Program
    {
        const string INPUT = @"..\..\test.002.in.txt";
        const string OUTPUT = @"..\..\out.txt";
        static int[] grid = new int[81];

        static void Main(string[] args)
        {
            //InputFile();
            Input();
            Solve(0);
        }

        static void InputFile()
        {
            StreamReader reader = new StreamReader(INPUT);
            using (reader)
            {
                for (int row = 0; row < 9; row++)
                {
                    string input = reader.ReadLine();
                    for (int col = 0; col < 9; col++)
                    {
                        if (input[col] != '-')
                        {
                            grid[row * 9 + col] = byte.Parse(input[col].ToString());
                        }
                        else
                        {
                            grid[row * 9 + col] = 0;
                        }
                    }
                }
            }
        }

        static void Input()
        {
            for (int row = 0; row < 9; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < 9; col++)
                {
                    if (input[col] != '-')
                    {
                        grid[row * 9 + col] = byte.Parse(input[col].ToString());
                    }
                    else
                    {
                        grid[row * 9 + col] = 0;
                    }
                }
            }
        }

        static void Solve(int pos)
        {
            if (pos == 81)
            {
                PrintGrid();
                return;
            }
            if (grid[pos] > 0)
            {
                Solve(pos + 1);
                return;
            }
            for (int n = 1; n <= 9; n++)
            {
                if (CheckValidity(n, pos % 9, pos / 9))
                {
                    grid[pos] = n;
                    Solve(pos + 1);
                    grid[pos] = 0;
                }
            }
        }

        static bool CheckValidity(int val, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                if (grid[y * 9 + i] == val || grid[i * 9 + x] == val)
                    return false;
            }
            int startX = (x / 3) * 3;
            int startY = (y / 3) * 3;
            for (int i = startY; i < startY + 3; i++)
            {
                for (int j = startX; j < startX + 3; j++)
                {
                    if (grid[i * 9 + j] == val)
                        return false;
                }
            }
            return true;
        }

        static void PrintGrid()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Console.Write(grid[row * 9 + col]);
                }
                Console.WriteLine();
            }
        }
    }
}
