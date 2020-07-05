namespace ConsoleApp1
{       
    using System;
    using System.Runtime.InteropServices;

    public class Program
    {
        public static void Main()
        {
            var arr = new int[3];
            var sndArr = new int[] { 1, 2, 3, 4 };

            var combinations = 2;
            var arrCombo = new int[combinations];

            //var combinations = 2;
            //GenerateCombinations(arr, 0);

            GenerateCombinations(sndArr, 0, arrCombo, -1);
        }

        //private static void GenerateCombinations(int[] arr, int index, int[] arrCombo, int border)
        //{
        //    if (index >= arrCombo.Length)
        //    {
        //        Console.WriteLine(string.Join(" ", arrCombo));
        //    }
        //    else
        //    {
        //        for (int i = border + 1; i < arr.Length; i++)
        //        {
        //            arrCombo[index] = arr[i];
        //            GenerateCombinations(arr, index + 1, arrCombo, i);
        //        }
        //    }
        //}

        private static void GenerateCombinations(int[] arr, int index, int[] arrCombo, int border)
        {
            if (index >= arrCombo.Length)
            {
                Console.WriteLine(string.Join(" ", arrCombo));
            }
            else
            {
                for (int i = border; i <= arr.Length; i++)
                {
                    arrCombo[index] = arr[i - 1];
                    GenerateCombinations(arr, index + 1, arrCombo, border + i);
                }
            }
        }

        private static void GenerateCombinations(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, index + 1);
                }
            }
        }
    }
}
