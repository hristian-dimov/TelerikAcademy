using System;

namespace KnapsackProblem
{
    public class Item
    {
        public Item(string name, int weight, int value)
        {
            this.Name = name;
            this.Weight = weight;
            this.Price = value;
        }

        public string Name { get; set; }

        public int Weight { get; set; }

        public int Price { get; set; }

        public override string ToString()
        {
            return "ID=" + this.Name + ",W=" + this.Weight + ",V=" + this.Price;
        }
    }
}