using System;
using System.Linq;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem;

namespace CalendarSystemTest
{
    [TestClass]
    public class EventsManagerFastTest
    {
        #region Add method test

        [TestMethod]
        public void AddEventTest()
        {
            EventsManagerFast fastManager = new EventsManagerFast();

            var firstDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact("2012-05-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var thirdDate = DateTime.ParseExact("2012-09-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            Event firstEvent = new Event(firstDate, "Party 1", "Sofia");
            Event secondEvent = new Event(secondDate, "Party 2", "Burgas");
            Event thirdEvent = new Event(thirdDate, "Party 3", "Varna");

            fastManager.AddEvent(firstEvent);
            fastManager.AddEvent(secondEvent);
            fastManager.AddEvent(thirdEvent);
            Assert.AreEqual(3, fastManager.Count);
        }

        [TestMethod]
        public void AddEventEmptyAndNullLocationTest()
        {
            EventsManagerFast fastManager = new EventsManagerFast();

            var firstDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact("2012-05-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var thirdDate = DateTime.ParseExact("2012-09-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            Event firstEvent = new Event(firstDate, "Party 1"); // empty location
            Event secondEvent = new Event(secondDate, "Party 2", null); // null location
            Event thirdEvent = new Event(thirdDate, "Party 3", "Sofia");

            fastManager.AddEvent(firstEvent);
            fastManager.AddEvent(secondEvent);
            fastManager.AddEvent(thirdEvent);
            Assert.AreEqual(3, fastManager.Count);
        }

        [TestMethod]
        public void AddDuplicatedEvent()
        {
            EventsManagerFast fastManager = new EventsManagerFast();

            var date = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            Event firstEvent = new Event(date, "Party 3", "Sofia");
            fastManager.AddEvent(firstEvent);
            fastManager.AddEvent(firstEvent);

            Assert.AreEqual(2, fastManager.Count);
        }

        [TestMethod]
        [Timeout(300)]
        public void Add5000Events()
        {
            EventsManagerFast fastManager = new EventsManagerFast();
            var date = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

            for (int i = 0; i < 5000; i++)
            {
                Event newEvent = new Event(date, "Party " + i, "Sofia");
                fastManager.AddEvent(newEvent);
            }

            Assert.AreEqual(5000, fastManager.Count);
        }

        #endregion

        #region Delete Events method test

        [TestMethod]
        public void DeleteElementsInEmptyList()
        {
            EventsManagerFast fastManager = new EventsManagerFast();

            int expected = fastManager.DeleteEventsByTitle("Party 1");
            int actual = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteEventTest()
        {
            EventsManagerFast fastManager = new EventsManagerFast();

            var firstDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact("2012-05-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            Event firstEvent = new Event(firstDate, "Party 1", "Sofia");
            Event secondEvent = new Event(secondDate, "Party 2", "Burgas");

            fastManager.AddEvent(firstEvent);
            fastManager.AddEvent(secondEvent);

            int expected = fastManager.DeleteEventsByTitle("Party 2");
            int actual = 1;

            Assert.AreEqual(1, fastManager.Count);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteMissingEventTest()
        {
            EventsManagerFast fastManager = new EventsManagerFast();

            var firstDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            Event firstEvent = new Event(firstDate, "Party 1", "Sofia");

            fastManager.AddEvent(firstEvent);

            int expected = fastManager.DeleteEventsByTitle("No event with that name");
            int actual = 0;

            Assert.AreEqual(1, fastManager.Count);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteMultipleEventTest()
        {
            EventsManagerFast fastManager = new EventsManagerFast();

            var firstDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact("2012-05-24T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var thirdDate = DateTime.ParseExact("2012-09-02T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var fourthDate = DateTime.ParseExact("2012-10-11T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            Event firstEvent = new Event(firstDate, "Party 1", "Sofia");
            Event secondEvent = new Event(secondDate, "Party 1", "Burgas");
            Event thirdEvent = new Event(thirdDate, "Party 1", "Varna");
            Event fourthEvent = new Event(fourthDate, "Party 2", "Na selo");

            fastManager.AddEvent(firstEvent);
            fastManager.AddEvent(secondEvent);
            fastManager.AddEvent(thirdEvent);
            fastManager.AddEvent(fourthEvent);

            int expected = fastManager.DeleteEventsByTitle("Party 1");
            int actual = 3;

            Assert.AreEqual(1, fastManager.Count);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region List Events test

        [TestMethod]
        public void ListSingleEventTest()
        {
            EventsManagerFast fastManager = new EventsManagerFast();

            var firstDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            Event firstEvent = new Event(firstDate, "Party 1", "Sofia");

            fastManager.AddEvent(firstEvent);

            var result = fastManager.ListEvents(firstDate, 1); // search for the same date 

            Assert.AreEqual(1, result.Count());
            Assert.AreSame(firstEvent, result.First());
        }

        [TestMethod]
        public void ListNoResultTest()
        {
            EventsManagerFast fastManager = new EventsManagerFast();

            var firstDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            Event firstEvent = new Event(firstDate, "Party 1", "Sofia");

            fastManager.AddEvent(firstEvent);

            var date = DateTime.ParseExact("2012-01-21T21:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var result = fastManager.ListEvents(date, 5);

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void ListMatchingEventsFirstOnlyTest()
        {
            EventsManagerFast fastManager = new EventsManagerFast();

            var firstDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var thirdDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var fourthDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            Event firstEvent = new Event(firstDate, "Sofia Party", "Sofia");
            Event secondEvent = new Event(secondDate, "Burgas Party", "Burgas");
            Event thirdEvent = new Event(thirdDate, "Varna Party", "Varna");
            Event fourthEvent = new Event(fourthDate, "Na selo Party", "Na selo");

            fastManager.AddEvent(firstEvent);
            fastManager.AddEvent(secondEvent);
            fastManager.AddEvent(thirdEvent);
            fastManager.AddEvent(fourthEvent);

            var date = DateTime.ParseExact("2012-01-20T21:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var result = fastManager.ListEvents(date, 1);

            Assert.AreEqual(1, result.Count());
            Assert.AreSame(secondEvent, result.First()); // because Burgas is alphabetically first
        }

        [TestMethod]
        public void ListEventsCheckOrderTest()
        {
            EventsManagerFast fastManager = new EventsManagerFast();

            var firstDate = DateTime.ParseExact("2012-01-21T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var secondDate = DateTime.ParseExact("2012-05-24T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var thirdDate = DateTime.ParseExact("2012-04-02T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var fourthDate = DateTime.ParseExact("2012-04-15T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            Event firstEvent = new Event(firstDate, "Party 1", "Sofia");
            Event secondEvent = new Event(secondDate, "Party 2", "Burgas");
            Event thirdEvent = new Event(thirdDate, "Party 3", "Varna");
            Event fourthEvent = new Event(fourthDate, "Party 4", "Na selo");

            fastManager.AddEvent(firstEvent);
            fastManager.AddEvent(secondEvent);
            fastManager.AddEvent(thirdEvent);
            fastManager.AddEvent(fourthEvent);

            var date = DateTime.ParseExact("2012-01-01T20:00:00", "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var result = fastManager.ListEvents(date, 10);

            string[] expected = 
            { 
                "2012-01-21T20:00:00 | Party 1 | Sofia",
                "2012-04-02T20:00:00 | Party 3 | Varna",
                "2012-04-15T20:00:00 | Party 4 | Na selo",
                "2012-05-24T20:00:00 | Party 2 | Burgas"
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
    }
}
