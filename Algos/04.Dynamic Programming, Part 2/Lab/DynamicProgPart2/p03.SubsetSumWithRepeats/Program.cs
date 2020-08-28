namespace p03.SubsetSumWithRepeats
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int[] nums = { 3, 5, 2 };
            var targetSum = 6;
            var possibleSums = new bool[targetSum + 1];
            possibleSums[0] = true;
            for (int sum = 0; sum < possibleSums.Length; sum++)
            {
                if (possibleSums[sum])
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        var currentNum = nums[j];
                        var newSum = currentNum + sum;
                        if (newSum <= targetSum)
                            possibleSums[newSum] = true;
                    }
                }
            }

            var subset = new List<int>();
            while (targetSum > 0)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    var currentNumber = nums[i];
                    var newSum = targetSum - currentNumber;
                    if (newSum >= 0 && possibleSums[newSum])
                    {
                        targetSum = newSum;
                        subset.Add(currentNumber);
                    }

                }
            }

            Console.WriteLine(string.Join(" ", subset));
        }
    }
}
