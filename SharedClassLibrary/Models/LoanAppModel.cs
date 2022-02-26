using System.ComponentModel.DataAnnotations;

namespace LoanAppMVC.Models
{
    public class LoanAppModel
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
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateSubmitted { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateProcessed { get; set; }
        public int Status { get; set; }
        public BusinessModel Business { get; set; }
    }
}
