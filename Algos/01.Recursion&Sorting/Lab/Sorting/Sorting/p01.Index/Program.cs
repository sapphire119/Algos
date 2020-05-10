namespace p01.Index
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //var arr = new int[] { 1, 4, 2, -1, 0 };
            //Console.WriteLine($"Initial array: {string.Join(" ", arr)}");

            MergeSort(input, 0, input.Length - 1);
            Console.WriteLine(string.Join(" ", input));
            //Console.WriteLine($"Sorted array: {string.Join(" ", arr)}");
        }

        private static void MergeSort(int[] arr, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                var middle = (leftIndex + rightIndex) / 2;
                MergeSort(arr, leftIndex, middle);
                MergeSort(arr, middle + 1, rightIndex);
                MergeArray(arr, leftIndex, middle, rightIndex);
            }
        }

        private static void MergeArray(int[] arr, int leftIndex, int middle, int rightIndex)
        {
            var tempArr = new int[arr.Length];
            Array.Copy(arr, tempArr, arr.Length);

            for (int i = leftIndex, tempLeft = leftIndex, tempMidRight = middle + 1; i <= rightIndex; i++)
            {
                if (tempLeft > middle)
                {
                    arr[i] = tempArr[tempMidRight];
                    tempMidRight++;
                }
                else if(tempMidRight > rightIndex)
                {
                    arr[i] = tempArr[tempLeft];
                    tempLeft++;
                }
                else
                {
                    var leftEle = tempArr[tempLeft];
                    var rightEle = tempArr[tempMidRight];

                    var comparison = leftEle.CompareTo(rightEle);
                    if (comparison == -1)
                    {
                        arr[i] = leftEle;
                        tempLeft++;
                    }
                    else if (comparison == 1)
                    {
                        arr[i] = rightEle;
                        tempMidRight++;
                    }
                    else
                    {
                        arr[i++] = leftEle;
                        arr[i] = rightEle;
                        tempLeft++;
                        tempMidRight++;
                    }
                }
            }
        }
    }
}