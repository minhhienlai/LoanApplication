using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAppWebAPI.Models.DTO
{
    public class LoanAppDTO
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

        public int BusinessId { get; set; }

    }
}
