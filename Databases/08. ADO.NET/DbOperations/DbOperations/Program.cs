using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; " +
            "Database=Northwind; Integrated Security=true");
            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand command = new SqlCommand(
                "SELECT COUNT(*) FROM Categories", dbConnection);
                int employeesCount = (int)command.ExecuteScalar();

                Console.WriteLine("----------------Ex. 1------------------");
                Console.WriteLine("Categories count: {0} ", employeesCount);
                Console.WriteLine("--------------------------------------");

                command = new SqlCommand(
                    "SELECT CategoryName, Description FROM Categories", dbConnection);
                var reader = command.ExecuteReader();

                Console.WriteLine("----------------Ex. 2------------------");
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["CategoryName"]);
                        Console.Write("---");
                        Console.Write(reader["Description"]);
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("--------------------------------------");

                command = new SqlCommand(
                    "SELECT CategoryName, ProductName FROM Products" +
                    " JOIN Categories" +
                    " ON Products.CategoryId = Categories.CategoryId" +
                    " ORDER BY CategoryName", dbConnection);

                reader = command.ExecuteReader();

                Console.WriteLine("----------------Ex. 3------------------");
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["ProductName"]);
                        Console.Write("---");
                        Console.Write(reader["CategoryName"]);
                        Console.WriteLine();
                    }
                }

                 

                Console.WriteLine("----------------Ex. 4------------------");
                int addedRow = InsertInProducts("Salami", 1, 3, "200", 0.70m, dbConnection);
                Console.WriteLine("Added new product successfully!");
            }
        }

        private static int InsertInProducts(string productName, int supplierID, int categoryID, string quantity, decimal price, SqlConnection dbCon)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Products " +
              "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice) VALUES " +
              "(@name, @supplier, @category, @quantity, @price)", dbCon);
            cmd.Parameters.AddWithValue("@name", productName);
            cmd.Parameters.AddWithValue("@supplier", supplierID);
            cmd.Parameters.AddWithValue("@category", categoryID);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.ExecuteNonQuery();

            SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbCon);
            int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();
            return insertedRecordId;
        }
    }
}
