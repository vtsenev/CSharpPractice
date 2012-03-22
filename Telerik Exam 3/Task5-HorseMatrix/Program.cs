using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Task5_HorseMatrix
{
    class Program
    {
        static int N;
        static char[,] board;
        const string INPUT_PATH = @"../../in.txt";

        static Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>>();
        static Dictionary<Tuple<int, int>, Tuple<int, int>> parentTree = new Dictionary<Tuple<int, int>, Tuple<int, int>>();
        static Tuple<int, int> startPoint;

        static void Main(string[] args)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //InputFromFile();
            InputFromConsole();
            //q.Enqueue(startPoint);
            //BreadthFirstSearch();
            BFS();
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds + "ms");
        }

        static void InputFromConsole()
        {
            N = int.Parse(Console.ReadLine());
            board = new char[N, N];
            for (int i = 0; i < N; i++)
            {
                string line = Console.ReadLine();
                int col = 0;
                for (int j = 0; j < N * 2 - 1; j++)
                {
                    if (!char.IsWhiteSpace(line[j]))
                    {
                        board[i, col] = line[j];
                        if (line[j] == 's')
                        {
                            startPoint = new Tuple<int, int>(i, col);
                        }
                        col++;
                    }
                }
            }
        }
        
        static void InputFromFile()
        {
            using (StreamReader sr = new StreamReader(INPUT_PATH))
            {
                N = int.Parse(sr.ReadLine());
                board = new char[N, N];
                for (int i = 0; i < N; i++)
                {
                    string line = sr.ReadLine();
                    int col = 0;
                    for (int j = 0; j < N * 2 - 1; j++)
                    {
                        if (!char.IsWhiteSpace(line[j]))
                        {
                            board[i, col] = line[j];
                            if (line[j] == 's')
                            {
                                startPoint = new Tuple<int, int>(i, col);
                            }
                            col++;
                        }
                    }
                }
            }
        }

        static void PrintBoard()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void BFS()
        {
            q.Enqueue(startPoint);
            board[startPoint.Item1, startPoint.Item2] = 'p';
            while (q.Count > 0)
            {
                Tuple<int, int> cell = q.Dequeue();
                List<Tuple<int, int>> possibleMoves = GetNextMoveCoords(cell);
                foreach (var coords in possibleMoves)
                {
                    if (IsLegalMove(coords.Item1, coords.Item2))
                    {
                        if (!parentTree.ContainsKey(coords))
                        {
                            parentTree.Add(coords, cell);
                        }
                        if (board[coords.Item1, coords.Item2] == 'e')
                        {
                            GetPath(coords.Item1, coords.Item2);
                            return;
                        }
                        q.Enqueue(coords);
                        board[coords.Item1, coords.Item2] = 'p';
                    }
                }
            }
            Console.WriteLine("No");
        }

        static List<Tuple<int, int>> GetNextMoveCoords(Tuple<int, int> cell)
        {
            List<Tuple<int, int>> possibleMoves = new List<Tuple<int, int>>();
            possibleMoves.Add(new Tuple<int, int>(cell.Item1 - 1, cell.Item2 - 2));
            possibleMoves.Add(new Tuple<int, int>(cell.Item1 - 2, cell.Item2 - 1));
            possibleMoves.Add(new Tuple<int, int>(cell.Item1 - 2, cell.Item2 + 1));
            possibleMoves.Add(new Tuple<int, int>(cell.Item1 - 1, cell.Item2 + 2));
            possibleMoves.Add(new Tuple<int, int>(cell.Item1 + 1, cell.Item2 + 2));
            possibleMoves.Add(new Tuple<int, int>(cell.Item1 + 2, cell.Item2 + 1));
            possibleMoves.Add(new Tuple<int, int>(cell.Item1 + 2, cell.Item2 - 1));
            possibleMoves.Add(new Tuple<int, int>(cell.Item1 + 1, cell.Item2 - 2));
            return possibleMoves;
        }

        static bool IsLegalMove(int x, int y)
        {
            bool inRange = InRange(x, y);
            if (!inRange)
            {
                return false;
            }
            bool passable = !(board[x, y] == 'x');
            bool unvisited = !(board[x, y] == 'p');
            return passable && unvisited;
        }

        static void GetPath(int endX, int endY)
        {
            int pathLength = 0;
            Tuple<int, int> cell = new Tuple<int, int>(endX, endY);
            Tuple<int, int> parentCell = parentTree[cell];
            while (parentTree.ContainsKey(parentCell))
            {
                cell = parentCell;
                parentCell = parentTree[cell];
                pathLength++;
            }
            Console.WriteLine(pathLength + 1);
        }

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < board.GetLength(0);
            bool colInRange = col >= 0 && col < board.GetLength(1);
            return rowInRange && colInRange;
        }
    }
}
