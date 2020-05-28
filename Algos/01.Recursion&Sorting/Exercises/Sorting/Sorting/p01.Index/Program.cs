namespace p01.Index
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //MergeSort(input, 0, input.Length - 1);
            //////////////////////////////////////////////////////////////////////

            var input = new int[] { 38, 27, 43, 3, 9, 82, 10 };



            QuickSort(input, 0, input.Length - 1);


            Console.WriteLine("{0}", string.Join(" ", input));
        }
        //private static void InsertionSort()
        //private static void BubbleSort()
        //private static void ShellSort()
        private static void MergeSort(int[] arr, int leftIndex, int rightIndex)
        {
            if (rightIndex > leftIndex)
            {
                var middle = (leftIndex + rightIndex) / 2;
                MergeSort(arr, leftIndex, middle);
                MergeSort(arr, middle + 1, rightIndex);
                Merge(arr, leftIndex, middle, rightIndex);
            }
        }
        private static void Merge(int[] arr, int leftIndex, int middle, int rightIndex)
        {
            var leftArr = new int[middle - leftIndex + 1];
            var rightArr = new int[rightIndex - middle];

            for (int i = leftIndex, p = 0; i <= middle; i++, p++) leftArr[p] = arr[i];
            for (int i = middle + 1, p = 0; i <= rightIndex; i++, p++) rightArr[p] = arr[i];

            var startLeft = 0;
            var startRight = 0;

            var tempIndex = leftIndex;
            while (startLeft < leftArr.Length && startRight < rightArr.Length)
            {
                if (leftArr[startLeft] > rightArr[startRight])
                {
                    arr[tempIndex] = rightArr[startRight];
                    startRight++;
                }
                else
                {
                    arr[tempIndex] = leftArr[startLeft];
                    startLeft++;
                }
                tempIndex++;
            }

            while (startLeft < leftArr.Length)
            {
                arr[tempIndex] = leftArr[startLeft];
                startLeft++;
                tempIndex++;
            }

            while (startRight < rightArr.Length)
            {
                arr[tempIndex] = rightArr[startRight];
                startRight++;
                tempIndex++;
            }
        }
        private static void QuickSort(int[] arr, int leftIndex, int rightIndex)
        {
            if (rightIndex > leftIndex)
            {

            }
        }
        //private static void BucketSort()
    }
}
