namespace p01.Knapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var capacity = int.Parse(Console.ReadLine());
            var items = new List<Item>();

            string line;
            while ((line = Console.ReadLine()) != "end")
            {
                var tokens = line.Split(' ');
                items.Add(
                    new Item(
                        tokens[0],
                        int.Parse(tokens[1]),
                        int.Parse(tokens[2]))
                    );
            }

            var matrix = new int[items.Count + 1, capacity + 1];
            var itemsTaken = new bool[items.Count + 1, capacity + 1];

            for (int index = 0; index < items.Count; index++)
            {
                var currentItem = items[index];
                var currentRow = index + 1;

                for (int currentCapacity = 0; currentCapacity <= capacity; currentCapacity++)
                {
                    if (currentItem.Weight > currentCapacity) continue;

                    var excluded = matrix[index, currentCapacity];
                    var included = currentItem.Value + matrix[index, currentCapacity - currentItem.Weight];
                    if (included > excluded)
                    {
                        matrix[currentRow, currentCapacity] = included;
                        itemsTaken[currentRow, currentCapacity] = true;
                    }
                    else
                    {
                        matrix[currentRow, currentCapacity] = excluded;
                    }
                }
            }

            var result = new List<Item>();
            for (int i = items.Count; i >= 0; i--)
            {
                if (!itemsTaken[i, capacity]) continue;
                var takenItem = items[i - 1];
                result.Add(takenItem);

                capacity -= takenItem.Weight;
            }

            Console.WriteLine($"Total Weight: {result.Sum(x => x.Weight)}");
            Console.WriteLine($"Total Value: {result.Sum(x => x.Value)}");
            Console.WriteLine(string.Join(Environment.NewLine, result.OrderBy(x => x.Name)));
        }

        public class Item
        {
            public Item(string name, int weight, int value)
            {
                this.Name = name;
                this.Weight = weight;
                this.Value = value;
            }

            public string Name { get; set; }
            public int Weight { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return this.Name;
            }
        }
    }
}
