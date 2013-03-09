using System;

public struct Point3D
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Z { get; private set; }

    public Point3D(int x, int y, int z)
        : this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    private static readonly Point3D zeroPoint = new Point3D(0, 0, 0);

    public static Point3D ZeroPoint
    {
        get { return zeroPoint; }
    }

    public override string ToString()
    {
        return string.Format(
            "Point X -> {0}; " +
            "Point Y -> {1}; " +
            "Point Z -> {2}",
            this.X, this.Y, this.Z
            );
    }
}