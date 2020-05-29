namespace p01.Index
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //var input = new int[100_000];
            //for (int i = 0; i < input.Length / 2; i++) input[i] = 10;
            //input[input.Length / 2] = 20;
            //for (int i = (input.Length / 2) + 1; i < input.Length; i++) input[i] = 5;

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //MergeSort(input, 0, input.Length - 1);
            //stopwatch.Stop();
            //MergeSort(input, 0, input.Length - 1);
            //Console.WriteLine(string.Join(" ", input));
            //Console.WriteLine(string.Join(" ", input));

            //Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}");
            //var mergeSortInput = new int[] { 38, 27, 43, 3, 9, 82, 10 };
            //var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //MergeSort(input, 0, input.Length - 1);
            //////////////////////////////////////////////////////////////////////

            //var quicksortInput = new int[] { 10, 80, 40, 50, 30, 90, 70 };
            //var quicksortInput1 = new int[] { 10, 80, 40, 90, 30, 50, 70 };
            //var quicksortInput2 = new int[] { 10, 80, 40, 30, 50, 90, 70 };
            //var quicksortInput3 = new int[] { 30, 80, 40, 10, 50, 90, 70 };
            //var input = new int[] { 1, 4, 2, -1, 0 };
            //var input1 = new int[] { 1, 4, -3, -5, 2, 0, -9, -1, -6 };
            //var input2 = new int[] { 5, 4, 3, 2, 1 };
            //L -> 10, 30, 40, (50)
            //R -> 80, 90, 70

            //Assume -> 10 40 30
            //Pivot -> 40
            //L -> 10, 30
            //
            //QuickSort(input2, 0, input2.Length - 1);
            //Console.WriteLine("{0}", string.Join(" ", input2));

            //QuickSort(input, 0, input.Length - 1);
            //Console.WriteLine("{0}", string.Join(" ", input));

            //QuickSort(input1, 0, input1.Length - 1);
            //Console.WriteLine("{0}", string.Join(" ", input1));

            //QuickSort(quicksortInput, 0, quicksortInput.Length - 1);
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

        //variation of Insertion Sort, need to implement InsertionSort first
        #region ShellSort
        private static void ShellSort()
        {
        }
        #endregion

        //TODO
        #region RadixSort
        private static void RadixSort()
        {

        }
        #endregion

        #region MergeSort
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
        #endregion

        #region QuickSort
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
                    if (arr[i] == pivotElement) pivotIndex = j;
                    Swap(arr, j, i);
                }
            }

            if (i + 1 < pivotIndex)
                Swap(arr, i + 1, pivotIndex);
            return (i + 1);
        }

        private static void Swap<T>(T[] arr, int currentIndex, int indexArr)
        {
            var temp = arr[indexArr];
            arr[indexArr] = arr[currentIndex];
            arr[currentIndex] = temp;
        }
        #endregion


        //Need to implement first Insertion Sort
        #region BucketSort
        private static void BucketSort()
        {
        }
        #endregion
    }
}
