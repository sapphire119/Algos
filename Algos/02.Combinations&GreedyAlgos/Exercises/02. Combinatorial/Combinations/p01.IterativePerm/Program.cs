namespace p01.IterativePerm
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Program
    {
        public static void Main()
        {
            var input = "ABC".ToCharArray();
            Array.Sort(input);
            var directionArr = new bool[input.Length];
            var positions = Enumerable.Range(0, input.Length).ToArray();

            SteinhausJohnsonTrotter(input, directionArr, positions, input.Length - 1);
        }

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

        private static void SteinhausJohnsonTrotter(char[] elements, bool[] signArr, int[] positions, int currentEleSignIndex)
        {
            Console.WriteLine(string.Join(" ", elements));
            while (currentEleSignIndex >= 0)
            {
                var nextIndex = CalcNextIndex(signArr, currentEleSignIndex, positions[currentEleSignIndex]);
                if (0 <= nextIndex && nextIndex < elements.Length &&
                    elements[positions[currentEleSignIndex]] > elements[nextIndex])
                {
                    var eleNextIndex = -1;
                    for (int i = elements.Length - 1; i >= 0; i--)
                    {
                        if (positions[i] == nextIndex)
                        {
                            eleNextIndex = i;
                            break;
                        }
                    }

                    Switch(elements, positions[currentEleSignIndex], nextIndex);
                    Console.WriteLine(string.Join(" ", elements));
                    Switch(positions, currentEleSignIndex, eleNextIndex);

                    if (ChangeSign(signArr, currentEleSignIndex, out var changeCount)) currentEleSignIndex += changeCount;
                }
                else
                {
                    currentEleSignIndex--;
                }
            }
        }
       
    }
}
