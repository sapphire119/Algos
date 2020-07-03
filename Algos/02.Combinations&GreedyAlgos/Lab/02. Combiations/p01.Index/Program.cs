namespace p01.Index
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToArray();
            Permute(input, 0);
            //Console.WriteLine("Second permute type");

            //var used = new bool[input.Length];
            //var vector = new string[input.Length];
            //PermuteSecond(input, vector, used, 0);
        }

        //#region Second
        //private static void PermuteSecond(string[] input, string[] vector, bool[] used, int index)
        //{
        //    if (index == input.Length)
        //    {
        //        Console.WriteLine(string.Join(" ", vector));
        //    }
        //    else
        //    {
        //        for (int i = 0; i < input.Length; i++)
        //        {
        //            if (!used[i])
        //            {
        //                used[i] = true;
        //                vector[index] = input[i];
        //                PermuteSecond(input, vector, used, index + 1);
        //                used[i] = false;
        //            }
        //        }
        //    }
        //}
        //#endregion

        private static void Permute(string[] input, int index)
        {
            if (index == input.Length)
            {
                Console.WriteLine(string.Join(" ", input));
            }
            else
            {
                Permute(input, index + 1);
                for (int i = index + 1; i < input.Length; i++)
                {
                    Swap(input, index, i);
                    Permute(input, index + 1);
                    Swap(input, i, index);
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
