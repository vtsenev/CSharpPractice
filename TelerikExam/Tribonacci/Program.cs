using System;
using System.Numerics;

namespace Tribonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            BigInteger t1 = BigInteger.Parse(input);
            input = Console.ReadLine();
            BigInteger t2 = BigInteger.Parse(input);
            input = Console.ReadLine();
            BigInteger t3 = BigInteger.Parse(input);
            input = Console.ReadLine();
            int n = int.Parse(input);

            BigInteger[] numbers = new BigInteger[n];
            numbers[0] = t1;
            numbers[1] = t2;
            numbers[2] = t3;
            for (int i = 3; i < n; i++)
            {
                numbers[i] = numbers[i - 1] + numbers[i - 2] + numbers[i - 3];
            }

            Console.WriteLine(numbers[n-1]);
        }
    }
}