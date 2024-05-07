// CustomerRepository.cs
using System.Text.Json;

public class CustomerRepository : ICustomerRepository
{
    // private list of customers
    private readonly List<Customer> _customers;

    public CustomerRepository()
    {
        // load the customers from the json file
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
            return new List<Customer>();
        }
        /*
        // create a filestream and read the input file
        using FileStream json = File.OpenRead(fileName);
        // deserialize the filestream
        List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(json, _options);
        return customers;
        */
    }

    public List<Customer> GetActiveCustomers()
    {
        // return all active customers
        return _customers.Where(c => c.status == "Active").ToList();
    }

    public Customer GetCustomer(string id)
    {
        // return the customer with the matching id
        return _customers.FirstOrDefault(c => c.id == id);
    }

    public void AddOrUpdateCustomer(Customer customer)
    {
        // Check if that email has already been entered
        var existingCustomer = _customers.FirstOrDefault(c => c.email == customer.email);
        // if that email has been entered
        if (existingCustomer != null)
        {
            // reject (do nothing)
        }
        else
        {
            // add the new customer
            _customers.Add(customer);
        }
    }

    public class CustomersJsonData
    {
        public List<Customer> Customers { get; set; }
    }

    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };
}