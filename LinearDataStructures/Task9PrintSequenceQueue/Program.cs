using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task9PrintSequenceQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 9: We are given a sequence. Using the Queue<T> class
            // write a program to print its first 50 members for given N.

            const int MEMBER_COUNT = 50;

            int N = int.Parse(Console.ReadLine());
            Queue<int> queue = new Queue<int>();
            Console.WriteLine("First {0} members: ", MEMBER_COUNT);
            Console.Write(N + ", ");
            int si = N;
            int operationCount = 1;
            for (int index = 2; index <= MEMBER_COUNT; index++)
            {
                if (operationCount == 1)
                {
                    queue.Enqueue(si + 1);
                    operationCount++;
                }
                else if (operationCount == 2)
                {
                    queue.Enqueue(2 * si + 1);
                    operationCount++;
                }
                else if (operationCount == 3)
                {
                    queue.Enqueue(si + 2);
                    operationCount = 1;
                    si = queue.Dequeue();
                    Console.Write(si + ", ");
                }
            }

            while (queue.Count != 1)
            {
                Console.Write(queue.Dequeue() + ", ");
            }
            Console.WriteLine(queue.Dequeue());
        }
    }
}
