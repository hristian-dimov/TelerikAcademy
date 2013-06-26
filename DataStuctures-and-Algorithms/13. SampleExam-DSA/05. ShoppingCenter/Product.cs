using System;
using System.Linq;
using System.Text;

public class Product : IComparable<Product>
{
    private string name;
    private float price;
    private string producer;

    public Product(string name, float price, string producer)
    {
        this.Name = name;
        this.Price = price;
        this.Producer = producer;
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            this.name = value;
        }
    }

    public float Price
    {
        get
        {
            return this.price;
        }

        private set
        {
            this.price = value;
        }
    }

    public string Producer
    {
        get
        {
            return this.producer;
        }

        private set
        {
            this.producer = value;
        }
    }


    public int CompareTo(Product other)
    {
        int compareResult = name.CompareTo(other.name);

        if (compareResult == 0)
        {
            compareResult = producer.CompareTo(other.producer);
        }

        if (compareResult == 0)
        {
            compareResult = price.CompareTo(other.price);
        }

        return compareResult;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.Append("{");
        result.AppendFormat("{0};{1};{2:0.00}", this.Name, this.Producer, this.Price);
        result.Append("}");

        return result.ToString();
    }
}