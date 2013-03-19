using System;

class DepositAccount : Account
{
    public DepositAccount(CustomerType customer, decimal balance, decimal intRate)
        : base(customer, balance, intRate)
    {
    }

    public void WithdrawMoney(decimal amount)
    {
        this.Balance -= amount;
    }

    public override decimal InterestAmount(int months)
    {
        if (this.Balance > 1000)
        {
            return months * this.InterestRate;
        }
        else
        {
            return 0;
        }
    }
}