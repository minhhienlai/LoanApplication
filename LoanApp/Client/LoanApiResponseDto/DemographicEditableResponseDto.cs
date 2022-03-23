using SharedClassLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace LoanAppMVC.Client.LoanApiResponseDto
{
    public class DemographicEditableResponseDto
    {
        public int Id { get; set; }
        [Display(Name = "First name")]
        public string? FirstName { get; set; }
        [Display(Name = "Last name")]
        public string? LastName { get; set; }
        [Display(Name = "Phone number")]
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        [Display(Name = "Address 1")]
        public string? Address1 { get; set; }
        [Display(Name = "Address 2")]
        public string? Address2 { get; set; }
        public int? State { get; set; }

        public string? Zipcode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
