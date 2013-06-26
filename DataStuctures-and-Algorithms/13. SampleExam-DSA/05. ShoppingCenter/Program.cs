using System;
using System.Text;
using System.Linq;
using System.Threading;
using System.Globalization;

public class Program
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        IProductsManager productsManager = new ProductsManager();
        CommandParser parser = new CommandParser(productsManager);

        StringBuilder answer = new StringBuilder();

        int commands = int.Parse(Console.ReadLine());
        for (int i = 1; i <= commands; i++)
        {
            string command = Console.ReadLine();
            string commandResult = parser.ProcessCommand(Command.Parse(command));
            answer.AppendLine(commandResult);
        }

        Console.Write(answer);
    }
}