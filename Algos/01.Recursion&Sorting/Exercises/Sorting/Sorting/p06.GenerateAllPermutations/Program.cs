namespace p06.GenerateAllPermutations
{
    using System;
    using System.Linq;

    public class Program
    {
        //private static int count = 0;

        public static void Main()
        {
            var input = "abca".ToCharArray();
            //var arr = Enumerable.Range(1, input).ToArray();
            var vector = new char[input.Length];
            var freePositions = new int[input.Length];
            Permutations(input, vector, freePositions, 0);
            //Console.WriteLine(count);
        }

        private static void Permutations(
            char[] arr, char[] vector, int[] freePositions, int index)
        {
            if (index == arr.Length)
            {
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
