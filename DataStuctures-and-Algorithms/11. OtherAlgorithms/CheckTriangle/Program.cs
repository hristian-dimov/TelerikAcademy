using System;

namespace CheckTriangle
{
    class CheckTriangle
    {
        static void Main()
        {
            double x1 = 1.0;
            double y1 = 1.0;
            double x2 = 2.0;
            double y2 = 3.0;
            double x3 = 3.0;
            double y3 = 2.0;

            double x4 = 2.0;
            double y4 = 2.0;

            double dx = (x4 - x3);
            double dy = (y4 - y3);

            double A = x1 - x3;
            double B = y1 - y3;
            double C = x2 - x3;
            double D = y2 - y3;

            double denominator = A * D - B * C;

            double alpha = D * dx - C * dy;
            alpha /= denominator;
            double beta = -B * dx + A * dy;
            beta /= denominator;
            double gamma = 1.0 - (alpha + beta);

            if (alpha >= 0 && beta >= 0 && gamma >= 0)
            {
                Console.WriteLine("The Point is inside the triangle");
            }
            else
            {
                Console.WriteLine("The Point is not inside the triangle");
            }
        }
    }
}