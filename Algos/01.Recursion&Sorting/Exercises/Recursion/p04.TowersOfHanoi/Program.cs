namespace p04.TowersOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    public class Program
    {
        public static void Main()
        {
            var input = 6;

            var source = new Stack<int>();

            for (int i = input; i >= 1; i--) source.Push(i);
            //for (int i = 1; i <= input; i++) source.Push(i);

            var destination = new Stack<int>();
            var spare = new Stack<int>();

            BuildTower(input, source, destination, spare);
        }

        private static void BuildTower(int input, Stack<int> from, Stack<int> to, Stack<int> spare)
        {
            //n - 1 -> A ... B

            BeforeElementSetAtEnd(input - 1, from, to, spare);
            //switch to last element --> A ... C

            var elementToTransfer = from.Pop();
            if (elementToTransfer == input)
                to.Push(elementToTransfer);
            else
                throw new ArgumentException();

            //n - 1 -> B ... C

            AfterElementSet(input - 1, from, to, spare);
        }

        private static void BeforeElementSetAtEnd(int currentEle, Stack<int> from, Stack<int> to, Stack<int> spare)
        {
            if (currentEle > 0)
            {
                BeforeElementSetAtEnd(currentEle - 1, from, to, spare);
                if (from.Contains(currentEle))
                {
                    var toCount = to.Count;
                    var lastEleTo = to.Peek();

                    if (from.Count % 2 == 1)
                    {
                        currentEle = from.Pop();
                        //if (currentEle )
                        //{

                        //}
                    }
                    else
                    {

                    }
                }
                    
            }
        }

        private static void AfterElementSet(int v, Stack<int> from, Stack<int> to, Stack<int> spare)
        {
            throw new NotImplementedException();
        }
    }
}