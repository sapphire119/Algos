namespace p04.Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {

        public static void Main()
        {
            //var sequenece = int.Parse(Console.ReadLine());
            //var limit = int.Parse(Console.ReadLine());

            //var input = int.Parse(Console.ReadLine());
            
            //for (int i = 0, j = 1; i < arr.Length; i++, j++) arr[i] = j;
            
            //var factorial = Factorial(4);

            //var input = Console.ReadLine().ToCharArray();
            //var input = new char[] { 'a', 'b', 'c' };
            //var input = new char[] { 'x', 'y' };
            //var input = new char[] { 'x', 'x', 'x', 'y' };
            //var input = "xxyy".ToCharArray();
            //var input = new char[] { 'a', 'a', 'h', 'h', 'h', 'a', 'a' };
            //var input = "nopqrstuvww".ToCharArray();
            //var input = "12333".ToCharArray();
            //var input = "1233".ToCharArray();
            //var input = "123".ToCharArray();
            //var input = "112233".ToCharArray();
            //var input = "1122".ToCharArray();
            //var input = "abbccc";
            //var input = "aaaaaaaaaa".ToCharArray();
            //var input = "ahhaa".ToCharArray();
            //var input = "abcabac".ToCharArray();
            //var symbolCount = new Dictionary<char, int>();
            //for (int i = 0; i < input.Length; i++)
            //{
            //    var currentChar = input[i];
            //    if (!symbolCount.ContainsKey(currentChar)) symbolCount[currentChar] = 0;
            //    else symbolCount[currentChar]++;
            //}

            ////var valueCount = symbolCount.OrderByDescending(x => x.Value).Select(x => x.Value).ToArray();

            //double totalUniqueSymbolsCount = symbolCount.Count;
            //double factorialCombinations = Factorial(symbolCount.Count);
            //double maxDuplicatesCount = GetDuplicatesCount(symbolCount, totalUniqueSymbolsCount);

            //var result = factorialCombinations - (maxDuplicatesCount / totalUniqueSymbolsCount * factorialCombinations);
            //Console.WriteLine(result);
        }

        private static double GetDuplicatesCount(Dictionary<char, int> valueCount, double totalUniqueSymbolsCount)
        {
            var maxValue = valueCount.Max(x => x.Value);
            var minValue = valueCount.Min(x => x.Value);
            foreach (var value in valueCount.Values)
            {
                if (value > minValue && value < maxValue) minValue = value;
            }

            if (totalUniqueSymbolsCount > 1)
            {
                var difference = maxValue - minValue;
                if (difference > totalUniqueSymbolsCount) return totalUniqueSymbolsCount;
                return maxValue - minValue;
            }
            else
            {
                return maxValue > totalUniqueSymbolsCount ? totalUniqueSymbolsCount : maxValue;
            }
        }

        private static int Factorial(int factorial)
        {
            var result = 1;
            for (int i = 1; i <= factorial; i++) result *= i;
            return result;
        }
    }
}
