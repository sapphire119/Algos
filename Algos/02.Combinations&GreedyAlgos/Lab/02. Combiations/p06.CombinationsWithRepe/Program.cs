namespace p06.CombinationsWithRepe
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(char.Parse).ToArray();
            var combinations = int.Parse(Console.ReadLine());

            var slotsArr = new char[combinations];

            PrintVariations(input, slotsArr, combinations, 0, 0);
        }

        private static void PrintVariations(char[] arr, char[] slotsArr, int combinations, int index, int start)
        {
            if (index == combinations)
            {
                Console.WriteLine(string.Join(" ", slotsArr));
            }
            else
            {
                for (int i = start; i < arr.Length; i++)
                {
                    slotsArr[index] = arr[i];
                    PrintVariations(arr, slotsArr, combinations, index + 1, i);
                }
            }
        }
    }
}
