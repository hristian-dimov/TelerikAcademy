using System;

class Connection
{
    public Node ToNode { get; set; }
    public double Distance { get; set; }

    public Connection(Node toNode, double distance)
    {
        this.ToNode = toNode;
        this.Distance = distance;
    }
}