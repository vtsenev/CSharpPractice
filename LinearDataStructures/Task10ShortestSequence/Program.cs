using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task10ShortestSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 10: We are given numbers N and M and the following operations:
            // a) N = N+1, b) N = N+2, c) N = N*2
            // Write a program that finds the shortest sequence of operations from
            // the list above that starts from N and finishes in M. Hint: use a queue.

            // input
            Console.Write("N = ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("M = ");
            int M = int.Parse(Console.ReadLine());

            // initialize queue of lists (solutions)
            LinkedList<int> initialList = new LinkedList<int>();
            initialList.AddLast(N);
            Queue<LinkedList<int>> solutions = new Queue<LinkedList<int>>();
            solutions.Enqueue(initialList);

            // find result
            LinkedList<int> result = FindShortestSequence(solutions, M);

            // output
            LinkedListNode<int> currentNode = result.First;
            while (true)
            {
                if (currentNode.Next != null)
                {
                    Console.Write("{0} -> ", currentNode.Value);
                    currentNode = currentNode.Next;
                }
                else
                {
                    Console.WriteLine("{0}", currentNode.Value);
                    break;
                }
            }
        }

        static LinkedList<int> FindShortestSequence(Queue<LinkedList<int>> queueList, int M)
        {
            while (true)
            {
                LinkedList<int> currentList = queueList.Dequeue();
                LinkedListNode<int> lastElement = currentList.Last;

                for (int i = 0; i < 3; i++)
                {
                    int nextValue = IncrementValue(lastElement.Value, i);
                    LinkedList<int> solution = new LinkedList<int>(currentList);
                    solution.AddLast(nextValue);
                    if (nextValue < M)
                    {
                        queueList.Enqueue(solution);
                    }
                    else if (nextValue == M)
                    {
                        queueList.Enqueue(solution);
                        return solution;
                    }
                }
            }
        }

        static int IncrementValue(int value, int operation)
        {
            if (operation == 0)
            {
                return ++value;
            }
            else if (operation == 1)
            {
                return value + 2;
            }
            else
            {
                return value * 2;
            }
        }
    }
}
