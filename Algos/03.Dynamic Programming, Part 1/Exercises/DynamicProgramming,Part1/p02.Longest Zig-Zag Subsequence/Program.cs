namespace p02.Longest_Zig_Zag_Subsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int maxSequenceLength = -1;
        private static int[] maxSequence;

        public static void Main()
        {
            //Solve Longest Zig-zag using bottom-up approach
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var entries = new Entry[input.Length];
            
            for (int i = 0; i < input.Length; i++)
            {
                entries[i] = new Entry(input[i]);
                var currentEntry = entries[i];
                for (int j = 0; j < i; j++)
                {
                    var prevEntry = entries[j];
                    if (prevEntry.Value == currentEntry.Value) continue;
                    foreach (var sequence in prevEntry.Sequences)
                    {
                        var isCurrentSmaller = prevEntry.Value < currentEntry.Value;
                        if (sequence.Length == 1)
                        { AddNewSequence(sequence, currentEntry.Value, currentEntry.Sequences); continue; }

                        var secondToLastEle = sequence[sequence.Length - 2];
                        var isSecondToLastSmaller = secondToLastEle < prevEntry.Value;
                        if (isCurrentSmaller && !isSecondToLastSmaller)
                        {
                            AddNewSequence(sequence, currentEntry.Value, currentEntry.Sequences);
                        }
                        else if (!isCurrentSmaller && isSecondToLastSmaller)
                        {
                            AddNewSequence(sequence, currentEntry.Value, currentEntry.Sequences);
                        }

                    }
                }
            }

            Console.WriteLine(string.Join(" ", maxSequence));
        }

        private static void AddNewSequence(int[] sequence, int value, HashSet<int[]> sequences)
        {
            var resultingArr = new int[sequence.Length + 1];
            for (int i = 0; i < resultingArr.Length - 1; i++) resultingArr[i] = sequence[i];
            resultingArr[resultingArr.Length - 1] = value;
            sequences.Add(resultingArr);

            if (maxSequenceLength < resultingArr.Length)
            {
                maxSequence = resultingArr;
                maxSequenceLength = resultingArr.Length;
            }
        }

        public class Entry
        {
            public Entry(int value)
            {
                this.Value = value;
                this.Sequences = new HashSet<int[]>()
                {
                    { new int[] { value } }
                };
            }

            public int Value { get; set; }
            public HashSet<int[]> Sequences { get; }

            public override string ToString()
            {
                return $"{this.Value} -> {string.Join(" ", this.Sequences)}";
            }
        }
    }
}
