using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task8TaskOrder
{
    class Program
    {
        static List<Edge> edges;
        static List<int> tasks;
        static List<int> sequence = new List<int>();
        static List<int> visited = new List<int>();

        static void Main(string[] args)
        {
            // Task 8: We are given a set of N tasks that should be executed in a sequence.
            // Some of the tasks depend on other tasks. We are given a list of tasks
            // {ti, tj} where tj depends on the result of ti and should be executed after
            // it. Write a program that arranges the tasks in a sequence so that each task
            // depending on another task is executed after it. If such arrangement is
            // impossible indicate this fact.
            // Example: {1, 2}, {2, 5}, {2, 4}, {3, 1} -> 3, 1, 2, 5, 4

            ConstructGraph();

            List<int> lastTasks = new List<int>();

            foreach (int task in tasks)
            {
                if (!edges.Exists(e => e.StartNode == task))
                    lastTasks.Add(task);
            }

            foreach (int task in lastTasks)
            {
                DoNextTask(task);
            }

            foreach (int node in sequence)
            {
                Console.Write(node + " ");
            }
            Console.WriteLine();
        }

        static void ConstructGraph()
        {
            Edge edge1 = new Edge(1, 2);
            Edge edge2 = new Edge(2, 5);
            Edge edge3 = new Edge(2, 4);
            Edge edge4 = new Edge(3, 1);

            Edge[] graphEdges = { edge1, edge2, edge3, edge4, };
            edges = graphEdges.ToList();
            tasks = new List<int>();

            foreach (Edge edge in edges)
            {
                if (!tasks.Contains(edge.StartNode))
                {
                    tasks.Add(edge.StartNode);
                }
                if (!tasks.Contains(edge.EndNode))
                {
                    tasks.Add(edge.EndNode);
                }
            }
        }

        static void DoNextTask(int node)
        {
            if (!visited.Contains(node))
            {
                visited.Add(node);
                Edge edge = edges.Find(e => e.EndNode == node);
                if (edge != null)
                {
                    DoNextTask(edge.StartNode);
                }
                sequence.Add(node);
            }
        }
    }

    class Edge
    {
        private int startNode;
        private int endNode;

        public Edge(int startNode, int endNode)
        {
            this.startNode = startNode;
            this.endNode = endNode;
        }

        public int StartNode
        {
            get { return this.startNode; }
        }

        public int EndNode
        {
            get { return this.endNode; }
        }
    }
}
