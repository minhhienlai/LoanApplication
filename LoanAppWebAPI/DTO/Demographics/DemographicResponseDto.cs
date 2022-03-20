using System.ComponentModel.DataAnnotations;

namespace LoanAppWebAPI.DTO.Demographics
{
    public class DemographicResponseDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public int? State { get; set; }

        public string? Zipcode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
       
    }
}
