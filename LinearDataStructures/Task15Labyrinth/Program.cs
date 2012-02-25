using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task15Labyrinth
{
    class Program
    {
        static char[,] labyrinth =
        {
            { '0', '0', '0', 'x', '0', 'x' },
            { '0', 'x', '0' ,'x', '0', 'x' },
            { '0', '*', 'x', '0', 'x', '0' },
            { '0', 'x', '0', '0', '0', '0' },
            { '0', '0', '0', 'x', 'x', '0' },
            { '0', '0', '0', 'x', '0', 'x' },
        };
        static string[,] result;

        static void Main(string[] args)
        {
            // Task 15: * We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x).
            // We can move from an empty cell to another empty cell if they share common wall. Given a starting position (*)
            // calculate and fill in the array the minimal distance from this position to any other cell in the array.
            // Use "u" for all unreachable cells.

            Tuple<int, int> startPos = FindStartingPosition();
            InitResultMatrix();

            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == '0')
                    {
                        result[row, col] = FindRoutes(startPos, new Tuple<int, int>(row, col));
                    }
                }
            }

            PrintResult();
        }

        static Tuple<int, int> FindStartingPosition()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == '*')
                        return new Tuple<int, int>(row, col);
                }
            }
            throw new ArgumentException("No starting position found.");
        }

        static void InitResultMatrix()
        {
            result = new string[labyrinth.GetLength(0), labyrinth.GetLength(1)];
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    result[row, col] = labyrinth[row, col].ToString();
                }
            }
        }

        static string FindRoutes(Tuple<int, int> startCell, Tuple<int, int> destination)
        {
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            List<Tuple<int, int>> visited = new List<Tuple<int, int>>();
            Dictionary<Tuple<int, int>, Tuple<int, int>> pathFinder = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
            queue.Enqueue(startCell);
            visited.Add(startCell);

            while (queue.Count > 0)
            {
                Tuple<int, int> currentCell = queue.Dequeue();

                if (currentCell.Item1 == destination.Item1 && currentCell.Item2 == destination.Item2)
                {
                    int routeLength = 0;
                    while (pathFinder.ContainsKey(currentCell))
                    {
                        if (currentCell.Item1 == startCell.Item1 && currentCell.Item2 == startCell.Item2)
                            break;
                        if (routeLength > 100)
                            return "B";

                        routeLength++;
                        currentCell = pathFinder[currentCell];
                    }

                    return routeLength.ToString();
                }

                List<Tuple<int, int>> neighbours = GetNeighbours(currentCell);
                foreach (Tuple<int, int> neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                        visited.Add(neighbour);
                        if (!pathFinder.ContainsKey(neighbour))
                            pathFinder.Add(neighbour, currentCell);
                    }
                }
            }

            return "u";
        }

        static List<Tuple<int, int>> GetNeighbours(Tuple<int, int> cell)
        {
            List<Tuple<int, int>> neighbours = new List<Tuple<int, int>>();
            
            // check up
            int x = cell.Item1 - 1;
            int y = cell.Item2;
            if (IsNeighbour(x, y))
                neighbours.Add(new Tuple<int, int>(x, y));
            
            //check down
            x = cell.Item1 + 1;
            y = cell.Item2;
            if (IsNeighbour(x, y))
                neighbours.Add(new Tuple<int, int>(x, y));

            //check left
            x = cell.Item1;
            y = cell.Item2 - 1;
            if (IsNeighbour(x, y))
                neighbours.Add(new Tuple<int, int>(x, y));

            //check right
            x = cell.Item1;
            y = cell.Item2 + 1;
            if (IsNeighbour(x, y))
                neighbours.Add(new Tuple<int, int>(x, y));

            return neighbours;
        }

        static bool IsNeighbour(int x, int y)
        {
            if (InRange(x, y))
            {
                if (labyrinth[x, y] == '0')
                {
                    return true;
                }
            }
            return false;
        }

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < labyrinth.GetLength(0);
            bool colInRange = col >= 0 && col < labyrinth.GetLength(1);
            return rowInRange && colInRange;
        }

        static void PrintResult()
        {
            for (int row = 0; row < result.GetLength(0); row++)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    Console.Write("{0, 4}", result[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
