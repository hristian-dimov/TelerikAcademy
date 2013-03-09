using System;

class GenericTest
{
    static void Main()
    {
        GenericList<int> ints = new GenericList<int>(3);
        ints.Add(1);
        ints.Add(2);
        ints.Add(3);

        Console.WriteLine("List: {0}", ints); // print generic list
        Console.WriteLine("Accessing by element by index [1]: {0}", ints[1]); //  accessing element by index
        Console.WriteLine("Min: {0} - Max: {1}", ints.Min<int>(), ints.Max<int>()); // using Min & Max

        Console.WriteLine("Index of 2: {0}", ints.IndexOf(2)); // return 1

        ints.Clear(); // clearing the list
    }
}