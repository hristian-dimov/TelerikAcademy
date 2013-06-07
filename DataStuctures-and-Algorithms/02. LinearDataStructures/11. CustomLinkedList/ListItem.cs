using System;
using System.Linq;

class ListItem<T>
{
    public T Value { get; set; }
    public ListItem<T> NextItem { get; set; }

    public ListItem(T value, ListItem<T> nextItem = null)
    {
        this.Value = value;
        this.NextItem = nextItem;
    }
}