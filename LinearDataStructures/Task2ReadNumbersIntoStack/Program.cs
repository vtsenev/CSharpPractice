using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2ReadNumbersIntoStack
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 2: Write a program that reads N integers from the console
            // and reverses them using a stack. Use the Stack<int> class.

            Console.WriteLine("N = ");
            Stack<int> stack = new Stack<int>();
            int N = int.Parse(Console.ReadLine());
            for (int counter = 0; counter < N; counter++)
            {
                int num = int.Parse(Console.ReadLine());
                stack.Push(num);
            }

            Console.WriteLine("Your numbers:");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Peek());
                stack.Pop();
            }
        }
    }
}
