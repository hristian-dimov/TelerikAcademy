using System;
using System.Collections.Generic;
using System.Linq;

namespace CalendarSystem
{
    public interface IEventsManager
    {
        /// <summary>
        /// Add event method
        /// </summary>
        /// <param name="newEvenet">The event which is going to be added to the calendar</param>
        void AddEvent(Event newEvenet);

        /// <summary>
        /// Deletes all events by given title
        /// </summary>
        /// <param name="title">Title to match the events which has to be deleted</param>
        /// <returns>How many events were deleted.</returns>
        int DeleteEventsByTitle(string title);

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
        IEnumerable<Event> ListEvents(DateTime date, int count);
    }
}
