namespace p01.Index
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //var mergeSortInput = new int[] { 38, 27, 43, 3, 9, 82, 10 };
            //var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //MergeSort(input, 0, input.Length - 1);
            //////////////////////////////////////////////////////////////////////

            var quicksortInput = new int[] { 10, 80, 40, 50, 30, 90, 70 };
            //var quicksortInput1 = new int[] { 10, 80, 40, 90, 30, 50, 70 };
            //var quicksortInput2 = new int[] { 10, 80, 40, 30, 50, 90, 70 };
            //var quicksortInput3 = new int[] { 30, 80, 40, 10, 50, 90, 70 };

            //L -> 10, 30, 40, (50)
            //R -> 80, 90, 70

            //Assume -> 10 40 30
            //Pivot -> 40
            //L -> 10, 30
            //
            QuickSort(quicksortInput, 0, quicksortInput.Length - 1);
            //QuickSort(quicksortInput1, 0, quicksortInput1.Length - 1);
            //QuickSort(quicksortInput2, 0, quicksortInput2.Length - 1);
            //QuickSort(quicksortInput3, 0, quicksortInput3.Length - 1);
            //Console.WriteLine("{0}", string.Join(" ", quicksortInput));
            //Console.WriteLine("{0}", string.Join(" ", quicksortInput1));
            //Console.WriteLine("{0}", string.Join(" ", quicksortInput2));
            //Console.WriteLine("{0}", string.Join(" ", quicksortInput3));
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
                var pivot = Partition(arr, leftIndex, rightIndex);

                QuickSort(arr, leftIndex, pivot - 1);
                QuickSort(arr, pivot + 1, rightIndex);
            }
        }

        private static int Partition(int[] arr, int leftIndex, int rightIndex)
        {
            var pivotIndex = (leftIndex + rightIndex) / 2;
            var pivotElement = arr[pivotIndex];

            var i = leftIndex - 1;
            for (int j = leftIndex; j <= rightIndex; j++)
            {
                if (arr[j] < pivotElement)
                {
                    i++;
                    Swap(arr, j, i);
                }
            }
            if(i + 1 < pivotIndex)
                Swap(arr, i + 1, pivotIndex);
            return (i + 1);
        }

        private static void Swap<T>(T[] arr, int currentIndex, int indexArr)
        {
            var temp = arr[indexArr];
            arr[indexArr] = arr[currentIndex];
            arr[currentIndex] = temp;
        }
        //private static void BucketSort()
    }
}
