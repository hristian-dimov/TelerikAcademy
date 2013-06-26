using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

public class CommandParser
{
    private readonly IProductsManager productsManagerList;

    public CommandParser(IProductsManager productsProcessor)
    {
        this.productsManagerList = productsProcessor;
    }

    public string ProcessCommand(Command command)
    {
        if (command.CommandName == "AddProduct")
        {
            Product newEvent = new Product(command.Parameters[0], float.Parse(command.Parameters[1]), command.Parameters[2]);

            this.productsManagerList.AddProduct(newEvent);

            return "Product added";
        }

        if (command.CommandName == "DeleteProducts")
        {
            int numberOfDeletedEvents = 0;
            if (command.Parameters.Length == 1)
            {
                numberOfDeletedEvents = this.productsManagerList.DeleteProducts(command.Parameters[0]);
            }
            else
            {
                numberOfDeletedEvents = this.productsManagerList.DeleteProducts(command.Parameters[0], command.Parameters[1]);
            }
            

            if (numberOfDeletedEvents == 0)
            {
                return "No products found";
            }

            return numberOfDeletedEvents + " products deleted";
        }

        if (command.CommandName == "FindProductsByName")
        {
            var productsList = this.productsManagerList.FindProductsByName(command.Parameters[0]).ToList();

            return Result(productsList);
        }

        if (command.CommandName == "FindProductsByPriceRange")
        {
            var productsList = this.productsManagerList.FindProductsByPriceRange(float.Parse(command.Parameters[0]), float.Parse(command.Parameters[1])).ToList();

            return Result(productsList);
        }

        if (command.CommandName == "FindProductsByProducer")
        {
            var productsList = this.productsManagerList.FindProductsByProducer(command.Parameters[0]).ToList();

            return Result(productsList);
        }

        throw new ArgumentException("Invalid command name: " + command.CommandName);
    }

    private string Result(IEnumerable<Product> productsList)
    {
        if (!productsList.Any())
        {
            return "No products found";
        }

        StringBuilder result = new StringBuilder();
        foreach (var product in productsList)
        {
            result.AppendLine(product.ToString());
        }

        return result.ToString().Trim();
    }
}