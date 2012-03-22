using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Tubes
{
    class Program
    {
        static int N;
        static int M;
        static int[] tubes;
        const string INPUT_PATH = @"../../in.txt";

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //Input();
            InputFromFile();
            long optimalSize = CalculateOptimalSize();
            long tubes = CountTubes(optimalSize);
            if (tubes == M)
            {
                Console.WriteLine(optimalSize);
            }
            else
            {
                Console.WriteLine(optimalSize - 1);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static void Input()
        {
            N = int.Parse(Console.ReadLine());
            M = int.Parse(Console.ReadLine());
            tubes = new int[N];
            for (int i = 0; i < N; i++)
            {
                tubes[i] = int.Parse(Console.ReadLine());
            }
        }

        static void InputFromFile()
        {
            using (StreamReader sr = new StreamReader(INPUT_PATH))
            {
                N = int.Parse(sr.ReadLine());
                M = int.Parse(sr.ReadLine());
                tubes = new int[N];
                for (int i = 0; i < N; i++)
                {
                    tubes[i] = int.Parse(sr.ReadLine());
                }
            }
        }

        static long CalculateOptimalSize()
        {
            long allTubes = 0;
            for (int i = 0; i < tubes.Length; i++)
            {
                allTubes += tubes[i];
            }
            long maxSize = allTubes / M;
            if (CountTubes(maxSize) == M)
            {
                return maxSize;
            }
            return FindSolution(M, 0, maxSize);
        }

        static long CountTubes(long size)
        {
            long tubeCount = 0;
            for (int i = 0; i < N; i++)
            {
                tubeCount += (tubes[i] / size);
            }
            return tubeCount;
        }

        static long FindSolution(int value, long low, long high)
        {
            if (high < low)
            {
                return -1;
            }
            if (low == high)
            {
                return low;
            }
            long mid = (low + high) / 2;
            if (CountTubes(mid) < value)
            {
                return FindSolution(value, low, mid - 1);
            }
            else if (CountTubes(mid) > value)
            {
                return FindSolution(value, mid + 1, high);
            }
            else
            {
                if (low == high)
                {
                    return mid;
                }
                else
                {
                    return FindSolution(value, mid + 1, high);
                }
            }
        }
    }
}
