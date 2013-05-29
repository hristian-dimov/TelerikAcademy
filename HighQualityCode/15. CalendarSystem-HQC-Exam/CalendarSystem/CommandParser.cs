using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CalendarSystem
{
    public class CommandParser
    {
        private const string DateFormat = "yyyy-MM-ddTHH:mm:ss";
        private readonly IEventsManager eventsManagerList;

        public CommandParser(IEventsManager eventsProcessor)
        {
            this.eventsManagerList = eventsProcessor;
        }

        public IEventsManager EventsProcessor
        {
            get
            {
                return this.eventsManagerList;
            }
        }

        public string ProcessCommand(Command command)
        {
            if (command.CommandName == "AddEvent")
            {
                string location;
                if (command.Parameters.Length == 2)
                {
                    location = null;
                }
                else
                {
                    location = command.Parameters[2];
                }

                var date = DateTime.ParseExact(command.Parameters[0], DateFormat, CultureInfo.InvariantCulture);
                var title = command.Parameters[1];

                Event newEvent = new Event(date, title, location);

                this.eventsManagerList.AddEvent(newEvent);

                return "Event added";
            }

            if ((command.CommandName == "DeleteEvents") && (command.Parameters.Length == 1))
            {
                int numberOfAddedEvents = this.eventsManagerList.DeleteEventsByTitle(command.Parameters[0]);

                if (numberOfAddedEvents == 0)
                {
                    return "No events found";
                }

                return numberOfAddedEvents + " events deleted";
            }

            if ((command.CommandName == "ListEvents") && (command.Parameters.Length == 2))
            {
                var date = DateTime.ParseExact(command.Parameters[0], DateFormat, CultureInfo.InvariantCulture);
                var numberOfElementsToList = int.Parse(command.Parameters[1]);
                var eventsList = this.eventsManagerList.ListEvents(date, numberOfElementsToList).ToList();

                if (!eventsList.Any())
                {
                    return "No events found";
                }

                StringBuilder result = new StringBuilder();
                foreach (var ev in eventsList)
                {
                    result.AppendLine(ev.ToString());
                }

                return result.ToString().Trim();
            }

            throw new ArgumentException("Invalid command name: " + command.CommandName);
        }
    }
}
