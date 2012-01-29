using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task10AllPassableAreas
{
    class Program
    {
        static char[,] lab =
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {'*', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', '*', '*', ' '},
            {' ', '*', ' ', ' ', ' ', '*', ' '},
        };

        static List<Tuple<int, int>> path; 

        static void Main(string[] args)
        {
            // Task 10: We are given a matrix of passable and non-passable cells. Write a
            // recursive program for finding all areas of passable cells in the matrix.

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
                        path = new List<Tuple<int, int>>();
                        FindAreas(row, col);
                        PrintArea(path);
                    }
                }
            }
        }

        static void FindAreas(int row, int col)
        {
            if ((row < 0 || row >= lab.GetLength(0)) || (col < 0 || col >= lab.GetLength(1)))
            {
                return;
            }

            if (lab[row, col] == ' ')
            {
                lab[row, col] = 's';
                path.Add(new Tuple<int, int>(row, col));
                FindAreas(row, col + 1);
                FindAreas(row + 1, col);
                FindAreas(row, col - 1);
                FindAreas(row - 1, col);
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

        static void PrintArea(List<Tuple<int, int>> area)
        {
            Console.WriteLine("Area #{0}", area.Count);
            Console.Write("| ");
            foreach (var cell in area)
            {
                Console.Write("({0}, {1}) | ", cell.Item1, cell.Item2);
            }
            Console.WriteLine();
        }
    }
}
