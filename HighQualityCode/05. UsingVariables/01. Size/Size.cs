using System;

public class Size
{
    private double width;
    private double height;

    public Size(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }


    public static Size GetRotatedSize(Size size, double angleOfRotation)
    {
        double cosWidth = Math.Abs(Math.Cos(angleOfRotation)) * size.Width;
        double cosHeight = Math.Abs(Math.Cos(angleOfRotation)) * size.Height;
        double sinWidth = Math.Abs(Math.Sin(angleOfRotation)) * size.Height;
        double sinHeight = Math.Abs(Math.Sin(angleOfRotation)) * size.Width;

        double width = cosWidth + sinWidth;
        double height = cosHeight + sinHeight;

        Size rotatedSize = new Size(width, height);

        return rotatedSize;
    }
}