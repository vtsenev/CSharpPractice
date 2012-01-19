using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task14
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 14: Write methods to calculate minimum, maximum, average, sum and product
            //  of given set of integer numbers. Use variable number of arguments.

            Console.Write("number of numbers = ");
            int setLength = int.Parse(Console.ReadLine());

            int[] set = new int[setLength];
            for (int i = 0; i < setLength; i++)
            {
                Console.Write("set[{0}] = ", i);
                set[i] = int.Parse(Console.ReadLine());
            }

            CalcMin(set);
            CalcMax(set);
            CalcAverage(set);
            CalcSum(set);
            CalcProduct(set);
        }

        private static void CalcMin(int[] set)
        {
            int min = set.Min();
            Console.WriteLine("min = {0}", min);
        }

        private static void CalcMax(int[] set)
        {
            int max = set.Max();
            Console.WriteLine("max = {0}", max);
        }

        private static void CalcAverage(int[] set)
        {
            double average = set.Average();
            Console.WriteLine("average = {0}", average);
        }

        private static void CalcSum(int[] set)
        {
            int sum = set.Sum();
            Console.WriteLine("sum = {0}", sum);
        }

        private static void CalcProduct(int[] set)
        {
            int product = 1;
            foreach (int item in set)
            {
                product *= item;
            }
            Console.WriteLine("product = {0}", product);
        }
    }
}
