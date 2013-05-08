using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Stopwatch timer = new Stopwatch();

        // Addition Tests
        Console.WriteLine("-----------------Addition Tests----------------");
        timer.Start();
        TestMethods.AdditionInt(0, 1000000);
        timer.Stop();
        Console.WriteLine("Addition int time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.AdditionFloat(0, 1000000f);
        timer.Stop();
        Console.WriteLine("Addition float time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.AdditionDouble(0, 1000000d);
        timer.Stop();
        Console.WriteLine("Addition double time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.AdditionLong(0, 1000000L);
        timer.Stop();
        Console.WriteLine("Addition long time: {0}", timer.Elapsed);
        timer.Reset();


        timer.Start();
        TestMethods.AdditionDecimal(0, 1000000m);
        timer.Stop();
        Console.WriteLine("Addition decimal time: {0}", timer.Elapsed);
        timer.Reset();

        // Substraction Tests
        Console.WriteLine();
        Console.WriteLine("---------------Substraction Tests--------------");
        timer.Start();
        TestMethods.SubstractInt(0, 1000000);
        timer.Stop();
        Console.WriteLine("Substraction int time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.SubstractFloat(0, 1000000f);
        timer.Stop();
        Console.WriteLine("Substraction float time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.SubstractDouble(0, 1000000d);
        timer.Stop();
        Console.WriteLine("Substraction double time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.SubstractLong(0, 1000000L);
        timer.Stop();
        Console.WriteLine("Substraction long time: {0}", timer.Elapsed);
        timer.Reset();


        timer.Start();
        TestMethods.SubstractDecimal(0, 1000000m);
        timer.Stop();
        Console.WriteLine("Substraction decimal time: {0}", timer.Elapsed);
        timer.Reset();

        // Multiplication Tests
        Console.WriteLine();
        Console.WriteLine("--------------Multiplication Tests-------------");
        timer.Start();
        TestMethods.MultiplyInt(1, 1000000, 2);
        timer.Stop();
        Console.WriteLine("Multiplication int time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.MultiplyFloat(1, 1000000f, 2);
        timer.Stop();
        Console.WriteLine("Multiplication float time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.MultiplyDouble(1, 1000000d, 2);
        timer.Stop();
        Console.WriteLine("Multiplication double time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.MultiplyLong(1, 1000000L, 2);
        timer.Stop();
        Console.WriteLine("Multiplication long time: {0}", timer.Elapsed);
        timer.Reset();


        timer.Start();
        TestMethods.MultiplyDecimal(1, 1000000m, 2);
        timer.Stop();
        Console.WriteLine("Multiplication decimal time: {0}", timer.Elapsed);
        timer.Reset();

        // Division Tests
        Console.WriteLine();
        Console.WriteLine("-----------------Division Tests----------------");
        timer.Start();
        TestMethods.DivideInt(1, 1000000, 2);
        timer.Stop();
        Console.WriteLine("Division int time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.DivideFloat(1, 1000000f, 2);
        timer.Stop();
        Console.WriteLine("Division float time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.DivideDouble(1, 1000000d, 2);
        timer.Stop();
        Console.WriteLine("Division double time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.DivideLong(1, 1000000L, 2);
        timer.Stop();
        Console.WriteLine("Division long time: {0}", timer.Elapsed);
        timer.Reset();


        timer.Start();
        TestMethods.DivideDecimal(1, 1000000m, 2);
        timer.Stop();
        Console.WriteLine("Division decimal time: {0}", timer.Elapsed);
        timer.Reset();
    }
}