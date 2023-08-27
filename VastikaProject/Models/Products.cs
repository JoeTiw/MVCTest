using System.ComponentModel.DataAnnotations;


namespace VastikaProject.Models;

public class Products
{

    [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }  
    
    public string ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public Decimal ProductPrice { get; set; }



}