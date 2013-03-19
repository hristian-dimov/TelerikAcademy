using System;

class TestInvalidRangeException
{
    static void Main()
    {
        try
        {
            int randomNumber = new Random().Next(100, 150);

            if (randomNumber < 1 || randomNumber > 100)
            {
                throw new InvalidRangeException<int>("Invalid number! Must be in range: ", 1, 100);
            }
        }
        catch (InvalidRangeException<int> e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("[ {0}, {1} ]", e.StartValue, e.EndValue);
        }

        try
        {
            DateTime startTestDate = new DateTime(2010, 1, 1);
            DateTime endTestDate = new DateTime(2013, 1, 1);

            DateTime now = DateTime.Now;
            if (now < startTestDate || now > endTestDate)
            {
                throw new InvalidRangeException<DateTime>("Invalid number! Must be in range: ", startTestDate, endTestDate);
            }
        }
        catch (InvalidRangeException<DateTime> e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("[ {0}, {1} ]", e.StartValue, e.EndValue);
        }
    }
}