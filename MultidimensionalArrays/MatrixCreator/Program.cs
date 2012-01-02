using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixCreator
{
    
    public class Matrix
    {

        protected int[,] matrix;

        public Matrix(int rowsNum, int colsNum)
        {
            matrix = new int[rowsNum, colsNum];
        }

        public int this[int row, int col]
        {
            get { return matrix[row, col]; }
            set { matrix[row, col] = value; }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            int aRows = a.GetLength(0);
            int aCols = a.GetLength(1);

            int bRows = b.GetLength(0);
            int bCols = b.GetLength(1);

            // check if dimensions are not equal
            if (aRows != bRows || aCols != bCols)
            {
                throw new ArgumentException("Matrix dimensions don't allow the operation.");
            }

            // perform addition
            Matrix c = new Matrix(aRows, aCols);
            for (int row = 0; row < aRows; row++)
            {
                for (int col = 0; col < aCols; col++)
                {
                    c[row, col] = a[row, col] + b[row, col];
                }
            }

            return c;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            int aRows = a.GetLength(0);
            int aCols = a.GetLength(1);

            int bRows = b.GetLength(0);
            int bCols = b.GetLength(1);

            // check if dimensions are not equal
            if (aRows != bRows || aCols != bCols)
            {
                throw new ArgumentException("Matrix dimensions don't allow the operation.");
            }

            // perform subtraction
            Matrix c = new Matrix(aRows, aCols);
            for (int row = 0; row < aRows; row++)
            {
                for (int col = 0; col < aCols; col++)
                {
                    c[row, col] = a[row, col] - b[row, col];
                }
            }

            return c;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            int aRows = a.GetLength(0);
            int aCols = a.GetLength(1);

            int bRows = b.GetLength(0);
            int bCols = b.GetLength(1);

            // check if dimensions are not equal
            if (aCols != bRows)
            {
                throw new ArgumentException("Matrix dimensions don't allow the operation.");
            }

            // perform subtraction
            Matrix c = new Matrix(aRows, aCols);
            for (int row = 0; row < aRows; row++)
            {
                for (int col = 0; col < bCols; col++)
                {
                    c[row, col] = 0;
                    for (int i = 0; i < aCols; i++)
                    {
                        c[row, col] += a[row, i] * b[i, col];
                    }
                }
            }

            return c;
        }
        
        public override string ToString()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            string result = "";
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result += "   ";
                    result += matrix[row, col];
                }
                result += "\n";
            }
            return result;
        }

        private int GetLength(int level)
        {
            // level 0 - for rows
            // level 1 - for cols
            return this.matrix.GetLength(level);
        }
    }

    public static class ArrayExtension
    {
        // This is an extension method to convert Array to Matrix.
        public static Matrix ToMatrix(this int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            Matrix result = new Matrix(rows, cols);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = arr[row, col];
                }
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // * Write a class Matrix, to holds a matrix of integers. 
            // Overload the operators for adding, subtracting and 
            // multiplying of matrices, indexer for accessing the 
            // matrix content and ToString().

            int[,] a = 
            {
                {1, 2, 3},
                {2, 3, 4},
                {5, 6, 7},
            };

            int[,] b = 
            {
                {8, 9, 3},
                {10,2, 4},
                {1, 1, 1},
            };

            Matrix m1 = a.ToMatrix();
            Matrix m2 = b.ToMatrix();

            Matrix sum = m1 + m2;
            Matrix product = m1 * m2;

            Console.WriteLine(sum.ToString());
            Console.WriteLine(product.ToString());
        }
    }

    
}
