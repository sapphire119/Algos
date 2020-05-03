namespace p01.Index
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            //var arr = input.Split(' ').Select(int.Parse).ToArray();
            //var result = Sum(arr, 0);
            //Console.WriteLine(result);

            //Factorial
            //var result = Factorial(factorial);
            //Console.WriteLine(result);

            //Drawing
            //var number = int.Parse(input);
            //Drawing(number);

            //Generating Vector
            //var numb = int.Parse(input);
            //var arr = new int[numb];
            ////GenerateVector(arr, 0);
            //GenerateVector2(arr, 0);

            //Combinations
            var kCombinations = int.Parse(Console.ReadLine());
            var arr = input.Split(' ').Select(int.Parse).ToArray();
            var slotArr = new int[kCombinations];

            GenerateCombinations(arr, 0, slotArr, -1);
        }

        private static void GenerateCombinations(int[] arr, int index, int[] slotArr, int border)
        {
            if (index >= slotArr.Length)
            {
                Console.WriteLine(string.Join(" ", slotArr));
            }
            else
            {
                for (int i = border + 1; i < arr.Length; i++)
                {
                    slotArr[index] = arr[i];
                    GenerateCombinations(arr, index + 1, slotArr, i);
                }
            }
        }

        //private static void GenerateVector2(int[] arr, int index)
        //{
        //    if (index >= arr.Length)
        //    {
        //        Console.WriteLine(string.Join("", arr));
        //    }
        //    else
        //    {
        //        for (int i = 0; i <= 1; i++)
        //        {
        //            arr[index] = i;
        //            GenerateVector2(arr, index + 1);
        //        }
        //    }
        //}

        //private static void GenerateVector(int[] arr, int index)
        //{
        //    if (index == arr.Length)
        //    {
        //        Print(arr);
        //    }
        //    else
        //    {
        //        for (int i = index; i < arr.Length; i++)
        //        {
        //            arr[i] = 0;
        //            GenerateVector(arr, i + 1);
        //            arr[i] = 1;
        //            if (i == arr.Length - 1) Print(arr);
        //            //arr[i] = 0;
        //            //GenerateVector(arr, index + 1);
        //            //arr[i] = 1;
        //            //if (index == arr.Length - 1) Print(arr);
        //        }
        //    }
        //}

        //private static void Print(int[] arr)
        //{
        //    Console.WriteLine(string.Join("", arr));
        //}

        //private static void Drawing(int number)
        //{
        //    if (number == 0) return;

        //    Console.WriteLine(new string('*', number));
        //    Drawing(number - 1);
        //    Console.WriteLine(new string('#', number));
        //}

        //private static int Sum(int[] arr, int index)
        //{
        //    if (index >= arr.Length)
        //    {
        //        return 0;
        //    }

        //    return arr[index] + Sum(arr, index + 1);
        //}

        //private static int Factorial(int factorial)
        //{
        //    if (factorial == 0)
        //    {
        //        return 1;
        //    }

        //    return factorial * Factorial(factorial - 1);
        //}
    }
}
