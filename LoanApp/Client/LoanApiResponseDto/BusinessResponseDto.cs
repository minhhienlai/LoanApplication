namespace LoanAppMVC.Client.LoanApiResponseDto
{
    public class BusinessResponseDto
    {
        public int Id { get; set; }
        public string? BusinessCode { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public int OwnerId { get; set; }
        public string? OwnerName { get; set; }
    }
}
