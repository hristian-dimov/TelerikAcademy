using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class ProductsManager : IProductsManager
{
    private readonly MultiDictionary<string, Product> productsByName = new MultiDictionary<string, Product>(true);
    private readonly MultiDictionary<Tuple<string, string>, Product> productsByNameAndProducer = new MultiDictionary<Tuple<string, string>, Product>(true);
    private readonly OrderedMultiDictionary<float, Product> productsByPrice = new OrderedMultiDictionary<float, Product>(true);
    private readonly MultiDictionary<string, Product> productsByProducer = new MultiDictionary<string, Product>(true);

    public void AddProduct(Product newProduct)
    {
        this.productsByName.Add(newProduct.Name, newProduct);
        this.productsByPrice.Add(newProduct.Price, newProduct);
        this.productsByProducer.Add(newProduct.Producer, newProduct);

        var tuple = new Tuple<string, string>(newProduct.Name, newProduct.Producer);
        this.productsByNameAndProducer[tuple].Add(newProduct);
    }

    public int DeleteProducts(string name, string producer)
    {
        var tuple = new Tuple<string, string>(name, producer);
        var listToDelete = this.productsByNameAndProducer[tuple];
        int countx = listToDelete.Count;

        foreach (var product in listToDelete)
        {
            this.productsByName.Remove(name, product);
            this.productsByProducer.Remove(producer, product);
            this.productsByPrice.Remove(product.Price, product);
        }

        this.productsByNameAndProducer.Remove(tuple);

        return countx;
    }

    public int DeleteProducts(string producer)
    {
        var listToDelete = this.productsByProducer[producer];
        int countx = listToDelete.Count;

        foreach (var product in listToDelete)
        {
            var tuple = new Tuple<string, string>(product.Name, producer);
            this.productsByNameAndProducer.Remove(tuple);
            this.productsByName.Remove(product.Name, product);
            this.productsByPrice.Remove(product.Price, product);
        }

        this.productsByProducer.Remove(producer);

        return countx;
    }

    public IEnumerable<Product> FindProductsByName(string name)
    {
        var productsFound = this.productsByName[name].ToList();
        productsFound.Sort();
        return productsFound;
    }

    public IEnumerable<Product> FindProductsByPriceRange(float fromPrice, float toPrice)
    {
        var productsFound = this.productsByPrice.Range(fromPrice, true, toPrice, true).Values.ToList();
        productsFound.Sort();
        return productsFound;
    }

    public IEnumerable<Product> FindProductsByProducer(string producer)
    {
        var productsFound = this.productsByProducer[producer].ToList();
        productsFound.Sort();
        return productsFound;
    }
}