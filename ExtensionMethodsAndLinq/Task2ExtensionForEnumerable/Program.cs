using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2ExtensionForEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 2: Implement a set of extension methods for IEnumerable<T>
            // that implement the following group functions: sum, product,
            // min, max, average.

            int[] strArr = { 10, 20 };
            IEnumerable<int> arr2 = strArr;
            Console.WriteLine(arr2.MySum());
            Console.WriteLine(arr2.Product());
            Console.WriteLine(arr2.MyMin());
            Console.WriteLine(arr2.MyMax());
            Console.WriteLine(arr2.MyAverage());
        }
    }

    static class Extension
    {
        public static T MySum<T>(this IEnumerable<T> collection) where T: struct
        {
            return collection.Aggregate(default(T), (current, number) => (dynamic)current + number);
        }

        public static T Product<T>(this IEnumerable<T> collection) where T: struct
        {
            return collection.Aggregate((current, number) => (dynamic)current * number);
        }

        public static T MyMin<T>(this IEnumerable<T> collection) where T : struct
        {
            return collection.Min(num => num);
        }

        public static T MyMax<T>(this IEnumerable<T> collection) where T : struct
        {
            return collection.Max(num => num);
        }

        public static double MyAverage<T>(this IEnumerable<T> collection) where T : struct
        {
            return collection.Average(num => (dynamic)num);
        }
    }
}
