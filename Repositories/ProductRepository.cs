// ProductRepository.cs
using System.Text.Json;

public class ProductRepository : IProductRepository
{
    // private list of products
    private readonly List<Product> _products;

    public ProductRepository()
    {
        // Initialize products 
        _products = LoadProductsFromJsonFile("QuickTest.json");
    }

    private List<Product> LoadProductsFromJsonFile(string fileName)
    {
        // create a filestream and read the input file
        using FileStream json = File.OpenRead(fileName);
        // deserialize the filestream
        List<Product> products = JsonSerializer.Deserialize<List<Product>>(json, _options);
        return products;
    }

    public List<Product> GetProducts()
    {
        // return the list of products
        return _products;
    }

    public Product GetProduct(int id)
    {
        // return the specific product using its id
        return _products.FirstOrDefault(p => p.id == id);
    }

    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };
}