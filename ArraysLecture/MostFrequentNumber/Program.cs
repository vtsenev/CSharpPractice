using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that finds the most frequent number in an array.
            // Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

            int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            Dictionary<int, int> frequencyMeter = new Dictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (frequencyMeter.ContainsKey(arr[i]))
                {
                    frequencyMeter[arr[i]]++;
                }
                else
                {
                    frequencyMeter.Add(arr[i], 1);
                }
            }

            int maxOccurences = frequencyMeter.ElementAt(0).Value;
            int number = frequencyMeter.ElementAt(0).Key;
            foreach (KeyValuePair<int, int> pair in frequencyMeter)
            {
                if (pair.Value > maxOccurences)
                {
                    maxOccurences = pair.Value;
                    number = pair.Key;
                }
            }

            Console.WriteLine("{0} ({1} times)", number, maxOccurences);
        }
    }
}
