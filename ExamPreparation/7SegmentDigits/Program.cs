using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using System.IO;

namespace _7SegmentDigits
{
    class Program
    {
        static int numberOfDigitsOnDisplay;
        static List<string> allSegments;
        static List<int> possibleDigits = new List<int>();
        static List<List<int>> allDigits = new List<List<int>>();
        static int combinationsCount;
        const string OUTPUT_PATH = @"../../out.txt";
        const string INPUT_PATH = @"../../in.txt";

        static void Main(string[] args)
        {
            //ReadInput();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ReadFromFile();
            FindAllDigits();
            FindCombinationsCount();
            GenerateAndPrintCombinations();
            sw.Stop();
            Console.WriteLine("Total time: " + sw.ElapsedMilliseconds + "ms");
        }

        static void ReadInput()
        {
            numberOfDigitsOnDisplay = int.Parse(Console.ReadLine());
            allSegments = new List<string>();
            for (int i = 0; i < numberOfDigitsOnDisplay; i++)
            {
                string digitSegments = Console.ReadLine();
                allSegments.Add(digitSegments);
            }
        }

        static void ReadFromFile()
        {
            using (StreamReader sr = new StreamReader(INPUT_PATH))
            {
                numberOfDigitsOnDisplay = int.Parse(sr.ReadLine());
                allSegments = new List<string>();
                for (int i = 0; i < numberOfDigitsOnDisplay; i++)
                {
                    string digitSegments = sr.ReadLine();
                    allSegments.Add(digitSegments);
                }
            }
        }

        static int ConvertSegmentsToDigit(string digitSegments)
        {
            switch (digitSegments)
            {
                case "1111110": return 0;
                case "0110000": return 1;
                case "1101101": return 2;
                case "1111001": return 3;
                case "0110011": return 4;
                case "1011011": return 5;
                case "1011111": return 6;
                case "1110000": return 7;
                case "1111111": return 8;
                case "1111011": return 9;
                default: return -1;
            }
        }

        static void FindPossibleDigits(string digitSegments, int index)
        {
            int digit = ConvertSegmentsToDigit(digitSegments);
            AddValidDigit(digit);

            if (index >= digitSegments.Length)
            {
                return;
            }

            for (int i = 0; i < digitSegments.Length; i++)
            {
                if (digitSegments[i] == '0')
                {
                    StringBuilder sb = new StringBuilder(digitSegments);
                    sb[i] = '1';
                    string alternativeDigitSegments = sb.ToString();
                    FindPossibleDigits(alternativeDigitSegments, index + 1);
                }
            }
        }

        static void AddValidDigit(int digit)
        {
            if (digit != -1 && !possibleDigits.Contains(digit))
            {
                possibleDigits.Add(digit);
            }
        }

        static void FindAllDigits()
        {
            for (int i = 0; i < allSegments.Count; i++)
            {
                string digitSegments = allSegments[i];
                FindPossibleDigits(digitSegments, 0);
                allDigits.Add(new List<int>(possibleDigits));
                possibleDigits = new List<int>();
            }
        }

        static void FindCombinationsCount()
        {
            combinationsCount = 1;
            foreach (List<int> digits in allDigits)
            {
                combinationsCount *= digits.Count;
                digits.Sort();
            }
            Console.WriteLine(combinationsCount);
        }

        static void GenerateAndPrintCombinations()
        {
            var combinations = AllCombinationsOf(allDigits.ToArray());
            string[] numbers = new string[combinationsCount];
            for (int combinationIndex = 0; combinationIndex < combinations.Count; combinationIndex++)
            {
                var combination = combinations[combinationIndex];
                StringBuilder sb = new StringBuilder();
                foreach (int digit in combination)
                {
                    sb.Append(digit);
                }
                numbers[combinationIndex] = sb.ToString();
            }
            Array.Sort(numbers);
            using (StreamWriter sw = new StreamWriter(OUTPUT_PATH))
            {
                foreach (string number in numbers)
                {
                    sw.WriteLine(number);
                }
            }
        }

        static List<List<int>> AllCombinationsOf(params List<int>[] sets)
        {
            var combinations = new List<List<int>>();

            foreach (var value in sets[0])
            {
                combinations.Add(new List<int> { value });
            }

            foreach (var set in sets.Skip(1))
            {
                combinations = AddExtraSet(combinations, set);
            }

            return combinations;
        }

        static List<List<int>> AddExtraSet(List<List<int>> combinations, List<int> set)
        {
            var newCombinations = from value in set
                                  from combination in combinations
                                  select new List<int>(combination) { value };

            return newCombinations.ToList();
        }
    }
}
