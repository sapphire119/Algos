namespace p04.SumWithUnlimitedAmountOfCoins
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            //var inputArr = new int[] { 1, 2, 5, 10, 20, 50, 100 };
            var inputArr = new int[] { 1, 2, 3, 4, 6 };
            //var inputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //var sum = int.Parse(Console.ReadLine());
            var sum = 8;

            var combinations = 0;
            
            if (sum % inputArr[0] == 0) combinations++;

            for (int i = 1; i < inputArr.Length; i++)
            {
                var currentNumb = inputArr[i];
                var accumulatedOriginalNumb = currentNumb;
                var tempSum = accumulatedOriginalNumb;
                for (int j = 0; j <= i; j++)
                {
                    //if(j != 0)
                    //{
                    //    accumulatedOriginalNumb += currentNumb;
                    //    tempSum = accumulatedOriginalNumb;
                    //    if (tempSum > sum) break;
                    //    j = -1;
                    //    continue;
                    //}
                    //if (tempMax < j) { tempMax = j; tempSum = currentNumb; }
                    if (j == 0 && (sum - tempSum) % inputArr[j] == 0) { combinations++; j++; }
                    if (tempSum + inputArr[j] <= sum && j != 0) { tempSum += inputArr[j]; j = -1; }
                }
            }
            Console.WriteLine(combinations);
        }
    }
}
