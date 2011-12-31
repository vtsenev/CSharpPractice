using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that sorts an array of strings
            // using the quick sort algorithm (find it in Wikipedia).

            const int CAPACITY = 20000;

            int[] arr = new int[CAPACITY];

            Stopwatch sw = new Stopwatch();
            sw.Start();
            QSort sorter = new QSort();
            sorter.Sort(arr, 0, arr.Length - 1);
            sw.Stop();
            Console.WriteLine("Array Items: {0}  Time: {1}", arr.Length, sw.Elapsed);
            // PrintArr(arr);
        }

        static void PrintArr(int[] arr)
        {
            Console.Write("{ ");
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Console.Write("{0}, ", arr[i]);
            }
            Console.Write("{0} ", arr[arr.Length - 1]);
            Console.WriteLine("}");
        }

    }

    class QSort
    {
        private static void swap(int[] Array, int Left, int Right)
        {
            int temp = Array[Right];
            Array[Right] = Array[Left];
            Array[Left] = temp;
        }

        public void Sort(int[] Array, int Left, int Right)
        {
            int LHold = Left;
            int RHold = Right;
            int Pivot = Left;
            Left++;

            while (Right >= Left)
            {
                if (Array[Left] >= Array[Pivot]
                        && Array[Right] < Array[Pivot])
                    swap(Array, Left, Right);
                else if (Array[Left] >= Array[Pivot])
                    Right--;
                else if (Array[Right] < Array[Pivot])
                    Left++;
                else
                {
                    Right--;
                    Left++;
                }
            }

            swap(Array, Pivot, Right);
            Pivot = Right;
            if (Pivot > LHold)
                Sort(Array, LHold, Pivot);
            if (RHold > Pivot + 1)
                Sort(Array, Pivot + 1, RHold);
        }
    }
}
