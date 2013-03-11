using System;
using System.Threading;

public delegate void TimerDelegate(string message);

class Timer
{
    public int Seconds { get; private set; }
    public TimerDelegate DisplayMessage { get; private set; }

    public Timer(int seconds = 1)
    {
        this.Seconds = seconds;
    }

    public void Message(string message)
    {
        Console.WriteLine(message);
    }

    public void DisplayIt(string message, int howManyTimeToDisplay)
    {
        this.DisplayMessage = Message;
        for (int i = 0; i < howManyTimeToDisplay; i++)
        {
            this.DisplayMessage(message);
            Thread.Sleep(this.Seconds * 1000);
        }
    }
}