namespace p05.CombinationsWithoutRepetition
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var sequenece = int.Parse(Console.ReadLine());
            var limit = int.Parse(Console.ReadLine());

            var arr = new int[sequenece];
            for (int i = 0, j = 1; i < arr.Length; i++, j++) arr[i] = j;
            var vector = new int[limit];

            CombineWithoutRepetition(arr, vector, 0, -1);
        }

        private static void CombineWithoutRepetition(int[] arr, int[] vector, int index, int currentIndex)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = currentIndex + 1; i < arr.Length; i++)
                {
                    vector[index] = arr[i];
                    CombineWithoutRepetition(arr, vector, index + 1, i);
                }
            }
        }
    }
}
