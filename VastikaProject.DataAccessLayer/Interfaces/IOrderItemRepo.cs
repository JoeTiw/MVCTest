using VastikaProject.Entities;

namespace VastikaProject.DataAccessLayer.Interfaces;

public interface IOrderItemRepo
{
    IEnumerable<OrderItem> GetOrderItemList();

    OrderItem GetOrderItemById(int id);

    bool AddOrderItem(OrderItem orderItem);

    bool UpdateOrderItem(OrderItem orderItem);

    bool DeleteOrderItem(int id);
    
}