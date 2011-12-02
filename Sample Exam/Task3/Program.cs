using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(input);
            int mapHeight = 2 * n - 1;
            char[,] map = new char[mapHeight, n];
            int[] passedLocations = new int[mapHeight];

            passedLocations[0] = 0;
            int moveLeft = 2;
            for (int i = 0; i < mapHeight; i++)
            {
                
                if (i < n)
                {
                    passedLocations[i] = i;
                }
                else
                {
                    passedLocations[i] = n - moveLeft;
                    moveLeft++;
                }
                
                for (int j = 0; j < n; j++)
                {
                    if (j != passedLocations[i])
                    {
                        map[i, j] = '.';
                    }
                    else
                    {
                        map[i, j] = '*';
                    }
                }
            }

            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j != n - 1)
                    {
                        Console.Write(map[i, j]);
                    }
                    else
                    {
                        Console.WriteLine(map[i, j]);
                    }
                }
            }
        }
    }
}
