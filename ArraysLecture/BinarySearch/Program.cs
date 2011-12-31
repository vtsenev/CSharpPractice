using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearch
{
    class Program
    {

        static int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 20, 25, 26, 27, 28, 29, 100 };

        static void Main(string[] args)
        {
            // Write a program that finds the index of given element
            // in a sorted array of integers by using the binary 
            // search algorithm (find it in Wikipedia).

            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("index = {0}", FindIndex(num, 0, arr.Length - 1));
        }

        static int FindIndex(int value, int low, int high)
        {
            if (high < low)
            {
                return -1;
            }
            int mid = (low + high) / 2;
            if (arr[mid] > value)
            {
                return FindIndex(value, low, mid - 1);
            }
            else if (arr[mid] < value)
            {
                return FindIndex(value, mid + 1, high);
            }
            else
            {
                return mid;
            }
        }
    }
}
