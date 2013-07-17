using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Data;

namespace EntityFramework.Client
{
    public static class DataAccessObject
    {
        public static void InsertCustomer(ExtendDbContext database, Customer customer)
        {
            if (!string.IsNullOrWhiteSpace(customer.CompanyName))
            {
                database.Customers.Add(customer);
                database.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("Company name is mandatory");
            }
        }

        public static void UpdateCustomer(ExtendDbContext database, string id, string newContactName)
        {
            var customer = database.Customers.Where(x => x.CustomerID == id).FirstOrDefault();

            if (customer != null)
            {
                customer.ContactName = newContactName;
                database.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("This customer doens't exists.");
            }
        }

        public static void Delete(ExtendDbContext database, string id)
        {
            var customer = database.Customers.Where(x => x.CustomerID == id).FirstOrDefault();

            if (customer != null)
            {
                database.Customers.Remove(customer);
                database.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("This customer doens't exists.");
            }
        }
    }
}