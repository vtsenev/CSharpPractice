using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task7Dijkstra
{
    class Program
    {
        static Graph graph;

        static void Main(string[] args)
        {
            ConstructGraph();
            PrintGraph();
            Dijkstra();
            PrintResults();
            ConstructGraph();
            Node node1 = graph.Nodes.ElementAt(1);
            Node node2 = graph.Nodes.ElementAt(6);
            int routeLength = ShortestPath(node1, node2);
            Console.WriteLine("route from {0} to {1} is {2}", node1.Name, node2.Name, node2.Dist);
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
            Node[] nodes = { node0, node1, node2, node3, node4, node5, node6 };

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

            graph = new Graph(nodes);
        }

        static void PrintGraph()
        {
            Console.WriteLine("Graph: ({0} nodes)", graph.Count);
            foreach (Node node in graph.Nodes)
            {
                List<Node> neighbours = node.GetNeighbours();
                if (neighbours.Count == 0)
                    continue;
                Console.Write(node.Name + " -> ");
                foreach (Node neighbour in neighbours)
                {
                    Console.Write(neighbour.Name + "; ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Dijkstra()
        {
            PriorityQueue<Node> pqueue = new PriorityQueue<Node>();

            graph.StartNode.Dist = 0;
            foreach (Node node in graph.Nodes)
            {
                pqueue.Enqueue(node.Dist, node);
            }

            while (!pqueue.IsEmpty)
            {
                Node node = pqueue.Dequeue();
                if (node.Dist == int.MaxValue)
                    break;

                foreach (var pair in node.GetNeighboursAndDistance())
                {
                    Node neighbour = pair.Key;
                    int distance = pair.Value;
                    if (pqueue.Contains(neighbour))
                    {
                        int currenRoute = node.Dist + distance;
                        if (currenRoute < neighbour.Dist)
                        {
                            neighbour.Dist = currenRoute;
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
                                pqueue.Enqueue(n.Dist, n);
                            }
                        }
                    }
                }
            }
        }

        static void PrintResults()
        {
            Console.WriteLine("Shortest paths to every node from the root:");
            foreach (Node node in graph.Nodes)
            {
                if (node == graph.StartNode)
                    continue;
                Console.WriteLine("To node {0}: {1}. Parent is {2}.", node.Name, node.Dist, node.Previous.Name);
            }
        }

        static int ShortestPath(Node node1, Node node2)
        {
            PriorityQueue<Node> pqueue = new PriorityQueue<Node>();

            foreach (Node node in graph.Nodes)
            {
                if (node == node1)
                    node.Dist = 0;
                pqueue.Enqueue(node.Dist, node);
            }

            while (!pqueue.IsEmpty)
            {
                Node node = pqueue.Dequeue();
                if (node.Dist == int.MaxValue)
                    break;
                if (node.Name == node2.Name)
                    return node.Dist;

                foreach (var pair in node.GetNeighboursAndDistance())
                {
                    Node neighbour = pair.Key;
                    int distance = pair.Value;
                    if (pqueue.Contains(neighbour))
                    {
                        int currenRoute = node.Dist + distance;
                        if (currenRoute < neighbour.Dist)
                        {
                            neighbour.Dist = currenRoute;
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
                                pqueue.Enqueue(n.Dist, n);
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
        private string name;
        private List<Edge> edges;
        private int dist; // distance to the root of the graph
        private Node previous;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Dist
        {
            get { return this.dist; }
            set { this.dist = value; }
        }

        public Node Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }

        public Node(string name)
        {
            this.name = name;
            this.dist = int.MaxValue;
            this.previous = null;
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
