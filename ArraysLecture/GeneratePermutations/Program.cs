using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneratePermutations
{
    class Program
    {

        static int[] nums;

        static void Main(string[] args)
        {
            // * Write a program that reads a number N 
            // and generates and prints all the 
            // permutations of the numbers [1 … N]. Example:
	        // n = 3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}

            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            nums = new int[n];
            for (int i = 1; i <= n; i++)
            {
                nums[i - 1] = i;
            }

            Print(nums);

            int count = 1;
            while (count < Factorial(n))
            {
                int i = n - 1;
                while (nums[i - 1] >= nums[i])
                {
                    i--;
                }

                int j = n;
                while (nums[j - 1] <= nums[i - 1])
                {
                    j--;
                }

                Swap(i - 1, j - 1);

                i++;
                j = n;
                while (i < j)
                {
                    Swap(i - 1, j - 1);
                    i++;
                    j--;
                }

                Print(nums);

                count++;
            }
        }

        private static void Swap(int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
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

        static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}
