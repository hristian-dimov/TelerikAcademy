using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class BitArray64 : IEnumerable<int>
{
    //Constructor
    public BitArray64(ulong number)
    {
        this.Number = number;
    }
    
    //Property
    public ulong Number { get; private set; }

    //Indexator
    public int this[int index]
    {
        get
        {
            if (index < 0 || index > 63)
            {
                throw new IndexOutOfRangeException("BitIndex must be in range 0 ande 63.");
            }

            return (int)((this.Number >> index) & 1); // Mask
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 63; i >= 0; i--)
        {
            yield return this[i];
        }
    }

    public override bool Equals(object param)
    {
        BitArray64 numberBitArray = param as BitArray64;

        if ((object)numberBitArray == null)
        {
            return false;
        }

        if (!Object.Equals(this.Number, numberBitArray.Number))
        {
            return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return this.Number.GetHashCode();
    }

    public static bool operator ==(BitArray64 bitArrayOne, BitArray64 bitArrayTwo)
    {
        return BitArray64.Equals(bitArrayOne, bitArrayTwo);
    }

    public static bool operator !=(BitArray64 bitArrayOne, BitArray64 bitArrayTwo)
    {
        return !(BitArray64.Equals(bitArrayOne, bitArrayTwo));
    }

    public override string ToString()
    {
        StringBuilder bits = new StringBuilder();

        for (int i = 63; i >= 0; i--)
        {
            bits.Append(this[i]);
        }
        bits.AppendLine();

        return bits.ToString();
    }
}