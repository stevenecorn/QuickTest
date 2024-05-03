// ProductRepository.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Routing.Constraints;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products;

    public ProductRepository()
    {
        // Initialize products 
        _products = LoadProductsFromJsonFile("QuickTest.json");
    }

    private List<Product> LoadProductsFromJsonFile(string fileName)
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, fileName);
        try
        {
            string json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var data = JsonSerializer.Deserialize<ProductsJsonData>(json, options);
            return data.Products;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading products from JSON file: {ex.Message}");
            return new List<Product>();
        }
    }

    public List<Product> GetProducts()
    {
        return _products;
    }

    public Product GetProduct(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }
}

public class ProductsJsonData
{
    public List<Product> Products { get; set; }
}