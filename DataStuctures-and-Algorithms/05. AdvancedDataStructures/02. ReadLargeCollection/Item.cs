using System;

class Item : IComparable<Item>
{
    private string name;
    private double price;

    public Item(string name, double price)
    {
        this.name = name;
        this.price = price;
    }

    public string Name
    {
        get 
        { 
            return this.name; 
        }
        set 
        { 
            this.name = value; 
        }
    }

    public double Price
    {
        get
        {
            return this.price;
        }
        set
        {
            this.price = value;
        }
    }

    public int CompareTo(Item other)
    {
        if (this.Price > other.Price)
        {
            return 1;
        }
        else if (this.Price < other.Price)
        {
            return -1;
        }

        return 0;
    }
}