using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreeContentCatalog
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();

            Catalog contentCatalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            var commands = ReadInputCommands();
            foreach (ICommand command in commands)
            {
                commandExecutor.ExecuteCommand(contentCatalog, command, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> ReadInputCommands()
        {
            List<ICommand> commands = new List<ICommand>();

            while(true)
            {
                string line = Console.ReadLine();

                if (line.Trim() == "End")
                {
                    break;
                }

                commands.Add(new Command(line));
            }

            return commands;
        }
    }
}
