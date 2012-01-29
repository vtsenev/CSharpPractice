using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task7CheckForPath
{
    class Program
    {
        static char[,] lab;
        static bool pathExists;

        static void Main(string[] args)
        {
            // Task 7: Modify the above program to check whether a path exists
            // between two cells without finding all possible paths. Test it
            // over an empty 100 x 100 matrix.

            lab = new char[100, 100];
            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    lab[i, j] = ' ';
                }
            }
            lab[lab.GetLength(0) - 1, lab.GetLength(1) - 1] = 'e';

            pathExists = false;
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
            if (lab[row, col] == 'e')
            {
                pathExists = true;
                Console.WriteLine("Path exists.");
            }

            if (lab[row, col] != ' ')
            {
                // The current cell is not free -> can't find a path
                return;
            }

            // Temporarily mark the current cell as visited
            lab[row, col] = 's';

            // Invoke recursion the explore all possible directions
            if (!pathExists)
            {
                FindPathToExit(row, col - 1); // left
                FindPathToExit(row - 1, col); // up
                FindPathToExit(row, col + 1); // right
                FindPathToExit(row + 1, col); // down
            }
            // Mark back the current cell as free
            lab[row, col] = ' ';
        }

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }
    }
}
