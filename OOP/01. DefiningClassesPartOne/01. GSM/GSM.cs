using System;
using System.Text;
using System.Collections.Generic;

class GSM
{
    private string model;
    private string manufacturer;
    private int? price;
    private string owner;

    public Battery Battery = new Battery();
    public Display Display = new Display();

    private List<Call> callHistory = new List<Call>();

    static private readonly GSM iPhone4S = new GSM("iPhone4S", "Apple", 1000);

    public GSM(string model, string manufacturer)
        : this(model, manufacturer, null, null, null, null)
    {
    }

    public GSM(string model, string manufacturer, int? price)
        : this(model, manufacturer, price, null, null, null)
    {
    }

    public GSM(string model, string manufacturer, int? price, string owner)
        : this(model, manufacturer, price, owner, null, null)
    {
    }

    public GSM(string model, string manufacturer, int? price, string owner, Battery battery) 
        : this(model, manufacturer, price, owner, battery, null)
    {
    }

    public GSM(string model, string manufacturer, int? price, string owner, Battery battery, Display display)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Price = price;
        this.Owner = owner;
        this.Battery = battery;
        this.Display = display;
    }

    public List<Call> CallHistory
    {
        get
        {
            return this.callHistory;
        }
    }

    public static GSM IPhone4S
    {
        get { return iPhone4S; }
    }

    public string Model
    {
        get { return this.model; }
        set
        {
            if (value == null || value.Length > 2)
            {
                this.model = value;
            }
            else
            {
                throw new ArgumentException("The model name should be longer than two characters");
            }
        }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set
        {
            if (value == null || value.Length > 2)
            {
                this.manufacturer = value;
            }
            else
            {
                throw new ArgumentException("The manufacturer name should be longer than two characters");
            }
        }
    }

    public int? Price
    {
        get { return this.price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The price shoud be a positive number");
            }
            else
            {
                this.price = value;
            }
        }
    }

    public string Owner
    {
        get { return this.owner; }
        set
        {
            if (value == null || value.Length > 2)
            {
                this.owner = value;
            }
            else
            {
                throw new ArgumentException("The owner name should be longer than two characters");
            }
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.AppendLine("Model: " + this.model);
        result.AppendLine("Manufacturer: " + this.manufacturer);
        result.AppendLine("Price: " + this.price);
        result.AppendLine("Owner: " + this.owner);
        result.AppendLine("Battery: " + this.Battery.ToString());
        result.AppendLine("Display: " + this.Display.ToString());
        return result.ToString();
    }

    //Task 10
    public void AddCall(DateTime date, long dialedPhoneNumber, int durationInSeconds)
    {
        CallHistory.Add(new Call(date, dialedPhoneNumber, durationInSeconds));
    }

    public void RemoveCall(int deleteCall)
    {
        CallHistory.RemoveAt(deleteCall);
    }

    public void ClearCalls()
    {
        CallHistory.Clear();
    }

    //Task 11
    public double TotalCallPrice(double callPrice)
    {
        double sum = 0;

        foreach (var call in CallHistory)
        {
            sum += callPrice * call.DurationInSeconds / 60;
        }

        return sum;
    }
}