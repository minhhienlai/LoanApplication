using System.ComponentModel.DataAnnotations;

namespace SharedClassLibrary.Models
{
    public class DemographicModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter your name")]
        [Display(Name ="Applicant name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your phone number (number only, 10 digits)")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid phone number (number only, 10 digits)")]
        public string PhoneNo { get; set; } 
        public string Email { get; set; }

        public List<BusinessModel>? Business { get; set; }
    }
}
