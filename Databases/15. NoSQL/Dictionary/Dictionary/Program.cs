using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("test");
            var collection = database.GetCollection<Word>("dictionary");

            MongoDictionary dictionary = new MongoDictionary(collection);

            PrintMenu();

            while (true)
            {
                ProcessCommands(dictionary, Console.ReadLine());
            }
        }

        static void ProcessCommands(MongoDictionary dictionary, string command)
        {
            string[] tokens = command.ToLower().Split();
            string commandName = tokens[0];

            switch (commandName)
            {
                case ("add"):
                    {
                        dictionary.AddWord(tokens[1], tokens[2]);
                        Console.WriteLine("Word added successfully!");
                        break;
                    }
                case ("find"):
                    {
                        Word word = dictionary.FindWordByName(tokens[1]);

                        if (word != null)
                        {
                            Console.WriteLine("{0} means {1}.", word.Name, word.Translation);
                        }
                        else
                        {
                            Console.WriteLine("Word was not found!");
                        }

                        break;
                    }
                case ("showall"):
                    {
                        var allWords = dictionary.GetAllWords();

                        foreach (var word in allWords)
                        {
                            Console.WriteLine("{0} ---> {1}", word.Name, word.Translation);
                        }

                        break;
                    }
                case ("help"):
                    {
                        PrintMenu();
                        break;
                    }
                case ("exit"):
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("------- Mongo Dictionary --------");
            Console.WriteLine("help - brings help menu");
            Console.WriteLine("add [wordName] [translation] - adds new entry to the dictionary");
            Console.WriteLine("find [wordName] - shows word's translation");
            Console.WriteLine("showAll - shows all words in the dictionary");
            Console.WriteLine("---------------------------------");
        }
    }
}
