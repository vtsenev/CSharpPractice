using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task6FindAllPaths
{
    class Program
    {
        static char[,] lab = 
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'е'},
        };

        static List<Tuple<int, int>> path = new List<Tuple<int, int>>();
        static int routeNum;

        static void Main(string[] args)
        {
            // Task 6: We are given a matrix of passable and non-passable cells. Write a
            // recursive program for finding all paths between two cells in the matrix.

            routeNum = 0;
            FindPathToExit(0, 0);
        }

        static void FindPathToExit(int row, int col)
        {
            if (!InRange(row, col))
            {
                // We are out of the labyrinth -> can't find a path
                return;
            }

            // Check if we have found the exit
            if (lab[row, col] == 'е')
            {
                routeNum++;
                Console.WriteLine("Route #{0} /Length = {1}/", routeNum, path.Count + 1);
                PrintPath(row, col);
            }

            if (lab[row, col] != ' ')
            {
                // The current cell is not free -> can't find a path
                return;
            }

            // Temporarily mark the current cell as visited
            lab[row, col] = 's';
            path.Add(new Tuple<int, int>(row, col));

            // Invoke recursion the explore all possible directions
            FindPathToExit(row, col - 1); // left
            FindPathToExit(row - 1, col); // up
            FindPathToExit(row, col + 1); // right
            FindPathToExit(row + 1, col); // down

            // Mark back the current cell as free
            lab[row, col] = ' ';
            path.RemoveAt(path.Count - 1);
        }

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        static void PrintPath(int finalRow, int finalCol)
        {
            bool filledCell = false;
            for (int row = 0; row < lab.GetLength(0); row++)
            {
                for (int col = 0; col < lab.GetLength(1); col++)
                {
                    foreach (var cell in path)
                    {
                        if (row == cell.Item1 && col == cell.Item2)
                        {
                            Console.Write("s");
                            filledCell = true;
                        }
                    }
                    if (!filledCell)
                    {
                        if (lab[row, col] != ' ')
                        {
                            Console.Write(lab[row, col]);
                        }
                        else
                        {
                            Console.Write(".");
                        }
                    }
                    filledCell = false;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
