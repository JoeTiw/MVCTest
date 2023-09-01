using VastikaProject.Entities;

namespace VastikaProject.DataAccessLayer.Interfaces;

public interface ICustomerRepo
{
    IEnumerable<Customer> GetCustomerList(); //Read
    Customer GetCustomerById(int id);
    bool AddCustomer(Customer customer); //Create or Add
    bool UpdateCustomer(Customer customer); //update
    bool DeleteCustomer(int id); //Delete
}