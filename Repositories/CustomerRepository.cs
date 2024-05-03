// CustomerRepository.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Routing.Constraints;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers;

    public CustomerRepository()
    {
        _customers = LoadCustomersFromJsonFile("QuickTest.json");
    }

    private List<Customer> LoadCustomersFromJsonFile(string fileName)
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, fileName);
        try 
        {
            string json = File.ReadAllText(filePath);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var data = JsonSerializer.Deserialize<CustomersJsonData>(json, options);
            return data.Customers;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading products from JSON file: {ex.Message}");
            return new List<Customer>();
        }   
    }

    public List<Customer> GetActiveCustomers()
    {
        return _customers.Where(c => c.Status == "Active").ToList();
    }

    public Customer GetCustomer(string id)
    {
        return _customers.FirstOrDefault(c => c.Id == id);
    }

    public void AddOrUpdateCustomer(Customer customer)
    {
        // Check if customer already exists
        var existingCustomer = _customers.FirstOrDefault(c => c.Id == customer.Id);
        if (existingCustomer != null)
        {
            // update existing customer
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.MiddleName = customer.MiddleName;
            existingCustomer.Dob = customer.Dob;
            existingCustomer.Email = customer.Email;
            existingCustomer.Notes = customer.Notes;
            existingCustomer.Status = customer.Status;
        }
        else
        {
            // add new customer
            _customers.Add(customer);
        }
    }
}

public class CustomersJsonData
{
    public List<Customer> Customers { get; set; }
}