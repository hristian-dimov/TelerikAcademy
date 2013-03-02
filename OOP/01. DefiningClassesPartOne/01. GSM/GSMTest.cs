using System;

class GSMTest
{
    static void Main()
    {
        Battery newBattery = new Battery(BatteryType.LiIon, "ChinaBattery", 10, 10);
        Display newDisplay = new Display(4.0, 16000000);

        GSM[] gsms = new GSM[2];

        gsms[0] = new GSM("iPhone5", "Apple", 1500, "Steve Jobs", newBattery, newDisplay);
        gsms[1] = new GSM("Galaxy Ace", "Samsung", 500, "Lee Byung-chull", newBattery, newDisplay);

        Console.WriteLine(gsms[0]);
        Console.WriteLine(gsms[1]);

        Console.WriteLine("Iphone Model: {0}", GSM.IPhone4S.Model);
        Console.WriteLine("Iphone Manufacturer: {0}", GSM.IPhone4S.Manufacturer);
        Console.WriteLine("Iphone Price: {0}", GSM.IPhone4S.Price);

        //Task 12

        Console.WriteLine();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine();

        GSM nokiaPhone = new GSM("C6-01", "Nokia", 400, "Nokia owner", newBattery, newDisplay);

        nokiaPhone.AddCall(DateTime.Now, 359888123456, 120);
        nokiaPhone.AddCall(DateTime.Now, 359884000000, 240);
        nokiaPhone.AddCall(DateTime.Now, 359882000000, 480);

        int longestCall = 0;
        int longestDuration = 0;
        for (int i = 0; i < nokiaPhone.CallHistory.Count; i++)
        {
            if (nokiaPhone.CallHistory[i].DurationInSeconds > longestDuration)
            {
                longestDuration = nokiaPhone.CallHistory[i].DurationInSeconds;
                longestCall = i;
            }
            Console.WriteLine("Call from {0} to {1} lasted {2} seconds", nokiaPhone.CallHistory[i].Date, nokiaPhone.CallHistory[i].DialedPhoneNumber, nokiaPhone.CallHistory[i].DurationInSeconds);
        }

        Console.WriteLine();
        Console.WriteLine("Total calls cost is {0}lv.", nokiaPhone.TotalCallPrice(0.37));

        nokiaPhone.RemoveCall(longestCall);
        Console.WriteLine("Total calls cost after deleting the longest call is {0}lv.", nokiaPhone.TotalCallPrice(0.37));
        nokiaPhone.ClearCalls();
    }
}