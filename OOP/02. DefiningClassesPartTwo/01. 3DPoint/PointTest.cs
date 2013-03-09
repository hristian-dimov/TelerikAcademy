using System;

class PointTest
{
    static void Main()
    {
        Point3D firstPoint = new Point3D(5, 5, 5);
        Point3D secondPoint = new Point3D(10, 11, 12);

        Console.WriteLine(CalculateDistance.Calculate(firstPoint, secondPoint));
        Console.WriteLine(CalculateDistance.Calculate(secondPoint, Point3D.ZeroPoint));

        Console.WriteLine();

        Path newPath = new Path();
        newPath.AddPoint(firstPoint);
        newPath.AddPoint(secondPoint);
        newPath.AddPoint(Point3D.ZeroPoint);

        PathStorage.SavePath(newPath); // save the path.
        PathStorage.LoadPath(); // load the path
    }
}