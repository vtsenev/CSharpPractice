using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trapezoid
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(input);

            int bottomWidth = 2 * n;
            int height = n + 1;

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (j == 0)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("*");
                    }
                }
            }
            Console.WriteLine();
            for (int i = 0; i < height - 2; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                for (int j = 0; j < n + i - 1; j++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
                Console.WriteLine();
            }

            for (int i = 0; i < bottomWidth; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
