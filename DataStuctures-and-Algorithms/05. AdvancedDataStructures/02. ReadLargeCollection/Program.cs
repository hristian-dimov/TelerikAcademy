using System;
using Wintellect.PowerCollections;

class Program
{
    static void Main()
    {
        const int PRODUCT_SEARCH = 20;

        OrderedBag<Item> bag = new OrderedBag<Item>();
        Random rand = new Random();

        for (int i = 0; i < 500000; i++)
        {
            bag.Add(new Item("ItemID: " + rand.Next(), rand.Next()));
        }

        var find = bag.Range(new Item("test", 0), true, new Item("test", 10000), true);

        int count = find.Count;
        if (count > PRODUCT_SEARCH)
        {
            count = PRODUCT_SEARCH;
        }

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("{0} ==== Price: {1}", find[i].Name, find[i].Price);
        }
    }
}