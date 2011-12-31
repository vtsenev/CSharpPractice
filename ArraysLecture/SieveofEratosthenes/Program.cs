using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SieveofEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {

            // Write a program that finds all prime numbers in the range [1...10 000 000].
            // Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

            const int LIMIT = 10000000;

            bool[] boolArray = new bool[LIMIT+1];
            for (int i = 0; i <= LIMIT; i++)
            {
                boolArray[i] = true;
            }

            for (int i = 2; i <= LIMIT / 2; i++)
            {
                if (boolArray[i])
                {
                    for (int j = 2 * i; j <= LIMIT; j += i)
                    {
                        boolArray[j] = false;
                    }
                }
            }
        }
    }
}
