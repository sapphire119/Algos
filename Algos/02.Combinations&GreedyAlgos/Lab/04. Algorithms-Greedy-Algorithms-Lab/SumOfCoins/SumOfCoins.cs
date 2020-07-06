namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var result = new Dictionary<int, int>();
            coins = coins.OrderByDescending(x => x).ToList();

            var tempOldSum = targetSum;
            var tempSum = 0;
            var tempIndex = 0;

            while (tempIndex < coins.Count && tempSum != targetSum)
            {
                var currentCoinValue = coins[tempIndex];
                if (currentCoinValue + tempSum > targetSum) { tempIndex++; continue; }

                var coinsCount = tempOldSum / currentCoinValue;
                var temp = (coinsCount * currentCoinValue);

                result.Add(currentCoinValue, coinsCount);
                tempSum += temp;
                tempOldSum -= temp;
            }

            if (tempSum != targetSum) throw new InvalidOperationException();

            return result;
        }
    }
}