using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenerateCombinations
{
    class Program
    {
        static int k, n;
        static int[] used;
        static int[] combo;
        static List<int[]> combinations;

        static void Main(string[] args)
        {
            // Write a program that reads two numbers N and K and
            // generates all the combinations of K distinct 
            // elements from the set [1..N]. Example:
            // N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}

            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            k = int.Parse(Console.ReadLine());

            used = new int[n];
            combo = new int[k];
            combinations = new List<int[]>();

            GenerateCombo(0);

            List<int[]> finalList = new List<int[]>();
            finalList = RemoveDuplicates(combinations);

            foreach (int[] comb in finalList)
            {    
                Print(comb);
            }
            
        }

        static List<int[]> RemoveDuplicates(List<int[]> inputList)
        {
            List<int[]> finalList = new List<int[]>();
            foreach (int[] current in inputList)
            {
                if (!Contains(finalList, current))
                {
                    finalList.Add(current);
                }
            }
            return finalList;
        }

        static bool Contains(List<int[]> list, int[] comparedValue)
        {
            foreach (int[] listValue in list)
            {
                if (listValue.SequenceEqual(comparedValue))
                {
                    return true;
                }
            }
            return false;
        }

        static void Print(int[] arr)
        {
            Console.Write("{");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" {0}", arr[i]);
            }
            Console.WriteLine(" }");
        }

        static void GenerateCombo(int startIndex)
        {
            if (startIndex >= k)
            {
                int[] tmpArr = new int[k];
                Array.Copy(combo, tmpArr, k);
                Array.Sort(tmpArr);
                combinations.Add(tmpArr);
                //Print(combo);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (used[i] == 0)
                {
                    used[i] = 1;
                    combo[startIndex] = i + 1;
                    GenerateCombo(startIndex + 1);
                    used[i] = 0;
                }
            }
        }
    }
}