using System;

namespace Feedzilla
{
    static class UI
    {
        public static void Load(ArticlesConsumer consumer)
        {
            Console.WriteLine("Enter query string (e.g. \"Micheal\", without quotes");
            string queryString = Console.ReadLine();

            Console.WriteLine("Enter articles count (leave empty for default count)");
            string countStr = Console.ReadLine();
            int? articlesCount;

            if (countStr != "")
            {
                articlesCount = int.Parse(countStr);
            }
            else
            {
                articlesCount = null;
            }


            if (articlesCount == null)
            {
                ArticlesCollection articles = consumer.GetArticles(queryString);
                PrintArticles(articles);
            }
            else
            {
                ArticlesCollection articles = consumer.GetArticles(queryString, (int)articlesCount);
                PrintArticles(articles);
            }
        }

        private static void PrintArticles(ArticlesCollection collection)
        {
            foreach (var article in collection.Articles)
            {
                Console.WriteLine("<=====================>");
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
            }
        }
    }
}
