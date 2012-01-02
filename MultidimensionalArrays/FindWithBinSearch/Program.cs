using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindWithBinSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program, that reads from the console an array of N integers
            // and an integer K, sorts the array and using the method Array.BinSearch() 
            // finds the largest number in the array which is ≤ K.

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("[{0}] = ", i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());

            Array.Sort(arr);
            int pos = Array.BinarySearch(arr, k);

            if (pos >= 0)
            {
                Console.WriteLine("k = {0} found, index = {1}", arr[pos], pos);
            }
            else
            {
                pos = (pos * (-1)) - 2;
                Console.WriteLine("array[{0}] = {1} <= {2}", pos, arr[pos], k);
            }
        }
    }
}
