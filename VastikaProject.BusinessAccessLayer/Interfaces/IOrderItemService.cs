using VastikaProject.Entities;

namespace VastikaProject.BusinessAccessLayer.Interfaces;

public interface IOrderItemService
{
    IEnumerable<OrderItem> GetOrderItemList(); //Read
    OrderItem GetOrderItemById(int id);
    bool AddOrderItem(OrderItem orderItem); //Create or Add
    bool UpdateOrderItem(OrderItem orderItem); //update
    bool DeleteOrderItem(int id); //Delete
}