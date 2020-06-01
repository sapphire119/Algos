namespace p02.Searching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        //Only 32-bit integers
        private static readonly int[] Fibs = new int[]
        {
            0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903, 2147483647
        };

        public static void Main()
        {
            #region Binary Search
            //var input = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            //var a = new int[] { 2 };
            //var t = 1.CompareTo(10);
            //var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //var elementToSearch = int.Parse(Console.ReadLine());
            //var element = BinarySearch(input, elementToSearch, 0, input.Length - 1);
            //Console.WriteLine(element);
            #endregion

            var input = new[] { 1, 2, 3, 4, 5 };
            var input1 = new[] { 2, 3, 4, 10, 40 };

            //Console.WriteLine(string.Join(", ", GenerateFibonacciNumber()));
            FibonacciSearch(input1, 10);
        }

        #region Binary Search
        private static int BinarySearch(int[] arr, int elementToSearch, int leftIndex, int rightIndex)
        {
            if (rightIndex >= leftIndex)
            {
                var middleIndex = (leftIndex + rightIndex) / 2;
                var compare = elementToSearch.CompareTo(arr[middleIndex]);
                if (compare < 0)
                {
                    return BinarySearch(arr, elementToSearch, leftIndex, middleIndex - 1);
                }
                else if (compare > 0)
                {
                    return BinarySearch(arr, elementToSearch, middleIndex + 1, rightIndex);
                }
                else
                {
                    return middleIndex;
                }
            }

            return -1;
        }
        #endregion

        private static int FibonacciSearch(int[] arr, int elementToSearch)
        {
            var fibMIndex = GetFibNumberGreaterOrEqualToArrLength(arr.Length);
            var fibMNumber = Fibs[fibMIndex];


            return default;
        }

        private static int GetFibNumberGreaterOrEqualToArrLength(int currentLength)
        {
            var fibMIndex = -1;
            for (int i = 0; i < Fibs.Length; i++)
            {
                if (Fibs[i] > currentLength) break;
                fibMIndex = Fibs[i];
            }

            return fibMIndex;
        }

        private static List<long> GenerateFibonacciNumber()
        {
            var numbers = new List<long>();
            var a = 0L;
            var currentNumber = 1L;
            numbers.Add(a);
            while (currentNumber < int.MaxValue)
            {
                numbers.Add(currentNumber);
                var temp = a + currentNumber;
                a = currentNumber;
                currentNumber = temp;
            }
            numbers.Add(int.MaxValue);

            return numbers;
        }
    }
}