using System;

class Program
{
    static void Main()
    {
        BiDictionary<int, string, string> dictionary = new BiDictionary<int, string, string>();

        dictionary.Add(0, "Zero");
        dictionary.Associate("0000", 0);

        dictionary.Add(3, "0011", "Three");

        string value = dictionary["0000"]; // value will be "Zero"
        Console.WriteLine(value);

        value = dictionary[0]; // val will be "Zero"
        Console.WriteLine(value);
    }
}