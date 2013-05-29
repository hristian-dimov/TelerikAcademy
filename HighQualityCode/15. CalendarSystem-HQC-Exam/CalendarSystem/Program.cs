using System;
using System.Linq;

namespace CalendarSystem
{
    internal class Program
    {
        internal static void Main()
        {
            IEventsManager eventsManager = new EventsManager();
            CommandParser parser = new CommandParser(eventsManager);

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End" || command == null)
                {
                    break;
                }

                try
                {
                    Console.WriteLine(parser.ProcessCommand(Command.Parse(command)));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("You've entered and invalid command.");
                }
            }
        }
    }
}