using SharedClassLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace LoanAppWebAPI.Models
{
    public class DemographicModel : BaseModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Please enter your phone number (number only, 10 digits)")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid phone number (number only, 10 digits)")]
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        [Range(0, 50, ErrorMessage = "Invalid state value")]
        public int? State { get; set; }
        [RegularExpression("^\\d{5}$", ErrorMessage = "Please enter a valid zip code")]
        public string? Zipcode { get; set; }

        public List<BusinessModel>? Business { get; set; }

        public override string TableName => "Demographics";
    }
    
}
