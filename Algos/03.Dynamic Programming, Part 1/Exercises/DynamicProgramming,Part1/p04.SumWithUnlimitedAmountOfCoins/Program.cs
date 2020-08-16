namespace p04.SumWithUnlimitedAmountOfCoins
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var inputArr = new int[] { 1, 2, 3, 4, 6 };
            var sum = 6;

            var combinations = 0;
            for (int i = 0; i < inputArr.Length; i++)
            {
                var currentNumber = inputArr[i];
                combinations += FetchAllCombinationsWithCurrentNumb(currentNumber, i, inputArr, sum);
            }
        }

        private static int FetchAllCombinationsWithCurrentNumb(int currentNumber, int index, int[] inputArr, int sum)
        {
            //case when a number cannot divide
            if (index == 0)
                if (sum % currentNumber == 0) return 1;
                else return 0;

            var combinations = 0;
            var tempSum = currentNumber;
            while (tempSum <= sum)
            {

                //for (int i = 0; i < index; i++)
                //{

                //}
                tempSum += currentNumber;
            }

            if (tempSum == sum) combinations++;
            //var tempSum = currentNumber;
            //while (sum - tempSum != 0)
            //{

            //}
            return combinations;
        }
    }
}
