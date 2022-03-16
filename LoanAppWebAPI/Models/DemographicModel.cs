using SharedClassLibrary.Models;
using System.ComponentModel.DataAnnotations;

namespace LoanAppWebAPI.Models
{
    public class DemographicModel : BaseModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public int State { get; set; }
        public string Zipcode { get; set; }

        public List<BusinessModel>? Business { get; set; }

       // public override string TableName { return "Demographic" ; }
    }
}
