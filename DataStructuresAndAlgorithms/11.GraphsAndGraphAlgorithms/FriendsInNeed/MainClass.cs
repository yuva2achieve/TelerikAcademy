using System;
using System.Collections.Generic;
using System.Linq;

namespace FriendsInNeed
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            Dictionary<Node, List<Connection>> graph = new Dictionary<Node, List<Connection>>();
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>();

            string[] arguments = Console.ReadLine().Split(' ');
            int streetsCount = int.Parse(arguments[1]);
            string[] hospitals = Console.ReadLine().Split(' ');

            for (int i = 0; i < streetsCount; i++)
            {
                string[] currentStreet = Console.ReadLine().Split(' ');
                int firstNodeID = int.Parse(currentStreet[0]);
                int secondNodeID = int.Parse(currentStreet[1]);
                int connectionDistance = int.Parse(currentStreet[2]);

                if (!allNodes.ContainsKey(firstNodeID))
                {
                    allNodes.Add(firstNodeID, new Node(firstNodeID));
                }

                if (!allNodes.ContainsKey(secondNodeID))
                {
                    allNodes.Add(secondNodeID, new Node(secondNodeID));
                }

                Node firstNode = allNodes[firstNodeID];
                Node secondNode = allNodes[secondNodeID];

                if (!graph.ContainsKey(firstNode))
                {
                    graph.Add(firstNode, new List<Connection>());
                }

                if (!graph.ContainsKey(secondNode))
                {
                    graph.Add(secondNode, new List<Connection>());
                }

                graph[firstNode].Add(new Connection(secondNode, connectionDistance));
                graph[secondNode].Add(new Connection(firstNode, connectionDistance));

            }


            List<int> allHospitals = new List<int>();
            for (int i = 0; i < hospitals.Length; i++)
            {
                int currentHospitalID = int.Parse(hospitals[i]);
                allNodes[currentHospitalID].IsHospital = true;
                allHospitals.Add(currentHospitalID);
            }

            long minDijkstra = long.MaxValue;

            for (int i = 0; i < allHospitals.Count; i++)
            {
                Dijkstra.DijkstraAlgorithm(graph, allNodes[allHospitals[i]]);

                long sum = 0;

                foreach (var item in allNodes)
                {
                    if (!item.Value.IsHospital)
                    {
                        sum += item.Value.DijkstraDistance;
                    }
                }

                if (sum < minDijkstra)
                {
                    minDijkstra = sum;
                }
            }

            Console.WriteLine(minDijkstra);
        }
    }

    public class Node : IComparable
    {
        public int ID { get; private set; }
        public bool IsHospital { get; set; }
        public long DijkstraDistance { get; set; }

        public Node(int id)
        {
            this.ID = id;
            this.IsHospital = false;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }

    public class Connection
    {
        public Node ToNode { get; set; }
        public long Distance { get; set; }

        public Connection(Node node, long distance)
        {
            this.ToNode = node;
            this.Distance = distance;
        }
    }

    public class PriorityQueue<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length)
            {
                IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            int minChild;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = rootIndex * 2 + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }
                else if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            T[] copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }

    public class Dijkstra
    {
        public static void DijkstraAlgorithm(Dictionary<Node, List<Connection>> graph, Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = long.MaxValue;
            }

            source.DijkstraDistance = 0;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Dequeue();

                if (currentNode.DijkstraDistance == long.MaxValue)
                {
                    break;
                }

                foreach (var neighbour in graph[currentNode])
                {
                    long potDistance = currentNode.DijkstraDistance + neighbour.Distance;

                    if (potDistance < neighbour.ToNode.DijkstraDistance)
                    {
                        neighbour.ToNode.DijkstraDistance = potDistance;
                        queue.Enqueue(neighbour.ToNode);
                    }
                }
            }
        }
    }
}
