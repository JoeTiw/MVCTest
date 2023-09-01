using VastikaProject.BusinessAccessLayer.Interfaces;
using VastikaProject.DataAccessLayer.Interfaces;
using VastikaProject.Entities;

namespace VastikaProject.BusinessAccessLayer.Services;

public class CustomerService: ICustomerService
{
    private readonly ICustomerRepo _customerRepo;
    public CustomerService(ICustomerRepo customerRepo)
    {
        _customerRepo = customerRepo;
    }
    
    //-------------------------------------------------------//
    public IEnumerable<Customer> GetCustomerList()
    {
        return _customerRepo.GetCustomerList();
    }

    public Customer GetCustomerById(int id)
    {
        return _customerRepo.GetCustomerById(id);
    }

    public bool AddCustomer(Customer customer)
    {
        // try
        // {
        //     _customerRepo.AddCustomer(customer); // Assuming "Customers" is the name of your DbSet for the Customer entity
        //     _customerRepo.UpdateCustomer(customer);
        //     return true;
        // }
        // catch (Exception ex)
        // {
        //     // Log the exception (if you have logging set up)
        //     return false;
        // }
        return _customerRepo.AddCustomer(customer);
    }

    public bool UpdateCustomer(Customer customer)
    {
        return _customerRepo.UpdateCustomer(customer);
    }

    public bool DeleteCustomer(int id)
    {
        return _customerRepo.DeleteCustomer(id);
    }
}