using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        string[] lines = File.ReadAllLines("../../words.txt");

        for (int i = 0; i < lines.Length; i++)
        {
            string[] tokens = lines[i].Split(new char[] { ',', ' ', '!', '?', '-', '.' }, 
                StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < tokens.Length; j++)
            {
                tokens[j] = tokens[j].ToLowerInvariant();

                if (!result.ContainsKey(tokens[j]))
                {
                    result.Add(tokens[j], 1);
                }
                else
                {
                    result[tokens[j]]++;
                }
            }
        }

        var ordered = result.OrderBy(x => x.Value).ThenBy(x => x.Key);

        foreach (var item in ordered)
        {
            Console.WriteLine(item.Value + " -> " + item.Key);
        }
    }
}