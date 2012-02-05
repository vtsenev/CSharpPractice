using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Task43DMaxWalk
{
    class Program
    {
        const string INPUT = @"..\..\test.009.in.txt";
        static short[, ,] cuboid;
        static List<KeyValuePair<int, Tuple<int, int, int>>> neighbours = new List<KeyValuePair<int, Tuple<int, int, int>>>();
        static List<Tuple<int, int, int>> visitedCubes = new List<Tuple<int,int,int>>();

        static void Main(string[] args)
        {
            Input();
            //InputFromFile();
            
            //calculate starting position
            int x = cuboid.GetLength(0) / 2;
            int y = cuboid.GetLength(1) / 2;
            int z = cuboid.GetLength(2) / 2;

            visitedCubes.Add(new Tuple<int, int, int>(x, y, z));

            Walk3D(x, y, z);
        }

        static void InputFromFile()
        {
            char[] empty = { ' ' };
            StreamReader reader = new StreamReader(INPUT);
            using (reader)
            {
                string input = reader.ReadLine();
                string[] whd = input.Split(empty);
                int w = int.Parse(whd[0]);
                int h = int.Parse(whd[1]);
                int d = int.Parse(whd[2]);

                cuboid = new short[w, h, d];

                for (int y = 0; y < h; y++)
                {
                    input = reader.ReadLine();
                    string[] sequences = input.Split('|');
                    for (int z = 0; z < d; z++)
                    {
                        string[] sequence = sequences[z].Split(empty, StringSplitOptions.RemoveEmptyEntries);
                        for (int x = 0; x < w; x++)
                        {
                            cuboid[x, y, z] = short.Parse(sequence[x]);
                        }
                    }
                }
            }
        }

        static void Input()
        {
            string input = Console.ReadLine();
            string[] whd = input.Split(' ');
            int w = int.Parse(whd[0]);
            int h = int.Parse(whd[1]);
            int d = int.Parse(whd[2]);

            cuboid = new short[w, h, d];

            for (int y = 0; y < h; y++)
            {
                input = Console.ReadLine();
                string[] sequences = input.Split('|');
                for (int z = 0; z < d; z++)
                {
                    string[] sequence = sequences[z].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int x = 0; x < w; x++)
                    {
                        cuboid[x, y, z] = short.Parse(sequence[x]);
                    }
                }
            }
        }

        static void Walk3D(int x, int y, int z)
        {
            // check for neighbours
            CheckForNeighbours(x, y, z);
            
            neighbours.Sort(
                delegate(KeyValuePair<int, Tuple<int, int, int>> firstPair,
                KeyValuePair<int, Tuple<int, int, int>> nextPair)
                {
                    return firstPair.Key.CompareTo(nextPair.Key);
                }
            );
            
            if (neighbours.Count == 0 || neighbours[neighbours.Count - 1].Key == neighbours[neighbours.Count - 2].Key)
            {
                CalculateResult();
                return;
            }

            if (visitedCubes.Contains(neighbours[neighbours.Count - 1].Value))
            {
                CalculateResult();
                return;
            }

            visitedCubes.Add(neighbours[neighbours.Count - 1].Value);

            int newX = neighbours[neighbours.Count - 1].Value.Item1;
            int newY = neighbours[neighbours.Count - 1].Value.Item2;
            int newZ = neighbours[neighbours.Count - 1].Value.Item3;
            neighbours.Clear();
            Walk3D(newX, newY, newZ);
        }

        static void CheckForNeighbours(int x, int y, int z)
        {
            // check right and left
            for (int row = 0; row < cuboid.GetLength(0); row++)
            {
                if (row != x)
                {
                    //if (!neighbours.Contains(new KeyValuePair<int, Tuple<int, int, int>>(cuboid[row, y, z], new Tuple<int, int, int>(row, y, z))))
                    //{
                        neighbours.Add(new KeyValuePair<int, Tuple<int, int, int>>(cuboid[row, y, z], new Tuple<int, int, int>(row, y, z)));
                    //}
                }
            }

            // check up and down
            for (int col = 0; col < cuboid.GetLength(1); col++)
            {
                if (col != y)
                {
                    //if (!neighbours.Contains(new KeyValuePair<int, Tuple<int, int, int>>(cuboid[x, col, z], new Tuple<int, int, int>(x, col, z))))
                    //{
                        neighbours.Add(new KeyValuePair<int, Tuple<int, int, int>>(cuboid[x, col, z], new Tuple<int, int, int>(x, col, z)));
                    //}
                }
            }

            // check inwards and outwards
            for (int d = 0; d < cuboid.GetLength(2); d++)
            {
                if (d != z)
                {
                    //if (!neighbours.Contains(new KeyValuePair<int, Tuple<int, int, int>>(cuboid[x, y, d], new Tuple<int, int, int>(x, y, d))))
                    //{
                        neighbours.Add(new KeyValuePair<int, Tuple<int, int, int>>(cuboid[x, y, d], new Tuple<int, int, int>(x, y, d)));
                    //}
                }
            }
        }

        static void CalculateResult()
        {
            int sum = 0;
            foreach (Tuple<int, int, int> tuple in visitedCubes)
            {
                sum += cuboid[tuple.Item1, tuple.Item2, tuple.Item3];
            }
            Console.WriteLine(sum);
        }
    }
}
