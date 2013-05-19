using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeContentCatalog
{
    public class Command : ICommand
    {
        private readonly char[] paramsSeparators = { ';' };
        private readonly char commandEnd = ':';

        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.Parse();
        }

        public CommandType Type { get; set; }
        public string OriginalForm { get; set; }
        public string Name { get; set; }
        public string[] Parameters { get; set; }

        public CommandType ParseCommandType(string commandName)
        {
            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException("The command name must not contains : or ;");
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    return CommandType.AddBook;
                case "Add movie":
                    return CommandType.AddMovie;
                case "Add song":
                    return CommandType.AddSong;
                case "Add application":
                    return CommandType.AddApplication;
                case "Update":
                    return CommandType.Update;
                case "Find":
                    return CommandType.Find;
                default:
                    throw new MissingFieldException("Invalid command name!" + commandName);
            }
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 3);

            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsLength);

            string[] parameters = paramsOriginalForm.Split(this.paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(this.commandEnd) - 1;
            return endIndex;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0} ", this.Name);

            foreach (string param in this.Parameters)
            {
                result.AppendFormat("{0} ", param);
            }
            
            return result.ToString();
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();
            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();
            this.Type = this.ParseCommandType(this.Name);
        }

        private void TrimParams()
        {
            for (int i = 0;; i++)
            {
                if (!(i < this.Parameters.Length))
                {
                    break;
                }

                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }
    }
}