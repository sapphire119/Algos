namespace p01.Index
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.NetworkInformation;
    using System.Runtime.CompilerServices;

    public class Program
    {
        public static void Main()
        {
            //TODO
            //Init graphs
            //BFS
            //DFS
            //Tpological Sort

            //directed cyclic graph

            //var graph = new List<int>[]
            //{
            //    new List<int> { 2, 4 }, //1
            //    new List<int> { 3 },    //2
            //    new List<int> { 1 },    //3
            //    new List<int> { 2 },    //4
            //};

            //var graphMatrix = new int[4, 4];
            //for (int i = 0; i < graphMatrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < graphMatrix.GetLength(1); j++)
            //    {
            //        if (graph[i].Contains(j + 1))
            //        {
            //            graphMatrix[i, j] = 1;
            //        }
            //    }
            //}

            var graph = new Graph
            {
                Nodes = new List<int>[]
                {
                    new List<int> { 1, 2, 3 },    // 0
                    new List<int> { 4, 5, 6, 2 }, // 1
                    new List<int> { 3 },          // 2
                    new List<int> { 8, 7 },       // 3
                    new List<int> { 0 },          // 4
                    new List<int> {   },          // 5
                    new List<int> { 2 },          // 6
                    new List<int> { 2 },          // 7
                    new List<int> {  },           // 8

                },
                Values = new int[]
                { //0, 1,  2,  3,  4, 5,  6,  7,  8
                    1, 19, 21, 14, 7, 12, 31, 23, 6
                }
            };


            var visited = new bool[graph.Nodes.Length];
            Console.Write("Output: ");
            //for (int i = 0; i < graph.Nodes.Length; i++)
            //{
            //    DepthFirstSearchIter(i, graph, visited);
            //    //BreadthFirstSearch(i, graph, visited);
            //    //DepthFirstSearch(i, graph, visited);
            //}
            Console.WriteLine();


            //Topological Sort
            var directedAcyclicGraph = new Graph
            {
                Nodes = new List<int>[]
                {
                    new List<int> { 1, 3 },     // 0
                    new List<int> { 4 },        // 1
                    new List<int> { 3 },        // 2
                    new List<int> { 4, 6, 7 },  // 3
                    new List<int> {  },         // 4
                    new List<int> { 1, 7 },     // 5
                    new List<int> {  },         // 6
                    new List<int> {  }          // 7
                    
                },
                Values = new int[]
                {
                  //0, 1, 2, 3,  4, 5, 6, 7
                    7, 8, 5, 11, 9, 3, 2, 10
                }
            };


            //TopologicalSort(directedAcyclicGraph);

            var visitedNodes = new bool[directedAcyclicGraph.Values.Length];
            var linkedList = new LinkedList<int>();
            for (int i = 0; i < directedAcyclicGraph.Nodes.Length; i++)
            {
                TopologicalSortV2(i, visitedNodes, linkedList, directedAcyclicGraph);
            }

            Console.WriteLine(string.Join(" ", linkedList));
        }

        private static void TopologicalSortV2(int node, bool[] visitedNodes, LinkedList<int> linkedList, Graph graph)
        {
            if (!visitedNodes[node])
            {
                visitedNodes[node] = true;
                var childrenNodes = graph.Nodes[node];
                foreach (var childNode in childrenNodes)
                {
                    TopologicalSortV2(childNode, visitedNodes, linkedList, graph);
                }

                linkedList.AddFirst(graph.Values[node]);
            }
        }

        private static void TopologicalSort(Graph graph)
        {
            var result = new List<int>();

            var nodesToDelete = new HashSet<int>();
            var nodesIncluded = GetNodesIncluded(graph);
            for (int i = 0; i < graph.Nodes.Length; i++)
            {
                if (!nodesIncluded.Contains(i)) nodesToDelete.Add(i);
            }

            while (nodesToDelete.Count > 0)
            {
                var nodeToDelete = nodesToDelete.First();
                nodesToDelete.Remove(nodeToDelete);
                result.Add(graph.Values[nodeToDelete]);
                var nodeChildren = graph.Nodes[nodeToDelete].ToList();

                graph.Nodes[nodeToDelete] = new List<int>();

                nodesIncluded = GetNodesIncluded(graph);
                foreach (var child in nodeChildren)
                {
                    if (!nodesIncluded.Contains(child)) nodesToDelete.Add(child);
                }
            }

            if (graph.Nodes.SelectMany(e => e).Any())
            {
                Console.WriteLine("Graph has a cycle!");
            }
            else
            {
                Console.WriteLine(string.Join(" ", result));
            }
        }

        private static HashSet<int> GetNodesIncluded(Graph graph)
        {
            var nodesIncluded = new HashSet<int>();

            graph.Nodes
                .SelectMany(n => n)
                .ToList()
                .ForEach(e => nodesIncluded.Add(e));

            return nodesIncluded;
        }

        private static void BreadthFirstSearch(int index, Graph graph, bool[] visited)
        {
            if (visited[index]) return;

            visited[index] = true;
            var queue = new Queue<int>();
            queue.Enqueue(index);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                Console.Write("{0} ", graph.Values[currentNode]);
                var children = graph.Nodes[currentNode];
                foreach (var child in children)
                {
                    if (!visited[child])
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        private static void DepthFirstSearchIter(int index, Graph graph, bool[] visited)
        {
            if (visited[index]) return;

            visited[index] = true;
            var stack = new Stack<int>();
            stack.Push(index);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                Console.Write("{0} ", graph.Values[currentNode]);

                var children = graph.Nodes[currentNode];
                foreach (var child in children)
                {
                    if (!visited[child])
                    {
                        visited[child] = true;
                        stack.Push(child);
                    }
                }
            }
        }

        private static void DepthFirstSearch(int index, Graph graph, bool[] visited)
        {
            if (!visited[index])
            {
                visited[index] = true;
                var currentChildren = graph.Nodes[index];
                foreach (var child in currentChildren)
                {
                    DepthFirstSearch(child, graph, visited);
                }
                Console.Write("{0} ", graph.Values[index]);
            }
        }
    }

    public class Graph
    {
        public List<int>[] Nodes { get; set; }
        public int[] Values { get; set; }
    }
}
