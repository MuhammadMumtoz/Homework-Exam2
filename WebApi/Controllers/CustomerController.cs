using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CustomerController
{
    private CustomerService _customerService;
    public CustomerController()
    {
        _customerService = new CustomerService();
    }

    [HttpGet]
    public List<Customer> GetCustomers()
    {
        return _customerService.GetCustomers();
    }
    [HttpPost]
    public int InsertCustomer(Customer customer)
    {
        return _customerService.InsertCustomer(customer);
    }
    [HttpPut]
    public int UpdateCustomer(Customer customer)
    {
        return _customerService.UpdateCustomer(customer);
    }
    [HttpDelete]
    public int DeleteCustomer(int id)
    {
        return _customerService.DeleteCustomer(id);
    }
}