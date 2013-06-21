using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static char[,] labyrinth =
        {
            {' ',' ', '*',' ',' '},
            {' ','*', '*',' ',' '},
            {' ','*', '*',' ',' '},
            {' ','*', '*',' ',' '},
            {'*',' ', '*',' ',' '},
        };

    private static List<Tuple<int, int>> paths = new List<Tuple<int, int>>();
    private static List<Tuple<int, int>> largestPath = new List<Tuple<int, int>>();

    private static void FindThePath(int row, int col)
    {
        if (!IsInRange(row, col))
        {
            return;
        }

        if (labyrinth[row, col] != ' ')
        {
            return;
        }

        labyrinth[row, col] = 'x';
        paths.Add(new Tuple<int, int>(row, col));

        FindThePath(row, col - 1);
        FindThePath(row - 1, col);
        FindThePath(row, col + 1);
        FindThePath(row + 1, col);
    }

    private static void PrintPath()
    {
        Console.WriteLine("Largest connected area of empty cells: ");
        Console.WriteLine();

        foreach (var path in largestPath)
        {
            Console.Write("(" + string.Join(",", path) + ") -> ");
        }
        Console.Write("Largest connected area of empty cells: ");
        Console.WriteLine();
    }

    private static bool IsInRange(int row, int col)
    {
        if (row >= 0 && row < labyrinth.GetLength(0) && col >= 0 && col < labyrinth.GetLength(1))
        {
            return true;
        }
        return false;
    }

    private static void MarkLargestPath(char[,] labyrinth, List<Tuple<int, int>> largestPath)
    {
        foreach (var cell in largestPath)
        {
            labyrinth[cell.Item1, cell.Item2] = '$';
        }
    }

    private static void PrintLabyrinth(char[,] labyrinth)
    {
        for (int i = 0; i < labyrinth.GetLength(0); i++)
        {
            for (int j = 0; j < labyrinth.GetLength(1); j++)
            {
                Console.Write(labyrinth[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    private static void FindEmptyCell()
    {
        for (int row = 0; row < labyrinth.GetLength(0); row++)
        {
            for (int col = 0; col < labyrinth.GetLength(1); col++)
            {
                if (labyrinth[row, col] == ' ')
                {
                    paths = new List<Tuple<int, int>>();
                    FindThePath(row, col);
                    if (paths.Count > largestPath.Count)
                    {
                        largestPath = paths;
                    }
                }
            }
        }
    }

    static void Main()
    {
        FindEmptyCell();

        MarkLargestPath(labyrinth, largestPath);
        PrintLabyrinth(labyrinth);

        PrintPath();
    }
}