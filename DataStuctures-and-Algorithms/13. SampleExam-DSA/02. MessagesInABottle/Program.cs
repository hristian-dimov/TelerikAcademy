using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static string message = string.Empty;
    static string cipher = string.Empty;

    static List<KeyValuePair<string, string>> ciphers = new List<KeyValuePair<string, string>>();
    static List<string> decodedCiphers = new List<string>();
    
    public static void Main()
    {
        List<string> symbols = new List<string>();
        List<string> nums = new List<string>();

        message = Console.ReadLine();
        cipher = Console.ReadLine();

        foreach (Match item in Regex.Matches(cipher, @"\D"))
        {
            symbols.Add(item.Value);
        }

        foreach (Match item in Regex.Matches(cipher, @"\d+"))
        {
            nums.Add(item.Value);
        }

        for (int i = 0; i < nums.Count; i++)
        {
            ciphers.Add(new KeyValuePair<string, string>(symbols[i], nums[i]));
        }

        Solve(0, string.Empty);

        decodedCiphers.Sort();
        Console.WriteLine(decodedCiphers.Count);
        Console.WriteLine(string.Join("\n", decodedCiphers));
    }

    public static void Solve(int currentIndex, string currentMessage)
    {
        if (currentIndex == message.Length)
        {
            decodedCiphers.Add(currentMessage);
            return;
        }

        for (int i = 0; i < ciphers.Count; i++)
        {
            if(message.Substring(currentIndex).StartsWith(ciphers[i].Value)) 
            {
                Solve(currentIndex + ciphers[i].Value.Length, currentMessage + ciphers[i].Key);
            }
        }
    }
}