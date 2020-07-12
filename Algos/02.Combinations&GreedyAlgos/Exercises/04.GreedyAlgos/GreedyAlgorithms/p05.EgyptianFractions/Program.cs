namespace p05.EgyptianFractions
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Program
    {
        public static void Main()
        {
            var inputExpression = Console.ReadLine();
            var tokens = inputExpression.Split('/');
            var numerator = int.Parse(tokens[0]);
            var denominator = int.Parse(tokens[1]);
            if(numerator >= denominator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }
            var result = new List<string>();
            EgyptianFractions(numerator, denominator, result);
            Console.WriteLine($"{inputExpression} = {string.Join(" + ", result)}");
            //var expressionToSolve = numerator / denominator;

            //if(expressionToSolve >= 1)
            //{
            //    Console.WriteLine("Error (fraction is equal to or greater than 1)");
            //    return;
            //}

            //expressionToSolve = Math.Round(expressionToSolve, 25);

            //var numbers = new List<string>();

            //var result = 0M;
            //var currentNumber = 2M;

            //while (Math.Round(result, 25) != expressionToSolve)
            //{
            //    decimal temp = 1 / currentNumber;
            //    decimal tempResult = Math.Round(temp + result, 25);
            //    if (tempResult <= expressionToSolve)
            //    {
            //        numbers.Add($"1/{currentNumber}");
            //        result += temp;
            //    }
                
            //    currentNumber++;
            //}

            //Console.WriteLine($"{inputExpression} = {string.Join(" + ", numbers)}");
        }

        public static void EgyptianFractions(int numerator, int denominator, List<string> result)
        {
            // If either numerator or 
            // denominator is 0 
            if (denominator == 0 || numerator == 0)
                return;

            // If numerator divides denominator,  
            // then simple division  makes 
            // the fraction in 1/n form 
            if (denominator % numerator == 0)
            {
                result.Add($"1/{denominator / numerator}");
                return;
            }

            // If denominator divides numerator,  
            // then the given number is not fraction 
            if (numerator % denominator == 0)
            {
                Console.Write(numerator / denominator);
                return;
            }

            // We reach here dr > nr and dr%nr 
            // is non-zero. Find ceiling of 
            // dr/nr and print it as first 
            // fraction 
            int n = denominator / numerator + 1;
            result.Add($"1/{n}");
            //Console.Write("1/" + n + " + ");

            // Recur for remaining part 
            EgyptianFractions(numerator * n - denominator, denominator * n, result);
        }
    }
}
