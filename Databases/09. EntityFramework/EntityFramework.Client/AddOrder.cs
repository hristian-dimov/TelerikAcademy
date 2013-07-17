using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;
using EntityFramework.Data;

namespace EntityFramework.Client
{
    class AddOrder
    {
        static void Main(string[] args)
        {
            Order firstOrder = new Order()
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(10),
                ShippedDate = DateTime.Now.AddDays(9),
                ShipVia = 1,
                Freight = 500.0m,
                ShipName = "First Ship",
                ShipAddress = "Kralstvo Trqvna",
                ShipCity = "Gabrovo",
                ShipRegion = "Sitnqkovo",
                ShipPostalCode = "it9au93",
                ShipCountry = "Bulgaria"
            };

            Order secondOrder = new Order()
            {
                CustomerID = "ALFKI",
                EmployeeID = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(10),
                ShippedDate = DateTime.Now.AddDays(9),
                ShipVia = 1,
                Freight = 500.0m,
                ShipName = "Second Ship",
                ShipAddress = "Kralstvo Trqvna",
                ShipCity = "Blabla",
                ShipRegion = "BlahBlah",
                ShipPostalCode = "itu93",
                ShipCountry = "Bulgaria"
            };

            IList<Order> orders = new List<Order>();
            orders.Add(firstOrder);
            orders.Add(secondOrder);

            using (var database = new ExtendDbContext())
            {
                AddNewOrder(database, orders);
                Console.WriteLine("Order(s) added successfully!");
            }
        }

        public static void AddNewOrder(ExtendDbContext db, ICollection<Order> orders)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                foreach (var order in orders)
                {
                    db.Orders.Add(order);
                }
                    
                db.SaveChanges();

                transaction.Complete();
            }
        }
    }
}