using System;

class Call
{
    private DateTime date;
    private long dialedPhoneNumber;
    private int durationInSeconds;

    public Call(DateTime date, long dialedPhoneNumber, int durationInSeconds)
    {
        this.Date = date;
        this.DialedPhoneNumber = dialedPhoneNumber;
        this.DurationInSeconds = durationInSeconds;
    }

    public DateTime Date
    {
        get { return this.date; }
        set { this.date = value; }
    }

    public long DialedPhoneNumber
    {
        get { return this.dialedPhoneNumber; }
        set { this.dialedPhoneNumber = value; }
    }

    public int DurationInSeconds
    {
        get { return this.durationInSeconds; }
        set { this.durationInSeconds = value; }
    }
}