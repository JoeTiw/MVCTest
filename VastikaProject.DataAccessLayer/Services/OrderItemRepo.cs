using VastikaProject.DataAccessLayer.DataContext;
using VastikaProject.DataAccessLayer.Interfaces;
using VastikaProject.Entities;

namespace VastikaProject.DataAccessLayer.Services;

public class OrderItemRepo: IOrderItemRepo
{
    private DbDataContext _dbContext;

    public OrderItemRepo(DbDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // Show Order Item
    public IEnumerable<OrderItem> GetOrderItemList()
    {
        return _dbContext.OrderItems.ToList();
    }

    public OrderItem GetOrderItemById(int id)
    {
        return _dbContext.OrderItems.FirstOrDefault(x => x.Id == id);
    }

    public bool AddOrderItem(OrderItem orderItem)
    {
        try
        {
            _dbContext.OrderItems.Add(orderItem);
            _dbContext.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool UpdateOrderItem(OrderItem orderItem)
    {
        try
        {
            //this is a check to see if the data already exist or not
            var _orderItem = _dbContext.OrderItems.FirstOrDefault(x => x.Id == orderItem.Id);
            if (orderItem != null)
            {
                _dbContext.OrderItems.Update(orderItem);
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

    public bool DeleteOrderItem(int id)
    {
        try
        {
            var _orderItem = _dbContext.OrderItems.FirstOrDefault(x => x.Id == id);
            if (_orderItem != null)
            {
                _dbContext.OrderItems.Remove(_orderItem);
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