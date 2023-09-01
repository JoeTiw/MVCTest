using Microsoft.Extensions.Logging;
using VastikaProject.DataAccessLayer.DataContext;
using VastikaProject.DataAccessLayer.Interfaces;
using VastikaProject.Entities;

namespace VastikaProject.DataAccessLayer.Services;

public class CustomerRepo : ICustomerRepo
{
    #region

    private DbDataContext _dbContext;
    private readonly ILogger<CustomerRepo> _logger;

    public CustomerRepo(DbDataContext dbContext, ILogger<CustomerRepo> logger) //connects to database
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    #endregion

    public IEnumerable<Customer> GetCustomerList()
    {
        return _dbContext.Customer.ToList();
    }



    public Customer GetCustomerById(int id)
    {
        return _dbContext.Customer.FirstOrDefault(x => x.Id == id);
    }

    public bool AddCustomer(Customer customer)
    {
        try
        {
            _dbContext.Customer.Add(customer);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding customer with FirstName: {FirstName} and LastName: {LastName}", customer.FirstName, customer.LastName);
            return false;
        }
    }

    public bool UpdateCustomer(Customer customer)
    {
        try
        {
            //this is a check to see if the data already exist or not
            var _customer = _dbContext.Customer.FirstOrDefault(x => x.Id == customer.Id);
            if (customer != null)
            {
                _dbContext.Customer.Update(customer);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }



    public bool DeleteCustomer(int id)
    {
        try
        {
            var _customer = _dbContext.Customer.FirstOrDefault(x => x.Id == id);
            if (_customer != null)
            {
                _dbContext.Customer.Remove(_customer);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
