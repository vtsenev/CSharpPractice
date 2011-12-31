using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubsetHasSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // * We are given an array of integers and a number S. Write a program to find if
            //  there exists a subset of the elements of the array that has a sum S. 
            // Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)

            int[] arr = {2, 1, 2, 4, 3, 5, 2, 6};
            int s = 14;

            int usedSum;
            List<int> usedNums = new List<int>();
            List<int> unusedNums = new List<int>();

            usedNums.Add(arr[0]);
            
            unusedNums = arr.ToList();
            unusedNums.RemoveAt(0);
            
            usedSum = usedNums.Sum();

            while (usedSum != s)
            {
                if (s > usedSum)
                {
                    usedNums.Add(unusedNums[0]);
                    unusedNums.RemoveAt(0);
                    usedSum = usedNums.Sum();
                }
                else
                {
                    unusedNums.Add(usedNums[usedNums.Count - 1]);
                    usedNums.RemoveAt(usedNums.Count - 1);
                    usedSum = usedNums.Sum();
                }
            }

            Console.Write("yes (");
            foreach (int num in usedNums)
            {
                Console.Write(" {0}", num);
            }
            Console.WriteLine(" )");
        }

    }
}
