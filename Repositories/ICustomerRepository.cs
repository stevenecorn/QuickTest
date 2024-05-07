// ICustomerRepository.cs
public interface ICustomerRepository
{
    List<Customer> GetActiveCustomers();
    Customer GetCustomer(string id);
    void AddOrUpdateCustomer(Customer customer);
}