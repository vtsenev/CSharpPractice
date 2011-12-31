using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SumSofKElementsofNDimArray
{
    class Program
    {
        static void Main(string[] args)
        {
            // * Write a program that reads three integer numbers N, K and S and an array
            // of N elements from the console. Find in the array a subset of K elements
            // that have sum S or indicate about its absence.

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("s = ");
            int s = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("[{0}] = ", i);
                arr[i] = int.Parse(Console.ReadLine());
            }

            int usedSum;
            List<int> usedNums = new List<int>();
            List<int> unusedNums = arr.ToList();

            usedNums.Add(arr[0]);
            unusedNums.RemoveAt(0);
            usedSum = usedNums.Sum();

            while (usedSum != s || usedNums.Count != k)
            {
                if (s > usedSum)
                {
                    usedNums.Add(unusedNums[0]);
                    unusedNums.RemoveAt(0);
                    usedSum = usedNums.Sum();
                }
                else
                {
                    unusedNums.Add(usedNums[0]);
                    usedNums.RemoveAt(0);
                    usedSum = usedNums.Sum();
                }
            }

            Console.Write("yes (");
            foreach (int num in usedNums)
            {
                Console.Write(" {0}", num);
            }
            Console.WriteLine(" )");
        }
    }
}
