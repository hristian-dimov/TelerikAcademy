using System;
using System.Collections.Generic;

class Path
{
    private readonly List<Point3D> points = new List<Point3D>();

    public void AddPoint(Point3D point)
    {
        points.Add(point);
    }

    public List<Point3D> Points
    {
        get
        {
            return this.points;
        }
    }
}