using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using FreeContentCatalog;

namespace FreeContentCatalogTest
{
    [TestClass]
    public class ICatalogTest
    {
        #region Test Add method

        [TestMethod]
        public void AddSingleItemTest()
        {
            Catalog contentCatalog = new Catalog();
            ContentItem item = new ContentItem(ContentType.Book, 
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            contentCatalog.Add(item);

            Assert.AreEqual(1, contentCatalog.Count);
        }

        [TestMethod]
        public void AddDuplicatedItemTest()
        {
            Catalog contentCatalog = new Catalog();
            ContentItem item = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            contentCatalog.Add(item);
            contentCatalog.Add(item);

            ContentItem item2 = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            contentCatalog.Add(item2);

            Assert.AreEqual(3, contentCatalog.Count);
        }

        [TestMethod]
        public void AddMultipleItems()
        {
            Catalog contentCatalog = new Catalog();
            ContentItem book = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            contentCatalog.Add(book);

            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" });
            contentCatalog.Add(movie);

            ContentItem secretBook = new ContentItem(ContentType.Book,
                new string[] { "The Secret", "Drew Heriot, Sean Byrne & others (2006)", "832763834", "http://t.co/dNV4d" });
            contentCatalog.Add(secretBook);

            ContentItem song = new ContentItem(ContentType.Song,
                new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" });
            contentCatalog.Add(song);

            ContentItem application = new ContentItem(ContentType.Application,
                new string[] { "Firefox v.11.0", "Mozilla", "16148072", "http://www.mozilla.org" });
            contentCatalog.Add(application);

            Assert.AreEqual(5, contentCatalog.Count);
        }

        [TestMethod]
        [Timeout(500)]
        public void Add5000Items()
        {
            Catalog contentCatalog = new Catalog();
            for (int i = 0; i < 5000; i++)
            {
                ContentItem item = new ContentItem(ContentType.Book,
                new string[] { "Intro C#" + i, "S.Nakov", "12763892", "http://www.introprogramming.info" });
                contentCatalog.Add(item);
            }
            
            Assert.AreEqual(5000, contentCatalog.Count);
        }

        #endregion

        #region Test GetListContent method

        [TestMethod]
        public void GetListContentSingleItemTest()
        {
            Catalog contentCatalog = new Catalog();
            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro Movie", "Author", "123", "http://www.intromovie.info" });
            contentCatalog.Add(movie);

            ContentItem book = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "S.Nakov", "12763892", "http://www.introprogramming.info" });
            contentCatalog.Add(book);

            var result = contentCatalog.GetListContent("Intro C#", 1);

            Assert.AreEqual(1, result.Count());
            Assert.AreSame(book, result.First());
        }

        [TestMethod]
        public void GetListContentNoResultsTest()
        {
            Catalog contentCatalog = new Catalog();
            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro Movie", "Author", "123", "http://www.intromovie.info" });
            contentCatalog.Add(movie);

            var result = contentCatalog.GetListContent("Something Different", 1);

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetListContentMatchingItemsFirstOnlyTest()
        {
            Catalog contentCatalog = new Catalog();
            ContentItem movie = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "Movie Author", "12345", "http://www.intromovie.info" });
            contentCatalog.Add(movie);

            ContentItem book = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "Book Author", "12356", "http://www.intromovie.info" });
            contentCatalog.Add(book);

            ContentItem song = new ContentItem(ContentType.Song,
                new string[] { "Intro C#", "Song Author", "1234567", "http://www.intromovie.info" });
            contentCatalog.Add(song);

            ContentItem otherBook = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "Other Book Author", "12345678", "http://www.intromovie.info" });
            contentCatalog.Add(otherBook);

            var result = contentCatalog.GetListContent("Intro C#", 1);

            Assert.AreEqual(1, result.Count());
            Assert.AreSame(book, result.First());
        }

        [TestMethod]
        public void GetListContentCheckOrderTest()
        {
            Catalog contentCatalog = new Catalog();
            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro C#", "Author", "12345", "http://www.intromovie.info" });
            contentCatalog.Add(movie);

            ContentItem book = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "Author", "12356", "http://www.intromovie.info" });
            contentCatalog.Add(book);

            ContentItem song = new ContentItem(ContentType.Song,
                new string[] { "Intro C#", "Author", "1234567", "http://www.intromovie.info" });
            contentCatalog.Add(song);

            ContentItem otherBook = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "Other Author", "12345678", "http://www.intromovie.info" });
            contentCatalog.Add(otherBook);

            var result = contentCatalog.GetListContent("Intro C#", 10);

            string[] expected = 
            { 
                "Book: Intro C#; Author; 12356; http://www.intromovie.info",
                "Book: Intro C#; Other Author; 12345678; http://www.intromovie.info",
                "Movie: Intro C#; Author; 12345; http://www.intromovie.info",
                "Song: Intro C#; Author; 1234567; http://www.intromovie.info"
            };

            string[] actual = 
            {
                result.First().ToString(),
                result.Skip(1).First().ToString(),
                result.Skip(2).First().ToString(),
                result.Skip(3).First().ToString()
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion

        #region Test Update Method

        [TestMethod]
        public void UpdateMisingItemTest()
        {
            Catalog contentCatalog = new Catalog();
            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro C#", "Author", "12345", "http://www.intromovie.INFO" }); // .info
            contentCatalog.Add(movie);

            var result = contentCatalog.UpdateContent("http://www.intromovie.com", "http://test.com");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void UpdateSingleItemTest()
        {
            Catalog contentCatalog = new Catalog();
            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro C#", "Author", "12345", "http://www.intromovie.info" });
            contentCatalog.Add(movie);

            var result = contentCatalog.UpdateContent("http://www.intromovie.info", "http://test.com");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateMultipleItems()
        {
            Catalog contentCatalog = new Catalog();
            ContentItem movie = new ContentItem(ContentType.Movie,
                new string[] { "Intro C#", "Movie", "12345", "http://www.intromovie.info" });
            contentCatalog.Add(movie);

            ContentItem book = new ContentItem(ContentType.Book,
                new string[] { "Intro C#", "Book", "123456", "http://www.blahblah.com" });
            contentCatalog.Add(book);

            ContentItem app = new ContentItem(ContentType.Application,
                new string[] { "Intro C#", "Application", "123457", "http://www.intromovie.info" });
            contentCatalog.Add(app);

            ContentItem song = new ContentItem(ContentType.Song,
                new string[] { "Intro C#", "Song", "1234578", "http://www.intromovie.info" });
            contentCatalog.Add(song);

            ContentItem otherBook = new ContentItem(ContentType.Book,
                new string[] { "Other Intro C#", "Other Book", "12345789", "http://www.noURL.info" });
            contentCatalog.Add(otherBook);

            ContentItem otherSong = new ContentItem(ContentType.Song,
                new string[] { "Other Song C#", "Other Song", "123457899", "http://www.intromovie.info" });
            contentCatalog.Add(otherSong);

            var result = contentCatalog.UpdateContent("http://www.intromovie.info", "http://test.com");

            Assert.AreEqual(4, result);
        }

        #endregion
    }
}
