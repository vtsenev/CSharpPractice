using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1NestedLoops
{
    class Program
    {
        static int numberOfLoops;
        static int[] loops;

        static void Main(string[] args)
        {
            // Task 1: Write a recursive program that simulates execution of n nested loops from 1 to n.

            Console.Write("number of loops = ");
            numberOfLoops = int.Parse(Console.ReadLine());
            loops = new int[numberOfLoops];

            SimulateNestedLoops(0);
        }

        static void SimulateNestedLoops(int currentLoop)
        {
            if (currentLoop == numberOfLoops)
            {
                Print();
                return;
            }

            for (int i = 1; i <= numberOfLoops; i++)
            {
                loops[currentLoop] = i;
                SimulateNestedLoops(currentLoop + 1);
            }
        }

        static void Print()
        {
            for (int i = 0; i < loops.Length; i++)
            {
                Console.Write("{0} ", loops[i]);
            }
            Console.WriteLine();
        }
    }
}
