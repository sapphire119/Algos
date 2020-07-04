namespace p04.VariationsWithRepe
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(char.Parse).ToArray();
            var slots = int.Parse(Console.ReadLine());

            var slotsArr = new char[slots];
            var used = new bool[input.Length];

            PrintVariations(input, slotsArr, slots, 0, used);
        }

        private static void PrintVariations(char[] arr, char[] slotsArr, int slots, int index, bool[] used)
        {
            if (index == slots)
            {
                Console.WriteLine(string.Join(" ", slotsArr));
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    slotsArr[index] = arr[i];
                    PrintVariations(arr, slotsArr, slots, index + 1, used);
                }
            }
        }
    }
}
