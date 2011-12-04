using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that reads from the console a positive integer number N (N < 20)
            // and outputs a matrix like the following:
	        // N = 3        N = 4
            // 1 2 3        1 2 3 4
            // 2 3 4        2 3 4 5
            // 3 4 5        3 4 5 6
            //              4 5 6 7

            Console.Write("N = ");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            if (n >= 20 || n < 1)
            {
                Console.WriteLine("N is a positive integer number (N < 20).");
                return;
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int current = col + row + 1;
                    if (col == n - 1)
                    {
                        Console.WriteLine("{0,3}", current);
                    }
                    else
                    {
                        Console.Write("{0,3} ", current);
                    }
                }
            }
        }
    }
}
