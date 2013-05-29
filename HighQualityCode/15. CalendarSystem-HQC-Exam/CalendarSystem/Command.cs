using System;
using System.Linq;

namespace CalendarSystem
{
    public struct Command // TODO <IComparable>
    {
        public string CommandName { get; set; }

        public string[] Parameters { get; set; }

        public static Command Parse(string command)
        {
            int indexOf = command.IndexOf(' ');
            if (indexOf == -1)
            {
                throw new ArgumentException("Invalid command: " + command);
            }

            string name = command.Substring(0, indexOf);
            string arguments = command.Substring(indexOf + 1);

            var commandArguments = arguments.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                arguments = commandArguments[i];
                commandArguments[i] = arguments.Trim();
            }

            var newCommand = new Command { CommandName = name, Parameters = commandArguments };

            return newCommand;
        }
    }
}
