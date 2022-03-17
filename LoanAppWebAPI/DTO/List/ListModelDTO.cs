using SharedClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAppWebAPI.Models
{
    public class ListModelDTO : BaseModel
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

        public override string TableName => throw new NotImplementedException();
    }
}
