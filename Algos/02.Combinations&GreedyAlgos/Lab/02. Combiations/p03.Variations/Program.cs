namespace p03.Variations
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
                //PrintVariations(arr, slotsArr, slots, index + 1);
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        slotsArr[index] = arr[i];
                        PrintVariations(arr, slotsArr, slots, index + 1, used); 
                        used[i] = false;
                    }
                    //Swap(arr, index, i);
                    //PrintVariations(arr, slotsArr, slots, index + 1);
                    //Swap(arr, i, index);
                }
            }
        }

        private static void Swap<T>(T[] arr, int leftIndex, int rightIndex)
        {
            var temp = arr[leftIndex];
            arr[leftIndex] = arr[rightIndex];
            arr[rightIndex] = temp;
        }
    }
}
