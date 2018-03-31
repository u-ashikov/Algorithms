namespace FractionalKnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public class Item
        {
            public decimal Price { get; private set; }

            public decimal Weight { get; private set; }

            public Item(decimal price, decimal weight)
            {
                this.Weight = weight;
                this.Price = price;
            }
        }

        public static void Main()
        {
            var capacity = decimal.Parse(Console.ReadLine()
                .Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[1]);

            var itemsCount = int.Parse(Console.ReadLine()
                .Split(new string[] { ": " }, StringSplitOptions.RemoveEmptyEntries)[1]);

            var items = new List<Item>();

            decimal totalPrice = 0;

            while (itemsCount > 0)
            {
                var itemParams = Console.ReadLine()
                    .Split(new string[] {" -> "},StringSplitOptions.RemoveEmptyEntries)
                    .Select(decimal.Parse)
                    .ToArray();

                if (capacity <= 0)
                {
                    break;
                }

                var price = itemParams[0];
                var weight = itemParams[1];

                items.Add(new Item(price, weight));

                itemsCount--;
            }

            foreach (var item in items.OrderByDescending(i=>i.Price / i.Weight))
            {
                decimal quantity = 0;

                if (item.Weight <= capacity)
                {
                    quantity = item.Weight;
                }
                else
                {
                    quantity = Math.Round((capacity / item.Weight) * item.Weight);
                }

                if (capacity - quantity >= 0 && quantity != 0)
                {
                    var percent = Math.Round(quantity / item.Weight * 100,2);
                    capacity -= (percent * item.Weight) / 100;
                    totalPrice += (percent * item.Price) / 100;
                    Console.WriteLine($"Take {percent}% of item with price {item.Price.ToString("0.00")} and weight {item.Weight.ToString("0.00")}");
                }
            }

            Console.WriteLine($"Total price: {totalPrice.ToString("0.00")}");
        }
    }
}
