using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackProblem
{
    public class Program
    {
        public static void Main()
        {
            Item beer = new Item("beer", 3, 2);
            Item vodka = new Item("vodka", 8, 12);
            Item cheese = new Item("cheese", 4, 5);
            Item nuts = new Item("nuts", 1, 4);
            Item ham = new Item("ham", 2, 3);
            Item whiskey = new Item("whiskey", 8, 13);

            List<Item> items = new List<Item>() { beer, vodka, cheese, nuts, ham, whiskey };

            int bagCapacity = 10;

            List<Item> itemsToBePacked = FindItemsToPack(items, bagCapacity);

            Console.WriteLine("Items: ");

            foreach (var item in itemsToBePacked)
            {
                Console.WriteLine("{0} weight: {1}, price: {2}", item.Name, item.Weight, item.Weight);
            }
        }

        public static List<Item> FindItemsToPack(List<Item> items, int capacity)
        {
            int[,] price = new int[items.Count + 1, capacity + 1];
            bool[,] keep = new bool[items.Count + 1, capacity + 1];

            for (int i = 1; i <= items.Count; i++)
            {
                Item currentItem = items[i - 1];
                for (int space = 1; space <= capacity; space++)
                {
                    if (space >= currentItem.Weight)
                    {
                        int remainingSpace = space - currentItem.Weight;
                        int remainingSpaceValue = 0;
                        if (remainingSpace > 0)
                        {
                            remainingSpaceValue = price[i - 1, remainingSpace];
                        }

                        int currentItemTotalValue = currentItem.Price + remainingSpaceValue;
                        if (currentItemTotalValue > price[i - 1, space])
                        {
                            keep[i, space] = true;
                            price[i, space] = currentItemTotalValue;
                        }
                        else
                        {
                            keep[i, space] = false;
                            price[i, space] = price[i - 1, space];
                        }
                    }
                }
            }

            List<Item> itemsToBePacked = new List<Item>();

            int remainSpace = capacity;
            int item = items.Count;
            while (item > 0)
            {
                bool toBePacked = keep[item, remainSpace];
                if (toBePacked)
                {
                    itemsToBePacked.Add(items[item - 1]);
                    remainSpace = remainSpace - items[item - 1].Weight;
                }

                item--;
            }

            return itemsToBePacked;
        }
    }
}