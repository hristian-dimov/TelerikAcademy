using System;

namespace Feedzilla
{
    class Program
    {
        static void Main(string[] args)
        {
            ArticlesConsumer consumer = new ArticlesConsumer("http://api.feedzilla.com/");

            UI.Load(consumer);
        }
    }
}
