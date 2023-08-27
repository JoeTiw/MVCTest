using System.ComponentModel.DataAnnotations;

namespace VastikaProject.Models
{
    public class SignUpModel
    {
        [Required]
        public string SignUpFirstName { get; set; }


        [Required]
        public string SignUpLastName { get; set; }


        [Required]
        public string SignUpUsername { get; set; }


        [Required]
        public string SignUpPassword { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public  DateTime SignUpDOB { get; set; }
    }
}