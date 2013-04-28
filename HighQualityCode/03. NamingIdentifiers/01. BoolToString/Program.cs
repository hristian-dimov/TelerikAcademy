﻿using System;

class Program
{
    const int MaxCount = 6;

    class BoolPrinter
    {
        public void PrintBoolValue(bool value)
        {
            string boolAsString = value.ToString();
            Console.WriteLine(boolAsString);
        }
    }

    public static void Main()
    {
        BoolPrinter printer = new BoolPrinter();
        printer.PrintBoolValue(true);
    }
}