using System;
using System.Collections.Generic;

class BankTest
{
    static void Main()
    {
        List<Account> accounts = new List<Account>();

        accounts.Add(new LoanAccount(CustomerType.Individual, 200, 2));
        accounts.Add(new DepositAccount(CustomerType.Company, 30000.12343242m, 14.234242m));
        accounts.Add(new MortgageAccount(CustomerType.Individual, 3213, 15.44444443m));
        accounts.Add(new LoanAccount(CustomerType.Company, 123456, 12));

        foreach (var acc in accounts)
        {
            Console.WriteLine("{0} client of {1} has {2: 0.000} interest amount for 7 months",
                    acc.Customer, acc.GetType(), acc.InterestAmount(7));
        }
    }
}