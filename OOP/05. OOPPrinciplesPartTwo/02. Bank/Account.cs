using System;

enum CustomerType { Individual, Company }

abstract class Account
{
    private CustomerType customer;
    private decimal balance;
    private decimal interestRate;

    public Account(CustomerType customer, decimal balance, decimal intRate)
    {
        this.Customer = customer;
        this.Balance = balance;
        this.InterestRate = intRate;
    }

    public CustomerType Customer 
    {
        get { return this.customer; }
        private set { this.customer = value; }
    }

    public decimal Balance
    {
        get { return this.balance; }
        protected set { this.balance = value; }
    }

    public decimal InterestRate
    {
        get { return this.interestRate; }
        protected set { this.interestRate = value; }
    }

    public void DepositMoney(decimal amount)
    {
        this.Balance += amount;
    }

    public abstract decimal InterestAmount(int months);
}