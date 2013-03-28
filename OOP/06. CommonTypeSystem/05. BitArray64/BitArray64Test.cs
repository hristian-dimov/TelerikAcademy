using System;

class BitArray64Test
{
    static void Main()
    {
        ulong numberToTest = 123456;

        BitArray64 arr = new BitArray64(numberToTest);
        Console.WriteLine(arr);
    }
}