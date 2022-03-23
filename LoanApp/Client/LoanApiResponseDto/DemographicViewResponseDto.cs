namespace LoanAppMVC.Client.LoanApiResponseDto
{
    public class DemographicViewResponseDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int? State { get; set; }

        public string? Zipcode { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
