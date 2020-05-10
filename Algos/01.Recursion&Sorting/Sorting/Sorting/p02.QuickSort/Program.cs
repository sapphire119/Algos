namespace p02.QuickSort
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //4, 5, 3, 1, 2
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var arr = new int[] { 10, 50, 90, 70, 40, 30, 80 };
            //input = arr;
            Console.WriteLine($"Initial arr\n{string.Join(" ", input)}");

            QuickSort(input, 0, input.Length - 1);

            Console.WriteLine($"Sorted arr:\n{string.Join(" ", input)}");
        }

        private static void QuickSort(int[] arr, int leftIndex, int rightIndex)
        {
            if (rightIndex > leftIndex)
            {
                var pivotIndex = Parition(arr, leftIndex, rightIndex);

                QuickSort(arr, leftIndex, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, rightIndex);
            }
        }

        private static int Parition(int[] arr, int leftIndex, int rightIndex)
        {
            var middleIndex = (leftIndex + rightIndex) / 2;

            var pivotElement = arr[middleIndex];

            var leftElements = new List<int>();
            var rightElements = new List<int>();

            for (int i = leftIndex; i <= rightIndex; i++)
            {
                var currentEle = arr[i];
                if (currentEle < pivotElement) leftElements.Add(currentEle);
                else if (currentEle > pivotElement) rightElements.Add(currentEle);
            }

            for (int i = leftIndex, p = 0, k = 0; i <= rightIndex; i++)
            {
                if (k < leftElements.Count)
                {
                    arr[i] = leftElements[k];
                    k++;
                }
                else if (k == leftElements.Count)
                {
                    arr[i] = pivotElement;
                    middleIndex = i;
                    k++;
                }
                else if (p < rightElements.Count)
                {
                    arr[i] = rightElements[p];
                    p++;
                }
            }

            return middleIndex;
        }
    }
}
