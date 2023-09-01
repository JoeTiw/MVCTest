using System.ComponentModel.DataAnnotations;

namespace VastikaProject.Models
{
    public class LoginModel
    {


        // You can also do [Required(Error message = "hdhdhdhdhd")]
        // Fpr phonr nunbrt [Phone] -> [Phone.maxLength]

        [Required, EmailAddress]
        public  string LoginUsername { get; set; }

        [Required]
        public  string LoginPassword { get; set; }


    }
}