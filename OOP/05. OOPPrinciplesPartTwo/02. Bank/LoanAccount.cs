using System;

class LoanAccount : Account
{
    public LoanAccount(CustomerType customer, decimal balance, decimal intRate)
        : base(customer, balance, intRate)
    {
    }

    public override decimal InterestAmount(int months)
    {
        if (this.Customer == CustomerType.Individual)
        {
            if (months > 3)
            {
                return months * this.InterestRate;
            }
            else
            {
                return 0;
            }
        }
        else if (this.Customer == CustomerType.Company)
        {
            if (months > 2)
            {
                return months * this.InterestRate;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            throw new Exception("Can't identify customer type");
        }
    }

}