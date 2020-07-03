namespace p02.Permutations_With_Repetitions
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;

    public class Program
    {
        public static void Main()
        {
            var input = new string[] { "A", "B", "B" };
            Array.Sort(input);

            PermuteWithRepetition(input, 0, input.Length - 1);
        }

        private static void PermuteWithRepetition(string[] input, int start, int end)
        {

            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (input[left] != input[right])
                    {
                        Swap(input, left, right);

                    }
                }
            }
        }

        private static void Swap<T>(T[] arr, int firstIndex, int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }
    }
}
