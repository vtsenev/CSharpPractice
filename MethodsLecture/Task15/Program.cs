using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 15: * Modify your last program and try to make it work for any number type,
            // not just integer (e.g. decimal, float, byte, etc.). Use generic method (read in
            // Internet about generic methods in C#).

            Console.Write("number of numbers = ");
            int setLength = int.Parse(Console.ReadLine());

            decimal[] set = new decimal[setLength];
            for (int i = 0; i < setLength; i++)
            {
                Console.Write("set[{0}] = ", i);
                set[i] = decimal.Parse(Console.ReadLine());
            }

            CalcMin<decimal>(ref set);
            CalcMax<decimal>(ref set);
            CalcAverage<decimal>(ref set);
            CalcSum<decimal>(ref set);
            CalcProduct<decimal>(ref set);
        }

        static void CalcMin<T>(ref T[] set) where T: IComparable<T>
        {
            T min = set.Min(a => a);
            Console.WriteLine("min = {0}", min);
        }

        static void CalcMax<T>(ref T[] set) where T : IComparable<T>
        {
            T max = set.Max(a => a);
            Console.WriteLine("max = {0}", max);
        }

        static void CalcAverage<T>(ref T[] set) where T : IConvertible
        {
            double average = set.Average(num => Convert.ToDouble(num));
            Console.WriteLine("average = {0}", average);
        }

        static void CalcSum<T>(ref T[] set) where T : IConvertible
        {
            double sum = set.Sum(num => Convert.ToDouble(num));
            Console.WriteLine("sum = {0}", sum);
        }

        static void CalcProduct<T>(ref T[] set)
        {
            dynamic product = 1;
            foreach (var item in set)
            {
                product *= item;
            }
            Console.WriteLine("product = {0}", product);
        }
    }
}
