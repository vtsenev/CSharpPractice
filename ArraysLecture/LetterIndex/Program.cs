using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetterIndex
{
    class Program
    {

        static char[] letters = new char[26];

        static void Main(string[] args)
        {
            // Write a program that creates an array containing all letters from the alphabet (A-Z).
            // Read a word from the console and print the index of each of its letters in the array.

            for (int i = 65; i <= 90; i++)
            {
                letters[i - 65] = (char)i;
            }

            string word = Console.ReadLine();

            for (int i = 0; i < word.Length; i++)
            {
                Console.WriteLine("'{0}' index = {1}", word[i], FindIndex((int)word[i], 0, 25));
            }

        }

        static int FindIndex(int value, int low, int high)
        {
            if (high < low)
            {
                return -1;
            }
            int mid = (low + high) / 2;
            if (letters[mid] > value)
            {
                return FindIndex(value, low, mid - 1);
            }
            else if (letters[mid] < value)
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
