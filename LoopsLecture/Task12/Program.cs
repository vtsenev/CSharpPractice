using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Task12
{
    class Program
    {
        static void Main(string[] args)
        {
            // * Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
	        // N = 10 -> N! = 3628800 -> 2
	        // N = 20 -> N! = 2432902008176640000 -> 4
	        // Does your program work for N = 50 000?
	        // Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!

            Console.Write("N = ");
            string input = Console.ReadLine();
            int n = int.Parse(input);

            BigInteger factorial = Factorial(n);
            Console.WriteLine("{0}! = {1}", n, factorial);

            int result = n / 5;
            Console.WriteLine("Number of zeros at the end of {0}! = {1}.", n, result);
        }

        static BigInteger Factorial(int n)
        {
            BigInteger result = 1;
            
            if (n < 1)
            {
                Console.WriteLine("Invalid value for variable n.");
                return 0;
            }
            
            if (n == 1)
            {
                return 1;
            }

            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
