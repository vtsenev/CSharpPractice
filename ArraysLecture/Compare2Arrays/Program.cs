using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compare2Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that reads two arrays from the
            // console and compares them element by element.

            const int LENGTH = 5;
            int[] arr1 = new int[LENGTH];
            int[] arr2 = new int[LENGTH];

            for (int i = 0; i < LENGTH; i++)
            {
                Console.Write("arrayOne[{0}] = ", i);
                string input = Console.ReadLine();
                arr1[i] = int.Parse(input);
                Console.Write("arrayTwo[{0}] = ", i);
                input = Console.ReadLine();
                arr2[i] = int.Parse(input);

                if (arr1[i] > arr2[i])
                {
                    Console.WriteLine("arrayOne[{0}] = {1} > {2} = arrayTwo[{0}]", i, arr1[i], arr2[i]);
                }
                else if (arr1[i] < arr2[i])
                {
                    Console.WriteLine("arrayOne[{0}] = {1} < {2} = arrayTwo[{0}]", i, arr1[i], arr2[i]);
                }
                else
                {
                    Console.WriteLine("arrayOne[{0}] = {1} = {2} = arrayTwo[{0}]", i, arr1[i], arr2[i]);
                }
            }
        }
    }
}
