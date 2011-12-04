using System;

namespace MathExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            const decimal NUM = 128.523123123m;
            decimal n, m, p;
            string input = Console.ReadLine();
            n = decimal.Parse(input);
            input = Console.ReadLine();
            m = decimal.Parse(input);
            input = Console.ReadLine();
            p = decimal.Parse(input);

            decimal numerator = (n * n) + (1 / (m * p)) + 1337;
            decimal denominator = n - (NUM * p);
            decimal expression = (decimal)Math.Sin((int)m % 180);
            decimal result = (numerator / denominator) + expression;
            
            Console.WriteLine("{0:F6}", result);
        }
    }
}