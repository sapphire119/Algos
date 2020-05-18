using System;

namespace p02.NestedLoopRecursion
{
    public class Program
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());

            var arr = new int[input];

            RecurseAllOptions(arr, input, 0);
        }

        private static void RecurseAllOptions(int[] arr, int limit, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 1; i <= limit; i++)
                {
                    arr[index] = i;
                    RecurseAllOptions(arr, limit, index + 1);
                }
            }
        }
    }
}
