using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class Program
{
    static void Main()
    {
        OrderedMultiDictionary<double, Article> articles = new OrderedMultiDictionary<double, Article>(true);
        Random rand = new Random();

        // make some random items
        for (int i = 0; i < 50000; i++)
        {
            Article item = new Article(i.ToString(), "vendor" + rand.Next(), "title:" + rand.Next(), rand.Next());
            articles.Add(item.Price, item);
        }

        double priceFrom = 0;
        double priceTo = 10000000;

        var extractArticles = articles.Range(priceFrom, true, priceTo, true);

        foreach (var article in extractArticles)
        {
            Console.WriteLine("{0}", string.Join(", ", article.Value));
        }
    }
}