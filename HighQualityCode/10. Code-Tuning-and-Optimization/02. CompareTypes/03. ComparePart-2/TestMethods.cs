using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestMethods
{
    // Sqrt methods
    public static void CalcSqrtFloat(float startValue, float endValue, float step)
    {
        for (float i = startValue; i <= endValue; i = i + step)
        {
            Math.Sqrt(i);
        }
    }

    public static void CalcSqrtDecimal(decimal startValue, decimal endValue, decimal step)
    {
        for (decimal i = startValue; i <= endValue; i = i + step)
        {
            Math.Sqrt((double)i);
        }
    }

    public static void CalcSqrtDouble(double startValue, double endValue, double step)
    {
        for (double i = startValue; i <= endValue; i = i + step)
        {
            Math.Sqrt(i);
        }
    }

    // Log methods
    public static void CalcLogFloat(float startValue, float endValue, float step)
    {
        for (float i = startValue; i <= endValue; i = i + step)
        {
            Math.Log(i);
        }
    }

    public static void CalcLogDecimal(decimal startValue, decimal endValue, decimal step)
    {
        for (decimal i = startValue; i <= endValue; i = i + step)
        {
            Math.Log((double)i);
        }
    }

    public static void CalcLogDouble(double startValue, double endValue, double step)
    {
        for (double i = startValue; i <= endValue; i = i + step)
        {
            Math.Log(i);
        }
    }

    // Sin methods
    public static void CalcSinFloat(float startValue, float endValue, float step)
    {
        for (float i = startValue; i <= endValue; i = i + step)
        {
            Math.Sin(i);
        }
    }

    public static void CalcSinDecimal(decimal startValue, decimal endValue, decimal step)
    {
        for (decimal i = startValue; i <= endValue; i = i + step)
        {
            Math.Sin((double)i);
        }
    }

    public static void CalcSinDouble(double startValue, double endValue, double step)
    {
        for (double i = startValue; i <= endValue; i = i + step)
        {
            Math.Sin(i);
        }
    }
}