using System;
using System.Linq;
using EntityFramework.Data;
using System.Collections.Generic;

namespace EntityFramework.Client
{
    class Program
    {
        static void Main()
        {
            using (var database = new ExtendDbContext())
            {
                /* Task 2
                Customer customer = new Customer();
                customer.CustomerID = "GFDSA";
                customer.CompanyName = "NewCompanyName";
                customer.ContactName = "NewContactName";
                DataAccessObject.InsertCustomer(database, customer);
                DataAccessObject.UpdateCustomer(database, "GFDSA", "JustNewContactName");
                DataAccessObject.Delete(database, "GFDSA");
                */
                var findedCustomers = FindCustomers(database, new DateTime(1995, 01, 01), "Canada");

                foreach (var customer in findedCustomers)
                {
                    Console.WriteLine("{0}", customer.ContactName);
                }

                Console.WriteLine("==========================================================");

                var findedCustomersSQL = FindCustomersSQL(database, new DateTime(1995, 01, 01), "Canada");

                foreach (var customer in findedCustomersSQL)
                {
                    Console.WriteLine(customer);
                }

                Console.WriteLine("==========================================================");

                var sales = FindSales(database, "RJ", new DateTime(1990, 1, 1), new DateTime(2000, 1, 1));

                foreach (var sale in sales)
                {
                    Console.WriteLine("Sale from {0} region from {1}", sale.ShipRegion, sale.OrderDate);
                }
            }
        }

        public static ICollection<Customer> FindCustomers(ExtendDbContext database, DateTime date, string country)
        {
            var customers =
                           from o in database.Orders
                           join c in database.Customers on o.CustomerID equals c.CustomerID
                           where o.OrderDate >= date && o.ShipCountry == country
                           select c;

            ICollection<Customer> customerList = customers.ToList();

            return customerList;
        }

        public static ICollection<string> FindCustomersSQL(ExtendDbContext database, DateTime date, string country)
        {
            string query = "SELECT c.ContactName " +
                           "FROM Orders o JOIN Customers c ON o.CustomerID = c.CustomerID " +
                           "WHERE o.OrderDate >= {0} AND o.ShipCountry = {1}";

            object[] parameters = { date, country };
            var resultView = database.Database.SqlQuery<string>(query, parameters);

            ICollection<string> customersList = resultView.ToList();

            return customersList;
        }

        public static ICollection<Order> FindSales(ExtendDbContext database, string region, DateTime startDate, DateTime endDate)
        {
            var sales =
                       from o in database.Orders
                       where o.ShipRegion == region && (o.OrderDate >= startDate && o.OrderDate <= endDate)
                       select o;

            ICollection<Order> salesList = sales.ToList();

            return salesList;
        }
    }
}