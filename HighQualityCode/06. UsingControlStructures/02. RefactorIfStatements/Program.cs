using System;

class Program
{
    static void Main()
    {
        Potato potato;

        if (potato != null)
        {
            if (!potato.HasNotBeenPeeled && !potato.IsRotten)
            {
                Cook(potato);
            }
        }

        /* -------------------------- */

        int x = 0;
        int y = 0;
        int minX = 0;
        int maxX = 0;
        int maxY = 0;
        int minY = 0;

        bool shoudVisitCell = true;
        bool isInBoundsX = minX <= x && x <= maxX;
        bool isInBoundsY = minY <= y && y <= maxY;

        if (isInBoundsX && isInBoundsY && shoudVisitCell)
        {
            VisitCell();
        }
    }
}