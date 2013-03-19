using System;
using System.Collections.Generic;

class ShapeTest
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Rectangle(2, 4));
        shapes.Add(new Triangle(5, 2));
        shapes.Add(new Circle(5));

        foreach (var shape in shapes)
        {
            Console.WriteLine("{0} has an area of {1:F2} cm2.", shape.GetType(), shape.CalculateSurface());
        }
    }
}