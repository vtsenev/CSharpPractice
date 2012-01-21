using System;

namespace Task2ReadNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 2: Write a method ReadNumber(int start, int end)
            // that enters an integer number in given range [start..end].
            // If invalid number or non-number text is entered, the
            // method should throw an exception. Based on this method
            // write a program that enters 10 numbers:
			// a1, a2, … a10, such that 1 < a1 < … < a10 < 100

            bool validInput = false;
            while (!validInput)
            try
            {
                int aPrevious = ReadNumber(2, 99);
                Console.WriteLine("a1 = {0}", aPrevious);
                int sequenceNum = 2;
                for (int i = 10; i >= 2; i--)
                {
                    int ai = ReadNumber(aPrevious + 1, 99);
                    aPrevious = ai;
                    Console.WriteLine("a{0} = {1}", sequenceNum, ai);
                    sequenceNum++;
                }
                validInput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Format error.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number is too big.");
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            
        }

        static int ReadNumber(int start, int end)
        {
            Console.Write("number[{0}..{1}] = ", start, end);
            string input = Console.ReadLine();
            int num = 0;

            try
            {
                num = int.Parse(input);
                if (num < start || num > end)
                {
                    string message = "number is not in range [" + start + ".." + end + "].";
                    throw new ArgumentOutOfRangeException(message);
                }
                return num;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (OverflowException)
            {
                throw;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
        }
    }
}
