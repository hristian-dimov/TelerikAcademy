using System;

class InvalidRangeException<T> : Exception
{
    private T startValue;
    private T endValue;

    public InvalidRangeException(string msg, T startValue, T endValue)
        : base(msg)
    {
        this.StartValue = startValue;
        this.EndValue = endValue;
    }

    public T StartValue 
    {
        get { return this.startValue; }
        private set { this.startValue = value; } 
    }

    public T EndValue
    {
        get { return this.endValue; }
        private set { this.endValue = value; }
    }
}