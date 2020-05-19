namespace p04.TowersOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
            if (input > 0)
            {
                BuildTower(input - 1, from, to, spare);
                if (from.Contains(input))
                {
                    SetElementsFrom(input, from, to, spare);
                }
                else if (spare.Contains(input))
                {
                }
                else if (to.Contains(input))
                {
                }
                
            }

            //n - 1 -> A ... B
            //SolveTowerByInput(input, from, to, spare);

            //switch to last element --> A ... C
            //var elementToTransfer = from.Pop();
            //if (elementToTransfer == input)
            //    to.Push(elementToTransfer);
            //else
            //    throw new ArgumentException();

            //n - 1 -> B ... C
            //SolveTowerByInput(input - 1, from, to, spare);
        }

        private static void SetElementsFrom(int element, Stack<int> from, Stack<int> to, Stack<int> spare)
        {
            if (from.Count > 0)
            {
                var lastEleFrom = from.Peek();
                if (from.Count % 2 == 1)
                {
                    if (to.Count > 0)
                    {
                        var toLastEle = to.Peek();
                        if (element > toLastEle)
                        {
                            BuildTower(toLastEle, from, to, spare);
                        }
                    }

                    to.Push(lastEleFrom);
                }
                else
                {

                    if (spare.Count > 0)
                    {
                        var spareLastEle = spare.Peek();
                        if (element > spareLastEle)
                        {
                            BuildTower(spareLastEle, from, to, spare);
                        }
                    }

                    spare.Push(lastEleFrom);
                }

                from.Pop();
            }
        }

        //private static void SetElementToStack(int element, Stack<int> currentTargetStack)
        //{
        //    //if (currentTargetStack.Count > 0)
        //    //{
        //    //    var toLastEle = currentTargetStack.Peek();
        //    //    if (element > toLastEle)
        //    //    {
        //    //        BuildTower(toLastEle, from, to, spare);
        //    //    }
        //    //}

        //    //currentTargetStack.Push(lastEleFrom);
        //}

        //private static void SolveTowerByInput(int currentEle, Stack<int> from, Stack<int> to, Stack<int> spare)
        //{
        //    if (currentEle > 0)
        //    {
        //        SolveTowerByInput(currentEle - 1, from, to, spare);
        //        if (from.Contains(currentEle)) 
        //        {
        //        }
        //        else if (to.Contains(currentEle))
        //        {

        //        }
        //        else if (spare.Contains(currentEle))
        //        {
        //        }
        //    }
        //}
    }
}