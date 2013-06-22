using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        string password = Console.ReadLine();
        int count = 0;

        foreach (var letter in password)
        {
            if (letter == '*')
            {
                count++;
            }
        }

        Console.WriteLine((long)Math.Pow(2, count));
    }
}