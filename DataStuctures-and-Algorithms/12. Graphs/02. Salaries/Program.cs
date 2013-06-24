using System;

class Program
{
    static int staffNumber;
    static bool[,] hierarchy;
    static long[] salaries;

    static void Main(string[] args)
    {
        // read C
        staffNumber = int.Parse(Console.ReadLine());
        hierarchy = new bool[staffNumber, staffNumber];
        salaries = new long[staffNumber];

        // fulfil the matrix
        for (int i = 0; i < staffNumber; i++)
        {
            string line = Console.ReadLine();

            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == 'Y')
                {
                    hierarchy[i, j] = true;
                }
            }
        }

        long salariesSum = 0;

        for (int i = 0; i < staffNumber; i++)
        {
            salariesSum += FindSalary(i);
        }

        Console.WriteLine(salariesSum);
    }

    static long FindSalary(int employer)
    {
        // if we already know the employer's salary we do not
        // need to recursively go through all his staff
        if (salaries[employer] > 0)
        {
            return salaries[employer];
        }

        long currentSalary = 0;

        for (int i = 0; i < staffNumber; i++)
        {
            if (hierarchy[employer, i])
            {
                currentSalary += FindSalary(i);
            }
        }

        if (currentSalary == 0)
        {
            currentSalary = 1;
        }

        salaries[employer] = currentSalary;

        return currentSalary;
    }
}