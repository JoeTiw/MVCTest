using System.ComponentModel.DataAnnotations;

namespace VastikaProject.Entities;

public class OrderItem
{
    [Key] 
    public int Id { get; set; }
    
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }
    
}