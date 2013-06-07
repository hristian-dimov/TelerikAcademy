using System;
using System.Linq;

class CustomLinkedList<T>
{
    public ListItem<T> FirstItem { get; set; }

    public int Count
    {
        get
        {
            ListItem<T> currentItem = this.FirstItem;
            int count = 0;
            
            if (this.FirstItem == null)
            {
                return 0;
            }

            while (currentItem.NextItem != null)
            {
                currentItem = currentItem.NextItem;
                count++;
            }

            return count + 1;
        }
    }

    public void AddLast(T value)
    {
        if (this.FirstItem == null)
        {
            this.FirstItem = new ListItem<T>(value);
        }
        else
        {
            ListItem<T> next = this.FirstItem;

            while (next.NextItem != null)
            {
                next = next.NextItem;
            }

            next.NextItem = new ListItem<T>(value);
        }
    }

    public void RemoveLast()
    {
        // Finding the last item
        ListItem<T> lastItem = this.FirstItem;

        while (lastItem.NextItem != null)
        {
            lastItem = lastItem.NextItem;
        }

        // Finding the last item
        ListItem<T> previusToLastItem = this.FirstItem;

        while (previusToLastItem.NextItem != lastItem)
        {
            previusToLastItem = previusToLastItem.NextItem;
        }

        previusToLastItem.NextItem = null;
    }
}