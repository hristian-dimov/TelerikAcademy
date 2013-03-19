using System;

class MortgageAccount : Account
{
    public MortgageAccount(CustomerType customer, decimal balance, decimal intRate)
        : base(customer, balance, intRate)
    {
    }

    public override decimal InterestAmount(int months)
    {
        if (this.Customer == CustomerType.Company)
        {
            if (months <= 12)
            {
                return months * this.InterestRate / 2;
            }
            else
            {
                return months * this.InterestRate;
            }
        }
        else if (this.Customer == CustomerType.Individual)
        {
            if (months > 6)
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

