using System;

class Worker : Human
{
    private double weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public double WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        set
        {
            this.weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get
        {
            return this.workHoursPerDay;
        }
        set
        {
            this.workHoursPerDay = value;
        }
    }

    public double MoneyPerHour()
    {
        return this.WeekSalary / (this.WorkHoursPerDay * 5); // working 5 days.
    }

    public override string ToString()
    {
        return string.Format("{0} {1} : {2}$ , {3} hours",
            this.FirstName, this.LastName, this.WeekSalary, this.WorkHoursPerDay);
    }
}