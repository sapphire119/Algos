namespace p01.MaximumTasksAssignment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var people = ParseInput();
            var tasks = ParseInput();

            var totalNodes = tasks + people + 2;
            var graph = new int[totalNodes][];

            for (int i = 0; i < graph.Length; i++) graph[i] = new int[totalNodes];

            for (int i = 1; i <= people; i++)
            {
                string line = Console.ReadLine();
                for (int j = people + 1; j <= people + tasks; j++)
                {
                    if (line[j - people - 1] == 'Y') graph[i][j] = 1;
                }
            }
            for (int i = 1; i <= people; i++) graph[0][i] = 1;
            for (int i = people + 1; i <= people + tasks; i++) graph[i][graph.Length - 1] = 1;

            var parents = Enumerable.Repeat(-1, graph.Length).ToArray();

            var start = 0;
            var end = graph.Length - 1;
            
            //Can be BFS/DFS
            while (DFS(start, end, graph, parents))
            {
                var currentNode = end;
                while (currentNode != start)
                {
                    var prevNode = parents[currentNode];

                    graph[prevNode][currentNode] = 0; // remove pathflow
                    graph[currentNode][prevNode] = 1; // add pathFlow

                    currentNode = prevNode;
                }
            }
            var result = new SortedSet<string>();
            Bfs(end, start, graph, result, people);

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static void Bfs(int end, int start, int[][] graph, SortedSet<string> result, int people)
        {
            var visisted = new bool[graph.Length];
            var queue = new Queue<int>();
            queue.Enqueue(end);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                for (int child = 0; child < graph[currentNode].Length; child++)
                {
                    if(graph[currentNode][child] > 0 && !visisted[child])
                    {
                        queue.Enqueue(child);
                        visisted[child] = true;

                        if(currentNode != end && child != start)
                        {
                            result.Add($"{(char)(child - 1 + 'A')}-{currentNode - people}");
                        }
                    }
                }
            }
        }

        //Change to DFS for different output
        private static bool DFS(int start, int end, int[][] graph, int[] parents)
        {
            var visited = new bool[graph.Length];
            var stack = new Stack<int>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                visited[node] = true;
                for (int child = 0; child < graph[node].Length; child++)
                {
                    if (graph[node][child] > 0 && !visited[child])
                    {
                        parents[child] = node;
                        stack.Push(child);
                        visited[child] = true;
                    }
                }
            }
            return visited[end];
        }

        private static void PrintGraph(int[][] graph)
        {
            for (int row = 0; row < graph.Length; row++)
            {
                for (int col = 0; col < graph[row].Length; col++)
                {
                    Console.Write($"{graph[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        private static int ParseInput()
        {
            return int.Parse(Console.ReadLine().Split(' ')[1]);
        }
    }
}
