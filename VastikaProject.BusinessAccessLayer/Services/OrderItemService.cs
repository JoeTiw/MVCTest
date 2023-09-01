using VastikaProject.BusinessAccessLayer.Interfaces;
using VastikaProject.DataAccessLayer.DataContext;
using VastikaProject.DataAccessLayer.Interfaces;
using VastikaProject.DataAccessLayer.Services;
using VastikaProject.Entities;

namespace VastikaProject.BusinessAccessLayer.Services;

public class OrderItemService : IOrderItemService
{
    public readonly IOrderItemRepo _orderItemRepo;

    public OrderItemService(OrderItemRepo orderItemRepo)
    {
        _orderItemRepo = orderItemRepo;
    }
    
    public IEnumerable<OrderItem> GetOrderItemList()
    {
        return _orderItemRepo.GetOrderItemList();
    }

    public OrderItem GetOrderItemById(int id)
    {
        return _orderItemRepo.GetOrderItemById(id);
    }

    public bool AddOrderItem(OrderItem orderItem)
    {
        return _orderItemRepo.AddOrderItem(orderItem);
    }

    public bool UpdateOrderItem(OrderItem orderItem)
    {
        return _orderItemRepo.UpdateOrderItem(orderItem);
    }

    public bool DeleteOrderItem(int id)
    {
        return _orderItemRepo.DeleteOrderItem(id);
    }
}