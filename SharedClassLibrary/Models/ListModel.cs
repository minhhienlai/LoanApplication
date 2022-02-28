using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLibrary.Models
{
    public class ListModel
    {
        public int LoanApplicationId { get; set; }
        public int DemographicId { get; set; }
        [Display(Name = "Applicant name")]
        public string DemographicName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string BusinessCode { get; set; }
        public string BusinessName { get; set; }
        public double Amount { get; set; }
        public int CreditScore { get; set; }
        public double RiskRate { get; set; }
    }
}
