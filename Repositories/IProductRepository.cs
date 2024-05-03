// IProductRepository.cs
using System.Collections.Generic;

public interface IProductRepository
{
    List<Product> GetProducts();
    Product GetProduct(int id);
}