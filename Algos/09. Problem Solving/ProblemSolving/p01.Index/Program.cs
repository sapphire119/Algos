namespace p01.Index
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    public class Program
    {
        private static List<string> currentEntries;
        private static HashSet<string> result;
        //private static Stack<int> letterIndexes;

        public static void Main()
        {
            var numberOfLetters = 10;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            currentEntries = new List<string>();
            result = new HashSet<string>();
            //letterIndexes = new Stack<int>();

            var providedLetters = new char[numberOfLetters];

            for (var (letter, i) = ('A', 0); i < providedLetters.Length; letter++, i++) providedLetters[i] = letter;

            var usedLetters = new bool[providedLetters.Length];
            char[] entry = new char[4];
            var startEntrIndex = entry.Length - 1;
            var endEntrIndex = 0;
            var lowerBoundIndex = entry.Length - 1;

            CheckForEntry(entry);

            GenerateAllPermutations(entry, providedLetters, usedLetters, startEntrIndex, endEntrIndex, lowerBoundIndex);
            Console.WriteLine($"Number of blocks: {result.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, result));
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void GenerateAllPermutations(char[] entry, char[] providedLetters, bool[] usedLetters, int startEntrIndex, int endEntrIndex, int lowerBoundIndex, int index = 0)
        {
            if (index >= entry.Length)
            {
                Console.WriteLine(EasyToString(entry));
            }
            else
            {
                for (int i = 0; i < providedLetters.Length; i++)
                {
                    if (!usedLetters[i])
                    {

                    }
                }
            }

            //Workings solution but slow
            //for (int entrIndex = startEntrIndex; endEntrIndex <= entrIndex && entrIndex < entry.Length; entrIndex--)
            //{
            //    if (lowerBoundIndex > entrIndex) lowerBoundIndex = entrIndex;

            //    for (int letterIndex = lowerBoundIndex; letterIndex < providedLetters.Length; letterIndex++)
            //    {
            //        var replaceLetter = providedLetters[letterIndex];

            //        if (replaceLetter == entry[entrIndex]) continue;

            //        if (!usedLetters[letterIndex])
            //        {
            //            letterIndexes.Push(letterIndex);
            //            usedLetters[letterIndex] = true;
            //            entry[entrIndex] = replaceLetter;
            //            GenerateAllPermutations(entry, providedLetters, usedLetters, entrIndex + 1, entrIndex + 1, lowerBoundIndex);
            //            var indexToRemove = letterIndexes.Pop();
            //            usedLetters[indexToRemove] = false;
            //            CheckForEntry(entry);
            //        }
            //    }
            //}
        }


        private static void CheckForEntry(char[] entryArr)
        {
            var entry = EasyToString(entryArr);
            if (!currentEntries.Contains(entry))
            {
                currentEntries.Add(entry);
                currentEntries.AddRange(GetRotatedEntries(entry));
                result.Add(entry);
            }
        }

        private static char[] CreateNewEntryArr(char[] entryArr)
        {
            var newEntry = new char[entryArr.Length];
            for (int i = 0; i < entryArr.Length; i++) newEntry[i] = entryArr[i];
            return newEntry;
        }

        private static string EasyToString(char[] entryArr)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < entryArr.Length; i++) sb.Append(entryArr[i]);

            return sb.ToString();
        }

        private static bool HasDuplicates(string entry)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < entry.Length; i++)
            {
                for (int j = i + 1; j < entry.Length; j++)
                {

                    if (entry[i] == entry[j]) return true;
                }
            }

            return false;
        }

        private static IEnumerable<string> GetRotatedEntries(string entry)
        {
            var rotate90 = new string(new char[] { entry[2], entry[0], entry[3], entry[1] });
            var rotate189 = new string(new char[] { entry[3], entry[2], entry[1], entry[0] });
            var rotate270 = new string(new char[] { entry[1], entry[3], entry[0], entry[2] });

            return new string[] { rotate90, rotate189, rotate270 };
        }
    }
}
