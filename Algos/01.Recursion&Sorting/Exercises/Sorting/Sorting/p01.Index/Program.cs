namespace p01.Index
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            //MergeSort
            //QuickSort


            var sb = new StringBuilder();
            sb.AppendLine("asdasdasdasd");
            sb.AppendLine("asdasdasdasd");
            sb.AppendLine("asdasdasdasd");
            sb.AppendLine("asdasdasdasd");
            sb.AppendLine("asdasdasdasd");

            Console.WriteLine(sb.ToString().Trim());
            Console.WriteLine("after");
            sb.AppendLine("1");
            sb.AppendLine("asd");
            Console.WriteLine(sb.ToString().Trim());
            //#region Bubble Sort
            ////var input = new[] { 5, 1, 4, 2, 8 };
            ////var input = new[] { 1, 4, 2, -1, 0, 15, 12, 9, -100, 50, 32, -8 };

            ////BubbleSort(input);
            ////Console.WriteLine(string.Join(" ", input));
            //#endregion

            //#region InsertionSort
            ////var input = new[] { 1, 4, 2, -1, 0, 15, 12, 9, -100, 50, 32, -8 };
            ////var input = new[] { 4, 3, 2, 10, 12, 1, 5, 6 };

            ////InsertionSort(input);
            ////Console.WriteLine(string.Join(" ", input));
            //#endregion

            //#region Radix Sort
            ////k = 9 (Number of possible digits)
            ////N > 0
            ////var buckets = new Dictionary<int, Queue<int>>();
            ////for (int i = 0; i < 10; i++) buckets[i] = new Queue<int>();
            ////var input = new int[] { 3221, 1, 10, 9680, 577, 9420, 7, 5622, 4793, 2030, 3138, 82, 2599, 743, 4127 };
            ////var maxDigitsCount = GetMaxLimitingDigit(input);
            ////RadixSort(input, buckets, 0, maxDigitsCount);
            ////Console.WriteLine(string.Join(" ", input));
            //#endregion
        }

        #region BubbleSort
        private static void BubbleSort(int[] arr)
        {
            while (true)
            {
                var comparePairsCount = 0;
                for (int i = 0, j = 1; j < arr.Length; i++, j++)
                {
                    var firstEle = arr[i];
                    var secondEle = arr[j];
                    if (firstEle > secondEle)
                    {
                        comparePairsCount++;
                        SwapBubbleSort(arr, i, j);
                    }
                }
                if (comparePairsCount == 0) break;
            }

            //for (int i = 0; i < arr.Length; i++)
            //    for (int j = 0; j < arr.Length - i - 1; j++)
            //    {
            //        if (arr[j] > arr[j + 1])
            //        {
            //            SwapBubbleSort(arr, j, j + 1);
            //        }
            //    }
        }

        private static void SwapBubbleSort<T>(T[] arr, int currentIndex, int indexArr)
        {
            var temp = arr[indexArr];
            arr[indexArr] = arr[currentIndex];
            arr[currentIndex] = temp;
        }

        #endregion

        #region InsertionSort
        private static void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var swapIndex = -1;
                for (int j = i; j >= 0; j--)
                {
                    if (arr[i] < arr[j])
                    {
                        swapIndex = j;
                    }
                }
                if (swapIndex >= 0)
                {
                    for (int p = swapIndex; p < i; p++)
                    {
                        var temp = arr[p];
                        arr[p] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            //int n = arr.Length;
            //for (int i = 1; i < n; ++i)
            //{
            //    int key = arr[i];
            //    int j = i - 1;

            //    // Move elements of arr[0..i-1], 
            //    // that are greater than key, 
            //    // to one position ahead of 
            //    // their current position 
            //    while (j >= 0 && arr[j] > key)
            //    {
            //        arr[j + 1] = arr[j];
            //        j = j - 1;
            //    }
            //    arr[j + 1] = key;
            //}
        }
        #endregion

        //Similar to Counting/Radix Sort
        #region BucketSort
        private static void BucketSort()
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

        //QuickSort with Middle pivot
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

        #region RadixSort

        //Only positive
        private static void RadixSort(int[] arr, Dictionary<int, Queue<int>> buckets, int currentDigit, int maxDigitsCount)
        {
            if (currentDigit <= maxDigitsCount)
            {
                //Move elements into Buckets
                for (int i = 0; i < arr.Length; i++)
                {
                    //Move element into bucket
                    var currentEle = arr[i];
                    //Probabbly move to Dictionary < element, number of digits>
                    var currentEleDigits = GetDigitsCount(currentEle);
                    if (currentDigit <= currentEleDigits)
                    {
                        var nthDigit = GetDigit(currentEle, currentDigit);
                        buckets[nthDigit].Enqueue(currentEle);
                    }
                    else
                    {
                        buckets[0].Enqueue(currentEle);
                    }
                }

                //Move elements from Bucket to Arr
                for (int i = 0, index = 0; i < buckets.Values.Count; i++)
                {
                    var currentBucket = buckets[i];
                    while (currentBucket.Count != 0)
                    {
                        arr[index++] = currentBucket.Dequeue();
                    }
                }

                RadixSort(arr, buckets, currentDigit + 1, maxDigitsCount);
            }
        }

        private static int GetMaxLimitingDigit(int[] arr)
        {
            var maxDigit = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                var currentDigitsCount = GetDigitsCount(arr[i]);
                if (maxDigit < currentDigitsCount)
                {
                    maxDigit = currentDigitsCount;
                }
            }

            return maxDigit;
        }

        private static int GetDigitsCount(int currentEle)
        {
            return (int)Math.Floor(Math.Log(currentEle, 10));
        }

        private static int GetDigit(int currentEle, int currentDigit)
        {
            return (currentEle / (int)Math.Pow(10, currentDigit)) % 10;
        }

        #endregion
    }

    public class Test
    {
        public Test(string a)
        {
            this.A = a; 
        }

        public string A { get; set; }
    }
}
