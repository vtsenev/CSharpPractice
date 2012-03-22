using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberFrequency
{
    class Program
    {
        static void Main(string[] args)
        {
            // 0, 6, 9 map to 1, 8 maps to 2, every other digit maps to 0

            List<int> numbers = new List<int>();
            numbers.Add(8809);
            numbers.Add(7111);
            numbers.Add(2172);
            numbers.Add(6666);

            CalculateResult(numbers);
        }

        static void CalculateResult(List<int> numbers)
        {
            foreach (int number in numbers)
            {
                string digits = number.ToString();
                int result = 0;
                foreach (char digit in digits)
                {
                    if (digit == '0' || digit == '6' || digit == '9')
                    {
                        result++;
                    }
                    else if (digit == '8')
                    {
                        result += 2;
                    }
                }
                Console.WriteLine("{0} -> {1}", number, result);
            }
        }
    }
}
