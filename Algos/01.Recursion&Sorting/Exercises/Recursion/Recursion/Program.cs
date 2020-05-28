namespace Recursion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using p01.Index;

    public class Program
    {
        public static void Main()
        {
            var person = new Person(10, "asd");
            var test = new Dictionary<int, Person>();
            test.Add(1, person);
            test.Add(2, new Person(5, "dd"));
            test.Add(3, new Person(8, "ffff"));
            test.Add(4, new Person(12, "gggg"));
            test.Add(5, new Person(15, "hhhh"));

            //purchaseType = eventType == 0 ?
            //        purchaseTypes.FirstOrDefault(i => i.ID == BDI.SINGLE_TYPE_ID) :
            //        purchaseTypes.FirstOrDefault(i => i.ID == BDI.CORNERS_TYPE_ID);

            IEnumerable<Person> test2 = new List<Person>();
            var c = 5;
            var b = JsonConvert.SerializeObject(test2);
            var a = c == 0 ?
                test2.FirstOrDefault(x => x.Age == 4) :
                test2.FirstOrDefault(x => x.Age == 10);

            ;
            //var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //var tempArr = new int[arr.Length];
            //Array.Copy(arr, tempArr, arr.Length);
            //ReverseArray(arr, tempArr, 0);
            //Console.WriteLine(string.Join(" ", arr));
        }

        private static void ReverseArray(int[] arr, int[] tempArr, int index)
        {
            if (index >= arr.Length) return;
            else
            {
                arr[index] = tempArr[arr.Length - 1 - index];
                ReverseArray(arr, tempArr, index + 1);
            }
        }
    }
}
