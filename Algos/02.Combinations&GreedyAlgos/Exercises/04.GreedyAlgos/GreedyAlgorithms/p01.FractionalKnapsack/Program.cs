namespace p01.FractionalKnapsack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var inputCapacity = int.Parse(Console.ReadLine().Split(' ')[1]);
            var inputItemsTotal = int.Parse(Console.ReadLine().Split(' ')[1]);

            var itemList = new List<Item>();
            for (int i = 0; i < inputItemsTotal; i++)
            {
                var tokens = Console.ReadLine().Split(' ');
                var price = int.Parse(tokens[0]);
                var weight = int.Parse(tokens[tokens.Length - 1]);
                itemList.Add(new Item(price, weight));
            }

            itemList = itemList.OrderByDescending(x => x.WeightPriceCoeff).ToList();

            var tempIndex = 0;
            var tempCapacity = 0;
            var oldCapacity = inputCapacity;
            var result = 0.0;

            while (tempIndex < itemList.Count && tempCapacity < inputCapacity)
            {
                var currentItem = itemList[tempIndex];
                if (currentItem.Weigth + tempCapacity > inputCapacity)
                {
                    Print(oldCapacity, currentItem);
                    tempCapacity += (int)currentItem.Weigth;
                    result += currentItem.Price;
                    continue;
                }

                tempCapacity += (int)currentItem.Weigth;
                Print(oldCapacity, currentItem);
                oldCapacity -= (int)currentItem.Weigth;
                tempIndex++;
                result += currentItem.Price;
            }
            Console.WriteLine($"Total price: {result:f2}");
        }

        private static void Print(int remainingCapacity, Item currentItem)
        {
            var temp = remainingCapacity / currentItem.Weigth;
            var percent = (temp) < 1.0 ? Math.Round(temp * 100, 2) : 100;
            Console.WriteLine($"Take {(percent < 100 ? $"{percent:f2}" : $"{percent}")}% of item with price {currentItem.Price:f2} and weight {currentItem.Weigth:f2}");
            if (percent < 100) currentItem.Price = (currentItem.Price * temp);
        }

        public class Item
        {
            public Item(int price, int weigth)
            {
                this.Weigth = weigth;
                this.Price = price;
            }

            public double Weigth { get; set; }

            public double Price { get; set; }

            public double WeightPriceCoeff => Math.Round(this.Price / this.Weigth, 2);
        }

    }
}
