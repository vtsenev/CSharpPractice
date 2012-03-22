using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task1_MaximalPath
{
    class Program
    {
        static int N;
        static Dictionary<int, Node> nodeDict = new Dictionary<int, Node>();
        static List<HashSet<long>> allPaths = new List<HashSet<long>>();
        const string INPUT_PATH = @"../../in.txt";

        static void Main(string[] args)
        {
            InputFromConsole();
            FindAllPaths();
        }

        static void InputFromConsole()
        {
            N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N - 1; i++)
            {
                string line = Console.ReadLine();
                Tuple<int, int> nodes = ParseLine(line);
                AddNodesToTree(nodes.Item1, nodes.Item2);
            }
        }

        static void InputFromFile()
        {
            using (StreamReader sr = new StreamReader(INPUT_PATH))
            {
                N = int.Parse(sr.ReadLine());
                for (int i = 0; i < N - 1; i++)
                {
                    string line = sr.ReadLine();
                    Tuple<int, int> nodes = ParseLine(line);
                    AddNodesToTree(nodes.Item1, nodes.Item2);
                }
            }
        }

        static Tuple<int, int> ParseLine(string line)
        {
            line = line.Substring(1, line.Length - 2);
            string[] lineSegments = line.Split(' ');
            int firstNodeId = int.Parse(lineSegments[0]);
            int secondNodeId = int.Parse(lineSegments[2]);
            return new Tuple<int, int>(firstNodeId, secondNodeId);
        }

        static void AddNodesToTree(int firstNodeId, int secondNodeId)
        {
            if (!nodeDict.ContainsKey(firstNodeId))
            {
                Node firstNode = new Node(firstNodeId);
                firstNode.AddChild(secondNodeId);
                nodeDict.Add(firstNodeId, firstNode);
            }
            else
            {
                nodeDict[firstNodeId].AddChild(secondNodeId);
            }
            if (!nodeDict.ContainsKey(secondNodeId))
            {
                Node secondNode = new Node(secondNodeId);
                secondNode.SetParent(firstNodeId);
                nodeDict.Add(secondNodeId, secondNode);
            }
            else
            {
                nodeDict[secondNodeId].SetParent(firstNodeId);
            }
        }

        static void FindAllPaths()
        {
            List<Node> startingNodes = FindStartingNodes();
            foreach (Node node in startingNodes)
            {
                GoToRoot(node);
            }
            FindLongestNotOverlappingPaths();
        }

        static List<Node> FindStartingNodes()
        {
            List<Node> startingNodes = new List<Node>();
            foreach (var pair in nodeDict)
            {
                if (pair.Value.Children.Count == 0)
                {
                    startingNodes.Add(pair.Value);
                }
            }
            return startingNodes.OrderByDescending(node => node.ID).ToList();
        }

        static void GoToRoot(Node startNode)
        {
            HashSet<long> currentPath = new HashSet<long>();
            currentPath.Add(startNode.ID);
            Node node = nodeDict[startNode.ParentID];
            while (node.ParentID != 0)
            {
                currentPath.Add(node.ID);
                node = nodeDict[node.ParentID];
            }
            allPaths.Add(currentPath);
        }

        static void FindLongestNotOverlappingPaths()
        {
            List<long> allSums = new List<long>();
            for (int i = 0; i < allPaths.Count; i++)
            {
                int pathsAdded = 1;
                HashSet<long> startSet = new HashSet<long>();
                foreach (long num in allPaths[i])
                {
                    startSet.Add(num);
                }
                for (int j = 0; j < allPaths.Count; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    HashSet<long> currentSet = new HashSet<long>();
                    foreach (long num in allPaths[j])
                    {
                        currentSet.Add(num);
                    }
                    if (startSet.Overlaps(currentSet))
                    {
                        continue;
                    }
                    foreach (long num in currentSet)
                    {
                        startSet.Add(num);
                    }
                    pathsAdded++;
                    if (pathsAdded == 2)
                    {
                        break;
                    }
                }
                allSums.Add(startSet.Sum());
            }
            AddRootAndPrintResult(allSums.Max());
        }

        static void AddRootAndPrintResult(long sum)
        {
            int root = GetRoot().ID;
            Console.WriteLine(sum + root);
        }

        static Node GetRoot()
        {
            Node root = null;
            foreach (var pair in nodeDict)
            {
                if (pair.Value.ParentID != 0)
                {
                    continue;
                }
                root = pair.Value;
            }
            return root;
        }
    }

    class Node
    {
        int id;
        int parentId = 0;
        List<int> children = new List<int>();

        public Node(int id)
        {
            this.id = id;
        }

        public void SetParent(int parentId)
        {
            this.parentId = parentId;
        }

        public void AddChild(int child)
        {
            this.children.Add(child);
        }

        public int ID
        {
            get { return this.id; }
        }

        public List<int> Children
        {
            get { return this.children; }
        }

        public int ParentID
        {
            get { return this.parentId; }
        }
    }
}
