using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task6FindConnectedComponents
{
    class Program
    {
        static List<Edge> edges;
        static List<int> globalVisited = new List<int>();
        static List<int> nodes;
        static int connectedComponents = 0;

        static void Main(string[] args)
        {
            // Task 6: Write a program for finding all connected components
            // of given undirected graph. Use a sequence of DFS traversals.

            ConstructGraph();

            int startNode = nodes[0];
            while (globalVisited.Count < nodes.Count)
            {
                DepthFirstSearch(startNode);
                startNode++;
            }
            Console.WriteLine("The number of connected components is: " + connectedComponents);
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
            Edge edge10 = new Edge(7, 8);
            Edge edge11 = new Edge(8, 9);
            Edge edge12 = new Edge(9, 10);
            Edge edge13 = new Edge(11, 12);
            Edge edge14 = new Edge(12, 13);
            Edge edge15 = new Edge(14, 15);

            Edge[] graphEdges = { edge1, edge2, edge3, edge4, edge5, edge6, edge7, edge8, edge9, edge10, edge11, edge12, edge13, edge14, edge15 };
            edges = graphEdges.ToList();

            nodes = new List<int>();
            foreach (Edge edge in edges)
            {
                if (!nodes.Contains(edge.StartNode))
                {
                    nodes.Add(edge.StartNode);
                }
                if (!nodes.Contains(edge.EndNode))
                {
                    nodes.Add(edge.EndNode);
                }
            }
        }

        static void DepthFirstSearch(int startNode)
        {
            Stack<int> stack = new Stack<int>();
            List<int> visited = new List<int>();

            stack.Push(startNode);
            visited.Add(startNode);

            while (stack.Count > 0)
            {
                int currentNode = stack.Pop();
                List<int> neighbours = FindNeighbours(currentNode);
                foreach (int neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        stack.Push(neighbour);
                        visited.Add(neighbour);
                    }
                }
            }

            int visitedCount = globalVisited.Count;

            foreach (int node in visited)
            {
                if (!globalVisited.Contains(node))
                {
                    globalVisited.Add(node);
                }
            }

            if (globalVisited.Count > visitedCount)
                connectedComponents++;
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
