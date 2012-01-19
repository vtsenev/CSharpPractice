using System;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 10: Write a program to calculate n! for each n in the range [1..100].
            // Hint: Implement first a method that multiplies a number
            // represented as array of digits by given integer number. 

            Console.Write("n[1..100] = ");
            int n = int.Parse(Console.ReadLine());

            int[] result = Factorial(n);

            Print(result);
        }

        // recursive factorial; multiplies numbers represented as arrays of digits
        static int[] Factorial(int num)
        {
            int[] result;
            if (num == 1)
            {
                result = RepresentAsArray(1);
                return result;
            }
            return MultiplyArrays(RepresentAsArray(num), Factorial(num - 1));
        }

        // implements the product of two numbers represented 
        // as arrays of digits without propagating carries
        static int[] MultiplyArrays(int[] arr1,int[] arr2)
        {
            int[] result = new int[arr1.Length + arr2.Length + 1];

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    result[i + j] += arr1[i] * arr2[j];
                }
            }

            result = Propagate(result);

            return result;
        }

        // propagating carries if necessary
        static int[] Propagate(int[] arr)
        {
            int rem = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += rem;
                rem = 0;
                if (arr[i] > 9)
                {
                    if (arr[i] > 99)
                    {
                        rem = arr[i] / 10;
                    }
                    else
                    {
                        rem = (arr[i] / 10) % 10;
                    }
                    arr[i] = arr[i] % 10;
                }
            }

            return arr;
        }

        // represents an integer as an array of digits
        static int[] RepresentAsArray(int num)
        {
            int digitCount = 0;
            int tmp = num;
 	        while (tmp > 0)
            {
                digitCount++;
                tmp /= 10;
            }

            int[] result = new int[digitCount];

            for (int i = 0; i < digitCount; i++)
            {
                result[i] = num % 10;
                num /= 10;
            }

            return result;
        }

        // prints an array without the zeroes in front
        static void Print(int[] arr)
        {
            bool zero = false;
            
            if (arr[arr.Length - 1] == 0)
            {
                zero = true;
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] != 0)
                {
                    zero = false;
                }
                if (!zero)
                {
                    Console.Write("{0}", arr[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
