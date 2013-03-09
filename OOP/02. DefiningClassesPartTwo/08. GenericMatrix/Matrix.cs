using System;
using System.Text;

class Matrix<T>
{
    public int MatrixRows { get; private set; }
    public int MatrixColumns { get; private set; }

    private readonly T[,] matrix;

    public Matrix(int matrixRows, int matrixColumns)
    {
        this.MatrixRows = matrixRows;
        this.MatrixColumns = matrixColumns;

        this.matrix = new T[matrixRows, matrixColumns];
    }

    public T this[int x, int y]
    {
        get
        {
            return matrix[x, y];
        }
        set
        {
            matrix[x, y] = value;
        }
    }

    public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
    {
        if (a.MatrixRows == b.MatrixRows && a.MatrixColumns == b.MatrixColumns)
        {
            Matrix<T> resultMatrix = new Matrix<T>(a.MatrixRows, a.MatrixColumns);
            for (int i = 0; i < a.MatrixRows; i++)
            {
                for (int j = 0; j < a.MatrixColumns; j++)
                {
                    resultMatrix[i, j] = (dynamic) a[i, j] + b[i, j];
                }
            }
            return resultMatrix;
        }
        else
        {
            throw new ArgumentException("Matrix sizes are different!");
        }
    }

    public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
    {
        if (a.MatrixRows == b.MatrixRows && a.MatrixColumns == b.MatrixColumns)
        {
            Matrix<T> resultMatrix = new Matrix<T>(a.MatrixRows, a.MatrixColumns);
            for (int i = 0; i < a.MatrixRows; i++)
            {
                for (int j = 0; j < a.MatrixColumns; j++)
                {
                    resultMatrix[i, j] = (dynamic) a[i, j] - b[i, j];
                }
            }
            return resultMatrix;
        }
        else
        {
            throw new ArgumentException("Matrix sizes are different!");
        }
    }

    public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
    {
        if (a.MatrixColumns == b.MatrixRows)
        {
            Matrix<T> resultMatrix = new Matrix<T>(a.MatrixRows, b.MatrixColumns);
            for (int i = 0; i < a.MatrixRows; i++)
            {
                for (int j = 0; j < b.MatrixColumns; j++)
                {
                    for (int z = 0; z < a.MatrixColumns; z++)
                    {
                        resultMatrix[i, j] += (dynamic) a[i, z] * b[z, j];
                    }
                }
            }
            return resultMatrix;
        }
        else
        {
            throw new ArgumentException("Wrong matrix sizes!");
        }
    }

    public static bool operator true(Matrix<T> a)
    {
        if (a == null || a.MatrixRows == 0 || a.MatrixColumns == 0)
        {
            return false;
        }

        for (int row = 0; row < a.MatrixRows; row++)
        {
            for (int col = 0; col < a.MatrixColumns; col++)
            {
                if (!a[row, col].Equals(default(T)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public static bool operator false(Matrix<T> a)
    {
        if (a == null || a.MatrixRows == 0 || a.MatrixColumns == 0)
        {
            return true;
        }

        for (int row = 0; row < a.MatrixRows; row++)
        {
            for (int col = 0; col < a.MatrixColumns; col++)
            {
                if (!a[row, col].Equals(default(T)))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override string ToString()
    {
        StringBuilder printMatrix = new StringBuilder();

        for (int i = 0; i < this.MatrixRows; i++)
        {
            for (int j = 0; j < this.MatrixColumns; j++)
            {
                printMatrix.AppendFormat("{0} ", this[i, j]);
            }
            printMatrix.AppendLine();
        }
        return printMatrix.ToString();
    }
}