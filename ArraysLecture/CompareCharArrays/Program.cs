using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that compares two char
            // arrays lexicographically (letter by letter).

            Console.Write("Enter arrayOne length = ");
            string input = Console.ReadLine();
            int l1 = int.Parse(input);
            char[] arr1 = new char[l1];
            Console.Write("Enter arrayTwo length = ");
            input = Console.ReadLine();
            int l2 = int.Parse(input);
            char[] arr2 = new char[l2];

            for (int i = 0; i < l1; i++)
            {
                Console.Write("arrayOne[{0}] = ", i);
                input = Console.ReadLine();
                arr1[i] = char.Parse(input);
            }

            for (int i = 0; i < l2; i++)
            {
                Console.Write("arrayTwo[{0}] = ", i);
                input = Console.ReadLine();
                arr2[i] = char.Parse(input);
            }

            char[] lesser = Compare(arr1, arr2);

            for (int i = 0; i < lesser.Length; i++)
            {
                Console.Write(lesser[i]);
            }
            if (arr1.Equals(lesser))
            {
                Console.Write(" < ");
                for (int i = 0; i < arr2.Length; i++)
                {
                    Console.Write(arr2[i]);
                }
            }
            else
            {
                Console.Write(" < ");
                for (int i = 0; i < arr1.Length; i++)
                {
                    Console.Write(arr1[i]);
                }
            }

            Console.WriteLine();
        }

        static char[] Compare(char[] a, char[] b)
        {
            char[] result;

            if (a.Length > b.Length)
            {
                result = b;
            }
            else
            {
                result = a;
            }
            int min = Math.Min(a.Length, b.Length);
            for (int i = 0; i < min; i++)
            {
                if (a[i] < b[i])
                {
                    result = a;
                    break;
                }
                else if (a[i] > b[i])
                {
                    result = b;
                    break;
                }
            }

            return result;
        }
    }
}
