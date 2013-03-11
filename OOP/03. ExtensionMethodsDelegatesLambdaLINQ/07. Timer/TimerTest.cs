using System;

class TimerTest
{
    static void Main()
    {
        Timer timer = new Timer(); // or new Timer(n) -> n is int
        timer.DisplayIt("Message", 5);
    }
}