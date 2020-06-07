namespace p06.GenerateAllPermutations
{
    using System;
    using System.Linq;

    public class Program
    {
        private static int count = 0;

        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            var arr = Enumerable.Range(1, input).ToArray();
            var vector = new int[input];
            var freePositions = new int[input];
            Permutations(arr, vector, freePositions, 0);
            Console.WriteLine(count);
        }

        private static void Permutations(
            int[] arr, int[] vector, int[] freePositions, int index)
        {
            if (index == arr.Length)
            {
                count++;
                Console.WriteLine(string.Join("", vector));
            }
            else
            {
                for (int currentIndex = 0; currentIndex < arr.Length; currentIndex++)
                {
                    if (freePositions[currentIndex] != 1)
                    {
                        vector[index] = arr[currentIndex];
                        freePositions[currentIndex] = 1;
                        Permutations(arr, vector, freePositions, index + 1);
                        freePositions[currentIndex] = 0;
                    }
                }
            }
            //123
            //132
            //213
            //231
            //312
            //321
        }
    }
}
