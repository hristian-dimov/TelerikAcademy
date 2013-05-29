using System;
using System.Linq;
using System.Text;

namespace CalendarSystem
{
    public class Event : IComparable<Event>
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public Event(DateTime date, string title)
            : this(date, title, null)
        {
        }

        public DateTime Date 
        {
            get
            {
                return this.date;
            }

            private set
            {
                this.date = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                this.title = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                this.location = value;
            }
        }

        public int CompareTo(Event other)
        {
            int compareResult = DateTime.Compare(this.Date, other.Date);

            if (compareResult == 0)
            {
                compareResult = string.Compare(this.Title, other.Title, StringComparison.Ordinal);
            }

            if (compareResult == 0)
            {
                compareResult = string.Compare(this.Location, other.Location, StringComparison.Ordinal);
            }

            return compareResult;
        }

        public override string ToString()
        {
            StringBuilder eventResult = new StringBuilder();
            eventResult.AppendFormat("{0:yyyy-MM-ddTHH:mm:ss} | {1}", this.Date, this.Title);

            if (!string.IsNullOrEmpty(this.Location))
            {
                eventResult.AppendFormat(" | {0}", this.Location);
            }

            return eventResult.ToString();
        }
    }
}
