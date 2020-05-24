namespace p04._1.TowerOfHanoiV2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var numberOfDisks = 4;

            var source = new Stack<int>(Enumerable.Range(1, numberOfDisks).Reverse());
            var spare = new Stack<int>();
            var destination = new Stack<int>();

            var firstTrigger = true;
            var secondTrigger = true;
            MoveDisks(numberOfDisks, source, spare, destination, firstTrigger, secondTrigger);
            ;
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> spare, Stack<int> destination, bool firstTrigger, bool secondTrigger)
        {
            if (bottomDisk == 1)
            {
                destination.Push(source.Pop());
            }
            else
            {
                //n - 1 > A ... B
                MoveDisks(bottomDisk - 1, source, destination, spare, !firstTrigger, secondTrigger);
                //Last element -> A .. C
                destination.Push(source.Pop());
                //n - 1 > B ... C
                MoveDisks(bottomDisk - 1, spare, source, destination, firstTrigger, !secondTrigger);
            }
        }
    }
}
