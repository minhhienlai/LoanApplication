using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAppWebAPI.DTO.LoanApps
{
    public class LoanAppResponseDto
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public int PayBackInMonths { get; set; }

        public int APRPercent { get; set; }
        public int CreditScore { get; set; }
        public double LatePaymentRate { get; set; }
        public double TotalDebt { get; set; }
        public double RiskRate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateSubmitted { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? DateProcessed { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public string? BusinessCode { get; set; }
        public string? BusinessName { get; set; }

    }
}
