namespace p03.InversionCount
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int inversions = 0;

        public static void Main()
        {
            //var input = new[] { 5, 4, 3, 2, 1 };
            //var input = new[] { 2, 4, 1, 3, 5 };
            //var input = new[] { 8, 4, 2, 1 };
            var input = new[] { 38, 27, 43, 3, 9, 82, 10 };
            //var input = new[] { 1, 2, 3, 4, 5 };
            //var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            MergeSort(input, 0, input.Length - 1);
            //Console.WriteLine(string.Join(" ", input));
            Console.WriteLine(inversions);
        }

        private static void MergeSort(int[] arr, int leftIndex, int rightIndex)
        {
            if (rightIndex > leftIndex)
            {
                var inversions = 0;
                //https://www.techiedelight.com/inversion-count-array/
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

            //var multiplier = 0;
            //var counter = 0;
            
            //Too easy, and slow
            //for (int i = 0; i < leftArr.Length; i++)
            //{
            //    for (int j = 0; j < rightArr.Length; j++)
            //    {
            //        if(leftArr[i] > rightArr[j])
            //        {
            //            counter++;
            //        }
            //    }
            //}

            var tempIndex = leftIndex;
            while (startLeft < leftArr.Length && startRight < rightArr.Length)
            {
                if (leftArr[startLeft] > rightArr[startRight])
                {
                    arr[tempIndex] = rightArr[startRight];
                    startRight++;
                    //multiplier++;
                }
                else
                {
                    //if (multiplier > 0) counter++;
                    arr[tempIndex] = leftArr[startLeft];
                    startLeft++;
                }
                tempIndex++;
            }

            while (startLeft < leftArr.Length)
            {
                //if (multiplier > 0) counter++;
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

            //result += (multiplier * counter);
        }
    }
}
