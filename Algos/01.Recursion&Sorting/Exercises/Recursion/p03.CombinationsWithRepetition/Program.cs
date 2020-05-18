namespace p03.CombinationsWithRepetition
{
    using Microsoft.VisualBasic;
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var limit = int.Parse(Console.ReadLine());
            var arrLength = int.Parse(Console.ReadLine());

            var vector = new int[arrLength];
            var arr = Enumerable.Range(1, limit).ToArray();

            Combiations(arr, vector, 0, 0);

            //int n = 5;
            //int k = 3;

            //Console.WriteLine();
            //// k == 3 => 3 nested for-loops
            //for (int i1 = 1; i1 <= n; i1++)
            //{
            //    for (int i2 = i1; i2 <= n; i2++)
            //    {
            //        for (int i3 = i2; i3 <= n; i3++)
            //        {
            //            Console.WriteLine($"{i1} {i2} {i3}");
            //        }
            //    }
            //}

        }

        private static void Combiations(int[] arr, int[] vector, int index, int currentIndex)
        {
            if (index >= vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = currentIndex; i < arr.Length; i++)
                {
                    vector[index] = arr[i];
                    Combiations(arr, vector, index + 1, i);
                }
            }
        }
    }
}
