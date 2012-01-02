using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = DoMatrixA(n);
            PrintMatrix(matrix);

            Console.WriteLine();

            matrix = DoMatrixB(n);
            PrintMatrix(matrix);

            Console.WriteLine();

            matrix = DoMatrixC(n);
            PrintMatrix(matrix);

            Console.WriteLine();

            matrix = DoMatrixD(n);
            PrintMatrix(matrix);

            Console.WriteLine();
        }

        static int[,] DoMatrixA(int dim)
        {
            int[,] matrix = new int[dim, dim];

            matrix[0, 0] = 1;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                matrix[0, i] = matrix[0, i - 1] + dim;
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = matrix[i - 1, j] + 1;
                }
            }

            return matrix;
        }

        static int[,] DoMatrixB(int dim)
        {
            int[,] matrix = new int[dim, dim];
            matrix[0, 0] = 1;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (i % 2 == 1)
                {
                    matrix[0, i] = matrix[0, i - 1] + dim * 2 - 1;
                }
                else
                {
                    matrix[0, i] = matrix[0, i - 1] + 1;
                }
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j % 2 == 1)
                    {
                        matrix[i, j] = matrix[i - 1, j] - 1;
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j] + 1;
                    }
                }
            }

            return matrix;
        }

        static int[,] DoMatrixC(int dim)
        {
            int[,] matrix = new int[dim, dim];
            matrix[dim - 1, 0] = 1;
            int counter = 1;
            for (int row = dim - 2; row >= 0; row--)
            {
                matrix[row, 0] = matrix[row + 1, 0] + counter;
                int newRow = row;
                for (int diagonal = 1; diagonal <= counter; diagonal++)
                {
                    matrix[newRow + 1, diagonal] = matrix[newRow, diagonal - 1] + 1;
                    newRow++;
                }
                counter++;
            }

            matrix[0, dim - 1] = dim * dim;
            int diagonalLength = 2;
            int posX = 1;
            int posY = dim - 1;
            int prevX = 0;
            int prevY = dim - 1;

            for (int i = 1; i < counter - 1; i++)
            {
                for (int j = 1; j <= diagonalLength; j++)
                {
                    matrix[posX, posY] = matrix[prevX, prevY] - 1;
                    prevX = posX;
                    prevY = posY;
                    posX--;
                    posY--;
                }
                diagonalLength++;
                posX = i + 1;
                posY = dim - 1;
            }

            return matrix;
        }

        static int[,] DoMatrixD(int dim)
        {
            int[,] matrix = new int[dim, dim];
            int numConcentricSquares = (int)Math.Ceiling((dim) / 2.0);
            int j;
            int sideLen = dim;
            int currNum = 0;

            for (int i = 0; i < numConcentricSquares; i++)
            {

                // do left side
                for (j = 0; j < sideLen; j++)
                {
                    matrix[i + j, i] = ++currNum;
                }

                // do bottom side
                for (j = 1; j < sideLen - 1; j++)
                {
                    matrix[dim - 1 - i, i + j] = ++currNum;
                }

                // do right side
                for (j = sideLen - 1; j > 0; j--)
                {
                    matrix[i + j, dim - 1 - i] = ++currNum;
                }

                // do top side
                for (j = sideLen - 1; j > 0; j--)
                {
                    matrix[i, i + j] = ++currNum;
                }

                sideLen -= 2;
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 4}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}