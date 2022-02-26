using System.ComponentModel.DataAnnotations;

namespace LoanAppMVC.Models
{
    public class BusinessModel
    {
        [Key]
        public int Id { get; set; }
        public string BusinessCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DemographicModel Owner { get; set; }
    }
}
