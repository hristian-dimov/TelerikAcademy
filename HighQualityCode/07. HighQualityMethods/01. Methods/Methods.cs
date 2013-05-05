using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        static string NumberToDigit(int number)
        {
            if (number >= 0 && number <= 9)
            {
                string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                return digits[number];
            }
            else
            {
                throw new ArgumentException(number + " is not a valid digit.");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Cannot pass null as parameter.");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("The array cannot have 0 elements.");
            }

            int maxNumber = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }

            return maxNumber;
        }

        private static void PrintNumberWithPrecision(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        private static void PrintNumberWithPercent(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        private static void PrintNumberWithAlign(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        private static bool IsHorizontal(double y1, double y2)
        {
            if (y1 == y2)
            {
                return true;
            }

            return false;
        }

        private static bool IsVertical(double x1, double x2)
        {
            if (x1 == x2)
            {
                return true;
            }

            return false;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintNumberWithPrecision(1.3);
            PrintNumberWithPercent(0.75);
            PrintNumberWithAlign(2.30);


            bool isHorizontal = IsHorizontal(-1, 2.5);
            bool isVertical = IsVertical(3, 3);

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + isHorizontal);
            Console.WriteLine("Vertical? " + isVertical);

            Student peter = new Student("Peter", "Ivanov", "Sofia", "17.03.1992");
            Student stella = new Student("Stella", "Markova", "Vidin", "03.11.1993");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
