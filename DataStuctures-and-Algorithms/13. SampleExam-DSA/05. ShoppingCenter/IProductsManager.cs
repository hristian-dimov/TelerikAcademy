using System;
using System.Collections.Generic;
using System.Linq;


public interface IProductsManager
{
    void AddProduct(Product newProduct);

    int DeleteProducts(string name, string producer);

    int DeleteProducts(string producer);

    IEnumerable<Product> FindProductsByName(string name);

    IEnumerable<Product> FindProductsByPriceRange(float fromPrice, float toPrice);

    IEnumerable<Product> FindProductsByProducer(string name);
}
