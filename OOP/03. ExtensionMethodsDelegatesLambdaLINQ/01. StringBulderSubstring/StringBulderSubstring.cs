using System;
using System.Text;

static class StringBulderSubstring
{
    public static StringBuilder Substring(this StringBuilder text, int index, int length)
    {
        if (index + length > text.Length)
        {
            throw new IndexOutOfRangeException("Index is outside the bounds of the text");
        }

        StringBuilder newText = new StringBuilder(length);
        for (int i = index; i < index + length; i++)
        {
            newText.Append(text[i]);
        }
        return newText;
    }

    static void Main()
    {
        Console.WriteLine(new StringBuilder("textToSubstring").Substring(9, 6));
    }
}