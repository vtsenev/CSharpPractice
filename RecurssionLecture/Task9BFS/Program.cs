using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task9BFS
{
    class Program
    {
        static char[,] lab = 
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
        };

        static Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
        static Dictionary<Tuple<int, int>, Tuple<int, int>> parentTree = new Dictionary<Tuple<int, int>, Tuple<int, int>>();

        static void Main(string[] args)
        {
            // Task 9: Implement the BFS algorithm to find the shortest path between
            // two cells in a matrix (read about Breath-First Search in Wikipedia).
            
            q.Enqueue(new Tuple<int, int>(0, 0));
            BreadthFirstSearch();
        }

        static void BreadthFirstSearch()
        {
            Tuple<int, int> cell = q.Dequeue();
            
            if (lab[cell.Item1, cell.Item2] == 'e')
            {
                Console.WriteLine("path found");
                GetPath();
                return;
            }

            int qCount = q.Count;

            lab[cell.Item1, cell.Item2] = 's';

            if (InRange(cell.Item1, cell.Item2 + 1) && lab[cell.Item1, cell.Item2 + 1] != '*' && lab[cell.Item1, cell.Item2 + 1] != 's')
            {
                q.Enqueue(new Tuple<int, int>(cell.Item1, cell.Item2 + 1));
            }
            if (InRange(cell.Item1 + 1, cell.Item2) && lab[cell.Item1 + 1, cell.Item2] != '*' && lab[cell.Item1 + 1, cell.Item2] != 's')
            {
                q.Enqueue(new Tuple<int, int>(cell.Item1 + 1, cell.Item2));
            }
            if (InRange(cell.Item1 - 1, cell.Item2) && lab[cell.Item1 - 1, cell.Item2] != '*' && lab[cell.Item1 - 1, cell.Item2] != 's')
            {
                q.Enqueue(new Tuple<int, int>(cell.Item1 - 1, cell.Item2));
            }
            if (InRange(cell.Item1, cell.Item2 - 1) && lab[cell.Item1, cell.Item2 - 1] != '*' && lab[cell.Item1, cell.Item2 - 1] != 's')
            {
                q.Enqueue(new Tuple<int, int>(cell.Item1, cell.Item2 - 1));
            }
            
            if (q.Count == 0)
            {
                Console.WriteLine("path not found");
                return;
            }

            foreach (var newCell in q)
            {
                if (!parentTree.ContainsKey(newCell))
                {
                    parentTree.Add(newCell, cell);
                }
            }

            BreadthFirstSearch();
        }

        static void GetPath()
        {
            // coords of end cell 4 and 6 in this case
            int pathLength = 0;
            Tuple<int, int> cell = new Tuple<int,int>(4, 6);
            Tuple<int, int> parentCell = parentTree[cell];
            while (parentTree.ContainsKey(parentCell))
            {
                Console.WriteLine("{0}, {1} - > {2}, {3}", cell.Item1, cell.Item2, parentCell.Item1, parentCell.Item2);
                cell = parentCell;
                parentCell = parentTree[cell];
                pathLength++;
            }
            Console.WriteLine("{0}, {1} - > {2}, {3}", cell.Item1, cell.Item2, parentCell.Item1, parentCell.Item2);
            Console.WriteLine("path length = {0}", pathLength + 1);
        }

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
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
