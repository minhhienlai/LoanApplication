using SharedClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAppWebAPI.DTO.ApplicationList
{
    public class ApplicationListResponseDto
    {
        public int LoanApplicationId { get; set; }
        //Demographic Info
        public int? DemographicId { get; set; }
        [Display(Name = "Applicant name")]
        public string? DemographicName { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        //Business Info
        public string? BusinessCode { get; set; }
        public string? BusinessName { get; set; }
        //Loan Info
        public double Amount { get; set; }
        public int PayBackInMonths { get; set; }
        public int APRPercent { get; set; }
        public int CreditScore { get; set; }
        public double LatePaymentRate { get; set; }
        public double TotalDebt { get; set; }
        public double RiskRate { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime? DateProcessed { get; set; }
        public int Status { get; set; }
    }
}
