using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarSystem
{
    public class EventsManager : IEventsManager
    {
        private readonly List<Event> list = new List<Event>();

        /// <summary>
        /// Add event method
        /// </summary>
        /// <param name="newEvenet">The event which is going to be added to the calendar</param>
        public void AddEvent(Event newEvenet)
        {
            this.list.Add(newEvenet);
        }

        /// <summary>
        /// Deletes all events by given title
        /// </summary>
        /// <param name="title">Title to match the events which has to be deleted</param>
        /// <returns>How many events were deleted.</returns>
        public int DeleteEventsByTitle(string title)
        {
            // Deleting elelments with lambda expressions are slow ( it is bottleneck )
            return this.list.RemoveAll(
                e => e.Title.ToLowerInvariant() == title.ToLowerInvariant());
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
            // Searching with linq slows the programs ( it is bottleneck )
            // epsecially orderby
            return (from e in this.list
                    where e.Date >= date
                    orderby e.Date, e.Title, e.Location
                    select e).Take(count);
        }
    }
}
