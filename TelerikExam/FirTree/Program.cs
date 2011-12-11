using System;

namespace FirTree
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(input);

            int lineLength = ((n - 1) * 2) - 1;

            int asterisks = 1;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 2 - i; j++)
                {
                    Console.Write(".");
                }
                for (int j = 0; j < asterisks; j++)
                {
                    Console.Write("*");
                }
                for (int j = 0; j < n - 2 - i; j++)
                {
                    Console.Write(".");
                }
                Console.WriteLine();
                asterisks += 2;
            }

            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write(".");
            }
        }
    }
}
