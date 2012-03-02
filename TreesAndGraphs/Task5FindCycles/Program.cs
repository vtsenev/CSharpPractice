using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5FindCycles
{
    class Program
    {
        static List<Edge> edges;
        static List<int> visited = new List<int>();
        static int cycles = 0;

        static void Main(string[] args)
        {
            // Task 5: Write a program for finding all cycles in given undirected graph using recursive DFS.

            ConstructGraph();
            RecursiveDFS(edges[0].StartNode);
            Console.WriteLine("basis cycles = {0}", (edges.Count - cycles));
        }

        static void ConstructGraph()
        {
            Edge edge1 = new Edge(0, 1);
            Edge edge2 = new Edge(0, 2);
            Edge edge3 = new Edge(0, 4);
            Edge edge4 = new Edge(1, 3);
            Edge edge5 = new Edge(1, 4);
            Edge edge6 = new Edge(2, 4);
            Edge edge7 = new Edge(3, 4);
            Edge edge8 = new Edge(4, 5);
            Edge edge9 = new Edge(5, 6);

            Edge[] graphEdges = { edge1, edge2, edge3, edge4, edge5, edge6, edge7, edge8, edge9 };
            edges = graphEdges.ToList();
        }

        static void RecursiveDFS(int node)
        {
            if (!visited.Contains(node))
                visited.Add(node);
            List<int> neighbours = FindNeighbours(node);
            foreach (int neighbour in neighbours)
            {
                if (!visited.Contains(neighbour))
                {
                    visited.Add(neighbour);
                    RecursiveDFS(neighbour);
                    cycles++;
                }
            }
            Console.WriteLine(node);
        }

        static List<int> FindNeighbours(int node)
        {
            List<int> neighbours = new List<int>();
            var children = edges.FindAll(e => e.StartNode == node);
            var parents = edges.FindAll(e => e.EndNode == node);
            foreach (Edge edge in children)
            {
                neighbours.Add(edge.EndNode);
            }
            foreach (Edge edge in parents)
            {
                neighbours.Add(edge.StartNode);
            }
            return neighbours;
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
