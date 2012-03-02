using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3DFS
{
    class Program
    {
        static Graph graph;

        static void Main(string[] args)
        {
            ConstructGraph();
            DepthFirstSearch("6");
        }

        static void ConstructGraph()
        {
            Node node0 = new Node("0");
            Node node1 = new Node("1");
            Node node2 = new Node("2");
            Node node3 = new Node("3");
            Node node4 = new Node("4");
            Node node5 = new Node("5");
            Node node6 = new Node("6");

            node0.AddNeighbour(node2, 3);
            node0.AddNeighbour(node4, 6);
            node0.AddNeighbour(node1, 2);

            node1.AddNeighbour(node3, 1);
            node1.AddNeighbour(node4, 2);

            node2.AddNeighbour(node4, 1);
            
            node3.AddNeighbour(node4, 5);
            
            node4.AddNeighbour(node2, 1);
            node4.AddNeighbour(node5, 10);

            node5.AddNeighbour(node6, 1);

            graph = new Graph(node0);
        }

        static void DepthFirstSearch(string nodeName)
        {
            Stack<Node> stack = new Stack<Node>();
            List<Node> visited = new List<Node>();

            Console.WriteLine("--BEGIN--");
            stack.Push(graph.StartNode);
            visited.Add(graph.StartNode);

            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                if (node.Name == nodeName)
                {
                    Console.WriteLine(node.Name);
                    Console.WriteLine("--END--");
                    return;
                }
                Console.Write(node.Name + " -> ");
                foreach (Node neighbour in node.GetNeighbours())
                {
                    if (!visited.Contains(neighbour))
                    {
                        stack.Push(neighbour);
                        visited.Add(neighbour);
                    }
                }
            }
        }
    }

    class Graph
    {
        private Node startNode;

        public Graph(Node startNode)
        {
            this.startNode = startNode;
        }

        public Node StartNode
        {
            get { return this.startNode; }
        }
    }

    class Node
    {
        private string name;
        private List<Edge> edges;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        
        public Node(string name)
        {
            this.name = name;
            edges = new List<Edge>();
        }

        public Node(string name, Dictionary<Node, int> neighbours)
        {
            this.name = name;
            foreach (var pair in neighbours)
            {
                AddNeighbour(pair.Key, pair.Value);
            }
        }

        public void AddNeighbour(Node neighbour, int weight = 1)
        {
            Edge edge = new Edge(weight, neighbour);
            edges.Add(edge);
        }

        public List<Node> GetNeighbours()
        {
            List<Node> neighbours = new List<Node>();
            foreach (Edge edge in edges)
            {
                neighbours.Add(edge.EndNode);
            }
            return neighbours;
        }

        public Dictionary<Node, int> GetNeighboursAndDistance()
        {
            Dictionary<Node, int> distanceToNeighbours = new Dictionary<Node, int>();
            foreach (Edge edge in edges)
            {
                distanceToNeighbours.Add(edge.EndNode, edge.Weight);
            }
            return distanceToNeighbours;
        }

        public Node GetNeighbour(string name)
        {
            foreach (Edge edge in edges)
            {
                if (edge.EndNode.Name == name)
                {
                    return edge.EndNode;
                }
            }
            throw new ArgumentException("No such neighbour.");
        }

        public void DeleteConnection(Node neighbour)
        {
            Edge edgeToRemove = null;
            foreach (Edge edge in edges)
            {
                if (edge.EndNode.Name == neighbour.Name)
                {
                    edgeToRemove = edge;
                    edges.Remove(edgeToRemove);
                    return;
                }
            }
        }
    }

    class Edge
    {
        private int weight;
        private Node endNode;

        public Edge(int weight, Node endNode)
        {
            this.weight = weight;
            this.endNode = endNode;
        }

        public Node EndNode
        {
            get { return this.endNode; }
        }

        public int Weight
        {
            get { return this.weight; }
        }
    }
}
