using System;

class Display
{
    private double? size;
    private int? numberOfColors;


    public Display()
        : this(null, null)
    {
    }

    public Display(double size)
        : this(size, null)
    {
    }

    public Display(double? size, int? numberOfColors)
    {
        this.Size = size;
        this.NumberOfColors = numberOfColors;
    }

    public double? Size
    {
        get { return this.size; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The size shoud be a positive number");
            }
            else
            {
                this.size = value;
            }
        }
    }

    public int? NumberOfColors
    {
        get { return this.numberOfColors; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Number of colors shoud be a positive number");
            }
            else
            {
                this.numberOfColors = value;
            }
        }
    }

    public override string ToString()
    {
        return string.Format("[ Size: {0} ], [ Number of Colors: {1} ]",
            this.Size, this.NumberOfColors);
    }
}