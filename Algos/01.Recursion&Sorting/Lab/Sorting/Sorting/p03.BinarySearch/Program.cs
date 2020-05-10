namespace p03.BinarySearch
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //var numberToSearch = int.Parse(Console.ReadLine());

            var input = new int[] { -1, 0, 1, 2, 4 };
            var n = -10;

            var index = BinarySearch(input, n, 0, input.Length - 1, -1);
            Console.WriteLine(index);
        }

        private static int BinarySearch(int[] arr, int n, int leftIndex, int rightIndex, int currentIndex)
        {
            if (rightIndex > leftIndex)
            {
                var middleIndex = (leftIndex + rightIndex) / 2;
                if (n < arr[middleIndex])
                {
                    currentIndex = BinarySearch(arr, n, leftIndex, middleIndex - 1, currentIndex);
                }
                else if (arr[middleIndex] < n)
                {
                    currentIndex = BinarySearch(arr, n, middleIndex + 1, rightIndex, currentIndex);
                }
                else
                {
                    return middleIndex;
                } 
            }

            return currentIndex;
        }
    }
}
