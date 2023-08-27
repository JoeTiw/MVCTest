using System.ComponentModel.DataAnnotations;

namespace VastikaProject.Models;

public class Customers
{
   [Key]
    public int Id{ get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}