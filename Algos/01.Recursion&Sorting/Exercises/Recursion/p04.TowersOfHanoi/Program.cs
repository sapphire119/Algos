namespace p04.TowersOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.PortableExecutable;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;

    public class Program
    {
        public static void Main()
        {
            var input = 3;

            var source = new Stack<int>(Enumerable.Range(1, input).Reverse());
            var destination = new Stack<int>();
            var spare = new Stack<int>();

            var towerHanoi = new Dictionary<int, Stack<int>>
            {
                { 0, source },
                { 1, spare },
                { 2, destination }
            };

            var iteratations = 0;
            PrintDisks(towerHanoi);
            BuildTower(1, input, towerHanoi, ref iteratations);
        }

        private static void BuildTower(int input, int limit, Dictionary<int, Stack<int>> towerHanoi, ref int numberOfIterations)
        {
            //n - 1 -> A ... B
            //last ele -> set to position
            if (input <= limit)
            {
                SetTower(input, limit, towerHanoi, ref numberOfIterations);
                BuildTower(input + 1, limit, towerHanoi, ref numberOfIterations);
            }
            //n - 1 -> B ... C
            if (input < limit)
            {
                SetTower(input, limit, towerHanoi, ref numberOfIterations);
            }
        }

        private static void SetTower(int input, int limit, Dictionary<int, Stack<int>> towerHanoi,
            ref int numberOfIterations)
        {
            var source = towerHanoi[0];
            var spare = towerHanoi[1];
            var destination = towerHanoi[2];

            if (source.Contains(input))
            {
                //A -> C odd
                //A -> B even
                SetElements(input, limit, source, destination, spare, towerHanoi, ref numberOfIterations);
            }
            else if (spare.Contains(input))
            {
                //B -> C odd
                //B -> A even
                SetElements(input, limit, spare, destination, source, towerHanoi, ref numberOfIterations);
            }
            else if (destination.Contains(input))
            {
                //C -> B odd
                //C -> A even
                SetElements(input, limit, destination, spare, source, towerHanoi, ref numberOfIterations);
            }
        }

        private static void SetElements(int element, int limit,
            Stack<int> source, Stack<int> destination, Stack<int> spare, Dictionary<int, Stack<int>> towerHanoi,
            ref int numberOfIterations)
        {
            if (source.Count > 0)
            {
                while (element > source.Peek())
                {
                    SetElements(source.Peek(), limit, source, destination, spare, towerHanoi, ref numberOfIterations);
                }

                var lastEleSource = source.Peek();

                if (source.Count % 2 == 1) //Check if odd
                {
                    while ((destination.Count > 0 && element > destination.Peek() && limit > destination.Peek()) ||
                        lastEleSource != source.Peek())
                    {
                        while (destination.Count > 0 && element > destination.Peek() && limit > destination.Peek())
                        {
                            SetTower(destination.Peek(), lastEleSource, towerHanoi, ref numberOfIterations);
                        }

                        while (lastEleSource != source.Peek())
                        {
                            SetElements(source.Peek(), limit, source, destination, spare, towerHanoi, ref numberOfIterations);
                        }
                    }

                    destination.Push(lastEleSource);
                }
                else //else Even
                {
                    while ((spare.Count > 0 && element > spare.Peek() && limit > spare.Peek()) ||
                        lastEleSource != source.Peek())
                    {
                        while (spare.Count > 0 && element > spare.Peek() && limit > spare.Peek())
                        {
                            SetTower(spare.Peek(), lastEleSource, towerHanoi, ref numberOfIterations);
                        }
                        while (lastEleSource != source.Peek())
                        {
                            SetElements(source.Peek(), limit, source, destination, spare, towerHanoi, ref numberOfIterations);
                        }
                    }

                    spare.Push(lastEleSource);
                }

                numberOfIterations++;
                source.Pop();
                PrintSteps(towerHanoi, lastEleSource, ref numberOfIterations);
            }
        }

        private static void PrintSteps(Dictionary<int, Stack<int>> towerHanoi, int currentEle, ref int numberOfIterations)
        {
            Console.WriteLine($"Step #{numberOfIterations}: Moved disk {currentEle}");
            PrintDisks(towerHanoi);
        }

        private static void PrintDisks(Dictionary<int, Stack<int>> towerHanoi)
        {
            var source = towerHanoi[0];
            var spare = towerHanoi[1];
            var destination = towerHanoi[2];

            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }
    }
}