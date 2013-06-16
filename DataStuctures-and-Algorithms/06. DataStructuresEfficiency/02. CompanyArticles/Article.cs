using System;

class Article : IComparable<Article>
{
    private string barcode;
    private string vendor;
    private string title;
    private double price;

    public Article(string barcode, string vendor, string title, double price)
    {
        this.Barcode = barcode;
        this.Vendor = vendor;
        this.Title = title;
        this.Price = price;
    }

    public string Barcode
    {
        get { return this.barcode; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Barcode cannot be null.");
            }

            this.barcode = value;
        }
    }

    public string Vendor
    {
        get { return this.vendor; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Vendor cannot be null.");
            }

            this.vendor = value;
        }
    }
    
    public string Title
    {
        get { return this.title; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Title cannot be null.");
            }

            this.title = value;
        }
    }

    public double Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Invalid price");
            }

            this.price = value;
        }
    }

    public int CompareTo(Article other)
    {
        return this.Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return string.Format(
            "Price: {0,10:F2}, Barcode: {1}, Vendor: {2}, Title: {3}",
            this.Price,
            this.Barcode,
            this.Vendor,
            this.Title);
    }
}