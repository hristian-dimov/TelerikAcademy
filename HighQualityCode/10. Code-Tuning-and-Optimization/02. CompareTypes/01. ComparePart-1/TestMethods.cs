using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TestMethods
{
    // Addition Methods
    public static void AdditionInt(int startValue, int endValue)
    {
        for (int i = startValue; i < endValue; )
        {
            i++;
        }
    }

    public static void AdditionLong(long startValue, long endValue)
    {
        for (long i = startValue; i < endValue; )
        {
            i++;
        }
    }

    public static void AdditionFloat(float startValue, float endValue)
    {
        for (float i = startValue; i < endValue; )
        {
            i++;
        }
    }

    public static void AdditionDouble(double startValue, double endValue)
    {
        for (double i = startValue; i < endValue; )
        {
            i++;
        }
    }

    public static void AdditionDecimal(decimal startValue, decimal endValue)
    {
        for (decimal i = startValue; i < endValue; )
        {
            i++;
        }
    }

    // Substraction Methods
    public static void SubstractInt(int startValue, int endValue)
    {
        for (int i = startValue; i > endValue; )
        {
            i--;
        }
    }

    public static void SubstractLong(long startValue, long endValue)
    {
        for (long i = startValue; i > endValue; )
        {
            i--;
        }
    }

    public static void SubstractFloat(float startValue, float endValue)
    {
        for (float i = startValue; i > endValue; )
        {
            i--;
        }
    }

    public static void SubstractDouble(double startValue, double endValue)
    {
        for (double i = startValue; i > endValue; )
        {
            i--;
        }
    }

    public static void SubstractDecimal(decimal startValue, decimal endValue)
    {
        for (decimal i = startValue; i > endValue; )
        {
            i--;
        }
    }

    // Multiplication Methods
    public static void MultiplyInt(int startValue, int endValue, int step)
    {
        for (int i = startValue; i <= endValue; )
        {
            i = i * step;
        }
    }

    public static void MultiplyLong(long startValue, long endValue, long step)
    {
        for (long i = startValue; i <= endValue; )
        {
            i = i * step;
        }
    }

    public static void MultiplyFloat(float startValue, float endValue, float step)
    {
        for (float i = startValue; i <= endValue; )
        {
            i = i * step;
        }
    }

    public static void MultiplyDouble(double startValue, double endValue, double step)
    {
        for (double i = startValue; i <= endValue; )
        {
            i = i * step;
        }
    }

    public static void MultiplyDecimal(decimal startValue, decimal endValue, decimal step)
    {
        for (decimal i = startValue; i <= endValue; )
        {
            i = i * step;
        }
    }

    // Division Methods
    public static void DivideInt(int startValue, int endValue, int step)
    {
        for (int i = startValue; i >= endValue; )
        {
            i = i / step;
        }
    }

    public static void DivideLong(long startValue, long endValue, long step)
    {
        for (long i = startValue; i >= endValue; )
        {
            i = i / step;
        }
    }

    public static void DivideFloat(float startValue, float endValue, float step)
    {
        for (float i = startValue; i >= endValue; )
        {
            i = i / step;
        }
    }

    public static void DivideDouble(double startValue, double endValue, double step)
    {
        for (double i = startValue; i >= endValue; )
        {
            i = i / step;
        }
    }

    public static void DivideDecimal(decimal startValue, decimal endValue, decimal step)
    {
        for (decimal i = startValue; i >= endValue; )
        {
            i = i / step;
        }
    }
}