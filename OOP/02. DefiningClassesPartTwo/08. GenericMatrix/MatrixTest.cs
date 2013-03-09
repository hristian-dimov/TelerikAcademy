using System;

class MatrixTest
{
    public static void Main()
    {
        Console.WriteLine("Adding: ");
        Matrix<int> a = new Matrix<int>(2, 3);
        Matrix<int> b = new Matrix<int>(2, 3);

        int[,] aValues = { { 1, 3, 1 }, { 1, 0, 0 } };
        int[,] bValues = { { 0, 0, 5 }, { 7, 5, 0 } };

        for (int i = 0; i < a.MatrixRows; i++)
        {
            for (int j = 0; j < a.MatrixColumns; j++)
            {
                a[i, j] = aValues[i, j];
                b[i, j] = bValues[i, j];
            }
        }

        Console.WriteLine(a + b);

        Console.WriteLine("Subtracting: ");
        Matrix<int> c = new Matrix<int>(2, 3);
        Matrix<int> d = new Matrix<int>(2, 3);

        int[,] cValues = { { 1, 3, 1 }, { 1, 0, 0 } };
        int[,] dValues = { { 0, 0, 5 }, { 7, 5, 0 } };

        for (int i = 0; i < c.MatrixRows; i++)
        {
            for (int j = 0; j < c.MatrixColumns; j++)
            {
                c[i, j] = cValues[i, j];
                d[i, j] = dValues[i, j];
            }
        }

        Console.WriteLine(a - b);

        Console.WriteLine("Multiplying: ");
        Matrix<int> e = new Matrix<int>(3, 2);
        Matrix<int> f = new Matrix<int>(2, 2);

        int[,] eValues = { { 1, 3 }, { 0, -2 }, { 4, 1 } };
        int[,] fValues = { { 7, 9 }, { 5, 2 } };

        for (int i = 0; i < e.MatrixRows; i++)
            for (int j = 0; j < e.MatrixColumns; j++)
                e[i, j] = eValues[i, j];

        for (int i = 0; i < f.MatrixRows; i++)
            for (int j = 0; j < f.MatrixColumns; j++)
                f[i, j] = fValues[i, j];

        Console.WriteLine(e * f);
    }
}