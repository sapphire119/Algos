namespace Recursion
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var tempArr = new int[arr.Length];
            Array.Copy(arr, tempArr, arr.Length);
            ReverseArray(arr, tempArr, 0);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void ReverseArray(int[] arr, int[] tempArr, int index)
        {
            if (index >= arr.Length) return;
            else
            {
                arr[index] = tempArr[arr.Length - 1 - index];
                ReverseArray(arr, tempArr, index + 1);
            }
        }
    }
}
