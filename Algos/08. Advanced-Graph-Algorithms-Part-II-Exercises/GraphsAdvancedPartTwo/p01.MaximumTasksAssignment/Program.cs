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

            var alphabet = new Dictionary<int, char>();
            for (var (i, j) = ('A', 1); i <= 'Z'; i++, j++) alphabet.Add(j, i);

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
            
            while (Dfs(start, end, graph, parents))
            {
                var currentNode = end;
                while (currentNode != start)
                {
                    var prevNode = parents[currentNode];

                    graph[prevNode][currentNode] = 0;
                    graph[currentNode][prevNode] = 1;

                    currentNode = prevNode;
                }
            }
            var result = new SortedSet<string>();
            Bfs(end, start, graph, result, people);

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static void Bfs(int start, int end, int[][] graph, SortedSet<string> result, int people)
        {
            var visisted = new bool[graph.Length];
            var queue = new Queue<int>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                for (int child = 0; child < graph[node].Length; child++)
                {
                    if(graph[node][child] > 0 && !visisted[child])
                    {
                        queue.Enqueue(child);
                        visisted[child] = true;

                        if(node != start && child != end)
                        {
                            result.Add($"{(char)(child - 1 + 'A')}-{node - people}");
                        }
                    }
                }
            }
        }

        //Change to BFS for different output
        private static bool Dfs(int start, int end, int[][] graph, int[] parents)
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
