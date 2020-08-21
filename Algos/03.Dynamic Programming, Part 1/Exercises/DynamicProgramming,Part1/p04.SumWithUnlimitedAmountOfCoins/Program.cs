namespace p04.SumWithUnlimitedAmountOfCoins
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var inputArr = new int[] { 1, 2, 3, 4, 6 };
            var sum = 8;

            var combinations = 0;


            
            if (sum % inputArr[0] == 0) combinations++;

            for (int i = 1; i < inputArr.Length; i++)
            {
                var currentNumb = inputArr[i];
                
                var tempSum = currentNumb;
                for (int j = 0; j < i; j++)
                {

                    if (j == 0 && (sum - tempSum) % inputArr[j] == 0) { combinations++; j++; }
                    if (tempSum + inputArr[j] <= sum && j != 0) { tempSum += inputArr[j]; j = -1; }
                }
            }
            

            //combinations += FetchAllCombinationsWithCurrentNumb(currentNumber, i, inputArr, sum);
        }

        private static void Test()
        {

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
