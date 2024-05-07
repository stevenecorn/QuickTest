// IProductRepository.cs
public interface IProductRepository
{
    List<Product> GetProducts();
    Product GetProduct(int id);
}