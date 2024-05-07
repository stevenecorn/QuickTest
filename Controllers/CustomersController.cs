// CustomersController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomersController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet]
    public IActionResult GetActiveCustomers()
    {
        var customers = _customerRepository.GetActiveCustomers();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomer(string id)
    {
        var customer = _customerRepository.GetCustomer(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    [HttpPost]
    public IActionResult AddOrUpdateCustomer([FromBody] Customer customer)
    {
        var existingCustomer = _customerRepository.GetCustomer(customer.email);
        if (existingCustomer != null)
        {
            return BadRequest("Customer already exists.");
        }

        _customerRepository.AddOrUpdateCustomer(customer);
        return Ok();
    }
}