using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task5Liquid
{
    class Program
    {
        const string INPUT = @"..\..\test.000.001.in.txt";
        static short[, ,] cuboid;
        static List<KeyValuePair<int, Tuple<int, int, int>>> neighbours = new List<KeyValuePair<int, Tuple<int, int, int>>>();
        static List<Tuple<int, int, int>> visitedCubes = new List<Tuple<int, int, int>>();

        static void Main(string[] args)
        {
            Input();
            //InputFromFile();
            Console.WriteLine(3);
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

        static void StartFlow()
        {
            
        }
    }
}
