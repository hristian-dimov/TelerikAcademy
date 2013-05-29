using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;
using MultiDictionaryAlias = Wintellect.PowerCollections.MultiDictionary<string, CalendarSystem.Event>;

namespace CalendarSystem
{
    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionaryAlias title = new MultiDictionaryAlias(true);
        private readonly OrderedMultiDictionary<DateTime, Event> arguments = new OrderedMultiDictionary<DateTime, Event>(true);

        /// <summary>
        /// Property which return how many items are in the arguments list
        /// </summary>
        public int Count 
        {
            get
            {
                return this.arguments.KeyValuePairs.Count;
            }
        }

        /// <summary>
        /// Add event method
        /// </summary>
        /// <param name="eventArgument">The event which is going to be added to the calendar</param>
        public void AddEvent(Event eventArgument)
        {
            string eventTitleLowerCase = eventArgument.Title.ToLowerInvariant();
            this.title.Add(eventTitleLowerCase, eventArgument);
            this.arguments.Add(eventArgument.Date, eventArgument);
        }

        /// <summary>
        /// Deletes all events by given title
        /// </summary>
        /// <param name="title">Title to match the events which has to be deleted</param>
        /// <returns>How many events were deleted.</returns>
        public int DeleteEventsByTitle(string title)
        {
            string toLowerCase = title.ToLowerInvariant();
            var listToDelete = this.title[toLowerCase];
            int countx = listToDelete.Count;

            foreach (var ev in listToDelete)
            {
                this.arguments.Remove(ev.Date, ev);
            }

            this.title.Remove(toLowerCase);

            return countx;
        }

        /// <summary>
        /// Listing events from given date
        /// </summary>
        /// <param name="date">Date of the events searching for</param>
        /// <param name="count">How many items to list</param>
        /// <remarks>This method can return less than all matching elements. For example:
        /// if we have 30 matching elements but only 10 requested, the method return 10 elements.
        /// And vice versa if we have requested 10 elements but only 3 matches are found only 3 elements
        /// will be returned.</remarks>
        /// <returns>count number events from given date</returns>
        public IEnumerable<Event> ListEvents(DateTime date, int count)
        {
            var da =
                from e in this.arguments.RangeFrom(date, true).Values
                select e;

            var events = da.Take(count);
            return events;
        }
    }
}