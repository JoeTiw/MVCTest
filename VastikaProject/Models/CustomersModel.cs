using System.ComponentModel.DataAnnotations;

namespace VastikaProject.Models;

public class CustomersModel
{
 
    public int? Id{ get; set; }
    
    
    [Required(ErrorMessage = "First Name is required.")]
    [StringLength(100, ErrorMessage = "First Name cannot be longer than 100 characters.")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last Name is required.")]
    [StringLength(100, ErrorMessage = "Last Name cannot be longer than 100 characters.")]
    public string LastName { get; set; }
}