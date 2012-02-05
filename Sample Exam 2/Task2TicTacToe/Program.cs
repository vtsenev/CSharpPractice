using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Task2TicTacToe
{
    class Program
    {
        static int[,] board = new int[3, 3];
        const string INPUT = @"..\..\input.txt";
        static int xwins = 0;
        static int owins = 0;
        static int draws = 0;

        static void Main(string[] args)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            Input();
            //InputFile();

            if (EmptyCells() % 2 == 0)
            {
                Play(-1);
            }
            else
            {
                Play(1);
            }

            Console.WriteLine(xwins);
            Console.WriteLine(draws);
            Console.WriteLine(owins);
            //sw.Stop();
            //Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static void InputFile()
        {
            using (StreamReader reader = new StreamReader(INPUT))
            {
                for (int i = 0; i < 3; i++)
                {
                    string input = reader.ReadLine();
                    for (int j = 0; j < 3; j++)
                    {
                        if (input[j] == 'X')
                        {
                            board[i, j] = 1;
                        }
                        else if (input[j] == 'O')
                        {
                            board[i, j] = -1;
                        }
                        else
                        {
                            board[i, j] = 0;
                        }
                    }
                }
            }
        }

        static void Input()
        {
            for (int i = 0; i < 3; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < 3; j++)
                {
                    if (input[j] == 'X')
                    {
                        board[i, j] = 1;
                    }
                    else if (input[j] == 'O')
                    {
                        board[i, j] = -1;
                    }
                    else
                    {
                        board[i, j] = 0;
                    }
                }
            }
        }

        static int CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 2] == board[i, 0] && board[i, 0] != 0)
                {
                    return board[i, 0];
                }
                if (board[0, i] == board[1, i] && board[2, i] == board[0, i] && board[0, i] != 0)
                {
                    return board[0, i];
                }
            }

            if (board[1, 1] == board[0, 0] && board[1, 1] == board[2, 2] && board[1, 1] != 0)
            {
                return board[1, 1];
            }
            if (board[1, 1] == board[0, 2] && board[1, 1] == board[2, 0] && board[1, 1] != 0)
            {
                return board[1, 1];
            }
            return 0;
        }

        static bool Full()
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static int EmptyCells()
        {
            int counter = 0;
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 0)
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        static void Play(int player)
        {
            int score = CheckWinner();

            if (score != 0)
            {
                if (score == 1)
                {
                    xwins++;
                }
                else
                {
                    owins++;
                }
                return;
            }

            if (score == 0 && Full())
            {
                draws++;
                return;
            }

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] != 0)
                    {
                        continue;
                    }

                    board[row, col] = player;
                    Play(-player);
                    board[row, col] = 0;
                }
            }
        }
    }
}
