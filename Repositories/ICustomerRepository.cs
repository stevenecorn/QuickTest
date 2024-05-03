// ICustomerRepository.cs
using System.Collections.Generic;

public interface ICustomerRepository
{
    List<Customer> GetActiveCustomers();
    Customer GetCustomer(string id);
    void AddOrUpdateCustomer(Customer customer);
}