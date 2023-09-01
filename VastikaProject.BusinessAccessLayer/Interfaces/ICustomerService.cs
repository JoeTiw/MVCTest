using VastikaProject.Entities;


namespace VastikaProject.BusinessAccessLayer.Interfaces;

public interface ICustomerService
{
    IEnumerable<Customer> GetCustomerList(); //Read
    Customer GetCustomerById(int id);
    bool AddCustomer(Customer customer); //Create or Add
    bool UpdateCustomer(Customer customer); //update
    bool DeleteCustomer(int id); //Delete
}