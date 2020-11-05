namespace p03.MostReliablePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());

            var path = Console.ReadLine().Split('-').Select(x => x.Trim()).Select(int.Parse).ToArray();
            var startNode = path[0];
            var targetNode = path[1];

            var edgesCount = int.Parse(Console.ReadLine());


            var nodeEdges = new Dictionary<int, List<Edge>>();

            var visited = new bool[nodesCount];
            var parents = new int[nodesCount];

            for (int i = 0; i < edgesCount; i++)
            {
                string line = Console.ReadLine();
                var tokens = line.Split(' ').Select(int.Parse).ToArray();

                var currentStart = tokens[0];
                var currentEndNode = tokens[1];
                var currentWeigth = tokens[2] / 100.0;

                if (!nodeEdges.ContainsKey(currentStart)) nodeEdges[currentStart] = new List<Edge>();
                if (!nodeEdges.ContainsKey(currentEndNode)) nodeEdges[currentEndNode] = new List<Edge>();

                nodeEdges[currentStart].Add(new Edge(currentStart, currentEndNode, currentWeigth));
                nodeEdges[currentEndNode].Add(new Edge(currentEndNode, currentStart, currentWeigth));
            }

            nodeEdges = nodeEdges.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value.OrderByDescending(e => e.Probability).ToList());

            var allNodes = new List<Node>();
            foreach (var node in nodeEdges.Keys)
            {
                allNodes.Add(new Node(node, double.NegativeInfinity));
            }
            var priorityQueue = new BinaryHeap<Node>();
            var firstNode = allNodes.First();
            firstNode.ProbabilityFromStart = 1;
            priorityQueue.Enqueue(firstNode);
            visited[firstNode.Id] = true;

            var temp = new List<Node>();
            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.FetchMin();

                var children = nodeEdges[currentNode.Id];
                foreach (var childEdge in children)
                {
                    var otherId = childEdge.To != currentNode.Id ? childEdge.To : childEdge.From;
                    var otherNode = allNodes[otherId];

                    if (!visited[otherId])
                    {
                        visited[otherId] = true;
                        priorityQueue.Enqueue(otherNode);
                    }

                    var currentProbability = Math.Round(currentNode.ProbabilityFromStart * childEdge.Probability, 4);
                    if (currentProbability > otherNode.ProbabilityFromStart)
                    {
                        otherNode.ProbabilityFromStart = currentProbability;
                        otherNode.Parent = currentNode;
                        priorityQueue.DecreaseKey(otherNode);
                    }
                }
            }

            var result = allNodes[targetNode];
            Console.WriteLine($"Most reliable path reliability: {result.ProbabilityFromStart * 100}%");
            var nodes = new List<int>();
            while (result != null)
            {
                nodes.Add(result.Id);
                result = result.Parent;
            }

            nodes.Reverse();
            Console.WriteLine(string.Join(" -> ", nodes));
        }
    }

    public class Node : IComparable<Node>
    {
        public Node(int id, double probabilityFromStart, Node parent = null)
        {
            this.Id = id;
            this.Parent = parent;
            this.ProbabilityFromStart = probabilityFromStart;
        }

        public int Id { get; set; }
        public double ProbabilityFromStart { get; set; }

        public Node Parent { get; set; }

        public int CompareTo(Node other)
        {
            return this.ProbabilityFromStart.CompareTo(other.ProbabilityFromStart);
        }

        public override string ToString()
        {
            return $"{this.Id} - {this.ProbabilityFromStart}{(this.Parent != null ? $" :: {this.Parent}" : "")}";
        }
    }

    public class Edge
    {
        public Edge(int from, int to, double probability)
        {
            this.From = from;
            this.To = to;
            this.Probability = probability;
        }

        public int From { get; set; }
        public int To { get; set; }
        public double Probability { get; set; }

        public override string ToString()
        {
            return $"{this.From} - {this.To} :: {this.Probability}";
        }

    }

    public class BinaryHeap<T> where T : IComparable<T>
    {
        private List<T> heap;

        public BinaryHeap()
        {
            this.heap = new List<T>();
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public void Enqueue(T item)
        {
            this.heap.Add(item);
            this.HeapifyUp(this.heap.Count - 1);
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = this.heap[index];
            this.heap[index] = this.heap[parentIndex];
            this.heap[parentIndex] = temp;
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private bool IsLess(int parentIndex, int index)
        {
            return this.heap[parentIndex].CompareTo(this.heap[index]) < 0;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0 && IsLess(Parent(index), index))
            {
                this.Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private int CalcLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private bool HasChild(int childIndex)
        {
            return childIndex < this.heap.Count;
        }

        private void HeapifyDown(int index)
        {
            while (index < this.heap.Count / 2)
            {
                var leftChild = CalcLeftChildIndex(index);

                //leftChild + 1 == rightChild
                if (HasChild(leftChild + 1) && IsLess(leftChild, leftChild + 1))
                {
                    leftChild = leftChild + 1;
                }

                if (IsLess(index, leftChild)) break;

                this.Swap(index, leftChild);
                index = leftChild;
            }
        }

        public T Peek()
        {
            return this.heap[0];
        }

        public T FetchMin()
        {
            if (this.heap.Count < 1)
            {
                throw new InvalidOperationException();
            }

            var minEle = this.heap[0];

            this.Swap(0, this.heap.Count - 1);
            this.heap.RemoveAt(this.heap.Count - 1);
            this.HeapifyDown(0);

            return minEle;
        }

        internal void DecreaseKey(T element)
        {
            var currentEle = this.heap.IndexOf(element);
            this.HeapifyUp(currentEle);
        }
    }

}