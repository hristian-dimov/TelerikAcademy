using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Stopwatch timer = new Stopwatch();

        // Sqrt Test
        Console.WriteLine("Sqrt Test");
        Console.WriteLine("======================================");

        timer.Start();
        TestMethods.CalcSqrtFloat(2f, 1000000f, 0.2f);
        timer.Stop();
        Console.WriteLine("Float Sqrt Time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.CalcSqrtDouble(2d, 1000000d, 0.2d);
        timer.Stop();
        Console.WriteLine("Double Sqrt Time: {0}", timer.Elapsed);

        timer.Start();
        TestMethods.CalcSqrtDecimal(2m, 1000000m, 0.2m);
        timer.Stop();
        Console.WriteLine("Decimal Sqrt Time: {0}", timer.Elapsed);
        timer.Reset();

        // Logarithm Test
        Console.WriteLine("Logarithm Test");
        Console.WriteLine("======================================");

        timer.Start();
        TestMethods.CalcLogFloat(2f, 1000000f, 0.2f);
        timer.Stop();
        Console.WriteLine("Float Logarithm Time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.CalcLogDouble(2d, 1000000d, 0.2d);
        timer.Stop();
        Console.WriteLine("Double Logarithm Time: {0}", timer.Elapsed);

        timer.Start();
        TestMethods.CalcLogDecimal(2m, 1000000m, 0.2m);
        timer.Stop();
        Console.WriteLine("Decimal Logarithm Time: {0}", timer.Elapsed);
        timer.Reset();

        // Sinus Test
        Console.WriteLine("Sinus Test");
        Console.WriteLine("======================================");

        timer.Start();
        TestMethods.CalcSinFloat(2f, 1000000f, 0.2f);
        timer.Stop();
        Console.WriteLine("Float Sinus Time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.CalcSinDouble(2d, 1000000d, 0.2d);
        timer.Stop();
        Console.WriteLine("Double Sinus Time: {0}", timer.Elapsed);
        timer.Reset();

        timer.Start();
        TestMethods.CalcSinDecimal(2m, 1000000m, 0.2m);
        timer.Stop();
        Console.WriteLine("Decimal Sinus Time: {0}", timer.Elapsed);
        timer.Reset();
    }
}
