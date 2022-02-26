using System.ComponentModel.DataAnnotations;

namespace LoanAppMVC.Models
{
    public class DemographicModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your phone number (number only)")]
        [RegularExpression("^[0-9]", ErrorMessage = "Please enter a valid phone number (number only)")]
        public string PhoneNo { get; set; } 
        public string Email { get; set; }

    }
}
