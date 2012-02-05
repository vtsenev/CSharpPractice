using System;
using System.IO;
using System.Collections.Generic;

namespace Task5ReadMatrixFindMaxSum
{
    class Program
    {
        const string INPUT = @"..\..\matrix.txt";
        const string OUTPUT = @"..\..\output.txt";
        static int[,] matrix;

        static void Main(string[] args)
        {
            // Task 5: Write a program that reads a text file containing 
            // a square matrix of numbers and finds in the matrix an area
            // of size 2 x 2 with a maximal sum of its elements. The first
            // line in the input file contains the size of matrix N. Each
            // of the next N lines contain N numbers separated by space. 
            // The output should be a single number in a separate text file.

            List<string> matrixAsString = new List<string>();
            int columnsCount;
            using (StreamReader reader = new StreamReader(INPUT))
            {
                columnsCount = int.Parse(reader.ReadLine());
                string matrixRow = reader.ReadLine();
                while (matrixRow != null)
                {
                    matrixAsString.Add(matrixRow);
                    matrixRow = reader.ReadLine();
                }
                matrix = new int[matrixAsString.Count, columnsCount];
            }

            for (int row = 0; row < matrixAsString.Count; row++)
            {
                string[] numbersAsString = matrixAsString[row].Split(' ');
                for (int col = 0; col < columnsCount; col++)
                {
                    matrix[row, col] = int.Parse(numbersAsString[col]);
                }
            }

            int bestSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > bestSum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(OUTPUT))
            {
                writer.WriteLine(bestSum);
            }
        }
    }
}
