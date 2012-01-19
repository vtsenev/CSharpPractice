using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 8: Write a method that adds two positive integer numbers
            // represented as arrays of digits (each array element arr[i]
            // contains a digit; the last digit is kept in arr[0]). Each of
            // the numbers that will be added could have up to 10 000 digits.

            int[] num1 = { 9, 9, 9 };
            int[] num2 = { 1, 3, 4 };

            Print(num1);
            Console.WriteLine("+");
            Print(num2);
            Console.WriteLine("------");

            int[] num3 = Sum(num1, num2);

            Print(num3);
        }

        private static int[] Sum(int[] num1, int[] num2)
        {
            int[] sum;

            int digitCount = GetMax(num1.Length, num2.Length);
            sum = new int[digitCount + 1];

            Array.Reverse(num1);
            Array.Reverse(num2);

            int remainder = 0;

            for (int i = 0; i <= digitCount; i++)
            {
                if (i > num1.Length - 1 && i > num2.Length - 1)
                {
                    sum[i] = remainder;
                }
                else if (i > num1.Length - 1)
                {
                    sum[i] = num2[i] + remainder;
                    remainder = 0;
                }
                else if (i > num2.Length - 1)
                {
                    sum[i] = num1[i] + remainder;
                    remainder = 0;
                }
                else
                {
                    if (num1[i] + num2[i] + remainder < 10)
                    {
                        sum[i] = num1[i] + num2[i] + remainder;
                        remainder = 0;
                    }
                    else
                    {
                        sum[i] = (num1[i] + num2[i] + remainder) % 10;
                        remainder = 1;
                    }
                }
            }

            Array.Reverse(sum);

            return sum;
        }

        static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0 && array[i] == 0)
                {
                    continue;
                }
                Console.Write(array[i]);
            }
            Console.WriteLine();
        }

        static int GetMax(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
