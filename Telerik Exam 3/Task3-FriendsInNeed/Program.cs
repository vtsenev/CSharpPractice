using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3_FriendsInNeed
{
    class Program
    {
        static int N;
        static int M;
        static int H;
        static int[] hospitals;
        static Graph graph;

        static void Main(string[] args)
        {

        }

        static void InputFromConsole()
        {
            string line = Console.ReadLine();
            string[] lineSegments = line.Split(' ');
            N = int.Parse(lineSegments[0]);
            M = int.Parse(lineSegments[1]);
            H = int.Parse(lineSegments[2]);
        }

        static void Dijkstra()
        {
            PriorityQueue<Node> pqueue = new PriorityQueue<Node>();
            graph.StartNode.DistanceToRoot = 0;
            foreach (Node node in graph.Nodes)
            {
                pqueue.Enqueue(node.DistanceToRoot, node);
            }
            while (!pqueue.IsEmpty)
            {
                Node node = pqueue.Dequeue();
                if (node.DistanceToRoot == int.MaxValue)
                {
                    break;
                }
                foreach (var pair in node.GetNeighboursAndDistance())
                {
                    Node neighbour = pair.Key;
                    int distance = pair.Value;
                    if (pqueue.Contains(neighbour))
                    {
                        int currenRoute = node.DistanceToRoot + distance;
                        if (currenRoute < neighbour.DistanceToRoot)
                        {
                            neighbour.DistanceToRoot = currenRoute;
                            neighbour.Previous = node;
                            // update priority queue
                            List<Node> nodesInQueue = new List<Node>();
                            while (!pqueue.IsEmpty)
                            {
                                nodesInQueue.Add(pqueue.Dequeue());
                            }
                            pqueue = new PriorityQueue<Node>();
                            foreach (Node n in nodesInQueue)
                            {
                                pqueue.Enqueue(n.DistanceToRoot, n);
                            }
                        }
                    }
                }
            }
        }

        static int ShortestPath(Node node1, Node node2)
        {
            PriorityQueue<Node> pqueue = new PriorityQueue<Node>();
            foreach (Node node in graph.Nodes)
            {
                if (node == node1)
                    node.DistanceToRoot = 0;
                pqueue.Enqueue(node.DistanceToRoot, node);
            }
            while (!pqueue.IsEmpty)
            {
                Node node = pqueue.Dequeue();
                if (node.DistanceToRoot == int.MaxValue)
                    break;
                if (node.Name == node2.Name)
                {
                    return node.DistanceToRoot;
                }
                foreach (var pair in node.GetNeighboursAndDistance())
                {
                    Node neighbour = pair.Key;
                    int distance = pair.Value;
                    if (pqueue.Contains(neighbour))
                    {
                        int currenRoute = node.DistanceToRoot + distance;
                        if (currenRoute < neighbour.DistanceToRoot)
                        {
                            neighbour.DistanceToRoot = currenRoute;
                            neighbour.Previous = node;
                            // update priority queue
                            List<Node> nodesInQueue = new List<Node>();
                            while (!pqueue.IsEmpty)
                            {
                                nodesInQueue.Add(pqueue.Dequeue());
                            }
                            pqueue = new PriorityQueue<Node>();
                            foreach (Node n in nodesInQueue)
                            {
                                pqueue.Enqueue(n.DistanceToRoot, n);
                            }
                        }
                    }
                }
            }
            return int.MaxValue;
        }
    }

    class Graph
    {
        private Node startNode;
        private HashSet<Node> nodes;

        public Graph(Node startNode)
        {
            this.startNode = startNode;
        }

        public Graph(Node[] graphSet)
        {
            nodes = new HashSet<Node>();
            foreach (var node in graphSet)
            {
                nodes.Add(node);
            }
            this.startNode = nodes.ElementAt(0);
        }

        public Node StartNode
        {
            get { return this.startNode; }
        }

        public HashSet<Node> Nodes
        {
            get { return this.nodes; }
        }

        public int Count
        {
            get { return nodes.Count; }
        }
    }

    class Node
    {
        private List<Edge> edges;
        public string Name { get; set; }
        public int DistanceToRoot { get; set; }
        public Node Previous { get; set; }

        public Node(string name)
        {
            this.Name = name;
            this.DistanceToRoot = int.MaxValue;
            this.Previous = null;
            edges = new List<Edge>();
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
        public Node EndNode { get; private set; }
        public int Weight { get; private set; }

        public Edge(int weight, Node endNode)
        {
            this.Weight = weight;
            this.EndNode = endNode;
        }
    }

    class PriorityQueue<T>
    {
        private SortedDictionary<int, Queue<T>> list = new SortedDictionary<int, Queue<T>>();

        public void Enqueue(int priority, T value)
        {
            Queue<T> q;
            if (!list.TryGetValue(priority, out q))
            {
                q = new Queue<T>();
                list.Add(priority, q);
            }
            q.Enqueue(value);
        }

        public T Dequeue()
        {
            var pair = list.First();
            var value = pair.Value.Dequeue();
            if (pair.Value.Count == 0)
                list.Remove(pair.Key);

            return value;
        }

        public bool Contains(T element)
        {
            foreach (var pair in list)
            {
                if (pair.Value.Contains(element))
                    return true;
            }
            return false;
        }

        public bool IsEmpty
        {
            get { return !list.Any(); }
        }
    }
}
