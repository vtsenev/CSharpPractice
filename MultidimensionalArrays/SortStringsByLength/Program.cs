using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortStringsByLength
{
    class Program
    {
        static void Main(string[] args)
        {
            // You are given an array of strings. Write a method  
            // that sorts the array by the length of its elements
            // (the number of characters composing them).

            string[] arr = { "aaaaaaa", "aaa", "aa", "aaaa", "a" };
            Console.Write("original array: ");
            Print(arr);

            string[] sortedArr = Sort(arr);
            Console.Write("sorted based on string length: ");
            Print(sortedArr);
        }

        static void Print(string[] arr)
        {
            Console.Write("{");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" " + arr[i]);
            }
            Console.WriteLine("}");
        }

        static string[] Sort(string[] arr)
        {
            string[] result = new string[arr.Length];

            result = arr.OrderBy(item => item.Length).ToArray();

            return result;
        }
    }
}
