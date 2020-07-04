namespace p02._1.PermuteWithRepetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //Passing solution since sorting is not required
            var input = Console.ReadLine().Split(' ').ToArray();
            //Array.Sort(input);
            PermuteWithRepetition(input, 0);
        }

        private static void PermuteWithRepetition(string[] permutation, int start)
        {
            if (start == permutation.Length)
            {
                Console.WriteLine(string.Join(" ", permutation));
            }
            else
            {
                var used = new HashSet<string>();
                for (int i = start; i < permutation.Length; i++)
                {
                    if (!used.Contains(permutation[i]))
                    {
                        Swap(permutation, start, i);
                        PermuteWithRepetition(permutation, start + 1);
                        Swap(permutation, i, start);
                        used.Add(permutation[i]);
                    }
                }
            }
        }
        private static void Swap(string[] input, int leftIndex, int rightIndex)
        {
            var temp = input[leftIndex];
            input[leftIndex] = input[rightIndex];
            input[rightIndex] = temp;
        }
    }
}
