using System;
using System.Collections.Generic;

namespace Odd_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(input);

            long[] numbers = new long[n];
            Dictionary<long, int> occurences = new Dictionary<long, int>();
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                numbers[i] = long.Parse(input);
                if (occurences.ContainsKey(numbers[i]))
                {
                    occurences[numbers[i]]++;
                }
                else
                {
                    occurences.Add(numbers[i], 1);
                }
            }

            foreach (KeyValuePair<long, int> pair in occurences)
            {
                if (pair.Value % 2 != 0)
                {
                    Console.WriteLine(pair.Key);
                }
            }
        }
    }
}
