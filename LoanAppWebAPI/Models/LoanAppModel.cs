using SharedClassLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAppWebAPI.Models
{
    public class LoanAppModel : BaseModel
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
        public DateTime DateSubmitted {
            get;set;
        }
            [DataType(DataType.Date)]
        public DateTime? DateProcessed { get; set; }
        public int Status { get; set; }

        [ForeignKey("Business")]
        public int BusinessId { get; set; }
        public BusinessModel? Business { get; set; }

        public override string TableName => "LoanApps";

        public LoanAppModel()
        {
            Random r = new Random();
            APRPercent = r.Next(4, 12);
            CreditScore = r.Next(600,750);
            LatePaymentRate = r.Next(0,100);
            TotalDebt = r.Next(25000,1000000);

            RiskRate = Math.Round(((TotalDebt / CreditScore - 33)/17+ LatePaymentRate)/2);
        }
    }
}
