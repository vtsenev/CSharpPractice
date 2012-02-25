using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4FindLongestSubsequence
{
    class Program
    {
        static List<int> sequence = new List<int>();

        static void Main(string[] args)
        {
            // Task 4: Write a method that finds the longest subsequence of equal
            // numbers in given List<int> and returns the result as new List<int>.
            // Write a program to test whether the method works correctly.

            Input();
            List<int> longestSubsequence = FindSubsequence();
                
            foreach (int num in longestSubsequence)
            {
                Console.WriteLine(num);
            }
        }

        static void Input()
        {
            string input = Console.ReadLine();
            while (input != string.Empty)
            {
                int number = 0;
                if (int.TryParse(input, out number))
                    sequence.Add(number);

                input = Console.ReadLine();
            }
        }

        static List<int> FindSubsequence()
        {
            sequence.Sort();
            int maxOccurences = int.MinValue;
            int currentOccurences = 1;
            int value = sequence[0];
            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] == sequence[i - 1])
                {
                    currentOccurences++;
                }
                else
                {
                    if (currentOccurences > maxOccurences)
                    {
                        maxOccurences = currentOccurences;
                        currentOccurences = 1;
                        value = sequence[i - 1];
                    }
                }
            }

            List<int> subsequence = new List<int>();
            for (int i = 0; i < maxOccurences; i++)
                subsequence.Add(value);

            return subsequence;
        }
    }
}
