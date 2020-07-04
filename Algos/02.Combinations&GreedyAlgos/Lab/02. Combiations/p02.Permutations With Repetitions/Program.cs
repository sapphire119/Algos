namespace p02.Permutations_With_Repetitions
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //var input = new string[] { "A", "B", "B" };
            var input = Console.ReadLine().Split(' ').ToArray();
            //Array.Sort(input);
            PermuteWithRepetition(input, 0, input.Length - 1);
        }

        private static void PermuteWithRepetition(string[] input, int start, int end)
        {
            Print(input);
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (input[left] != input[right])
                    {
                        Swap(input, left, right);
                        PermuteWithRepetition(input, left + 1, end);
                    }
                }

                //Take the element previous to current swapped
                var swapElement = input[left];
                for (int i = left; i <= end - 1; i++)
                {
                    //first Iteration takes
                    //{ 5, 1, 4 --> if left == 0, then ->  1, 1, 4 -> 1, 4, 4}
                    input[i] = input[i + 1];
                }
                //last set takes the "swapElement" and sets it to the last position
                //{ 1, 4, 5}
                input[end] = swapElement;
            }
        }

        private static void Swap<T>(T[] arr, int firstIndex, int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }

        private static void Print<T>(T[] input)
        {
            Console.WriteLine(string.Join(" ", input).Trim());
        }
    }
}
