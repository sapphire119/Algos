namespace Words
{
    using System;
    using System.Collections.Generic;

    public class WordsMain
    {
        private static int resultsCount = 0;

        static void Main(string[] args)
        {
            var source = Console.ReadLine().ToCharArray();
            PermWithoutRepetitions(source, 0);
            Console.WriteLine(resultsCount);
        }

        private static void PermWithoutRepetitions(char[] source, int index)
        {
            if (index >= source.Length)
            {
                for (int i = 0; i < source.Length - 1; i++)
                {
                    if (source[i] == source[i + 1])
                    {
                        return;
                    }
                }

                resultsCount++;
            }
            else
            {
                var swapped = new HashSet<char>();
                for (int k = index; k < source.Length; k++)
                {
                    if (!swapped.Contains(source[k]))
                    {
                        Swap(ref source[index], ref source[k]);
                        PermWithoutRepetitions(source, index + 1);
                        Swap(ref source[index], ref source[k]);

                        swapped.Add(source[k]);
                    }
                }
            }
        }

        private static void Swap(ref char i, ref char k)
        {
            var temp = i;
            i = k;
            k = temp;
        }

        //JohnsonTrotter support methods

        private static bool ChangeSign(bool[] signArr, int currentEleSignIndex, out int changeCount)
        {
            changeCount = 0;
            for (int i = currentEleSignIndex + 1; i < signArr.Length; i++, changeCount++) signArr[i] = !signArr[i];
            return changeCount > 0;
        }

        private static int CalcNextIndex(bool[] signArr, int currentEleSignIndex, int currentIndex)
        {
            return !signArr[currentEleSignIndex] ? currentIndex - 1 : currentIndex + 1;
        }

        private static void Switch<T>(T[] arr, int firstIndex, int secondIndex)
        {
            var temp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = temp;
        }
    }
}