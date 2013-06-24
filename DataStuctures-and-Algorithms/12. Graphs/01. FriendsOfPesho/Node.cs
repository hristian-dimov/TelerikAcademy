using System;
using System.Collections.Generic;

class Node : IComparable
{
    public int Id { get; set; }

    public long DjikstraDistance { get; set; }

    public bool IsHospital { get; set; }

    public Node(int id)
    {
        this.Id = id;
        this.IsHospital = false;
    }

    public int CompareTo(Object obj)
    {
        Node other = obj as Node;
        int result = this.DjikstraDistance.CompareTo(other.DjikstraDistance);

        return result;
    }
}